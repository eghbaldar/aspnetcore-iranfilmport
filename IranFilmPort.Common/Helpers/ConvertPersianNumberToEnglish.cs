namespace IranFilmPort.Common.Helpers
{
    public class ConvertPersianNumberToEnglish
    {
        public static string ConvertPersianToEnglish(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] persianDigits = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            string[] arabicDigits = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i < 10; i++)
            {
                input = input.Replace(persianDigits[i], i.ToString());
                input = input.Replace(arabicDigits[i], i.ToString());
            }

            return input;
        }
    }
}
