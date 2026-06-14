namespace RPGd;
//ATENÇÃO: Se você quiser colaborar com esta parte do código criando fases, consulte o Templates.txt
//e siga as linhas com a palabra chave [COLABORADOR].
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
        //PEGA UM NÚMERO ALEATÓRIO
        int i=random.Next(0,1);

        //VERIFICA SE ESSA SALA JÁ FOI COMPLETADA
        foreach(FaseProfile fase in fasesStatus)
        {   
            //CONFIRMA QUE É A FASE CERTA PELO ID
            if(fase.id == i)
            {
                //VERIFICA SE A FASE JÁ ESTÁ COMPLETA
                if(fase.isClear !=true)
                FaseId=i;

            }
        }
        AllMenus.loop = false;
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
            //CONCLUIR A SALA RECOMPENSA O JOGADOR COM EXPERIÊNCIA (PROGRESSÃO DE NÍVEL)
            Player.GanharExperiencia(50);
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
                    string chave = "Chave1";
                    while (AllMenus.loop == true)
                    {
                        //MUDA A ARTE DO BANNER ASCII
                        AllMenus.Interface._settings.IntroText=@"
                                                                 
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
                                                                 ";

                        //1.Limpo as opções da lista do menu
                        AllMenus.InterfaceList.Clear();

                        //2.Encho a lista com as opções
                        AllMenus.InterfaceList.Add("Graffiti");
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
                                case "Graffiti":
                                    {
                                        Console.WriteLine("Um graffiti na parede, o que Diddy significa?");
                                        System.Console.WriteLine("Olha, uma porta...");
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
        }
        
    }
    
}