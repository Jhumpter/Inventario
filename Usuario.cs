
namespace Inventario
{
    internal class Usuario
    {
        private float dinheiro;
        internal float Dinheiro => dinheiro;
        internal string Nome { get; set; }
        internal List<Item> Inventario { get; }
        internal Usuario(float dinheiro, string nome, List<Item> inventario)
        {
            this.dinheiro = dinheiro;
            Nome = nome;
            Inventario = inventario;
        }
        private void SetDinheiro(float dinheiro)
        {
            this.dinheiro += dinheiro;
        }
        internal Item VenderItem(int id)
        {
            Item itemVendido = Inventario[id];
            Inventario.Remove(Inventario[id]);
            SetDinheiro(itemVendido.Preco);
            return itemVendido;
        }
        internal Item ExcluirItem(int id)
        {
            Item itemExcluido = Inventario[id];
            Inventario.Remove(Inventario[id]);
            return itemExcluido;
        }
    }
}
