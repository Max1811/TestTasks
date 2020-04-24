using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Contracts
{
    public interface IUserService
    {
        public KeyValuePair<string, string> GetToken(string id);
    }
}
