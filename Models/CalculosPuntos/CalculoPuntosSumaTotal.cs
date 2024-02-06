using FIFA_Ranking.Models.Interfaces;

namespace FIFA_Ranking.Models.CalculosPuntos
{
    public class CalculoPuntosSumaTotal : ICalculoPuntos
    {
        public int CalcularPuntos(IEnumerable<Equipo> equipos)
        {
            return equipos.Any() ? (int)equipos.Sum(e => e.ObtenerPuntos()) : 0;
        }
    }
}
