namespace RPGd;

using System;
using System.Collections.Generic;
using ConsoleHelper;

public class FaseProfile
{
    public int id;
    public string chave;
    public bool isClear;
}

public static class Loot
{
    private static Random random = new Random();

    public static Arma GerarArmaAleatoria()
    {
        int roll = random.Next(1, 8);

        switch (roll)
        {
            case 1: return new Adaga();
            case 2: return new EspadaEnferrujada();
            case 3: return new EspadaReta();
            case 4: return new Machado();
            case 5: return new Arco();
            case 6: return new CaixaDeMarimbondo();
            case 7: return new Behelit();
            default: return new Nada();
        }
    }
}

public static class Fases
{
    private static int FaseId = 1;
    private static List<string> chavesPossuidas = new();
    private static List<FaseProfile> fasesStatus = new();

    static Fases()
    {
        for (int i = 1; i <= 5; i++)
        {
            fasesStatus.Add(new FaseProfile
            {
                id = i,
                chave = $"Chave{i}",
                isClear = false
            });
        }
    }

    // =========================
    // CHAVES
    // =========================
    private static void AddKey(string chave)
    {
        if (!chavesPossuidas.Contains(chave))
            chavesPossuidas.Add(chave);
    }

    private static void MarcarFase(string chave)
    {
        foreach (var f in fasesStatus)
        {
            if (f.chave == chave)
            {
                f.isClear = true;
                return;
            }
        }
    }

    // =========================
    // INVENTÁRIO
    // =========================
    public static void AbrirInventario()
    {
        Console.WriteLine("\n=== INVENTÁRIO ===");

        if (Player.InventarioArmas.Count == 0)
        {
            Console.WriteLine("Você não possui armas.");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < Player.InventarioArmas.Count; i++)
        {
            Console.WriteLine($"{i} - {Player.InventarioArmas[i].Nome}");
        }

        Console.WriteLine("\nEscolha a arma:");

        if (!int.TryParse(Console.ReadLine(), out int escolha))
            return;

        if (escolha >= 0 && escolha < Player.InventarioArmas.Count)
        {
            Player.Arma = Player.InventarioArmas[escolha];
            Console.WriteLine($"Equipou: {Player.Arma.Nome}");
        }

        Console.ReadKey();
    }

    // =========================
    // FINAL DA FASE
    // =========================
    private static void FinalizarFase()
    {
        Arma drop = Loot.GerarArmaAleatoria();

        Console.WriteLine("\nVocê encontrou:");
        Console.WriteLine(drop.Nome);
        Console.WriteLine(drop.Descrição);

        Player.InventarioArmas.Add(drop);
        Player.Arma = drop;

        // efeito especial
        if (drop is Behelit)
        {
            Console.WriteLine("Algo estranho pulsa na sua mão...");
            Player.VidaAtual -= 10;
        }

        if (Player.VidaAtual < 0)
            Player.VidaAtual = 0;

        Player.VidaAtual = Player.VidaMaxima;

        Console.ReadKey();
    }

    // =========================
    // LOOP DE MENU DA FASE
    // =========================
    private static void MenuFase()
    {
        bool menu = true;

        while (menu)
        {
            AllMenus.InterfaceList.Clear();
            AllMenus.InterfaceList.Add("Inventário");
            AllMenus.InterfaceList.Add("Continuar");

            AllMenus.LimparEInserir();

            var choice = AllMenus.Interface.ReadChoice(true);

            switch (choice.Value)
            {
                case "Inventário":
                    AbrirInventario();
                    break;

                case "Continuar":
                    menu = false;
                    break;
            }
        }
    }

    // =========================
    // EXECUTAR FASE
    // =========================
    private static void ExecutarFase(Monstro monstro, string chave, string ascii)
    {
        Combate.monstros.Clear();
        Combate.monstros.Add(monstro);

        Combate.CombatLoop();

        FinalizarFase();
        AddKey(chave);
        MarcarFase(chave);

        AllMenus.Interface._settings.IntroText = ascii;

        MenuFase();
    }

    // =========================
    // START
    // =========================
    public static void Start()
    {
        AllMenus.loop = true;

        switch (FaseId)
        {
            case 1:
                ExecutarFase(new Esqueleto(), "Chave1", @"                                                               
                               ██                ████            
                     ██          █          ██████               
                     ███       █████       ██   █             ██ 
         ████████████         ██   ███████ ██   ██      █   ████ 
      ███           ██ ██     █     █       █    █       █ ███   
    ██████           █   ██    █████         █████        ███    
         ███         █    █                                █     
           ██        █                   ███████          ██     
             █      █               █████      █████      █      
              █    ██         ██████               ████   █      
              ██ ███      ████                            █      
               ██      ████                               █      
               █     ██                                          
                                                                 ");
                break;

            case 2:
                ExecutarFase(new Goblin(), "Chave2", @"                                                               
                               ██                ████            
                     ██          █          ██████               
                     ███       █████       ██   █             ██ 
         ████████████         ██   ███████ ██   ██      █   ████ 
      ███           ██ ██     █     █       █    █       █ ███   
    ██████           █   ██    █████         █████        ███    
         ███         █    █                                █     
           ██        █                   ███████          ██     
             █      █               █████      █████      █      
              █    ██         ██████               ████   █      
              ██ ███      ████                            █      
               ██      ████                               █      
               █     ██                                          
                                                                 ");
                break;

            case 3:
                ExecutarFase(new Fantasma(), "Chave3", @"                                                               
                               ██                ████            
                     ██          █          ██████               
                     ███       █████       ██   █             ██ 
         ████████████         ██   ███████ ██   ██      █   ████ 
      ███           ██ ██     █     █       █    █       █ ███   
    ██████           █   ██    █████         █████        ███    
         ███         █    █                                █     
           ██        █                   ███████          ██     
             █      █               █████      █████      █      
              █    ██         ██████               ████   █      
              ██ ███      ████                            █      
               ██      ████                               █      
               █     ██                                          
                                                                 ");
                break;

            case 4:
                ExecutarFase(new Zood(), "Chave4", @"                                                               
                               ██                ████            
                     ██          █          ██████               
                     ███       █████       ██   █             ██ 
         ████████████         ██   ███████ ██   ██      █   ████ 
      ███           ██ ██     █     █       █    █       █ ███   
    ██████           █   ██    █████         █████        ███    
         ███         █    █                                █     
           ██        █                   ███████          ██     
             █      █               █████      █████      █      
              █    ██         ██████               ████   █      
              ██ ███      ████                            █      
               ██      ████                               █      
               █     ██                                          
                                                                 ");
                break;

            case 5:
                ExecutarFase(new Morte(), "Chave5", @"                                                               
                               ██                ████            
                     ██          █          ██████               
                     ███       █████       ██   █             ██ 
         ████████████         ██   ███████ ██   ██      █   ████ 
      ███           ██ ██     █     █       █    █       █ ███   
    ██████           █   ██    █████         █████        ███    
         ███         █    █                                █     
           ██        █                   ███████          ██     
             █      █               █████      █████      █      
              █    ██         ██████               ████   █      
              ██ ███      ████                            █      
               ██      ████                               █      
               █     ██                                          
                                                                 ");
                break;

            default:
                Console.WriteLine("Você venceu o jogo!");
                Console.ReadKey();
                Environment.Exit(0);
                break;
        }

        FaseId++;
    }
}