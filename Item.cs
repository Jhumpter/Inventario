
namespace Inventario
{
    internal class Item
    {
        public string Nome { get; }
        public float Preco { get; }
        internal Item(string name, float preco)
        {
            Nome = name;
            Preco = preco;
        }
    }
}
