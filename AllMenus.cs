namespace RPGd;

using System.Runtime.Intrinsics.Arm;
using ConsoleHelper;

public static class AllMenus
{
    public static ChoiceMenu Equipamento;
    public static ChoiceMenu Inventário;
    public static ChoiceMenu MainLoop;
    public static string bimbim = Player.Arma.Imagem;
    static AllMenus()
    {
        //MAIN LOOP
        MainLoop = new ChoiceMenu(new Settings
        {
            IntroText= "Menu Principal",
            Selection= ">"
        });
        //INVENTÁRIO
        Inventário = new ChoiceMenu(new Settings
        {
            IntroText= "Inventário",
            Selection= ">"
        });
        //EQUIPAMENTO
        Equipamento = new ChoiceMenu(new Settings
        {
            IntroText= $"{Player.Arma.Imagem}{Player.Armadura.Imagem}",
            Selection= ">"
        });
    }
}