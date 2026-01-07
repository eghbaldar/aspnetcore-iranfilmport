namespace IranFilmPort.Common.Constants
{
    public class JobRequestCategoryConstants
    {
        public const byte Screenwriter = 0;
        public const byte TranslatorEnglish = 1;
        public const byte TranslatorSpanish = 2;
        public const byte TranslatorFrench = 3;
        public const byte ProfessionalEditor = 4;
        public const byte GraphicDesignerPhotoshop = 5;
        public const byte TelemarketerFemaleOnly = 6;
        public const byte ComputerScienceICDLWithIELTS = 7;
        public const byte SubtitleEditAndVideoConverter = 8;
        public const byte DeveloperAspNetFormVbNetSql = 9;
        public const byte DeveloperAspNetCoreCSharpSql = 10;
        public const byte DeveloperKotlinSql = 11;
        public const byte DeveloperWindowsFormsVbNetSql = 12;
        public const byte SeoSpecialistAndSocialAnalyzer = 13;
        public const byte ContentCreatorTextVisual = 14;
        public const byte BilingualTypist = 15;
        public const byte FieldReporter = 16;

        public static string GetValue(byte categoryId)
        {
            switch (categoryId)
            {
                case Screenwriter:
                    return "فیلمنامه‌نویس";
                case TranslatorEnglish:
                    return "مترجمی: انگلیسی";
                case TranslatorSpanish:
                    return "مترجمی: اسپانیایی";
                case TranslatorFrench:
                    return "مترجمی: فرانسوی";
                case ProfessionalEditor:
                    return "تدوینگر حرفه‌ای";
                case GraphicDesignerPhotoshop:
                    return "گرافیست با نرم افزار فتوشاپ";
                case TelemarketerFemaleOnly:
                    return "بازاریاب تلفنی (فقط خانم)";
                case ComputerScienceICDLWithIELTS:
                    return "علوم کامپیوتر (دارای مدرک ICDL) با مدرک زبان انگلیسی (حداقل 6 آیلس)";
                case SubtitleEditAndVideoConverter:
                    return "آشنایی با نرم افزار SubTitle Edit و نرم افزار های Video Convertor";
                case DeveloperAspNetFormVbNetSql:
                    return "برنامه نویس: ASP.NET FORM & VB.NET + SQL";
                case DeveloperAspNetCoreCSharpSql:
                    return "برنامه نویس: ASP.NET CORE & C# + SQL";
                case DeveloperKotlinSql:
                    return "برنامه نویس: Kotlin + SQL";
                case DeveloperWindowsFormsVbNetSql:
                    return "برنامه نویس: Windows Forms VB.NET + SQL";
                case SeoSpecialistAndSocialAnalyzer:
                    return "متخصص SEO و آنالیزور شبکه‌های مجازی";
                case ContentCreatorTextVisual:
                    return "کارشناس تولید محتوا متنی و ویژوال";
                case BilingualTypist:
                    return "تایپیست دو زبانه";
                case FieldReporter:
                    return "گزارشگر حضوری";
                default:
                    return "نوع همکاری را مشخص کنید ...";
            }
        }
    }
}
