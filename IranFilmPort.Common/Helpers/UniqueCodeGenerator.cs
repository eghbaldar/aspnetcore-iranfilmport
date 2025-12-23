namespace IranFilmPort.Common.Helpers
{
    public class UniqueCodeGenerator
    {
        private static readonly Random Random = new Random();

        public static long GenerateRandomLong()
        {
            byte[] buffer = new byte[sizeof(long)];
            Random.NextBytes(buffer);
            return Math.Abs(BitConverter.ToInt64(buffer, 0));
        }
    }
}
