using DbUp;
using System.Reflection;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dbConnectionString = "User ID=postgres;Password=LabasRytas123;Host=localhost;Port=5432;Database=DoggoDollarsDB;";
            EnsureDatabase.For.PostgresqlDatabase(dbConnectionString);
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(dbConnectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
        }
    }
}
