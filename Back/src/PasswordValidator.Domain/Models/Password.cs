using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordValidator.Domain.Models
{
    public class Password
    {
        public string Pattern { get; private set; }
        
        public Password(string pattern)
        {
            Pattern = pattern;
        }
    }
}