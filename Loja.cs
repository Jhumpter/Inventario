namespace Inventario
{
    internal class Loja
    {
        internal string Nome { get; }
        internal List<Item> Produtos { get; }
        internal Loja(string Nome,List<Item> Produtos)
        {
            this.Nome = Nome;
            this.Produtos = Produtos;
        }
    }
}
