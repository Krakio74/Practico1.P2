using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1.P2
{
    internal class Senador : Legisladores
    {
        private int NumAsientoCamaraAlta;
        public Senador(int NumAsientoCamaraAlta, string PartidoPolitico, string DepartamentoR, int NumDespachante, string Nombre, string Apellido, int Edad, bool Casado):base(PartidoPolitico, DepartamentoR, NumDespachante, Nombre, Apellido, Edad, Casado)
        {
            this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;
        }
        public void SetNumAsientoCamaraAlta(int NumAsientoCamaraAlta) => this.NumAsientoCamaraAlta = NumAsientoCamaraAlta;
        public int GetNumAsientoCamaraAlta()=>NumAsientoCamaraAlta;

        public override void presentarPropuestaLegislativa(Parlamento Parlamento, string Propuesta)
        {
            Parlamento.AgregarPropuesta(new Propuestas(this, Propuesta));
        }
        public override void Votar(Parlamento Parlamento, int PropuestaVotada)
        {
            Parlamento.GetPropuestas(PropuestaVotada).SetVotos(1);
        }
        public override void ParticiparDebate(Parlamento Parlamento, int PropuestaDebatida)
        {
            Parlamento.GetPropuestas(PropuestaDebatida).SetPersonasDebatiendo(1);
        }

    }
}
