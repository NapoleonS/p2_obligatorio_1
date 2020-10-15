using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Excursion
    {
        private int id = 0;
        private static int ultId = 900;
        private string descripcion = "";
        private DateTime fechaComienzo = new DateTime();
        private List<Destino> destinos;
        private int diasTraslado = 0;
        private int stock = 0;

        public int Id
        {
            get { return id; }
        }

        public Excursion(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslado, int stock)
        {
            ultId += 100;
            this.id = ultId;
            this.descripcion = descripcion;
            this.fechaComienzo = fechaComienzo;
            this.destinos = destinos;
            this.diasTraslado = diasTraslado;
            this.stock = stock;
        }

        public DateTime FechaComienzo
        {
            get { return fechaComienzo; }
        }

        public int CalcularCosto()
        {
            int result = 0;
            foreach (Destino destino in destinos)
            {
                result += destino.CostoDiario * destino.Dias;
            }
            return result;
        }

        public override string ToString()
        {
            return $"id: {id}, descripcion: {descripcion}, fecha de comienzo: {fechaComienzo}, destinos: {destinos}, dias de traslado: {diasTraslado}, stock: {stock}, costo: {CalcularCosto()}.";
        }
    }
}
