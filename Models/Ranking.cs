namespace FIFA_Ranking.Models
{
    public abstract class Ranking
    {
        private string _nombre;
        private int _puntos;

        public Ranking(string nombre, int puntos)
        {
           this._nombre = nombre;
           this._puntos = puntos;
        }

        public Ranking(string nombre)
        {
            this._nombre = nombre;
        }
        public int ObtenerPuntos()
        {
            return this._puntos;
        }

        public void EstablecerPuntos(int nuevosPuntos)
        {
            this._puntos = nuevosPuntos;
        }
        public string ObtenerNombre()
        {
            return this._nombre;
        }
    }
}
