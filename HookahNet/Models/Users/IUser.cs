using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public interface IUser
    {
        Guid Id { get; }
        public string Email { get; }
        string Name { get; }
        string Password { get; }
    }
}
