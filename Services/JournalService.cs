using Journal_App_MAUI.Models;

namespace Journal_App_MAUI.Services
{
    public class JournalService : DatabaseService
    {
        private bool _initialized;

        public async Task InitializeAsync()
        {
            if (_initialized) return;
            await _db.CreateTableAsync<JournalEntry>();
            _initialized = true;
        }

        // Add journal entry with one-per-day enforcement
        public async Task<bool> AddJournalEntry(JournalEntry entry)
        {
            var exists = await _db.Table<JournalEntry>()
                                  .Where(e => e.UserId == entry.UserId && e.EntryDate == entry.EntryDate)
                                  .FirstOrDefaultAsync();

            if (exists != null)
                return false;

            await _db.InsertAsync(entry);
            return true;
        }

        public Task<List<JournalEntry>> GetAllEntries(int userId) =>
            _db.Table<JournalEntry>()
               .Where(e => e.UserId == userId)
               .OrderByDescending(e => e.EntryDate)
               .ToListAsync();

        public Task<int> DeleteEntryAsync(JournalEntry entry) => _db.DeleteAsync(entry);

        public Task<int> UpdateEntryAsync(JournalEntry entry)
        {
            entry.UpdatedAt = DateTime.Now;
            return _db.UpdateAsync(entry);
        }

    }
}
