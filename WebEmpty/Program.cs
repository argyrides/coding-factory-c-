using WebEmpty;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
}).Build().Run();
//The following msg is shown when Kestrel has stopped.
Console.WriteLine("Thanks for using Coding Factory.");
