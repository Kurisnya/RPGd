namespace RPGd;
using ConsoleHelper;
//C: A classe player é onde o jogador terá todos os seus atributos usados para interagir com o mundo
//declarados.

public class Player
{
    public Equipamento Arma;
    public Equipamento Armadura;

    public List<string> Inventário = new List<string>();
    

    //C: O player começa com uma banana no seu inventário.
    public Player()
    {
        Inventário.Add("Banana");
        Inventário.Add("Faca");
    }
}