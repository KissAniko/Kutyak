using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public  class KutyaFajta
    {
        // id;név;eredeti név

        int id;
        string nev;
        string eredetiNev;

        public KutyaFajta(int id, string nev, string eredetiNev)
        {
            this.id = id;
            this.nev = nev;
            this.eredetiNev = eredetiNev;
        }

        public int Id { get => id; }
        public string Nev { get => nev; }
        public string EredetiNev { get => eredetiNev; }
    }
}
