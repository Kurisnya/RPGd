namespace RPGd;
using ConsoleHelper;
//C: A classe player é onde o jogador terá todos os seus atributos usados para interagir com o mundo
//declarados.

public static class Player
{

    static public Equipamento Arma;
    static public Equipamento Armadura;

    static public List<Equipamento> Inventário = new List<Equipamento>();
    

    //C: O player começa com uma banana no seu inventário.
    static Player()
    {
        Arma = Itens.Nada;
        Armadura = Itens.Nada;
        Inventário.Add(Itens.Banana);
        Inventário.Add(Itens.Faca);
    }
}