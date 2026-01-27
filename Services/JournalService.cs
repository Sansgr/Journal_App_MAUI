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
            await _db.CreateTableAsync<Mood>();
            await _db.CreateTableAsync<Tag>();
            await _db.CreateTableAsync<Category>();
            await _db.CreateTableAsync<EntryMood>();
            await _db.CreateTableAsync<EntryTag>();
            await _db.CreateTableAsync<Streak>();

            _initialized = true;
        }

        // Journal Entries
        public Task<List<JournalEntry>> GetEntriesAsync(int userId) =>
            _db.Table<JournalEntry>().Where(e => e.UserId == userId).ToListAsync();

        public Task<int> SaveEntryAsync(JournalEntry entry) =>
            entry.EntryId != 0 ? _db.UpdateAsync(entry) : _db.InsertAsync(entry);

        public Task<int> DeleteEntryAsync(JournalEntry entry) => _db.DeleteAsync(entry);

        // Categories
        public Task<List<Category>> GetCategoriesAsync() => _db.Table<Category>().ToListAsync();

        // Moods
        public Task<List<Mood>> GetMoodsAsync() => _db.Table<Mood>().ToListAsync();

        public Task<int> SaveEntryMoodAsync(EntryMood entryMood) =>
            entryMood.EntryMoodId != 0 ? _db.UpdateAsync(entryMood) : _db.InsertAsync(entryMood);

        // Tags
        public Task<List<Tag>> GetTagsAsync() => _db.Table<Tag>().ToListAsync();

        public Task<int> SaveEntryTagAsync(EntryTag entryTag) =>
            entryTag.EntryTagId != 0 ? _db.UpdateAsync(entryTag) : _db.InsertAsync(entryTag);

        // Streak Tracking
        public async Task UpdateStreakAsync(int userId)
        {
            var streak = await _db.Table<Streak>().FirstOrDefaultAsync(s => s.UserId == userId);
            if (streak == null)
            {
                streak = new Streak
                {
                    UserId = userId,
                    CurrentStreak = 1,
                    LongestStreak = 1,
                    LastEntryDate = DateTime.Today
                };
                await _db.InsertAsync(streak);
            }
            else
            {
                if (streak.LastEntryDate == DateTime.Today.AddDays(-1))
                {
                    streak.CurrentStreak++;
                    if (streak.CurrentStreak > streak.LongestStreak)
                        streak.LongestStreak = streak.CurrentStreak;
                }
                else
                {
                    streak.CurrentStreak = 1;
                }
                streak.LastEntryDate = DateTime.Today;
                await _db.UpdateAsync(streak);
            }
        }
    }
}
