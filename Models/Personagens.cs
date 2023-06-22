namespace api_death_note.Models
{
    public class Personagens
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Alterego { get; set; }
        public string? Ocupacao { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemPersonagem { get; set; } 
        public int? Idade { get; set; }
        public int? PrimeiroEp { get; set; }
        public int? UltimoEp { get; set; }
    }
}