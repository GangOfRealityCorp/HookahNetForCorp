using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models.Users
{
    public class UserManager : IUserManager
    {
        public IUser user { get; private set; }
        public void CreateUser(string Name, string Password)
        {
            IUser user = new GuestUser(Name, Password);
            //TODO: push to DB.
            this.user = user;
            throw new NotImplementedException();
        }
        public void RetrieveUserById(int Id)
        {
            throw new NotImplementedException();
        }
        public void RetrieveUserByName(string Name)
        {
            throw new NotImplementedException();
        }
        public void UpdateUser()
        {
            throw new NotImplementedException();
        }
        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

    }
}
