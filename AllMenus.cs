namespace RPGd;
using ConsoleHelper;

public class AllMenus
{
    //INVENTÁRIO
    private Settings settingsINV = new Settings
    {
        IntroText= "Inventário",
        Selection= ">"

    };
    public ChoiceMenu Inventário;
    //
    //MAIN LOOP
    private Settings settingsMainLoop = new Settings
    {
        IntroText= "Menu Principal",
        Selection= ">"
    };
    public ChoiceMenu MainLoop;
    public AllMenus()
    {
        //MAIN LOOP
        MainLoop = new ChoiceMenu(settingsMainLoop);
        MainLoop.Options.Add(new MenuItem
        {
            Title= "Inventário",
            Value= "Inventário"
        });
        //INVENTÁRIO
        Inventário = new ChoiceMenu(settingsINV);
    }
}