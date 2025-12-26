namespace IranFilmPort.Common.Helpers
{
    public static class SlugHelper
    {
        public static string Generate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return text
                .Replace(" ", "-")
                .Replace("»", "")
                .Replace("«", "")
                .Replace("‌", "-")
                .Replace("ي", "ی")
                .Replace("?", "")
                .Replace("؟", "")
                .Replace("!", "")
                .Replace("معرفی", "")
                .Replace(")", "")
                .Replace("(", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("_", "")
                .Replace("،", "")
                .Replace("؛", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace("\"", "-")
                .Replace("/", "")
                .Replace("|", "")
                .Replace("\\", "-")
                .Replace("--", "-")
                .Trim('-')
                .ToLowerInvariant();
        }
    }
}
