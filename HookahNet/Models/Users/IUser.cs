using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public interface IUser
    {
        string Name { get; }
        string Password { get; }
    }
}
