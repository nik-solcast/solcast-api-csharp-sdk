using Solcast.Clients;

namespace Solcast.Examples
{
    public class PvPowerSitesExample
    {
        public static async Task RunPvPowerSitesExample()
        {
            try
            {
                var pvPowerSitesClient = new PvPowerSitesClient();
                var response = await pvPowerSitesClient.GetPvPowerSite("ba75-e17a-7374-95ed");

                Console.WriteLine("PV Power Site Data:");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PvPowerSitesExample: {ex.Message}");
            }
        }
    }
}
