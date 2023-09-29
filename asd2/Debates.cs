using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1.P2
{
    internal class Debates
    {
        private string Debate;
        private int Participantes = 0;

        public Debates(string Propuesta)
        {
            this.Debate = Propuesta;
        }
        public void SetDebates(string Propuesta) => this.Debate = Propuesta;
        public string GetDebates() => this.Debate;
        public void SetParticipantes(int Participantes) => this.Participantes += Participantes;
        public int GetParticipantes() => this.Participantes;
    }
}
