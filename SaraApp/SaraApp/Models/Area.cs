using System.Collections.Generic;

namespace SaraApp.Models
{
    public class Area
    {
        public Area()
        {
            Acoes = new HashSet<Acao>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PatologiaID { get; set; }
        public Patologia Patologia { get; set; }

        public ICollection<Acao> Acoes { get; set; }
    }
}