using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1.P2
{
    abstract class Legisladores
    {

        private string PartidoPolitico;
        private string DepartamentoRepresentado;
        private string Nombre;
        private string Apellido;
        private int NumDespacho;
        private int Edad;
        private bool Casado;

        public Legisladores()
        {
            PartidoPolitico = string.Empty;
            DepartamentoRepresentado = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NumDespacho = 0;
            Edad = 0;
            Casado = false;
        }
        public Legisladores(string PartidoPolitico, string DepartamentoRepresentado, int NumDespacho, string Nombre, string Apellido, int Edad, bool Casado)
        {
            this.PartidoPolitico = PartidoPolitico;
            this.DepartamentoRepresentado = DepartamentoRepresentado;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.NumDespacho = NumDespacho;
            this.Edad = Edad;
            this.Casado = Casado;

        }
        public string GetPartidoPolitico()=> PartidoPolitico;
        public void SetPartidoPolitico(string PartidoPolitico)=> this.PartidoPolitico=PartidoPolitico;
        public void SetDepartamentoRepresentado(string DepartamentoRepresentado)=> this.DepartamentoRepresentado = DepartamentoRepresentado;
        public string GetDepartamentoRepresentado()=> DepartamentoRepresentado;
        public string GetNombre() => Nombre;
        public void SetNombre(string Nombre)=>this.Nombre=Nombre;
        public string GetApellido() => Apellido;
        public void SetApellido(string Apellido) => this.Apellido = Apellido;
        public int GetNumDespacho() => NumDespacho;
        public void SetNumDespacho(int NumDespacho)=> this.NumDespacho = NumDespacho;
        public int GetEdad() => Edad;
        public void SetEdad(int Edad)=> this.Edad = Edad;
        public bool GetCasado() => Casado;  
        public void SetCasado(bool Casado) =>this.Casado = Casado;
        public void GetCamara()
        {
            Console.WriteLine("ASD");
            Console.WriteLine(this.GetType().Name);
        }
        public abstract void presentarPropuestaLegislativa(Parlamento Parlamento, string Propuesta);
        public abstract void Votar(Parlamento Parlamento, int PropuestaVotada);
        public abstract void ParticiparDebate(Parlamento Parlamento, int PropuestaDebatida);
       
    }
}
