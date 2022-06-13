using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIT.Contracts
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public Psychologist UserData { get; set; }
    }
}
