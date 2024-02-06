using FIFA_Ranking.Models.CalculosPuntos;
using FIFA_Ranking.Models.Interfaces;

namespace FIFA_Ranking.Models
{
    public class Grupo : Ranking
    {
        private int _jugadoresTemporada;
        private List<Equipo> _equipos;

        private ICalculoPuntos _calculoPuntos;

        public Grupo(string nombre) : base(nombre)
        {
            this._equipos = new List<Equipo>();
            this._jugadoresTemporada = 0;
            this._calculoPuntos = new CalculoPuntosPromedio();
        }
        public void AgregarEquipo(Equipo equipo)
        {
            this._jugadoresTemporada += equipo.ObtenerNumeroJugadores();
            this._equipos.Add(equipo);
        }

        public int ObtenerNumeroJugadores()
        {
            return this._jugadoresTemporada;
        }

        public List<Equipo> ObtenerEquipos()
        {
            return this._equipos;
        }

        public void EvaluarPuntuacion()
        {
            int puntuacion = this._calculoPuntos.CalcularPuntos(this._equipos);
            EstablecerPuntos(puntuacion);
        }

        public void CambiarEstrategiaCalculo(ICalculoPuntos nuevaEstrategia)
        {
            this._calculoPuntos = nuevaEstrategia;
            EvaluarPuntuacion();
        }

    }
}
