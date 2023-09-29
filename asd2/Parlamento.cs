using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Practico1.P2
{
    internal class Parlamento
    {
        private List<Legisladores> ListaLegisladores;
        private List<Propuestas> Propuestas;
        public Parlamento()
        {
            ListaLegisladores = new List<Legisladores>();
            Propuestas = new List<Propuestas>();
        }
        public void RegistrarLegislador(Legisladores Legisladores)
        {
            ListaLegisladores.Add(Legisladores);
        }
        public void ListaCamaras(object TipoRequerido)
        {
            //if(TipoRequerido.GetType().Name == "Diputado") { }
            for(int i = 0; i < ListaLegisladores.Count; i++)
            {
                if (ListaLegisladores[i].GetType().Name == TipoRequerido.GetType().Name)
                {
                    Console.WriteLine(ListaLegisladores[i].GetNumDespacho());
                }
            }
        }
        public void LegisladoresPorTipo()
        {
            List<Type> ListaUnica = new List<Type>();
            foreach(Legisladores legisladores in ListaLegisladores)
            {
                if (!ListaUnica.Contains(legisladores.GetType()))
                {
                    ListaUnica.Add(legisladores.GetType());
                }
            }
            foreach(Type legisladores1 in ListaUnica)
            {
                int Conteo = ListaLegisladores.Where(item => item.GetType() == legisladores1).Count();
                Console.WriteLine($"Existen {Conteo} de {legisladores1.Name}");
            }
        }
        public void AgregarPropuesta(Propuestas Propuesta)
        {
            Propuestas.Add(Propuesta);
        }
        public List<Legisladores> GetLegisladores()
        {
            return ListaLegisladores;
        }
        public List<Propuestas> GetPropuestas()
        {
            return Propuestas;
        }
        public Propuestas GetPropuestas(int PropuestaRequerida)
        {
            return Propuestas[PropuestaRequerida];
        }

    }
}
