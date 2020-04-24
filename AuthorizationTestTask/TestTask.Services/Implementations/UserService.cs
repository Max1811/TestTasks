using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.Services.Contracts;

namespace TestTask.Services.Implementations
{
    public class UserService: IUserService
    {
        Dictionary<string, string> tokens = new Dictionary<string, string>()
        {
            { "1", "dgtk1l6rjfowkgwl563jgopo02" },
            { "2", "djgh69204kgpwgwl563jgodwer" },
            { "3", "alopfgir5820skgmmw4lqpowr9" },
            { "4", "dopqw12mflavsadour560mfakf" },
        };

        public KeyValuePair<string, string> GetToken(string id)
        {
            return tokens.FirstOrDefault(token => token.Key == id);
        }
    }
}
