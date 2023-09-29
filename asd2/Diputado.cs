using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practico1.P2
{
    internal class Diputado : Legisladores
    {
        private int NumAsientoCamaraBaja;
        public Diputado(int NumAsientoCamaraBaja, string PartidoPolitico, string DepartamentoR, int NumDespachante, string Nombre, string Apellido, int Edad, bool Casado) : base(PartidoPolitico, DepartamentoR, NumDespachante, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraBaja = NumAsientoCamaraBaja;
        }
        public override void GetCamara()
        {
            Console.WriteLine(this.GetType().Name);
        }
        public override void presentarPropuestaLegislativa(Parlamento Parlamento, string Propuesta)
        {
            Parlamento.AgregarPropuesta(new Propuestas(this, Propuesta));
        }
        public override void Votar(Parlamento Parlamento, int PropuestaVotada)
        {
            Parlamento.GetPropuestas(PropuestaVotada).SetVotos(1);
        }
    }
}
