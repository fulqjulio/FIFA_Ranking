using System.Transactions;

namespace FIFA_Ranking.Models
{
    public class Equipo : Ranking
    {
        private int _titulosInternacionales;
        private int _titulosNacionales;
        private int _jugadoresTemporada;
        private string _ciudad;
        private string _tecnico;

        public Equipo(
            string nombre, 
            int puntos, 
            int titulosInternacionales, 
            int titulosNacionales, 
            int jugadoresTemporada, 
            string ciudad, 
            string tecnico
            ) : base(nombre, puntos)
        {
            this._titulosInternacionales = titulosInternacionales;
            this._titulosNacionales = titulosNacionales;
            this._jugadoresTemporada = jugadoresTemporada;
            this._ciudad = ciudad;
            this._tecnico = tecnico;
        }

        public int ObtenerNumeroJugadores()
        {
            return this._jugadoresTemporada;
        }

        public string ObtenerCiudad()
        {
            return this._ciudad;
        }

        public int ObtenerTitulosInternacionales()
        {
            return this._titulosInternacionales;
        }

        
    }
}