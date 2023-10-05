using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Practico1.P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parlamento Parlamento = new Parlamento();
            List<Legisladores> Legisladores = new List<Legisladores>();
            int Opcion;
            bool OpcionValida = false;
            Senador SenadorDePrueba = new Senador(34, "boludo", "Maldonado", 4, "Pepe", "Pepa", 21, false);
            Diputado DiputadoDePrueba = new Diputado(53, "boludo", "Maldonado", 5, "Pepe", "Pepa", 21, false);
            Legisladores.Add(SenadorDePrueba);
            Legisladores.Add(DiputadoDePrueba);

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Que quiere hacer?");
                    Console.WriteLine("1. Crear Senador");//pronto
                    Console.WriteLine("2. Crear Diputado");//pronto
                    Console.WriteLine("3. Agregar Legislador a Parlamento");//pronto
                    Console.WriteLine("4. Presentar propuesta legislativa");//pronto
                    Console.WriteLine("5. Debatir propuesta");//pronto
                    Console.WriteLine("6. Listado de Legisladores");//pronto
                    Console.WriteLine("7. Legisladores por tipo");//pronto
                    Console.WriteLine("8. Votar");
                    Console.WriteLine("9. ver propuestas");
                    Console.WriteLine("10. Ver Camara");
                    Console.WriteLine("11. Salir");
                    OpcionValida = int.TryParse(Console.ReadLine(), out Opcion);
                    if (!OpcionValida || Opcion > 11 || Opcion < 1)
                    {
                        Console.WriteLine("La opcion ingresada es invalida, vuelva a ingresarla");
                        OpcionValida = false;
                    }
                } while (!OpcionValida);
                switch (Opcion)
                {
                    case 1:
                        Legisladores.Add(CrearSenador());
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 2:
                        Legisladores.Add(CrearDiputado());
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 3:
                        int SenadorARegistrar;
                        bool DatoValido = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Elija el legislador a agregar.");
                            for (int i = 0; i < Legisladores.Count; i++)
                            {
                                var Muestra = Legisladores[i];
                                Console.WriteLine($"{i}. {Muestra.GetType().Name} {Muestra.GetApellido()} {Muestra.GetNombre()}");
                            }
                            DatoValido = int.TryParse(Console.ReadLine(), out SenadorARegistrar);
                            if (!DatoValido || SenadorARegistrar < 0 || SenadorARegistrar > Legisladores.Count - 1)
                            {
                                if (!DatoValido)
                                {
                                    Console.WriteLine("El tipo de dato ingresado es invalido");
                                }
                                else
                                {
                                    DatoValido = false;
                                    Console.WriteLine("El legislador seleccionado no existe.");
                                }
                            }
                        } while (!DatoValido);
                        Parlamento.RegistrarLegislador(Legisladores[SenadorARegistrar]);
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 4:
                        int QuienPropone;
                        string Propuesta;
                        var LegisladoresParlamento = Parlamento.GetLegisladores();
                        Console.WriteLine("Quien propone la propuesta?");
                        for(int i = 0;i < LegisladoresParlamento.Count; i++)
                        {
                            var Presenta = LegisladoresParlamento[i];
                            Console.WriteLine($"{i}. {Presenta.GetType().Name} {Presenta.GetNombre()}");
                        }
                        do
                        {
                            bool OpcionAceptable = int.TryParse(Console.ReadLine(), out QuienPropone);
                            if (!OpcionAceptable)
                            {
                                Console.WriteLine("Opcion invalida");
                            }
                        }while(QuienPropone > 0 && QuienPropone < Legisladores.Count);
                        Console.WriteLine("Que propone?");
                        Propuesta = Console.ReadLine();
                        Legisladores[QuienPropone].presentarPropuestaLegislativa(Parlamento, Propuesta);
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 5:
                        bool Valido;
                        int PropuestaADebatir;
                        Console.WriteLine("Que quiere debatir?");
                        for( int i = 0;i < Parlamento.GetPropuestas().Count; i++)
                        {
                            var ListaPropuestas = Parlamento.GetPropuestas();
                            Console.WriteLine($"{i}. {ListaPropuestas[i].GetPropuesta()} ");
                        }
                        do
                        {
                            Valido = int.TryParse(Console.ReadLine(), out PropuestaADebatir);
                            if (!Valido)
                            {
                                Console.WriteLine("Opcion incorrecta");
                            }
                        } while (!Valido);
                        Console.WriteLine("Usted esta debatiendo " + Parlamento.GetPropuestas()[PropuestaADebatir].GetPropuesta());
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 6:
                        for(int i = 0;i < Legisladores.Count; i++)
                        {
                           var Leg = Legisladores[i];
                           Console.WriteLine($"{Leg.GetType().Name} {Leg.GetApellido()}");
                        }
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 7:
                        Parlamento.LegisladoresPorTipo();
                        Console.WriteLine("Precione una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 8:
                        Votar(Parlamento);
                        break;
                    case 9:
                        var Propuestas = Parlamento.GetPropuestas();
                        if (Parlamento.GetPropuestas().Count == 0)
                        {
                            Console.WriteLine("No existe ninguna propuesta ingresada \nIngrese una propuesta antes de continuar");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < Propuestas.Count; i++)
                            {
                                Console.WriteLine($"{i}. {Propuestas[i].GetPropuesta()}. Fue votada \x1b[32m{Propuestas[i].GetVotos()}\x1b[0m");
                            }
                        }                        
                        break;
                    case 10:
                        var Lista = Parlamento.GetLegisladores();
                        int LegisladorSeleccionado;
                        bool CorrectInput = false;
                        if(Parlamento.GetLegisladores().Count == 0)
                        {
                            Console.WriteLine("No hay Legisladores registrados.\nPresione enter para continuar.");
                            Console.ReadLine();
                            break;
                        }
                        do
                        {
                            Console.WriteLine("De quien quiere ver la camara?");
                            for (int i = 0; i < Lista.Count; i++)
                            {
                                Console.WriteLine($"{i}. {Lista[i].GetApellido()} {Lista[i].GetNombre()}");
                            }
                            CorrectInput = int.TryParse(Console.ReadLine(), out LegisladorSeleccionado);
                        } while (!CorrectInput);
                        Legisladores Seleccion = Parlamento.GetLegisladores(LegisladorSeleccionado);
                        Seleccion.GetCamara();
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadLine();
                        break;
                    case 11:
                        Environment.Exit(0);
                        break;

                }
            }while(true);
            
        }
        public static Senador CrearSenador()
        {
            bool DatoValido = false;
            int NumAsientoCamaraAlta;
            string PartidoPolitico;
            string DepartamentoRepresentado;
            int NumDespacho;
            string Nombre, Apellido;
            int Edad;
            bool Casado = false;
            string DatoInvalido = "El tipo de dato ingresado es incorrecto. \nIngrese un numero entero";

            do
            {
                Console.WriteLine("Ingrese Numero de asiento clase alta");
                DatoValido = int.TryParse(Console.ReadLine(), out NumAsientoCamaraAlta);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            Console.WriteLine("Ingrese el partido politico");
            PartidoPolitico = Console.ReadLine();
            Console.WriteLine("Ingrese el departamento que representa");
            DepartamentoRepresentado = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese el numero de despacho");
                DatoValido = int.TryParse(Console.ReadLine(), out NumDespacho);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            Console.WriteLine("Ingrese el nombre del senador");
            Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del senador");
            Apellido = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese la edad del senador");
                DatoValido = int.TryParse(Console.ReadLine(), out Edad);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            do
            {
                Console.WriteLine("El senador esta casado? 'S' o 'N'");
                string ValorTemporal = Console.ReadLine().ToLower();
                if (ValorTemporal != "s" && ValorTemporal != "n")
                {
                    Console.WriteLine("El valor ingresado tiene que ser 'S' o 'N'");
                }
                else
                {
                    if (ValorTemporal == "n")
                    {
                        DatoValido = true;
                        Casado = false;
                    }
                    else
                    {
                        DatoValido = true;
                        Casado = true;
                    }
                }
            } while (!DatoValido);
            Console.WriteLine("Creando Senador");
            return new Senador(NumAsientoCamaraAlta, PartidoPolitico, DepartamentoRepresentado, NumDespacho, Nombre, Apellido, Edad, Casado);

        }
        public static Diputado CrearDiputado()
        {
            bool DatoValido = false;
            int NumAsientoCamaraBaja;
            string PartidoPolitico;
            string DepartamentoRepresentado;
            int NumDespacho;
            string Nombre, Apellido;
            int Edad;
            bool Casado = false;
            string DatoInvalido = "El tipo de dato ingresado es incorrecto. \nIngrese un numero entero";

            do
            {
                Console.WriteLine("Ingrese Numero de asiento clase alta");
                DatoValido = int.TryParse(Console.ReadLine(), out NumAsientoCamaraBaja);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            Console.WriteLine("Ingrese el partido politico");
            PartidoPolitico = Console.ReadLine();
            Console.WriteLine("Ingrese el departamento que representa");
            DepartamentoRepresentado = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese el numero de despacho");
                DatoValido = int.TryParse(Console.ReadLine(), out NumDespacho);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            Console.WriteLine("Ingrese el nombre del Diputado");
            Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del Diputado");
            Apellido = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese la edad del Diputado");
                DatoValido = int.TryParse(Console.ReadLine(), out Edad);
                if (!DatoValido)
                {
                    Console.WriteLine(DatoInvalido);
                }
            } while (!DatoValido);
            do
            {
                Console.WriteLine("El Diputado esta casado? 'S' o 'N'");
                string ValorTemporal = Console.ReadLine().ToLower();
                if (ValorTemporal != "s" && ValorTemporal != "n")
                {
                    Console.WriteLine("El valor ingresado tiene que ser 'S' o 'N'");
                }
                else
                {
                    if (ValorTemporal == "n")
                    {
                        DatoValido = true;
                        Casado = false;
                    }
                    else
                    {
                        DatoValido = true;
                        Casado = true;
                    }
                }
            } while (!DatoValido);
            Console.WriteLine("Creando Diputado");
            return new Diputado(NumAsientoCamaraBaja, PartidoPolitico, DepartamentoRepresentado, NumDespacho, Nombre, Apellido, Edad, Casado);
        }
        public static void Votar(Parlamento Parlamento)
        {
            var Votantes = Parlamento.GetLegisladores();
            var Propuestas = Parlamento.GetPropuestas();
            int Vota;
            int PropuestaVotada;
            Legisladores QuienVota;

            if(Parlamento.GetLegisladores().Count == 0)
            {
                Console.WriteLine("No existen legisladores en el parlamento \nIngreselos primero antes de continuar");
                Console.ReadLine();
                return;
            }
            if(Parlamento.GetPropuestas().Count == 0)
            {
                Console.WriteLine("No existe ninguna propuesta ingresada \nIngrese una propuesta antes de continuar");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Quien vota?");
            for(int i = 0; i < Votantes.Count; i++)
            {
                Console.WriteLine($"{i}. {Votantes[i].GetType().Name} {Votantes[i].GetApellido()}");
            }
            do
            {
                bool DatoCorrecto = int.TryParse(Console.ReadLine(), out Vota);
                if (!DatoCorrecto)
                {
                    Console.WriteLine("Tipo de dato incorrecto");
                }
                else if (Vota < 0 || Vota > Votantes.Count)
                {
                    Console.WriteLine("Opcion invalida");
                }
            } while (Vota < 0 || Vota > Votantes.Count);
            QuienVota = Votantes[Vota];
            Console.WriteLine("Que propuesta vota?");
            for (int i = 0; i < Propuestas.Count; i++)
            {
                Console.WriteLine($"{i}. {Propuestas[i].GetPropuesta()}");
            }
            do
            {
                bool DatoCorrecto = int.TryParse(Console.ReadLine(), out PropuestaVotada);
                if (!DatoCorrecto)
                {
                    Console.WriteLine("Tipo de dato invalido");
                }
            } while (PropuestaVotada < 0 || PropuestaVotada > Propuestas.Count);

            QuienVota.Votar(Parlamento, PropuestaVotada);
        }
    }
    
}
