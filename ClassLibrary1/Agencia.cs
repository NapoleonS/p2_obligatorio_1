using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Agencia
    {
        private List<Destino> listaDestinos = new List<Destino>();
        private List<Excursion> listaExcursiones = new List<Excursion>();
        private List<CompaniaAerea> listaCompanias = new List<CompaniaAerea>();
        private double cotizacion = 0;

        public Agencia()
        {
            Precarga();
        }

        public List<Destino> ListarDestinos
        {
            get { return listaDestinos; }
        }

        public List<Excursion> ListarExcursiones
        {
            get { return listaExcursiones; }
        }

        // busca un destino por combinacion ciudad pais
        public Destino BuscarDestinoPorCiudad(string ciudad, string pais)
        { 
            int i = 0;
            Destino destino = null;
            while (destino == null && i < listaDestinos.Count)
            {
                if (listaDestinos[i].Ciudad == ciudad && listaDestinos[i].Pais == pais)
                {
                    destino = listaDestinos[i];
                }
                i++;
            }
            return destino;
        }

        public Destino BuscarDestinoPorId(int id)
        {
            int i = 0;
            Destino destino = null;
            while (destino == null && i < listaDestinos.Count)
            {
                if (listaExcursiones[i].Id == id)
                {
                    destino = listaDestinos[i];
                }
                i++;
            }
            return destino;
        }

        public Excursion BuscarExcursion(int id)
        {
            int i = 0;
            Excursion excursion = null;
            while (excursion == null && i < listaExcursiones.Count)
            {
                if (listaExcursiones[i].Id == id)
                {
                    excursion = listaExcursiones[i];
                }
                i++;
            }
            return excursion;
        }

        public List<Excursion> ExcursionesADestinoEntreFechas(Destino destino, DateTime fecha1, DateTime fecha2)
        {
            List<Excursion> result = new List<Excursion>();
            foreach (Excursion unaExcursion in listaExcursiones)
            {
                if (DateTime.Compare(fecha1, unaExcursion.FechaComienzo) <= 0 && DateTime.Compare(unaExcursion.FechaComienzo, fecha2) <= 0)
                {
                    result.Add(unaExcursion);
                }
            }
            return result;
        }

        public bool AgregarExcursionNacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslado, int stock,bool esDeInteresNacional)
        {
            bool success = true;
            foreach (var destino in destinos)
            {
                if (destino.Pais != "Uruguay")
                {
                    success = false;
                }
            }
            if (success == true)
            {
            Nacional excursion = new Nacional(descripcion, fechaComienzo, destinos, diasTraslado, stock, esDeInteresNacional);
            listaExcursiones.Add(excursion);
            }
            return success;
        }

        public bool AgregarExcursionInternacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslado, int stock, CompaniaAerea compania)
        {
            bool success = true;
            Internacional excursion = new Internacional(descripcion, fechaComienzo, destinos, diasTraslado, stock, compania);
            listaExcursiones.Add(excursion);
            return success;
        }

        public void Precarga()
        {
            PrecargaCotizacion();
            PrecargaDestinos();
            PrecargaExcursiones();
        }

        public void PrecargaExcursiones()
        {
            DateTime fecha;
            List<Destino> listaDestinos = new List<Destino>();

            fecha = new DateTime(2012, 12, 31);
            AgregarCompania(1, "Estados Unidos");
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Nueva York", "Estados Unidos"));
            AgregarExcursionInternacional("Viaje de placer", fecha, listaDestinos, 2, 7, BuscarCompania(1));

            fecha = new DateTime(2018, 12, 31);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Nueva York", "Estados Unidos"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Londres", "Inglaterra"));
            AgregarExcursionInternacional("Viaje de placer", fecha, listaDestinos, 4, 14, BuscarCompania(1));

            fecha = new DateTime(2010, 10, 11);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Nueva York", "Estados Unidos"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Londres", "Inglaterra"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Roma", "Italia"));
            AgregarExcursionInternacional("Viaje de placer", fecha, listaDestinos, 5, 21, BuscarCompania(1));

            fecha = new DateTime(2012, 12, 31);
            AgregarCompania(2, "Emiratos Arabes Unidos");
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Dubai", "Emiratos Arabes Unidos"));
            AgregarExcursionInternacional("Viaje de placer", fecha, listaDestinos, 2, 7, BuscarCompania(2));

            fecha = new DateTime(2012, 12, 31);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Rocha", "Uruguay"));
            AgregarExcursionNacional("Viaje de placer", fecha, listaDestinos, 0, 3, true);

            fecha = new DateTime(2012, 12, 31);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Rivera", "Uruguay"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Montevideo", "Uruguay"));
            AgregarExcursionNacional("Viaje de placer", fecha, listaDestinos, 1, 10, true);

            fecha = new DateTime(2012, 12, 31);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Rocha", "Uruguay"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Punta del Este", "Uruguay"));
            AgregarExcursionNacional("Viaje de placer", fecha, listaDestinos, 1, 10, true);

            fecha = new DateTime(2012, 12, 31);
            listaDestinos.Clear();
            listaDestinos.Add(BuscarDestinoPorCiudad("Rocha", "Uruguay"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Rivera", "Uruguay"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Montevideo", "Uruguay"));
            listaDestinos.Add(BuscarDestinoPorCiudad("Punta del Este", "Uruguay"));
            AgregarExcursionNacional("Viaje de placer", fecha, listaDestinos, 2, 14, true);
        }

        public void PrecargaCotizacion()
        {
            ModificarCotizacion(42.59); 
        }

        public bool AgregarDestino(string ciudad, string pais, int dias, int costoDiario)
        {
            bool success = false;
            if (BuscarDestinoPorCiudad(ciudad, pais) == null)
            {
                Destino destino = new Destino(ciudad, pais, dias, costoDiario);
                listaDestinos.Add(destino);
                success = true;
            }
            return success;
        }

        public void PrecargaDestinos()
        {
            AgregarDestino("Nueva York", "Estados Unidos", 12, 1550);
            AgregarDestino("Rivera", "Uruguay", 17, 750);
            AgregarDestino("Buenos Aires", "Argentina", 11, 800);
            AgregarDestino("Dubai", "Emiratos Arabes Unidos", 7, 2120);
            AgregarDestino("Roma", "Italia", 7, 1820);
            AgregarDestino("Rocha", "Uruguay", 20, 550);
            AgregarDestino("Montevideo", "Uruguay", 20, 550);
            AgregarDestino("Londres", "Inglaterra", 18, 1800);
            AgregarDestino("Punta del Este", "Uruguay", 12, 1550);
            AgregarDestino("Tokyo", "Japon", 7, 2200);
        }

        public CompaniaAerea BuscarCompania(int codigo)
        {
            int i = 0;
            CompaniaAerea compania = null;
            while (compania == null && i < listaCompanias.Count)
            {
                if (listaCompanias[i].Codigo == codigo)
                {
                    compania = listaCompanias[i];
                }
                i++;
            }
            return compania;
        }

        public bool AgregarCompania(int codigo, string pais)
        {
            bool success = false;
            if (BuscarCompania(codigo) == null)
            {
                CompaniaAerea compania = new CompaniaAerea(codigo, pais);
                listaCompanias.Add(compania);
                success = true;
            }
            return success;
        }

        public bool ModificarCotizacion(double nuevaCotizacion)
        {
            bool success = false;
            if (nuevaCotizacion > 0)
            {
                cotizacion = nuevaCotizacion;
                success = true;
            }
            return success;
        }

       
    }
}
