using Journal_App_MAUI.Models;

namespace Journal_App_MAUI.Services
{
    public class UserService : DatabaseService
    {
        private bool _initialized;

        public async Task InitializeAsync()
        {
            if (_initialized) return;
            await _db.CreateTableAsync<User>();
            _initialized = true;
        }

        public Task<List<User>> GetUsersAsync() => _db.Table<User>().ToListAsync();

        public Task<User?> GetUserByUsernameAsync(string username) =>
            _db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);

        public Task<int> SaveUserAsync(User user) =>
            user.UserId != 0 ? _db.UpdateAsync(user) : _db.InsertAsync(user);

        public Task<int> DeleteUserAsync(User user) => _db.DeleteAsync(user);
    }
}
