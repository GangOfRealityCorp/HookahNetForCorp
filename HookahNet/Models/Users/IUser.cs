using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string Password { get; }
    }
}
