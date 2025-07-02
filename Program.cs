Menu();
void Menu()
{
    Console.Clear();
    Console.WriteLine("Bem vindo!");
    Console.WriteLine("[1] Acessar inventário");
    Console.WriteLine("[2] Acessar lojas");
    Console.WriteLine("[-1] Sair");
    Console.WriteLine("Digite uma opção: ");
    int opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            //MenuInventario();
            break;
        case 2:
            //MenuLojas();
            break;
        case -1:
            Console.Clear();
            Console.WriteLine("Até logo!");
            Console.WriteLine("Saindo...");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
