namespace RPGd;
using ConsoleHelper;
//C: A classe player é onde o jogador terá todos os seus atributos usados para interagir com o mundo
//declarados.

public static class Player
{
    // INFORMAÇÕES BÁSICAS
    static public string Nome;
    static public int XP=0;
    static public TipoRaca RacaEscolhida { get; set; }
    static public DadosRaca DadosRaca { get; set; }
    
    // ATRIBUTOS
    static public int Forca { get; set; }
    static public int Destreza { get; set; }
    static public int Constituicao { get; set; }
    static public int Inteligencia { get; set; }
    static public int Sabedoria { get; set; }
    static public int Carisma { get; set; }
    
    // VIDA
    static public double VidaMaxima { get; set; }
    static public double VidaAtual { get; set; }

    // EQUIPAMENTOS
    static public ObjetoFísico Arma;
    static public ObjetoFísico Armadura;

    static public List<ObjetoFísico> Inventário = new List<ObjetoFísico>();
    
    // SKILLS
    public static List<Skill> InventárioSkills = new List<Skill>();

    //C: O player começa com uma banana no seu inventário.
    static Player()
    {
        //Puxa o item de dentro da lista de itens
        Arma = Itens.ItensLista.Find(x => x.Nome == "Nada");
        Armadura = Itens.ItensLista.Find(x => x.Nome == "Trapos");
        //Enchendo o inventário com itens já existentes
        Inventário.Add(Itens.ItensLista.Find(x => x.Nome == "Adaga"));
        Inventário.Add(Itens.ItensLista.Find(x => x.Nome == "Trapos"));
    }
    
    // inicializa com a raça escolhida
    static public void InicializarComRaca(TipoRaca raca)
    {
        RacaEscolhida = raca;
        DadosRaca = Racas.ObterRaca(raca);
        
        Forca = DadosRaca.Forca;
        //Destreza = DadosRaca.Destreza;  ==========SÃO IDEIAS Q PEGUEI COM I.A, ACHO MELHOR NAO COLOCAR NO CODIGO PRA NÃO FICAR COMPLEXO======
        //Constituicao = DadosRaca.Constituicao;
        //Inteligencia = DadosRaca.Inteligencia;
        //Sabedoria = DadosRaca.Sabedoria;
        //Carisma = DadosRaca.Carisma;
        
        VidaMaxima = DadosRaca.VidaBase;
        VidaAtual = DadosRaca.VidaBase;

        //O PLAYER RECEBE AS SKILLS DA RAÇA
        foreach(Skill x in DadosRaca.Habilidades)
        {
            Player.InventárioSkills.Add(x);
        }
    }
    
    // Exibe o status do jogador
    static public void ExibirStatus()
    {
        System.Console.Clear();
        System.Console.WriteLine($"\n═══════════════════════════════════════");
        System.Console.WriteLine($"           STATUS DO JOGADOR");
        System.Console.WriteLine($"═══════════════════════════════════════");
        System.Console.WriteLine($"\nRAÇA: {DadosRaca?.Nome ?? "Não definida"}\n");
        
        System.Console.WriteLine("ATRIBUTOS:");
        System.Console.WriteLine($"  FOR: {Forca:D2}  "); //DEX: {Destreza:D2}  CON: {Constituicao:D2}
        //System.Console.WriteLine($"  INT: {Inteligencia:D2}  SAB: {Sabedoria:D2}  CAR: {Carisma:D2}");
        
        System.Console.WriteLine($"\nVIDA: {VidaAtual}/{VidaMaxima}");
        
        if (DadosRaca?.Habilidades.Count > 0)
        {
            System.Console.WriteLine("\nHABILIDADES:");
            foreach (var hab in DadosRaca.Habilidades)
            {
                System.Console.WriteLine($"  • {hab}");
            }
        }
        
        System.Console.WriteLine($"\n═══════════════════════════════════════");
        System.Console.WriteLine("Pressione qualquer tecla para continuar...");
        System.Console.ReadKey(true);
    }
}