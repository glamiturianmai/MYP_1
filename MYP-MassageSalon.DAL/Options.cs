namespace MYP_MassageSalon.DAL
{
    public class Options
    {
        public static string ConStr
        {
            get
            {
                return Environment.GetEnvironmentVariable("conectionstring");
            }
        }
    }
}