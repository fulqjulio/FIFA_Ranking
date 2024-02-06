using FIFA_Ranking.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA_Ranking.Models.CalculosPuntos
{
    public class CalculoPuntosPromedioCincoPeores : ICalculoPuntos
    {
        public int CalcularPuntos(IEnumerable<Equipo> equipos)
        {
            equipos = equipos.OrderBy(e => e.ObtenerPuntos());

            List<Equipo> mejoresEquipos = equipos.Take(5).ToList();

            return mejoresEquipos.Any() ? (int)mejoresEquipos.Average(e => e.ObtenerPuntos()) : 0;
        }
    }
}
