using Dominio;
using System;
using System.Collections.Generic;

namespace Entrega_1
{
    class Program
    {
        static Agencia laAgencia = new Agencia();

        static void Main(string[] args)
        {
            bool leave = false;
            int option = 0;
            while (!leave)
            {
                MostrarMenu();
                option = PedirNumeroEntero("Ingrese la opcion deseada");
                switch (option)
                {
                    case 1:
                        AltaDestino();
                        break;
                    case 2:
                        ListarDestinos();
                        break;
                    case 3:
                        ModificarCotizacion();
                        break;
                    case 4:
                        ListarExcursiones();
                        break;
                    case 5:
                        ExcursionesEntreFechas();
                        break;
                    case 0:
                        leave = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            MostrarTitulo("Menu");
            Console.WriteLine("1-ingresar un destino");
            Console.WriteLine("2-visualizar destinos disponibles");
            Console.WriteLine("3-modificar cotizacion del dolar");
            Console.WriteLine("4-visualizar las excursiones");
            Console.WriteLine("5-visualizar excursiones que vayan a un destino dado entre dos fechas");
            Console.WriteLine();
            Console.WriteLine("0-salir");
        }

        private static void MostrarTitulo(string title)
        {
            string line = "*************************";
            Console.WriteLine();
            Console.WriteLine(line);
            Console.WriteLine(title);
            Console.WriteLine(line);
        }

        private static void ExcursionesEntreFechas()
        {
            int option = PedirNumeroEntero("presione 1 si conoce el identificador del destino/presione dos para elegir por ciudad y pais");
            bool valido = false;
            while (!valido)
            {
                if (option == 1 || option == 2)
                {
                    valido = true;
                } else
                {
                    Console.WriteLine("esa o es una opcion valida");
                }

            }
            string ciudad = "";
            string pais = "";
            int idABuscar;

            DateTime desde = PedirFecha("Ingrese fecha desde dd/mm/yyyy");
            DateTime hasta = PedirFecha("Ingrese fecha hasta dd/mm/yyyy");

            Destino destino = null;
            if (option == 1)
            {
                idABuscar = PedirNumeroEntero("ingrese el id del destino");
                destino = laAgencia.BuscarDestinoPorId(idABuscar);
            } else
            {
                pais = PedirTexto("ingrese el pais destino:");
                ciudad = PedirTexto($"ingrese una ciudad dentro de {pais}:");
                destino = laAgencia.BuscarDestinoPorCiudad(ciudad, pais);
            }

            List<Excursion> excursiones = laAgencia.ExcursionesADestinoEntreFechas(destino, desde, hasta);
            MostrarListaExcursiones(excursiones, "--> No hay excursiones en ese rango de fechas para ese destino.");
        }

        private static void MostrarListaExcursiones(List<Excursion> excursiones, string msgError)
        {
            if (excursiones.Count > 0)
            {
                foreach (Excursion excursion in excursiones)
                {
                    Console.WriteLine(excursion);
                }
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }

        private static Destino BuscarDestinoPorCiudad(string ciudad, string pais)
        {
            return laAgencia.BuscarDestinoPorCiudad(ciudad, pais);
        }

        private static Destino BuscarDestinoPorId(int id)
        {
            return laAgencia.BuscarDestinoPorId(id);
        }

        private static DateTime PedirFecha(string mensaje = "Ingrese la fecha:")
        {
            DateTime fecha;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = DateTime.TryParse(Console.ReadLine(), out fecha);
                if (!valido)
                {
                    Console.WriteLine("La fecha no es valida.");
                }
            } while (!valido);
            return fecha;
        }

        private static void MensajeAlta(bool resultado)
        {
            if (resultado == true)
            {
                Console.WriteLine("--> Se dio el alta correctamente");
            }
            else
            {
                Console.WriteLine("--> No se pudo dar el alta, revise los datos ingresados");
            }
        }

        private static void AltaDestino()
        {
            string ciudad;
            string pais;
            int dias;
            int costoDiario;
            MostrarTitulo("Alta Destino");
            ciudad = PedirTexto("Ingrese la ciudad:");
            pais = PedirTexto("Ingrese el pais:");
            dias = PedirNumeroEntero("Ingrese la cantidad de dias que se estara en el destino:");
            costoDiario = PedirNumeroEntero("Ingrese el costo diario aproximado:");
            MensajeAlta(laAgencia.AgregarDestino(ciudad, pais, dias, costoDiario));
        }

        private static void ListarDestinos()
        {
            MostrarTitulo("Listado de Destinos");
            foreach (Destino destino in laAgencia.ListarDestinos)
            {
                Console.WriteLine(destino);
            }
        }

        private static void ListarExcursiones()
        {
            MostrarTitulo("Listado de Excursiones");
            foreach (Excursion excursion in laAgencia.ListarExcursiones)
            {
                Console.WriteLine(excursion);
            }
        }

        private static void ModificarCotizacion()
        {
            double nuevaCotizacion;
            nuevaCotizacion = PedirNumeroDecimal("Ingrese la nueva cotizacion:");
            MensajeAlta(laAgencia.ModificarCotizacion(nuevaCotizacion));
        }

        private static double PedirNumeroDecimal(string mensaje = "Ingrese el numero:")
        {
            double num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = double.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("Solo se admiten numeros");
                }
            } while (!valido);
            return num;
        }

        private static int PedirNumeroEntero(string mensaje = "Ingrese el numero:")
        {
            int num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = int.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("Solo se admiten numeros");
                }
            } while (!valido);
            return num;
        }

        private static string PedirTexto(string mensaje = "Ingrese el texto:")
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }
    }
}
