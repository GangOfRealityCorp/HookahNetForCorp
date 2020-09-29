namespace HookahNet.Models.Users
{
    public interface IUserManager
    {
        public IUser user { get; }
        void CreateUser(string Name, string Password);
        void RetrieveUserById(int Id);
        void RetrieveUserByName(string Name);
        void UpdateUser();
        void DeleteUser();
    }
}