namespace RPGd;
using ConsoleHelper;

public static class MenuRaca
{
    public static void SelecionarRaca()
    {
        bool selecionando = true;
        
        while (selecionando)
        {
            System.Console.Clear();
            System.Console.WriteLine(@"
╔═══════════════════════════════════════════════╗
║     ESCOLHA SUA RAÇA / CLASSE                 ║
╚═══════════════════════════════════════════════╝
");
            
            // cria menu de seleção
            AllMenus.InterfaceList.Clear();
            AllMenus.InterfaceList.Add("Mago");
            AllMenus.InterfaceList.Add("Cavaleiro");
            AllMenus.InterfaceList.Add("Necromante");
            AllMenus.InterfaceList.Add("Goblin");
            
            AllMenus.LimparEInserir();
            
            var escolha = AllMenus.Interface.ReadChoice(true);
            
            TipoRaca racaSelecionada = escolha.Value switch // se quiser adicionar mais aqui diddy⬇️
            {
                "Mago" => TipoRaca.Mago,
                "Cavaleiro" => TipoRaca.Cavaleiro,
                "Necromante" => TipoRaca.Necromante,
                "Goblin" => TipoRaca.Goblin,
            
            };
            
            
            // Exibe descrição da raça
            Racas.ExibirDescricaoRaca(racaSelecionada);
            
            // Confirma seleção
            System.Console.Clear();
            System.Console.WriteLine($"\nDeseja ser um {Racas.ObterRaca(racaSelecionada).Nome}?");
            
            AllMenus.InterfaceList.Clear();
            AllMenus.InterfaceList.Add("Sim");
            AllMenus.InterfaceList.Add("Não (escolher outra)");
            
            AllMenus.LimparEInserir();
            
            var confirmacao = AllMenus.Interface.ReadChoice(true);
            
            if (confirmacao.Value == "Sim")
            {
                Player.InicializarComRaca(racaSelecionada);
                selecionando = false;
                
                System.Console.Clear();
                System.Console.WriteLine($"\n✓ Você é agora um(a) {Racas.ObterRaca(racaSelecionada).Nome} Boa sorte!\n");
                System.Console.WriteLine("Pressione qualquer tecla para continuar...");
                System.Console.ReadKey(true);
            }
        }
    }
}
