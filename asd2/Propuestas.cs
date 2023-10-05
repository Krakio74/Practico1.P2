using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1.P2
{
    internal class Propuestas
    {
        private Legisladores Propone;
        private string Propuesta;
        private int CantidadDeVotos = 0;
        private int PersonasDebatiendo = 0;


        public Propuestas(Legisladores Propone, string Propuesta)
        {
            this.Propone = Propone;
            this.Propuesta = Propuesta;
        }
        public void SetPropone(Legisladores Propone) => this.Propone = Propone;
        public Legisladores GetPropone() => this.Propone;
        public void SetPropuesta(string Propuesta)=>this.Propuesta = Propuesta;
        public string GetPropuesta()=>this.Propuesta;
        public void SetVotos(int CantidadDeVotos) => this.CantidadDeVotos += CantidadDeVotos;
        public int GetVotos()=>this.CantidadDeVotos;
        public void SetPersonasDebatiendo(int PersonasDebatiendo) => this.PersonasDebatiendo += PersonasDebatiendo;
        public int GetPersonasDebatiendo() => this.PersonasDebatiendo;

    }
}
