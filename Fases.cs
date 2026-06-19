namespace RPGd;
//ATENÇÃO: Se você quiser colaborar com esta parte do código criando fases, consulte o Templates.txt
//e siga as linhas com a palavra chave [COLABORADOR].
using System.Data.Common;
using System.Runtime.CompilerServices;
using ConsoleHelper;
//CLASSE QUE CONTÉM INFORMAÇÕES DE UMA FASE
public class FaseProfile
{
    public int id;
    public string chave;
    public bool isClear;
}
static public class Fases
{
    static private bool ChecarTodasConcluidas()
    {
        foreach (FaseProfile fase in fasesStatus)
        {
            // Se encontrar QUALQUER fase que ainda NÃO foi limpa, retorna falso
            if (fase.isClear == false)
            {
                return false; 
            }
        }
        // Se o loop terminou e não achou nenhuma pendente
        return true;
    }
    static private bool Combate1 =true;
    static private bool Combate2 =true;
    static private bool Combate3 =true;
    static private int FaseId = 0;
    static private List<string> chavesPossuídas = new List<string>();
    static private List<FaseProfile> fasesStatus= new List<FaseProfile>();
    private static Random random = new Random();

    //CONSTRUTOR
    static Fases()
    {
        //LISTA DE FASES - STATUS [COLABORADOR 1]
        fasesStatus.Add(new FaseProfile
        {
            id=1,
            chave = "Chave1"
        });
        fasesStatus.Add(new FaseProfile
        {
            id=2,
            chave = "Chave2"
        });
        fasesStatus.Add(new FaseProfile
        {
            id=3,
            chave = "Chave3"
        });
        
    }

    //ADICIONA A CHAVE NAS CHAVES POSSUÍDAS
    static private void AddKey(string chave)
    {
        //VERIFICA SE A CHAVE JÁ EXISTE NA LISTA
        if (!chavesPossuídas.Contains(chave))
        {
            chavesPossuídas.Add(chave);
        }
        else
        System.Console.WriteLine("Eu já sabia...");
    }
    static private void GenerateRoom()
    {
        if (ChecarTodasConcluidas())
        {
            AllMenus.loop = false;
            System.Console.WriteLine("PARABENS! VOCÊ VENCEU TODAS AS FASES!!!");            
        }

        else
        {
        // PEGA UM NÚMERO ALEATÓRIO ENTRE 1 E 3
        int i = random.Next(1, 4);

        // VERIFICA SE ESSA SALA JÁ FOI COMPLETADA
        foreach(FaseProfile fase in fasesStatus)
        {   
            if(fase.id == i)
            {
                // SE NÃO ESTIVER COMPLETA, MUDA A SALA
                if(fase.isClear != true)
                {
                    FaseId = i;
                }
                else
                {
                    // Se a sala sorteada já foi limpa, chama a função de novo para sortear outra
                    GenerateRoom();
                    return;
                }
            }
        }
        AllMenus.loop = false;
        }
        
    }

    static private void NextRoom(string chave)
    {
        if (chavesPossuídas.Contains(chave))
        {
            System.Console.WriteLine("Ok.. hora de sair daqui...");
            //VASCULHA A TAL FASE E MARCA COMO CONCLUÍDA
            foreach(FaseProfile fase in fasesStatus)
            {
                if(fase.chave==chave)
                fase.isClear=true;
            }
            Console.ReadKey();
        }
        else
        {
            System.Console.WriteLine("Não tem saída.");
            Console.ReadKey();
        }
    }

    //LISTA DE FASES
    public static void Start()
    {   
        if(FaseId == 0)
            FaseId = 1;
        //LOOP RESETADO
        AllMenus.loop=true;

        //SWITCH DAS FASES - LISTA [COLABORADOR 2]
        switch (FaseId)
        {
            //A PRIMEIRA SALA
            case 1:
                {
                    System.Console.WriteLine();
                    if(Combate1){
                    Combate.monstros.Add(new Esqueleto());
                    Combate.CombatLoop();
                    Player.Inventário.Add(new CaixaDeMarimbondo());
                    Combate1=false;
                    }
                    string chave = "Chave1";
                    while (AllMenus.loop == true)
                    {
                        //MUDA A ARTE DO BANNER ASCII
                        AllMenus.Interface._settings.IntroText=@"
█████████████████████████████████████████████
█▀▄▄▄▄ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒█   █
█    ▀▄▄▄▄   ▒░░░░░░░░░░░░░░░░░░░░▒░░░▒▄▀   █
█        ▀▄▄▄░░░░░░░░░▒░░░░░░░░░░░░░░▒▄▀ ░  █
█            ▀▄▄░░░░░░░░░░░░░░░░░░░░░▄▀  ░░ █
█     ░   ░░   ▀▄▄▓▓▓░░░▓░░░▓▓▓▓▓▓▓▓▄▀  ░░░ █
█    ░░░░ ░░░░    ▀▄▄▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▀  ░░░░ █
█    ░░░░░░░░░░      ▀▄▄▄ ▓▓▓▓▓▓▓▓▓█  ░░ ░░ █
█    ░░ ░░░░░░░░░░      ▀▄▄▄▄▄▄▄▄▄▀▀ ░░░ ░░ █
█   ░░░░░░░░░░░░░░        █░▓▓▓▓▓▓▄  ░░░░░  █
█  ░░ ░ ░░░ ░░ ░░░░░░░░  █░▓▓▓▓▓▒▒█░░░░░ ░  █
█░░░ ░ ░ ░  ░     ░░░░   ▄▓▓▓▒▒▒▒█ ░░░░░░░░ █
█░░ ░░ ░ ░  ░      ▄▄▄▄▄▄ █░▄░░▄█    ░░ ░░░ █
█   ░ ░░     ▄▄▄▀▀▀▓▓▓▓▓▄▄▀      ▀▄▄  ░  ░░ █
█   ░    ▄▄█▀▓▓▓▓▓▓▓▓▄▄▄▀    ░  ░  ▀▄▄▄  ░░ █
█       █▀▓▓▓▓▓▓▓▓▄▄▀      ░   ░░      █  ░ █
█    █▀▀▓▓▓▓▓▓▓▄▄▄▀░       ░            ▀▄░ █
█  █▀▓▓▓▓▓▓▓▓▄▀     ░  ░    ░░    ░ ░    ▀▄ █
█▀▀▓▓▓▓▓▓▓▓▓▄▀   ░                        ▀▄█
█████████████████████████████████████████████
                                                                 ";

                        //1.Limpo as opções da lista do menu
                        AllMenus.InterfaceList.Clear();

                        //2.Encho a lista com as opções
                        AllMenus.InterfaceList.Add("Alçapão");
                        AllMenus.InterfaceList.Add("Sair da Sala");
                        

                        //3.Limpo o menu e lanço a nova lista nele
                        AllMenus.LimparEInserir();

                        //Adiciono a opção de voltar
                         AllMenus.Interface.Options.Add(new MenuItem
                        {
                            Title= "Voltar",
                            Value= "Voltar"
                        });
                        
                        //OPÇÃO É SELECIONADA
                        var choiceINV = AllMenus.Interface.ReadChoice(true);
                        if(choiceINV.Value == "Voltar")
                        {
                            AllMenus.loop = false;
                        }
                        else
                        {
                            switch (choiceINV.Value)
                            {
                                case "Alçapão":
                                    {
                                        Console.WriteLine("Você fica prentes a pular em um alçapão no chão, ele está escancarado...");
                                        System.Console.WriteLine("Devo pular...?");
                                        //[COLABORADOR 3]
                                        AddKey(chave);
                                        Console.ReadKey(true);
                                    }
                                break;
                                case "Sair da Sala":
                                    {
                                        //[COLABORADOR 3]
                                        NextRoom(chave);
                                        //[COLABORADOR 3]
                                        GenerateRoom();
                                    }
                                break;
                            }
                        }                        

                    }
                }
            break;
            case 2:
                {
                    {
                    System.Console.WriteLine();
                    // Adiciona um monstro diferente (ajuste para um que exista no seu jogo)
                    if(Combate2){
                    Combate.monstros.Add(new Goblin("Goblin")); 
                    Combate.monstros.Add(new Goblin("Goblin 2")); 
                    Combate.CombatLoop();
                    Combate2=false;
                    Player.Inventário.Add(new EspadaReta());
                    }
                    string chave = "Chave2";
                    while (AllMenus.loop == true)
                    {
                        AllMenus.Interface._settings.IntroText = @"
█████████████████████████████████████████████
█      ▒ ▒▒ ▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒       █
█   ▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒▒ ▒▒▒▒ ▓▓▓▓        █
█  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒                   ▓▓▓     █
█   ▒▒▒▒▒▒▒▒▒                          ▓▓▓  █
█    ▒▒      ▄▄▄▄▄            ▄▄▄▄▄▄▄▄   ▓▓ █
█ ▒▒▒▒  ▄▄▄▄▄▀    ▀▄▄       ▄▀▄       ▀▄    █
█      ▄▀            ▄    ▄▄▀         ▀█    █
█    ▄▀              ▄▄  ▄▀   ▄▄▄▄ ▄▄▄ ██   █
█ █▄ ▀    ▄▄▄▄▄▄▄▄▄   ▄▄▄   ▄▄▀         █   █
█ ███   ▄▄▀            █                ██  █
█  ██     ▄▄▄ ▄▄▄▄     █     ▄▄▄▄▄▄▄▄▄   ██ █
█  ██    ▀             █   ▄▀▀        ▄   █ █
█ ▓ ██   ▄  ▄▄▄▄▄▄▄▄▄  █ ▄▄   ▄▄▄▄▄▄▄▀ ▄▄▄███
█▓▓  ██   ▀▀▄  ▄▄▄▄ ▀▄ █▄   ▄▄▀          ▄▄██
█▓▓▓ ███▄▄    ▄▄▀  ▄  ██  ▄▄▄▄▄▄▄▄█████████ █
█ ▓▓▓ ████████████████████████████████▀▀  ▓▓█
█▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ █
█   ▒▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ █
█████████████████████████████████████████████";

                        AllMenus.InterfaceList.Clear();
                        AllMenus.InterfaceList.Add("Vasculhar Estante");
                        AllMenus.InterfaceList.Add("Sair da Sala");
                        
                        AllMenus.LimparEInserir();

                        AllMenus.Interface.Options.Add(new MenuItem
                        {
                            Title = "Voltar",
                            Value = "Voltar"
                        });
                        
                        var choiceINV = AllMenus.Interface.ReadChoice(true);
                        if(choiceINV.Value == "Voltar")
                        {
                            AllMenus.loop = false;
                        }
                        else
                        {
                            switch (choiceINV.Value)
                            {
                                case "Vasculhar Estante":
                                    {
                                        Console.WriteLine("Você mexe nos livros velhos e encontra uma chave brilhante caída atrás de um tomo.");
                                        AddKey(chave);
                                        Console.ReadKey(true);
                                    }
                                break;
                                case "Sair da Sala":
                                    {
                                        NextRoom(chave);
                                        GenerateRoom();
                                    }
                                break;
                            }
                        }                        
                    }
                }
                }
            break;
            case 3:
                {
                    {
                    System.Console.WriteLine();
                    if(Combate3){
                    Combate.monstros.Add(new Zood()); 
                    Combate.CombatLoop();
                    Combate3 = false;
                    Player.Inventário.Add(new Behelit());
                    }
                    string chave = "Chave3";
                    while (AllMenus.loop == true)
                    {
                        AllMenus.Interface._settings.IntroText = @"
█████████████████████████████████████████████
█      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒              █
█ █         ▒▒▒▒▒▒▒▒▒▒▒▒         █   █      █
█              ▒▒▒▒▒▒         █     █       █
█    █           ▒▒▒ ▄▄▄▄            ▄▄▄▄████
█    ██         ▄ ▄▄▄▄ ▄     ▄▄▄▄▄▄▄▄▄▓▓▓▓▓▓█
█  █            ▄▄▄    ▄▄▄▄▄▄▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█            ▄▄▓▓█ ░░░░░ █▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█       ▄▄▄▄▄ ▓▓▓█░░░░░░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
██▄▄▄▄▄▄▄    ▓▓▓██ ░░░░   █▄▄▄▄▄▄▄▄▒▓▓▓▓▓▓▓▓█
█▒▒▒▒▒▒▒▓▓▓▓▓▓▓██ ░░░░░░░░░░░░░░ ▄█▓▓▓▓▓▓▓▓▓█
█▒▒▓▓▓▓▓▓▓▓▓▓▓██░░░░░░░░░░░░░░░ ▄█▓▓▓▓▓▓▓▓▓▓█
█▒▓▓▓▓▓▓▓▓▓▓██░░░ ░░░░░░░░░░░░ ▄█▓▓▓▓▓▓▓▓▓▓▓█
█▒▓▓▓▓▓▓▓▓▓▓█  ░░░░░░░ ░░░░  ▄█▓▓▓▓▓▓▓▓▓▓▓▓▓█
█▒▓▓▓▓▓▓▓▓▓▓█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█████████████████████████████████████████████";

                        AllMenus.InterfaceList.Clear();
                        AllMenus.InterfaceList.Add("Abrir Baú de Ferro");
                        AllMenus.InterfaceList.Add("Sair da Sala");
                        
                        AllMenus.LimparEInserir();

                        AllMenus.Interface.Options.Add(new MenuItem
                        {
                            Title = "Voltar",
                            Value = "Voltar"
                        });
                        
                        var choiceINV = AllMenus.Interface.ReadChoice(true);
                        if(choiceINV.Value == "Voltar")
                        {
                            AllMenus.loop = false;
                        }
                        else
                        {
                            switch (choiceINV.Value)
                            {
                                case "Abrir Baú de Ferro":
                                    {
                                        Console.WriteLine("O baú range ao abrir. Dentro dele, envolta em veludo, está a chave da saída.");
                                        AddKey(chave);
                                        Console.ReadKey(true);
                                    }
                                break;
                                case "Sair da Sala":
                                    {
                                        NextRoom(chave);
                                        GenerateRoom();
                                    }
                                break;
                            }
                        }                        
                    }
                }
                }
            break;
        }
        
    }
    
}