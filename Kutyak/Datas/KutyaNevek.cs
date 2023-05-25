using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak.Datas
{
    internal class KutyaNevek

    {
        // id;kutyanév

        int id;
        string kutyanev;

        public KutyaNevek(int id, string kutyanev)
        {
            this.id = id;
            this.kutyanev = kutyanev;
        }

        public int Id { get => id; }
        public string Kutyanev { get => kutyanev; }
    }
}
