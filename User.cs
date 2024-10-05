using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Personkonto personKonto;

        public Sparkonto sparKonto;

        public Investeringskonto investeringsKonto;
    }
}