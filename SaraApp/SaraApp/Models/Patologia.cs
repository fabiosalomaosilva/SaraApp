using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaraApp.Models
{
    public class Patologia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Area> Areas { get; set; }
        public ICollection<Acao> Acoes { get; set; }
    }
}
