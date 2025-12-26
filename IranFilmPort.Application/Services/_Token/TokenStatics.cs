namespace IranFilmPort.Application.Services._Token
{
    public class TokenStatics
    {
        public static string AuthCookieName = "IranfilmportCookie";
        public static string RefreshCookieName = "IranfilmportRefreshCookie";

        //TODO: change the followign values to DECODE ones
        //use:AES Encryption
        //for example use: https://anycript.com/crypto
        public static string AccessTokenKey = "qNH5TQIeGeChlLv9m9XT4BjTSFsty+CGYz73tpsO3Hl76QTUS5dexcd56BMLUkEkaP4z9sdXTy4Z3BmD0StCWQ==";
        public static string RefreshTokenKey = "qNH5TQIeGeChlLv9m9XT4PkEJNfLDyhgtSAeJdF5D5sCxudPqsUnozYIVWIOA4NeDqJ6mDI14VTJ9L2/py0Rjw==";

        //TODO: change the following values to ones are based on standard DAY EXPIRATION
        public static int ExpirationDayAuthCookie = 15;
        public static int ExpirationDayRefreshCookie = 30;

        public static string DestinationControllerAfterLogout = "auth";
        public static string DestinationActionAfterLogout = "login";

        public static string BandPageController = "Auth";
        public static string BandPageAction = "Forbidden";

        public static byte HourBannedUser = 1; // it means the user cannot access to protected pages in [ExpirationHourBannedUser] hour.
        public static byte AllowedUserTriesToAccess = 50; // it means the user can ***frequently*** try only [AllowedUserTriesToAccess] times to access.
        public static sbyte AtLeastUserSuspiciousActivites = -10; // it means if the user tries [AllowedUserTriesToAccess] time less than [AtLeastUserSuspiciousActivites] the account is blocked

    }
}
