using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Agencia
    {
        private List<Destino> listaDestinos = new List<Destino>();
        private List<Excursion> listaExcursiones = new List<Excursion>();
        private List<CompaniaAerea> listaCompanias = new List<CompaniaAerea>();
        private decimal cotizacion = 0;

        public List<Destino> ListarDestinos()
        {
            List<Destino> aux = new List<Destino>();
            foreach (var destino in listaDestinos)
            {
                aux.Add(destino);
            }
            return aux;
        }

        public List<Excursion> listarExcursiones
        {
            get { return listaExcursiones; }
        }

        public Destino BuscarDestino(string ciudad, string pais)
        { 
            int i = 0;
            Destino destino = null;
            while (destino == null && i < listaDestinos.Count)
            {
                if (listaDestinos[i].Ciudad == ciudad && listaDestinos[i].Pais == pais)
                {
                    destino = listaDestinos[i];
                }
            }
            return destino;
        }

        public List<Excursion> ExcursionesADestino(Destino destino, DateTime fecha1, DateTime fecha2)
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

        public bool AgregarDestino(string ciudad, string pais, int dias, decimal costoDiario)
        {
            bool success = false;
            if (BuscarDestino(ciudad, pais) == null)
            {
                Destino destino = new Destino(ciudad, pais, dias, costoDiario);
                listaDestinos.Add(destino);
                success = true;
            }
            return success;
        }

        public CompaniaAerea BuscarCompania(int codigo)
        {
            int i = 0;
            CompaniaAerea compania = null;
            while (compania == null && i < listaDestinos.Count)
            {
                if (listaCompanias[i].Codigo == codigo)
                {
                    compania = listaCompanias[i];
                }
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

        public bool ModificarCotizacion(decimal nuevaCotizacion)
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
