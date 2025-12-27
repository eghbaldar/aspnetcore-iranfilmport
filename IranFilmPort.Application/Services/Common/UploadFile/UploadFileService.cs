using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace IranFilmPort.Application.Services.Common.UploadFile
{
    public class UploadFileService
    {
        public ResultUploadDto UploadFile(RequestUploadFileServiceDto req)
        {
            // check file ....
            if (req.File == null || req.File.Length == 0)
            {
                return new ResultUploadDto
                {
                    IsSuccess = false,
                    Message = "فایلی وجود ندارد.",
                    Filename = "",
                };
            }
            // check signature ....
            var resultCheckFileSignature = FileSignatureValidator.ValidateFileSignatureByFile(req.File);
            if (!resultCheckFileSignature.IsSuccess)
            {
                return new ResultUploadDto
                {
                    IsSuccess = false,
                    Message = "فایل نامناسبی انتخاب شده است.",
                    Filename = "",
                };
            }
            // check extension ....
            FileInfo info = new FileInfo(req.File.FileName);
            if (Array.IndexOf(req.Extension, info.Extension.ToLower()) < 0)
            {
                return new ResultUploadDto
                {
                    IsSuccess = false,
                    Message = $"فرمت (${Array.IndexOf(req.Extension, info.Extension.ToLower())}) غیر قابل قبول است.",
                    Filename = "",
                };
            }
            // check size ....
            if (req.File.Length > Convert.ToInt64(req.FileSize))
            {
                return new ResultUploadDto
                {
                    IsSuccess = false,
                    Message = $"حجم فایل باید کمتر از {Math.Round(Convert.ToDouble(req.FileSize) / 1048576, 2)} مگابایت باشد.",
                    Filename = "",
                };
            }
            // create folder ...
            string folder = $@"wwwroot\UploadedStuff\" +
                req.DirectoryROOT + @"\" +
                req.DirectoryNameLevelParent + @"\" +
                req.DirectoryNameLevelChild;
            var uploadRootFolder = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(uploadRootFolder)) Directory.CreateDirectory(uploadRootFolder);
            string filename;
            try
            {
                if (!req.Type) // Photo
                {
                    if (info.Extension.ToLower() == ".webp")
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            req.File.CopyToAsync(memoryStream);
                            memoryStream.Position = 0;
                            // For WebP, save directly without Image processing
                            filename = GenerateFilenameExceptImageOne(info.Extension.ToLower(), req.Suffix);
                            var outputPath = Path.Combine(uploadRootFolder, filename);
                            using (var fileStream = new FileStream(outputPath, FileMode.Create))
                            {
                                memoryStream.WriteTo(fileStream);
                            }
                            return new ResultUploadDto
                            {
                                IsSuccess = true,
                                Message = "فایل با موفقیت آپلود شد.",
                                Filename = filename,
                            };
                        }
                    }
                    else
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            req.File.CopyTo(memoryStream);// Copy the file contents to the MemoryStream
                            memoryStream.Position = 0;// Reset the position of the MemoryStream to the beginning
                                                      // Now you can use the MemoryStream as needed
                                                      // For example, you can pass it to the SaveImageFromMemoryStream method                
                            filename = SaveImageFromMemoryStream(
                                memoryStream,
                                ".jpg",//info.Extension.ToLower()
                                req.Scales,
                                uploadRootFolder,
                                req.Suffix);
                        }
                        return new ResultUploadDto
                        {
                            IsSuccess = true,
                            Message = "فایل با موفقیت آپلود شد.",
                            Filename = filename,
                        };
                    }
                }
                else // other kind of files
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        req.File.CopyTo(memoryStream);// Copy the file contents to the MemoryStream
                        memoryStream.Position = 0;// Reset the position of the MemoryStream to the beginning
                                                  // Now you can use the MemoryStream as needed
                                                  // For example, you can pass it to the SaveImageFromMemoryStream method                
                        filename = GenerateFilenameExceptImageOne(info.Extension.ToLower(), req.Suffix);
                        SaveFileFromMemoryStream(memoryStream, $"{uploadRootFolder}/{filename}");

                    }
                    return new ResultUploadDto
                    {
                        IsSuccess = true,
                        Message = "فایل با موفقیت آپلود شد.",
                        Filename = filename,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultUploadDto
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داده است.",
                };
            }
        }
        private string GenerateFilenameExceptImageOne(string extension, string? suffix)
        {
            return $"{suffix}{DateTime.Now.ToString("yyyyMMddHHmmss")}-{DateTime.Now.Ticks.ToString()}" + extension;
        }
        private void SaveFileFromMemoryStream(MemoryStream memoryStream, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
        private string SaveImageFromMemoryStream(MemoryStream memoryStream, string extension, Dictionary<string, string> scales, string uploadPath, string? suffix)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream))
            {
                string firstPartOfFilename = $"{suffix}{DateTime.Now.ToString("yyyyMMddHHmmss")}-{DateTime.Now.Ticks.ToString()}";
                for (int i = 0; i < scales.Count; i++)
                {
                    int Width = int.Parse(scales.ElementAt(i).Value);
                    int Height = (int)Math.Round(image.Height * ((double)Width / image.Width));

                    string uniqueFileName = $"{firstPartOfFilename}-{scales.ElementAt(i).Key}{extension}"; // Guid.NewGuid().ToString() + ".jpg";
                    string imagePath = $"{uploadPath}/{uniqueFileName}";


                    if (Width <= image.Width)
                    {
                        using (Bitmap bitmap = new Bitmap(image, Width, Height))
                        {
                            // make compress the photo
                            // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-set-jpeg-compression-level?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                            EncoderParameters myEncoderParameters = new EncoderParameters(1);
                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 40L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            // save the photo
                            bitmap.Save(imagePath, jpgEncoder, myEncoderParameters);
                        }
                    }
                    else
                    {
                        image.Save(imagePath, ImageFormat.Jpeg);
                    }
                }
                return firstPartOfFilename;
            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
