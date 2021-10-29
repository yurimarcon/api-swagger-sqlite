namespace api_Sqlite.Models
{
    public class Pessoa
    {
        public Pessoa(int id, string nome, int idade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}