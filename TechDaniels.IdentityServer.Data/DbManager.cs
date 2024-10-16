using DbUp;

namespace TechDaniels.IdentityServer.Data
{
    public static class DbManager
    {
        public static void TryUpdateDB(string connectionString)
        {
            var path = Directory.GetCurrentDirectory();

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem($"{path}/Scripts")
                    .WithTransaction()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw result.Error;
            }
        }
    }
}
