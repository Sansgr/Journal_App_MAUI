using SQLite;

namespace Journal_App_MAUI.Services
{
    public abstract class DatabaseService
    {
        protected readonly SQLiteAsyncConnection _db;

        protected DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "journal_app.db3");
            Console.WriteLine($"Database Path: {dbPath}");

            // Initialize SQLite batteries
            SQLitePCL.Batteries_V2.Init();

            _db = new SQLiteAsyncConnection(dbPath);
        }
    }
}
