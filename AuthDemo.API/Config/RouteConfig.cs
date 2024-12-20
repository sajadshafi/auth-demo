namespace AuthDemo.API.Config
{
    public class RouteConfigds
    {
        public required List<string> HiddenRoutes { get; set; }
    }


    public static class RouteConfig
    {
        public static List<string> HiddenRoutes { get; private set; } = ["/auth/register", "/auth/resendConfirmationEmail", "/auth/manage/info"];
    }
}