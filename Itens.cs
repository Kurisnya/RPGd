namespace RPGd;

using System.Security.Cryptography.X509Certificates;
using ConsoleHelper;
//C: A classe Itens será onde TODOS os itens e suas categorias serão verdadeiramente declarados
//a existir, desde classes para seus atributos ou até mesmo procedimentos separados para uso no
//inventário. Seja criativo. É bom que cada item tenha um desenho em ASCII para deixar o jogo mais
//legal.
public static class Itens
{
    //LISTA DE ITENS DO JOGO (é uma lista)
    static public List<ObjetoFísico> ItensLista = new List<ObjetoFísico>();
    static Itens()
    {
        //TODOS OS ITENS DO JOGO:
        ItensLista.Add(new Adaga());
        ItensLista.Add(new Nada());
        ItensLista.Add(new Trapos());

        
    }

    public static void BuscarEDescreverEquipamento(string nomeDoItem)
    {
        foreach(ObjetoFísico x in ItensLista)
        {
            if(x.Nome == nomeDoItem)
            {
                System.Console.WriteLine(x.Imagem);
                System.Console.WriteLine(x.Descrição);
                Console.ReadKey(true);
            }
        }
    }
}

