using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Customer ID: ");
            int id = Int32.Parse(Console.ReadLine());
            var oldCustomer = await CustomerClient.GetCustomer(id);
            Console.WriteLine(oldCustomer);
            Console.ReadKey();
            
            Console.WriteLine("Генерация случайного клиента...");
            Customer randomCustomer = CustomerRandomizer.CustomerRandom();
            var new_id = await CustomerClient.AddCustomer(randomCustomer);
            
            var newCustomer = await CustomerClient.GetCustomer(new_id);
            Console.WriteLine("Добавлен пользователь: ");
            Console.WriteLine(newCustomer);
        }
    }
}