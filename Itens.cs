namespace RPGd;
using ConsoleHelper;
//C: A classe Itens será onde TODOS os itens e suas categorias serão verdadeiramente declarados
//a existir, desde classes para seus atributos ou até mesmo procedimentos separados para uso no
//inventário. Seja criativo. É bom que cada item tenha um desenho em ASCII para deixar o jogo mais
//legal.
public static class Itens
{
    //EQUIPAMENTOS
    public static Equipamento Nada;
    public static Equipamento Banana;
    public static Equipamento Faca;
    static Itens()
    {
        Banana = new Equipamento();
        Banana.Nome = "Banana";
        Banana.Tipo = "Permanente";
        Banana.Descrição = "Como isso foi parar aqui?";
        Banana.Imagem = @"
█████████████████████
█▌  ▄▄ ▄▄▄         ▐█
█▌    █▒▒ █▄▄      ▐█
█▌     █▒▒▄ █▄     ▐█
█▌      █ ▄▒ █▄    ▐█
█▌      █▄ ▒▒ █    ▐█
█▌       █ ▄▒▄█    ▐█
█▌       █▒▒▄█     ▐█
█▌       █▀▀       ▐█
█████████████████████";
    //-----------------------------------------------------------------------------------
        Faca = new Equipamento();
        Faca.Nome = "Faca";
        Faca.Tipo = "Arma";
        Faca.Atq = 3;
        Faca.Def = 1;
        Faca.Descrição = "Uma faca do tipo que se encontra em uma sala de cirurgia. Deve doer";
        Faca.Imagem = @"
████████████████████
█▌   ▄▄▄▄▄▄▄█     ▐█
█▌  █▒▒▒▒▒▒▒█■■   ▐█
█▌   ▀▀▀▀▀▀▀█     ▐█
████████████████████";
    //---------------------------------------------------------------------------
        Nada = new Equipamento();
        Nada.Nome = "Nada";
        Nada.Tipo = "Nenhum";
        Nada.Descrição = "Não tem nada aqui.";
        Nada.Imagem = @"
████████████████████
█▌                ▐█
█▌                ▐█
█▌                ▐█
████████████████████";
    }
    //
    //C: O método Stat é onde as descrições e imagens dos itens serão mostrados, caso o jogador queira
    //ver os detalhes de um item específico. Ele é chamado no MainLoop, dentro do loop do inventário, quando
    //o jogador seleciona um item para ver.
    public static void Stat(string ItemName)
    {
        switch (ItemName)
        {
            case "Banana":
                {
                    System.Console.WriteLine(Banana.Descrição);
                    System.Console.WriteLine(Banana.Imagem);
                    Console.ReadKey(true);
                }
            break;
            case "Faca":
                {
                    System.Console.WriteLine(Faca.Descrição);
                    System.Console.WriteLine(Faca.Imagem);
                    Console.ReadKey(true);
                }
            break;
        }
    }
}