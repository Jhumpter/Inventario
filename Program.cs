MenuPrincipal();
void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("Bem vindo!");
    Console.WriteLine("[1] Acessar inventário");
    Console.WriteLine("[2] Acessar lojas");
    Console.WriteLine("[-1] Sair");
    Console.WriteLine("Digite uma opção: ");
    int opcao = 0;
    do
    {
        opcao = int.Parse(Console.ReadLine()!);
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
    /*Console.Clear();
    //MostrarItens();
    Console.WriteLine("[1] Vender item");
    Console.WriteLine("[2] Excluir item");
    Console.WriteLine("[3] Voltar ao menu principal");
    Console.WriteLine("Digite uma opção: ");
    int opcao = 0;
    do
    {
        opcao = int.Parse(Console.ReadLine()!);
        switch (opcao)
        {
            case 1:
                //VenderItem();
                break;
            case 2:
                //ExcluirItem();
                break;
            case 3:
                MenuPrincipal();
                break;
            default:
                opcao = 0;
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    } while (opcao == 0);*/
    Console.Clear();
    Console.WriteLine("Inventário ainda não implementado.");
    Thread.Sleep(2000);
    MenuPrincipal();
}

void MenuLojas()
{
    Console.Clear();
    Console.WriteLine("Lojas ainda não implementadas.");
    Thread.Sleep(2000);
    MenuPrincipal();
}