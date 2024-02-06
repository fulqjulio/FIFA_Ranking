namespace FIFA_Ranking.Models.Interfaces
{
    public interface ICalculoPuntos
    {
        int CalcularPuntos(IEnumerable<Equipo> equipos);
    }
}
