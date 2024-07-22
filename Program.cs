using FIFA_Ranking.Models;
using FIFA_Ranking.Models.CalculosPuntos;

class Program
{
    static void Main()
    {
        Equipo RealMadrid = new Equipo("Real Madrid", 80, 13, 34, 18, "Madrid", "Zinedine Zidane");
        Equipo Barcelona = new Equipo("FC Barcelona", 75, 5, 26, 22, "Barcelona", "Ronald Koeman");
        Equipo Manchester = new Equipo("Manchester United", 70, 3, 20, 13, "Manchester", "Ole Gunnar Solskjær");
        Equipo Juventus = new Equipo("Juventus", 78, 2, 36, 21, "Turín", "Andrea Pirlo");
        Equipo Liverpool = new Equipo("Liverpool", 76, 6, 19, 23, "Liverpool", "Jurgen Klopp");
        
        Equipo BocaJuniors = new Equipo("Boca Juniors", 88, 22, 34, 15, "Buenos Aires", "Miguel Ángel Russo");
        Equipo RiverPlate = new Equipo("River Plate", 85, 18, 36, 18, "Buenos Aires", "Marcelo Gallardo");
        Equipo Flamengo = new Equipo("Flamengo", 82, 6, 37, 16, "Río de Janeiro", "Renato Gaúcho");

        Equipo ClubAmerica = new Equipo("Club América", 75, 3, 13, 22, "Ciudad de México", "Santiago Solari");
        Equipo Toronto = new Equipo("Toronto FC", 72, 1, 6, 12, "Toronto", "Bob Bradley");


        Confederacion UEFA = new Confederacion("UEFA");
        UEFA.AgregarEquipo(RealMadrid);
        UEFA.AgregarEquipo(Barcelona);
        UEFA.AgregarEquipo(Manchester);
        UEFA.AgregarEquipo(Juventus);
        UEFA.AgregarEquipo(Liverpool);
        UEFA.EvaluarPuntuacion();

        Confederacion CONMEBOL = new Confederacion("CONMEBOL");
        CONMEBOL.AgregarEquipo(BocaJuniors);
        CONMEBOL.AgregarEquipo(RiverPlate);
        CONMEBOL.AgregarEquipo(Flamengo);
        CONMEBOL.EvaluarPuntuacion();

        Confederacion CONCACAF = new Confederacion("CONCACAF");
        CONCACAF.AgregarEquipo(ClubAmerica);
        CONCACAF.AgregarEquipo(Toronto);
        CONCACAF.EvaluarPuntuacion();



        FIFA fifa = new FIFA();
        fifa.AgregarGrupo(UEFA);
        fifa.AgregarGrupo(CONMEBOL);
        fifa.AgregarGrupo(CONCACAF);

        fifa.VerRankingEquipos();
        Console.WriteLine(" ");

        fifa.VerRankingGrupos();
        Console.WriteLine(" ");

        fifa.VerRankingTodos();
        Console.WriteLine(" ");

        CONMEBOL.CambiarEstrategiaCalculo(new CalculoPuntosSumaTotal());
        UEFA.CambiarEstrategiaCalculo(new CalculoPuntosPromedioCincoMejores());
        CONCACAF.CambiarEstrategiaCalculo(new CalculoPuntosPromedioCincoPeores());

        fifa.VerRankingGrupos();
        Console.WriteLine(" ");

        Console.WriteLine("Busquedas: ");

        List<Equipo> equiposFiltrados = fifa.BuscarEquipos(false, "Buenos Aires", true, true);

        foreach (var equipo in equiposFiltrados)
        {
            Console.WriteLine($"Nombre: {equipo.ObtenerNombre()} Ciudad: {equipo.ObtenerCiudad()} TitulosInternacionales: {equipo.ObtenerTitulosInternacionales()} Puntos: {equipo.ObtenerPuntos()} ");
        }

    }
}