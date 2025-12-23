using IranFilmPort.Application.Common;
using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services.Common.UploadFile
{
    public class FileSignatureValidator
    {
        public static ResultDto ValidateFileSignatureByFile(IFormFile file)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Copy the contents of the IFormFile to the MemoryStream
                    file.CopyTo(ms);

                    // Get the bytes from the MemoryStream
                    byte[] fileBytes = ms.ToArray();

                    // Check the file signature
                    if (IsPDF(fileBytes) || IsJPEG(fileBytes) || IsPNG(fileBytes) || VideoFormat(fileBytes))
                    {
                        return new ResultDto
                        {
                            Message = "File signature is valid.",
                            IsSuccess = true,
                        };
                    }
                    else
                    {
                        return new ResultDto
                        {
                            Message = "Invalid file signature.",
                            IsSuccess = false,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    Message = "Error validating file signature: " + ex.Message,
                    IsSuccess = false,
                };
            }
        }

        public static ResultDto ValidateFileSignatureByFilePath(string filePath)
        {
            try
            {
                // Read the file contents
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Check the file signature
                if (IsPDF(fileBytes) || IsMP3(fileBytes) || IsZIP(fileBytes) || IsRAR(fileBytes) || IsJPEG(fileBytes) || IsPNG(fileBytes)
                    || IsGIF(fileBytes) || IsBMP(fileBytes) || IsDoc(fileBytes) || IsTIFF(fileBytes) || IsHEIC(fileBytes) || IsOGG(fileBytes) || IsDOCX(fileBytes))
                {
                    return new ResultDto
                    {
                        Message = "File signature is valid.",
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        Message = "Invalid file signature.",
                        IsSuccess = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    Message = "Error validating file signature: " + ex.Message,
                    IsSuccess = false,
                };
            }
        }

        private static bool IsPDF(byte[] header)
        {
            // Check if the file signature matches a PDF file
            return header[0] == 0x25 && header[1] == 0x50 && header[2] == 0x44 && header[3] == 0x46;
        }
        private static bool IsMP3(byte[] header)
        {
            if (header.Length < 2) return false; // Check if the header has at least two bytes to check for the MP3 signature 
            //return header[0] == 0xFF && (header[1] & 0xE0) == 0xE0;
            return header[0] == 0x49 && header[1] == 0x44 && header[2] == 0x33;
        }

        private static bool IsZIP(byte[] header)
        {
            // Check if the file signature matches a ZIP file
            // ZIP file signature: PKZIP file format signature (0x50 0x4B 0x03 0x04)
            return header[0] == 0x50 && header[1] == 0x4B && header[2] == 0x03 && header[3] == 0x04;
        }
        private static bool IsRAR(byte[] header)
        {
            // Check if the file signature matches a RAR file
            // RAR file signature: RAR file format signature (0x52 0x61 0x72 0x21)
            return header[0] == 0x52 && header[1] == 0x61 && header[2] == 0x72 && header[3] == 0x21;
        }
        private static bool IsJPEG(byte[] header)
        {
            // Check if the file signature matches a JPEG file
            return header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
        }
        private static bool IsPNG(byte[] header)
        {
            // Check if the file signature matches a PNG file
            return header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47 &&
                   header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A;
        }
        private static bool IsGIF(byte[] fileBytes)
        {
            return fileBytes.Length >= 3 && fileBytes[0] == 0x47 && fileBytes[1] == 0x49 && fileBytes[2] == 0x46;
        }
        private static bool IsBMP(byte[] fileBytes)
        {
            return fileBytes.Length >= 2 && fileBytes[0] == 0x42 && fileBytes[1] == 0x4D;
        }
        private static bool IsDoc(byte[] fileBytes)
        {
            return fileBytes.Length >= 8 && fileBytes[0] == 0xD0 && fileBytes[1] == 0xCF && fileBytes[2] == 0x11 && fileBytes[3] == 0xE0 && fileBytes[4] == 0xA1 && fileBytes[5] == 0xB1 && fileBytes[6] == 0x1A && fileBytes[7] == 0xE1;
        }
        private static bool IsTIFF(byte[] fileBytes)
        {
            return (fileBytes.Length >= 4 && ((fileBytes[0] == 0x49 && fileBytes[1] == 0x49 && fileBytes[2] == 0x2A && fileBytes[3] == 0x00) || (fileBytes[0] == 0x4D && fileBytes[1] == 0x4D && fileBytes[2] == 0x00 && fileBytes[3] == 0x2A)));
        }
        private static bool IsHEIC(byte[] fileBytes)
        {
            return fileBytes.Length >= 12 && fileBytes[4] == 0x66 && fileBytes[5] == 0x74 && fileBytes[6] == 0x79 && fileBytes[7] == 0x70 && fileBytes[8] == 0x68 && fileBytes[9] == 0x65 && fileBytes[10] == 0x69 && fileBytes[11] == 0x63;
        }
        private static bool IsOGG(byte[] header)
        {
            // Check if the file signature matches an OGG file
            return header.Length >= 4 && header[0] == 0x4F && header[1] == 0x67 && header[2] == 0x67 && header[3] == 0x53;
        }
        private static bool IsDOCX(byte[] header)
        {
            return header[0] == 0x50 && header[1] == 0x4B && header[2] == 0x03 && header[3] == 0x04 && header[4] == 0x14 && header[5] == 0x4E && header[6] == 0x6E && header[7] == 0x61;
        }
        private static bool VideoFormat(byte[] header)
        {
            if (header == null || header.Length < 12)
                return false;

            // MP4 (ISO Base Media)
            if (header[4] == 0x66 && header[5] == 0x74 && header[6] == 0x79 && header[7] == 0x70)
                return true;

            //// MKV/WebM (Matroska)
            //if (header[0] == 0x1A && header[1] == 0x45 && header[2] == 0xDF && header[3] == 0xA3)
            //    return true;

            //// AVI
            //if (header[0] == 0x52 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x46 &&
            //    header[8] == 0x41 && header[9] == 0x56 && header[10] == 0x49)
            //    return true;

            //// FLV
            //if (header[0] == 0x46 && header[1] == 0x4C && header[2] == 0x56)
            //    return true;

            //// MOV (Apple QuickTime)
            //if (header[4] == 0x6D && header[5] == 0x6F && header[6] == 0x6F && header[7] == 0x76)
            //    return true;

            //// WMV (ASF)
            //if (header.Length >= 16 &&
            //    header[0] == 0x30 && header[1] == 0x26 && header[2] == 0xB2 && header[3] == 0x75 &&
            //    header[4] == 0x8E && header[5] == 0x66 && header[6] == 0xCF && header[7] == 0x11 &&
            //    header[8] == 0xA6 && header[9] == 0xD9 && header[10] == 0x00 && header[11] == 0xAA &&
            //    header[12] == 0x00 && header[13] == 0x62 && header[14] == 0xCE && header[15] == 0x6C)
            //    return true;

            //// MPEG-TS (Transport Stream)
            //if (header[0] == 0x47)
            //    return true;

            //// MPEG-PS (Program Stream)
            //if (header[0] == 0x00 && header[1] == 0x00 && header[2] == 0x01 && header[3] == 0xBA)
            //    return true;

            return false;
        }
    }
}
