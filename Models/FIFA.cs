namespace FIFA_Ranking.Models
{
    public class FIFA
    {
        private List<Grupo> _grupos;
        private List<Grupo> _rankingGrupos;
        private List<Equipo> _rankingEquipos;
        private List<Ranking> _rankingTodos;

        public FIFA()
        {
            this._grupos = new List<Grupo>();
            this._rankingGrupos = new List<Grupo>();
            this._rankingEquipos = new List<Equipo>();
            this._rankingTodos = new List<Ranking>();
        }

        public void AgregarGrupo(Grupo grupo)
        {
            this._grupos.Add(grupo);
        }

        public void ElaborarRankingGrupos()
        {
            this._rankingGrupos = this._grupos.OrderByDescending(g => g.ObtenerPuntos()).ToList();
        }

        public void ElaborarRankingEquipos()
        {

            this._rankingEquipos = this._grupos.SelectMany(grupo => grupo.ObtenerEquipos())
                                                .Distinct()
                                                .OrderByDescending(equipo => equipo.ObtenerPuntos())
                                                .ToList();
            
        }

        public void ElaborarRankingTodos()
        {
            if (this._rankingGrupos.Count == 0)
            {
                ElaborarRankingGrupos();
            }

            if (this._rankingEquipos.Count == 0) 
            {
                ElaborarRankingEquipos();
            }

            this._rankingTodos = (List<Ranking>)this._rankingTodos.Concat(this._rankingEquipos)
                                                                    .Concat(this._rankingGrupos)
                                                                    .OrderByDescending(ranking => ranking.ObtenerPuntos())
                                                                    .ToList();
        }

        public void VerRankingGrupos()
        {
            if(this._rankingGrupos.Count == 0)
            {
                ElaborarRankingGrupos();
            }

            int position = 1;
            foreach (var grupo in this._rankingGrupos)
            {
                Console.WriteLine($"{position}: Nombre: {grupo.ObtenerNombre()} Puntuación: {grupo.ObtenerPuntos()}");
                position++;
            }
        }

        public void VerRankingEquipos()
        {
            if(this._rankingEquipos.Count == 0)
            {
                ElaborarRankingEquipos();
            }

            int position = 1;
            foreach (var equipo in this._rankingEquipos)
            {
                Console.WriteLine($"{position}: Nombre: {equipo.ObtenerNombre()} Puntuación: {equipo.ObtenerPuntos()}");
                position++;
            }
        }

        public void VerRankingTodos()
        {
            if(this._rankingTodos.Count == 0)
            {
                ElaborarRankingTodos();
            }

            int position = 1;
            foreach (var item in this._rankingTodos)
            {
                Console.WriteLine($"{position}: Nombre: {item.ObtenerNombre()} Puntuación: {item.ObtenerPuntos()}");
                position++;
            }
        }
        public List<Equipo> BuscarEquipos(bool masDe17Jugadores, string ciudad, bool masDeUnTituloInternacional,  bool masDeDiezTitulosInternacionales)
        {
            var criterios = new Dictionary<string, Func<Equipo, bool>>();

            if (masDe17Jugadores) { criterios.Add("MasDe17Jugadores", equipo => equipo.ObtenerNumeroJugadores() > 17); }
            if (ciudad != null) { criterios.Add($"Ciudad {ciudad}", equipo => equipo.ObtenerCiudad() == ciudad); }
            if (masDeUnTituloInternacional) { criterios.Add("MasDeUnTituloInternacional", equipo => equipo.ObtenerTitulosInternacionales() > 1);  }
            if (masDeUnTituloInternacional) { criterios.Add("MasDeDiezTitulosInternacionales", equipo => equipo.ObtenerTitulosInternacionales() > 10); }

            if(this._rankingEquipos.Count == 0)
            {
                ElaborarRankingEquipos();
            }

            List<Equipo> equiposFiltrados = this._rankingEquipos.Where(equipo =>
            {
                bool cumpleCriterios = true;
                foreach (var criterio in criterios)
                {
                    if (criterio.Value != null && !criterio.Value(equipo))
                    {
                        cumpleCriterios = false;
                        break;
                    }
                }
                return cumpleCriterios;
            }).ToList();

            return equiposFiltrados;
        }
    }
}
