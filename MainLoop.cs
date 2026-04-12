namespace RPGd;
using ConsoleHelper;
class Program
{
//LEGENDA:
//C - Comentário


    static void Main(string[] args)
    {
        //INICIAÇÃO DE ATRIBUTOS PRIMORDIAIS
        AllMenus menus = new AllMenus();
        Player P1 = new Player();

        //CHAVE BOOLEANA PARA LOOP
        bool loopINV = true;

        //LOOP PRINCIPAL (NEUTRO)
        while(true)
        {   
            //RESET DE CHAVES BOOLEANAS
            loopINV=true;

            //MENU PRINCIPAL
            var choice = menus.MainLoop.ReadChoice(true);
            switch (choice.Value)
            {
                //INVENTÁRIO
                case "Inventário":
                while(loopINV == true)
                {
                    {   //C: Encho o menu do inventário com os itens dentro do inventário do
                        //jogador.
                        foreach(string item in P1.Inventário)
                        menus.Inventário.Options.Add(new MenuItem
                        {
                            Title= item,
                            Value= item
                        });
                    }
                        //INVENTÁRIO - SAÍDA
                        menus.Inventário.Options.Add(new MenuItem
                        {
                            Title= "Voltar",
                            Value= "Voltar"
                        });
                        //OPÇÃO É SELECIONADA
                        var choiceINV = menus.Inventário.ReadChoice(true);
                        if(choiceINV.Value == "Voltar")
                        {
                            loopINV = false;
                        }
                        else
                        Itens.Stat(choiceINV.Value);
                        //C: Após todo o processo, limpo o menu do inventário do jogador.
                        menus.Inventário.Options.Clear();
                }
                break;
            }
            
        }
    }
}
