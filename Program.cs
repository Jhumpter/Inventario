using Inventario;

Console.WriteLine("Digite seu nome: ");
string nome = Console.ReadLine();

//Inicializando o inventário
Item calca = new Item("Calça Jeans", 79.90f);
Item blusa = new Item("Blusa de Frio", 99.90f);
Item sandalia = new Item("Havaiana", 49.90f);
Item oculos = new Item("Óculos de Sol", 199.90f);
Item shorts = new Item("Short Jeans", 59.90f);
Item camiseta = new Item("Camiseta Básica", 39.90f);
Item camisa = new Item("Camisa Social", 89.90f);
Item tenis = new Item("Tênis Esportivo", 299.90f);
Item jaqueta = new Item("Jaqueta de Couro", 399.90f);
Item vestido = new Item("Vestido Floral", 129.90f);
Item saia = new Item("Saia Midi", 79.90f);
Item blusaDeBanho = new Item("Blusa de Banho", 59.90f);
Item bolsa = new Item("Bolsa de Couro", 249.90f);
Item mochila = new Item("Mochila Escolar", 89.90f);

// Adicionando itens ao inventário
List<Item> inventario = new List<Item>();

//Inicializando o usuário
Usuario usuario = new Usuario(500, nome, inventario);

//Inicializando as lojas
List<Loja> lojas = new List<Loja>();
Loja tenner = new Loja("Tenner", [sandalia,tenis]);
lojas.Add(tenner);
Loja avivas = new Loja("Avivas", [oculos,bolsa,mochila]);
lojas.Add(avivas);
Loja like = new Loja("Like", [blusa,shorts,camiseta,camisa,jaqueta,vestido,saia,blusaDeBanho]);
lojas.Add(like);

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
    if (usuario.Inventario.Count != 0)
    {
        Console.WriteLine("[1] Vender item");
        Console.WriteLine("[2] Excluir item");
    }
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
    else
    {
        Console.WriteLine("Seu inventário está vazio.");
    }
}

void VenderItem()
{
    Console.Clear();
    MostrarItens();
    Console.WriteLine("Digite o ID do item que deseja vender (-1 para cancelar): ");
    int idItem = -1;
    try
    {
        idItem = int.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        ExcluirItem();
    }
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
    else if (idItem == -1)
    {
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
    MostrarItens();
    Console.WriteLine("Digite o ID do item que deseja jogar fora (-1 para cancelar): ");
    int idItem = -1;
    try
    {
        idItem = int.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        ExcluirItem();
    }
    if (inventario.Count > idItem && idItem >= 0)
    {
        Console.WriteLine("Tem certeza que quer excluir este item? (S/N)");
        string confirmacao = Console.ReadLine().ToUpper();
        if (confirmacao != "S")
        {
            ExcluirItem();
        }
        Console.WriteLine($"Você jogou {usuario.ExcluirItem(idItem).Nome} fora.");
        Thread.Sleep(2000);
        MenuInventario();
    }
    else if (idItem == -1)
    {
        MenuInventario();
    }
    else
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        ExcluirItem();
    }
}

void MenuLojas()
{
    Console.Clear();
    MostrarLojas();
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
            opcao = -2;
        }
        if (opcao == -1)
        {
            MenuPrincipal();
        }
        else if (opcao >= 0 && opcao < lojas.Count)
        {
            Loja lojaSelecionada = lojas[opcao];
            EntrarLoja(lojaSelecionada);
        }
        else
        {
            opcao = -2;
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    } while (opcao == -2);
}

void MostrarLojas()
{

    if (lojas.Count != 0)
    {
        foreach (Loja loja in lojas)
        {
            Console.WriteLine("[{0}] - {1}",lojas.IndexOf(loja),loja.Nome);
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Não há lojas disponíveis.");
    }
}

void EntrarLoja(Loja loja)
{
    Console.Clear();
    Console.WriteLine($"Bem vindo à {loja.Nome}!");
    Console.WriteLine("Estes são os itens disponíveis:");
    if (loja.Produtos.Count != 0)
    {
        foreach (Item item in loja.Produtos)
        {
            Console.WriteLine("ID:{0,-3}| Item:{1,-30}| {2:c}", loja.Produtos.IndexOf(item), item.Nome, item.Preco);
        }
        Console.WriteLine();
        Console.WriteLine("[1] Comprar item");
    }
    else
    {
        Console.WriteLine("Não há itens disponíveis nesta loja.");
    }
    Console.WriteLine("[2] Voltar ao menu de lojas");
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
                ComprarItem(loja);
                break;
            case 2:
                MenuLojas();
                break;
            default:
                opcao = 0;
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao == 0);
}

void ComprarItem(Loja loja)
{
    Console.Clear();
    MostrarItensLoja(loja);
    Console.WriteLine("Digite o ID do item que deseja comprar (-1 para cancelar): ");
    int idItem = -1;
    try
    {
        idItem = int.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        ExcluirItem();
    }
    if (loja.Produtos.Count > idItem && idItem >= 0)
    {
        Console.WriteLine("Tem certeza que quer comprar este item? (S/N)");
        string confirmacao = Console.ReadLine().ToUpper();
        if (confirmacao != "S")
        {
            ComprarItem(loja);
        }
        usuario.ComprarItem(loja.Produtos[idItem]);
        Thread.Sleep(2000);
        EntrarLoja(loja);
    }
    else if (idItem == -1)
    {
        EntrarLoja(loja);
    }
    else
    {
        Console.WriteLine("ID inválido. Tente novamente.");
        Thread.Sleep(2000);
        ComprarItem(loja);
    }
}

void MostrarItensLoja(Loja loja)
{
    if (loja.Produtos.Count != 0)
    {
        foreach (Item item in loja.Produtos)
        {
            Console.WriteLine("ID:{0,-3}| Item:{1,-30}| {2:c}", loja.Produtos.IndexOf(item), item.Nome, item.Preco);
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("A loja está fechada.");
    }
}