namespace RPGd;
using ConsoleHelper;
//C: A classe Itens será onde TODOS os itens e suas categorias serão verdadeiramente declarados
//a existir, desde classes para seus atributos ou até mesmo procedimentos separados para uso no
//inventário. Seja criativo. É bom que cada item tenha um desenho em ASCII para deixar o jogo mais
//legal.
public static class Itens
{
    //C: O procedimento STAT apenas serve para lançar status dos itens do inventário, por enquanto.
    public static void Stat(string ItemName)
    {
        switch (ItemName)
        {
            case "Banana":
                {
                  System.Console.WriteLine("\nComo isso foi parar aqui?"); 
                  System.Console.WriteLine(@"
                    ▄▄
                    ▄▄▄▄▄▄▄▄
                     ▄▄ ▄  ▄▄▄▄
                      ▄▄      ▄▄
                       ▄  ▄    ▄
                       ▄    ▄  ▄
                       ▄   ▄  ▄▄
                       ▄ ▄   ▄▄
                      ▄▄   ▄▄▄
                     ▄▄▄▄▄▄
                     ▄▄
                                                                                ");
                  Console.ReadKey(); 
                }
            break;
        }
    }
}