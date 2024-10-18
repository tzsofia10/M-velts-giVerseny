using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MűveltségiVerseny
{
    internal class verseny
    {
        public string Kerdes { get; set; }
        public int Valasz { get; set; }
        public int Pontszam { get; set; }
        public string Terulet { get; set; }

        public verseny(string sorok) 
        {
            var s= sorok.Split(';');
            Kerdes = s[0];
            Valasz = Convert.ToInt32(s[1]);
            Pontszam = Convert.ToInt32(s[2]);
            Terulet = s[3];
        }    
    }
}
