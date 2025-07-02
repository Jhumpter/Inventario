using Inventario;

Console.WriteLine("Digite seu nome: ");
string nome = Console.ReadLine();
Item calca = new Item("Calça Jeans", 79.90f);
Item blusa = new Item("Blusa de Frio", 99.90f);
Item sandalia = new Item("Havaiana", 49.90f);
Item oculos = new Item("Óculos de Sol", 199.90f);
List<Item> inventario = new List<Item>();
inventario.Add(calca);
inventario.Add(blusa);
inventario.Add(sandalia);
inventario.Add(oculos);
Usuario usuario = new Usuario(1000, nome, inventario);
List<Loja> lojas = new List<Loja>();
Loja renner = new Loja("Renner", []);

MenuPrincipal();
void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine($"Bem vindo {usuario.Nome}!");
    Console.WriteLine($"Banco: {usuario.Dinheiro:c}");
    Console.WriteLine("[1] Acessar inventário");
    Console.WriteLine("[2] Acessar lojas");
    Console.WriteLine("[-1] Sair");
    Console.WriteLine("Digite uma opção: ");
    int opcao;
    do
    {
        try
        {
            opcao = int.Parse(Console.ReadLine()!);
        }
        catch
        {
            opcao = 0;
        }
        switch (opcao)
        {
            case 1:
                MenuInventario();
                break;
            case 2:
                MenuLojas();
                break;
            case -1:
                Console.Clear();
                Console.WriteLine("Até logo!");
                Thread.Sleep(2000);
                Console.WriteLine("Saindo...");
                Thread.Sleep(1000);
                return;
            default:
                opcao = 0;
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao == 0);
}

void MenuInventario()
{
    Console.Clear();
    MostrarItens();
    Console.WriteLine("[1] Vender item");
    Console.WriteLine("[2] Excluir item");
    Console.WriteLine("[3] Voltar ao menu principal");
    Console.WriteLine("Digite uma opção: ");
    int opcao;
    do
    {
        try
        {
            opcao = int.Parse(Console.ReadLine()!);
        }
        catch
        {
            opcao = 0;
        }
        switch (opcao)
        {
            case 1:
                VenderItem();
                break;
            case 2:
                ExcluirItem();
                break;
            case 3:
                MenuPrincipal();
                break;
            default:
                opcao = 0;
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao == 0);
}

void MostrarItens()
{
    if(usuario.Inventario.Count != 0)
    {
        Console.WriteLine($"Inventário de {usuario.Nome}:");
        Console.WriteLine($"Banco: {usuario.Dinheiro:c}");
        Console.WriteLine();
        foreach (Item item in usuario.Inventario)
        {
            Console.WriteLine("ID:{0,-3}| Item:{1,-30}| {2:c}", inventario.IndexOf(item), item.Nome, item.Preco);
        }
        Console.WriteLine();
    }
    
}

void VenderItem()
{
    Console.Clear();
    MostrarItens();
    Console.WriteLine("Digite o ID do item que deseja vender: ");
    int idItem = int.Parse(Console.ReadLine());
    if (inventario.Count>idItem && idItem>=0)
    {
        Console.WriteLine("Tem certeza que quer vender este item? (S/N)");
        string confirmacao = Console.ReadLine().ToUpper();
        if (confirmacao != "S")
        {
            VenderItem();
        }
        Console.WriteLine($"Você vendeu {usuario.Inventario[idItem].Nome} por {usuario.Inventario[idItem].Preco:c}.");
        usuario.VenderItem(idItem);
        Thread.Sleep(2000);
        MenuInventario();
    }
    else
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        VenderItem();
    }
}

void ExcluirItem()
{
    Console.Clear();
    Console.WriteLine("Ainda não implementado.");
    Thread.Sleep(2000);
    MenuInventario();
}

void MenuLojas()
{
    Console.Clear();
    //MostrarLojas();
    Console.WriteLine("Digite o ID da loja que quer visitar ou digite [-1] para voltar para o menu principal:");
    int opcao;
    do
    {
        try
        {
            opcao = int.Parse(Console.ReadLine()!);
        }
        catch
        {
            opcao = 0;
        }
        switch (opcao)
        {
            case -1:
                MenuPrincipal();
                break;
            default:
                opcao = 0;
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao == 0);
}