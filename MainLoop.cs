namespace RPGd;
using ConsoleHelper;
class Program
{
//LEGENDA:
//C - Comentário

    static void Main(string[] args)
    {
        
        //inicia e escolhe a raça do jogador
        AllMenus.Interface._settings.IntroText=@"
                                                                                 
                   █████████████                  
               ████            ███                
             ███                 ██████           
            ██                   ██   ██          
           ██             ███████ ██   ██         
          ██            ███        ██   █         
          █           ███           █    █        
          ████████████              ██   ██       
        █████  █████                 ██   █       
        █       ██     RPGD            █   ██      
        █                            ██    ██     
        ██                         ██████████     
         ███                 ███████              
            █████████████████                     
                                                  
         Bem-vindo ao RPGd! Antes de começar, escolha sua raça/classe!                                
          ";
        
        
        
    
        if (Player.DadosRaca == null)
        {
            MenuRaca.SelecionarRaca();
        }

        //LOOP PRINCIPAL (NEUTRO)
        while(true)
        {   
            //RESET DE CHAVES BOOLEANAS
            AllMenus.loop=true;

            AllMenus.Interface._settings.IntroText=@"
                                                                                 
                   █████████████                  
               ████            ███                
             ███                 ██████           
            ██                   ██   ██          
           ██             ███████ ██   ██         
          ██            ███        ██   █         
          █           ███           █    █        
          ████████████              ██   ██       
        █████  █████                 ██   █       
        █       ██  RPGD               █   ██      
        █                            ██    ██     
        ██                         ██████████     
         ███                 ███████              
            █████████████████                     
                                                  
                                                  ";
            {
                
            }

            //MENU PRINCIPAL
            //1.Limpo as opções da lista do menu
            AllMenus.InterfaceList.Clear();

            //2.Encho a lista com os itens
            AllMenus.InterfaceList.Add("Inventário");
            AllMenus.InterfaceList.Add("Equipamento");
            AllMenus.InterfaceList.Add("Status");
            AllMenus.InterfaceList.Add("Sala");

            //3.Limpo o menu e lanço a nova lista nele
            AllMenus.LimparEInserir();

            //Menu lançado
            var choice = AllMenus.Interface.ReadChoice(true);
            switch (choice.Value)
            {
                //INVENTÁRIO
                case "Inventário":
                while(AllMenus.loop==true)
                {
                    {   //1.Limpo as opções da lista do menu
                        AllMenus.InterfaceList.Clear();

                        //2.Encho a lista com os itens
                        foreach(ObjetoFísico item in Player.Inventário)
                        AllMenus.InterfaceList.Add(item.Nome);

                        //3.Limpo o menu e lanço a nova lista nele
                        AllMenus.LimparEInserir();
                    
                        //INVENTÁRIO - SAÍDA
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
                                Itens.BuscarEDescreverEquipamento(choiceINV.Value);
                            }
                    }
                }
                break;
                //EQUIPAMENTO
                case "Equipamento":
                while(AllMenus.loop==true)
                    {   //Arma armadura voltar
                        //1.Limpo as opções da lista do menu
                        AllMenus.InterfaceList.Clear();

                        //2.Encho a lista com as opções
                        AllMenus.InterfaceList.Add("Arma");
                        AllMenus.InterfaceList.Add("Armadura");


                        //3.Limpo o menu e lanço a nova lista nele
                        AllMenus.LimparEInserir();

                        //Adiciono a opção de voltar
                         AllMenus.Interface.Options.Add(new MenuItem
                        {
                            Title= "Voltar",
                            Value= "Voltar"
                        });

                        //EQUIPAMENTO
                        var choiceEquip = AllMenus.Interface.ReadChoice(true); 
                        if(choiceEquip.Value == "Voltar")
                        {
                            AllMenus.loop = false;
                        }
                        switch(choiceEquip.Value)
                        {
                            case "Arma":
                                {
                                    //1.Limpo a lista de opções
                                    AllMenus.InterfaceList.Clear();

                                    //Adiciono as opções de equipamento já existentes à lista:
                                    foreach(ObjetoFísico item in Player.Inventário)
                                    {
                                        if(item is Arma)
                                            AllMenus.InterfaceList.Add(item.Nome);
                                    }

                                    //Adiciono a opção de nada.
                                    AllMenus.InterfaceList.Add("Nada");

                                    //Adiciono tudo e limpo a interface.
                                    AllMenus.LimparEInserir();

                                    //LEIO O MENU
                                    var choiceArma = AllMenus.Interface.ReadChoice(true);

                                    //Valido a resposta nos itens já existentes.
                                    foreach(ObjetoFísico item in Player.Inventário)
                                    {
                                        if(item.Nome == choiceArma.Value)
                                        {
                                            Player.Arma = item;
                                            System.Console.WriteLine($"Você equipou {item.Nome} como arma.");
                                            Console.ReadKey(true);
                                            AllMenus.Interface._settings.IntroText= $"{Player.Arma.Imagem}{Player.Armadura.Imagem}";
                                        }
                                    }
                                }
                            break;
                            case "Armadura":
                                {
                                    //1.Limpo a lista de opções
                                    AllMenus.InterfaceList.Clear();

                                    //Adiciono as opções de equipamento já existentes à lista:
                                    foreach(ObjetoFísico item in Player.Inventário)
                                    {
                                        if(item is Armadura)
                                        {
                                            AllMenus.InterfaceList.Add(item.Nome);
                                        }
                                    }

                                    //Adiciono a opção de nada.
                                    AllMenus.InterfaceList.Add("Nada");

                                    //Adiciono tudo e limpo a interface.
                                    AllMenus.LimparEInserir();

                                    //Lanço o menu
                                    var choiceArmadura = AllMenus.Interface.ReadChoice(true);
                                    foreach(ObjetoFísico item in Player.Inventário)
                                    {
                                        if(item.Nome == choiceArmadura.Value)
                                        {
                                            Player.Armadura = item;
                                            System.Console.WriteLine($"Você equipou {item.Nome} como armadura.");
                                            Console.ReadKey(true);
                                            AllMenus.Interface._settings.IntroText= $"{Player.Arma.Imagem}{Player.Armadura.Imagem}";
                                        }
                                    }
                                }
                            break;
                        }
                    }
                break;
                case "Status":
                    {
                        Player.ExibirStatus();
                    }
                break;
                case "Sala":
                    {
                        Fases.Start();
                    }
                break;
            }
        }
    }
}
