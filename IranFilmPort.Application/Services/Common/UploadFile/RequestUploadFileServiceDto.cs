using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services.Common.UploadFile
{
    public class RequestUploadFileServiceDto
    {
        public bool Type { get; set; } //0=> photo 1=> other
        public string DirectoryROOT { get; set; } // W => wwwroot + W 
        public string DirectoryNameLevelParent { get; set; } // Y=> wwwroot + W + Y 
        public string DirectoryNameLevelChild { get; set; } // Z => wwwroot + W + Y + Z
        public IFormFile File { get; set; }
        public string? Suffix { get; set; } // the presuffix can be added at the beginning of the file name
        public string[] Extension { get; set; } // acceptable extensions
        public string FileSize { get; set; } // acceptable fileSize
        public Dictionary<string, string>? Scales { get; set; }
        // For example, if we want to create photos with different scales, we need to send: "{'original', '550'}, {'thumb', '150'},{'verySmall', '50'}"
        // However, if you only desire to have one photo, simply pass a single scale: "{'original', '550'}"
        // Here, 150 represents the width, and the height is automatically determined based on the photo's aspect ratio.
        // The terms 'original' and 'thumb' are merely sample names for those scale; they hold no additional significance.
    }
}
