namespace RPGd;
using ConsoleHelper;
class Program
{
//LEGENDA:
//C - Comentário


    static void Main(string[] args)
    {
        //INICIAÇÃO DE ATRIBUTOS PRIMORDIAIS
        List<string> MainLoopOptions = new List<string>
        {
            "Inventário",
            "Equipamento"
        };

        //CHAVE BOOLEANA PARA LOOP
        bool loopINV = true;

        //LOOP PRINCIPAL (NEUTRO)
        while(true)
        {   
            //RESET DE CHAVES BOOLEANAS
            loopINV=true;

            //MENU PRINCIPAL
            foreach(string option in MainLoopOptions)
            AllMenus.MainLoop.Options.Add(new MenuItem
            {
                Title= option,
                Value= option
            });
            var choice = AllMenus.MainLoop.ReadChoice(true);
            switch (choice.Value)
            {
                //INVENTÁRIO
                case "Inventário":
                while(loopINV == true)
                {
                    {   //C: Encho o menu do inventário com os itens dentro do inventário do
                        //jogador.
                        foreach(Equipamento item in Player.Inventário)
                        AllMenus.Inventário.Options.Add(new MenuItem
                        {
                            Title= item.Nome,
                            Value= item.Nome
                        });
                    }
                        //INVENTÁRIO - SAÍDA
                        AllMenus.Inventário.Options.Add(new MenuItem
                        {
                            Title= "Voltar",
                            Value= "Voltar"
                        });
                        //OPÇÃO É SELECIONADA
                        var choiceINV = AllMenus.Inventário.ReadChoice(true);
                        if(choiceINV.Value == "Voltar")
                        {
                            loopINV = false;
                        }
                        else
                        Itens.Stat(choiceINV.Value);
                        //C: Após todo o processo, limpo o menu do inventário do jogador.
                        AllMenus.Inventário.Options.Clear();
                }
                break;
                case "Equipamento":
                while(loopINV == true)
                    {
                       AllMenus.Equipamento.Options.Add(new MenuItem
                        {
                            Title= "Arma",
                            Value= "Arma"
                        });
                        AllMenus.Equipamento.Options.Add(new MenuItem
                        {
                            Title= "Armadura",
                            Value= "Armadura"
                        });
                         AllMenus.Equipamento.Options.Add(new MenuItem
                        {
                            Title= "Voltar",
                            Value= "Voltar"
                        });
                        //EQUIPAMENTO
                        Console.Clear();
                        var choiceEquip = AllMenus.Equipamento.ReadChoice(true); 
                        if(choiceEquip.Value == "Voltar")
                        {
                            loopINV = false;
                        }
                        switch(choiceEquip.Value)
                        {
                            case "Arma":
                                {
                                    //Adiciono as opções de equipamento já existentes:
                                    foreach(Equipamento item in Player.Inventário)
                                    {
                                        if(item.Tipo == "Arma")
                                        {
                                            AllMenus.Inventário.Options.Add(new MenuItem
                                            {
                                                Title= item.Nome,
                                                Value= item.Nome
                                            });
                                        }
                                    }
                                    //Adiciono a opção de nada.
                                    AllMenus.Inventário.Options.Add(new MenuItem
                                    {
                                        Title= "Nada",
                                        Value="Nada"
                                    });
                                    //LEIO O MENU
                                    var choiceArma = AllMenus.Inventário.ReadChoice(true);
                                    //Valido a resposta nos itens já existentes.
                                    foreach(Equipamento item in Player.Inventário)
                                    {
                                        if(item.Nome == choiceArma.Value)
                                        {
                                            Player.Arma = item;
                                            System.Console.WriteLine($"Você equipou {item.Nome} como arma.");
                                            Console.ReadKey(true);
                                            AllMenus.Equipamento._settings.IntroText= $"{Player.Arma.Imagem}{Player.Armadura.Imagem}";
                                        }
                                    }
                                //LIMPA O MENU EQUIPAMENTO E INVENTÁRIO
                                AllMenus.Inventário.Options.Clear();
                                AllMenus.Equipamento.Options.Clear();
                                }
                            break;
                            case "Armadura":
                                {
                                    foreach(Equipamento item in Player.Inventário)
                                    {
                                        if(item.Tipo == "Armadura")
                                        {
                                            AllMenus.Inventário.Options.Add(new MenuItem
                                            {
                                                Title= item.Nome,
                                                Value= item.Nome
                                            });
                                        }
                                    }
                                    //Adiciono a opção de nada.
                                    AllMenus.Inventário.Options.Add(new MenuItem
                                    {
                                        Title= "Nada",
                                        Value="Nada"
                                    });
                                    var choiceArmadura = AllMenus.Inventário.ReadChoice(true);
                                    foreach(Equipamento item in Player.Inventário)
                                    {
                                        if(item.Nome == choiceArmadura.Value)
                                        {
                                            Player.Armadura = item;
                                            System.Console.WriteLine($"Você equipou {item.Nome} como armadura.");

                                        }
                                    }

                                //LIMPO O OS MENUS
                                AllMenus.Inventário.Options.Clear();
                                AllMenus.Equipamento.Options.Clear();
                                }
                            break;
                        }
                        //C: Após todo o processo, limpo o menu de equipamento do jogador.
                        AllMenus.Equipamento.Options.Clear();
                    }
                break;
            }
            //C: Após todo o processo, limpo o menu principal do jogador.
            AllMenus.MainLoop.Options.Clear();
        }
    }
}
