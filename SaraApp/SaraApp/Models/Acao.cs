namespace SaraApp.Models
{
    public class Acao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Recomendacao { get; set; }
        public int AreaID { get; set; }
        public Area Area { get; set; }
    }
}