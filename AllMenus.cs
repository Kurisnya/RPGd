namespace RPGd;

using System.Runtime.Intrinsics.Arm;
using ConsoleHelper;

public static class AllMenus
{
    //INTERFACE DO JOGO
    public static ChoiceMenu Interface;

    //LISTA ONDE FICAM AS OPÇÕES DA INTERFACE DO JOGO
    public static List<string> InterfaceList = new List<string>();
    static AllMenus()
    {
        //MAIN LOOP
        Interface = new ChoiceMenu(new Settings
        {
            IntroText= "Menu Principal",
            Selection= ">"
        });
    }

    //Limpa as opções já existentes no menu e injeta as opções presentes na InterfaceList
    public static void LimparEInserir()
    {
        Interface.Options.Clear();
        foreach (string option in InterfaceList)
        {
            Interface.Options.Add(new MenuItem
            {
                Title= option,
                Value= option
            });
        }
    }

    //Edita o título da interface.
    public static void EditarTitulo(string title)
    {
        Interface._settings.IntroText = title;
    }
    
}