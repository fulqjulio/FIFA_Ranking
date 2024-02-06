using FIFA_Ranking.Models.Interfaces;

namespace FIFA_Ranking.Models.CalculosPuntos
{
    internal class CalculoPuntosPromedioCincoMejores : ICalculoPuntos
    {
        public int CalcularPuntos(IEnumerable<Equipo> equipos)
        {
            equipos = equipos.OrderByDescending(e => e.ObtenerPuntos());

            List<Equipo> mejoresEquipos = equipos.Take(5).ToList();

            return mejoresEquipos.Any() ? (int)mejoresEquipos.Average(e => e.ObtenerPuntos()) : 0;
        }
    }
}
