using MYP_MassageSalon.BLL;
using MYP_MassageSalon.DAL;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ApplicationRepository appRepository = new ApplicationRepository();

            //ProductRepository productRepository = new ProductRepository();

            //ServiceClient serviceClient = new ServiceClient();

            //var a= productRepository.GetAllProductsOldNames();
            //var b = productRepository.GetAllProductsNewNames();

            //var q = serviceClient.GetAllServicesNameMap();


            ClientClient clientClient = new ClientClient();
            var c = clientClient.GetAllClientsMap();

            Console.WriteLine(c[2].IPInf);

        }
    }
}
