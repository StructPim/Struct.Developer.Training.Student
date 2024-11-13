using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Helpers;
using Shared.Import;
using Shared.Index;
using TaskConsole.Tasks;

namespace TaskConsole
{
    internal class Program
    {
        private static TaskService _taskService;
        private static void Main(string[] args)
        {
            Initialize();

            RenderOptions:
            Console.WriteLine("Tasks:");
            Console.WriteLine("0: PIM api heart beat");
            Console.WriteLine("1.1: Import category data");
            Console.WriteLine("1.2: Import product data");
            Console.WriteLine("1.3: Import variant data");

            Console.WriteLine("2.1: Build product index");
            Console.WriteLine("2.2: Delta update product index");

            Console.WriteLine("3.1: Delta update existing variants");
            Console.WriteLine("3.2: Delta update existing and new variants");
            Console.WriteLine("3.3: Update existing global list values");
            Console.WriteLine("3.4: Update cost prices");

            Console.WriteLine("e: Exit");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "0":
                    Console.WriteLine("Pim status: " + _taskService.DoHeartBeat());
                    break;
                case "1.1":
                    _taskService.DoTask1_1();
                    break;
                case "1.2":
                    _taskService.DoTask1_2();
                    break;
                case "1.3":
                    _taskService.DoTask1_3();
                    break;
                case "2.1":
                    _taskService.DoTask2_1();
                    break;
                case "2.2":
                    _taskService.DoTask2_2();
                    break;
                case "3.1":
                    _taskService.DoTask3_1();
                    break;
                case "3.2":
                    _taskService.DoTask3_2();
                    break;
                case "3.3":
                    _taskService.DoTask3_3();
                    break;
                case "3.4":
                    _taskService.DoTask3_4();
                    break;
                case "e":
                    break;
                default:
                    Console.WriteLine("Input not recognized as a valid option, try again");
                    Console.WriteLine();
                    goto RenderOptions;
            }
        }

        private static void Initialize()
        {
            var host = CreateHostBuilder().Build();
            _taskService = host.Services.GetRequiredService<TaskService>();
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // register your services here.
                services.AddSingleton<ImportService>();
                services.AddSingleton<IndexService>();
                services.AddSingleton<TaskService>();
                services.AddSingleton<MessageClient>();
                services.AddSingleton<Task0>();
                services.AddSingleton<Task1>();
                services.AddSingleton<Task2>();
                services.AddSingleton<Task3>();
            });
    }
}