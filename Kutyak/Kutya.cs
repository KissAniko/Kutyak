using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class Kutya
    {
        // id;fajta_id;név_id;életkor;utolsó orvosi ellenőrzés

        int id;
        int fajtaId;
        int nevId;
        int eletkorId;
        DateTime utolsoEllenorzes;
        private byte sor;

        public Kutya(byte sor)
        {
            this.sor = sor;
        }

        public Kutya(int id, int fajtaId, int nevId, int eletkorId, DateTime utolsoEllenorzes)
        {
            this.id = id;
            this.fajtaId = fajtaId;
            this.nevId = nevId;
            this.eletkorId = eletkorId;
            this.utolsoEllenorzes = utolsoEllenorzes;
        }

        public int Id { get => id;  }
        public int FajtaId { get => fajtaId;  }
        public int NevId { get => nevId;  }
        public int EletkorId { get => eletkorId;  }
        public DateTime UtolsoEllenorzes { get => utolsoEllenorzes; }

        internal Kutya ToList()
        {
            throw new NotImplementedException();
        }
    }
}
