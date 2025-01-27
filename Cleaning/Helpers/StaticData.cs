namespace Cleaning.Helpers
{
    public class StaticData
    {
        public const string Role_Admin = "Admin";
        public const string Role_Client = "Client";
        public const string Role_Employee = "Employee";

        public static string GetEmptyImagePath()
        {
            return "files" + Path.DirectorySeparatorChar + "images" + Path.DirectorySeparatorChar + "empty.jpg";
        }
    }
}
