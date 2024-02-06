using FIFA_Ranking.Models.Interfaces;

namespace FIFA_Ranking.Models.CalculosPuntos
{
    public class CalculoPuntosPromedio : ICalculoPuntos
    {
        public int CalcularPuntos(IEnumerable<Equipo> equipos)
        {
            return equipos.Any() ? (int)equipos.Average(e => e.ObtenerPuntos()) : 0;
        }
    }
}
