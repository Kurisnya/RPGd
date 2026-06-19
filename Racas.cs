namespace RPGd;

public enum TipoRaca
{
    Mago,
    Cavaleiro,
    Necromante,
    Goblin
}

public class DadosRaca
{
    public TipoRaca Tipo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }  //imagem da raça

    // Atributos base
    public int Forca { get; set; }

    // Vida base
    public int VidaBase { get; set; }

    // Habilidades especiais
    public List<Skill> Habilidades { get; set; } = new List<Skill>(); //skills unicas
}

public static class Racas
{
    public static Dictionary<TipoRaca, DadosRaca> TodasAsRacas = new Dictionary<TipoRaca, DadosRaca>
    {
        {
            TipoRaca.Mago,
            new DadosRaca
            {

                Tipo = TipoRaca.Mago,
                Nome = "Mago",
                Descricao = "Bruxo ou mago? Não sabemos, mas você manja dos feitiços",
                 Imagem = @"
                 /\
                /  \
               |    |
             --:'''':--
               :'_' :
               _:"":\___
    ' '      ____.' :::     ' '
           .*/.-' .-'''
         .'/\/   / /\
         |_/\/   |/  \
         / /||   ||   |
        / / ||   ||   |
       / /  ||___||   |
      /_/   |/   \|   |
             \___/ \___\
",
                Forca = 8,
                //Destreza = 12,
                //Constituicao = 10,
                //Inteligencia = 16,
                //Sabedoria = 13,
                //Carisma = 11,
                VidaBase = 30,
                Habilidades = new List<Skill>
                {
                   new CuraArcana(),
                   new Ignite()
                }
            }
        },
        {
            TipoRaca.Cavaleiro,
            new DadosRaca
            {
                Tipo = TipoRaca.Cavaleiro,
                Nome = "Cavaleiro",
                 Imagem = @"
                 .-.
                (o.o)
                 |=|
                __|__
              //.=|=.\\
             // .=|=. \\
             \\ .=|=. //
              \\(_=_)//
               (:| |:)
                || ||
                () ()
                || ||
                || ||
               ==' '==
",
                Descricao = "Um nobre homem de armadura, simples e rustico",
                Forca = 12,
                //Destreza = 10,
                //Constituicao = 14,
                //Inteligencia = 10,
                //Sabedoria = 12,
                //Carisma = 13,
                VidaBase = 50,
                Habilidades = new List<Skill>
                {
                    new GolpeMarcial()
                }
            }
        },
        {
            TipoRaca.Necromante,
            new DadosRaca
            {
                Tipo = TipoRaca.Necromante,
                Nome = "Necromante",
                Imagem = @"
           .------.
         .'        '.
        /   .--.     \
       |   (    )     |
       |    '--'      |
        \            /
         '.        .'
           '-.__.-'

             ",

                Descricao = "Ocultista sombrio, ninguem sabe suas intenções, seu esquisito!",
                Forca = 10,
                //Destreza = 11,
                //Constituicao = 12,
                //Inteligencia = 15,
                //Sabedoria = 10,
                //Carisma = 14,
                VidaBase = 35,
                Habilidades = new List<Skill>
                {
                   
                }
            }
        },
        {
            TipoRaca.Goblin,
            new DadosRaca
            {
                Tipo = TipoRaca.Goblin,
                Nome = "Goblin",
                Imagem = @"
     ,      ,
     /(.-""-.)\
     |\  \/  /|
     | \ /\ / |
     \( o  o )/
      /|_==_|\
     /_|____|_\
       / || \
      /__||__\
         /\
        /__\

      
                ",
                Descricao = "Verde, pequeno, feio e malvado. Porém, astuto e flexível",
                Forca = 20,
                //Destreza = 15,
                //Constituicao = 9,
                //Inteligencia = 12,
                //Sabedoria = 10,
                //Carisma = 8,
                VidaBase = 25,
                Habilidades = new List<Skill>
                {
                    //"Ataque Rápido - Ataque adicional uma vez por turno",
                    //"Sorte - Chance de 25% de causar dano crítico (2x dano) a cada ataque"
                }
            }
        }
    };

    public static DadosRaca ObterRaca(TipoRaca tipo)
    {
        return TodasAsRacas[tipo];
    }

    public static void ExibirDescricaoRaca(TipoRaca tipo)
    {
        var raca = ObterRaca(tipo);
        System.Console.Clear();
        System.Console.WriteLine($"\n═══════════════════════════════════════");
        System.Console.WriteLine($"         {raca.Nome.ToUpper()}");

        System.Console.WriteLine($"═══════════════════════════════════════\n");
        System.Console.WriteLine(raca.Imagem);
        System.Console.WriteLine($"{raca.Descricao}\n");

        System.Console.WriteLine("ATRIBUTOS:");
        System.Console.WriteLine($"  Força............. {raca.Forca}");
        //System.Console.WriteLine($"  //Destreza.......... {raca.//Destreza}");
        //System.Console.WriteLine($"  Constituição..... {raca.Constituicao}");
        //System.Console.WriteLine($"  Inteligência..... {raca.Inteligencia}");
        //System.Console.WriteLine($"  Sabedoria........ {raca.Sabedoria}");
        //System.Console.WriteLine($"  Carisma.......... {raca.Carisma}");

        System.Console.WriteLine($"\nVIDA BASE: {raca.VidaBase}");

        System.Console.WriteLine("\nHABILIDADES:");
        foreach (var hab in raca.Habilidades)
        {
            System.Console.WriteLine($"  • {hab}");
        }

        System.Console.WriteLine("\n═══════════════════════════════════════");
        System.Console.WriteLine("Pressione qualquer tecla para continuar...");
        System.Console.ReadKey(true);
    }
}
