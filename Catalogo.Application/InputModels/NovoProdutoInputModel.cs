namespace Catalogo.Application.InputModels
{
    public class NovoProdutoInputModel
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }

        public NovoProdutoInputModel()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
