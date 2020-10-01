using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class GuestUser : IGuestUser
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public GuestUser(string Email, string Name, string Password)
        {
            this.Email = Email;
            this.Name = Name;
            this.Password = Password;
        }
    }
}
