namespace RPGd;
using ConsoleHelper;
//C: A classe player é onde o jogador terá todos os seus atributos usados para interagir com o mundo
//declarados.

public static class Player
{
    // INFORMAÇÕES BÁSICAS
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
    static public int VidaMaxima { get; set; }
    static public int VidaAtual { get; set; }

    // PROGRESSÃO (NÍVEL E EXPERIÊNCIA)
    //C: O 'private set' garante o encapsulamento: nível e experiência só podem ser
    //alterados pelos métodos da própria classe (GanharExperiencia / SubirDeNivel),
    //evitando alterações inválidas vindas de fora.
    static public int Nivel { get; private set; }
    static public int Experiencia { get; private set; }
    static public int ExperienciaProximoNivel { get; private set; }

    //C: Constantes que controlam o balanceamento da progressão.
    private const int VidaPorNivel = 5;   // vida máxima ganha a cada nível
    private const int ForcaPorNivel = 1;  // força ganha a cada nível

    // EQUIPAMENTOS
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
        Inventário.Add(Itens.Behelit);
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

        //C: Todo personagem começa no nível 1, sem experiência.
        Nivel = 1;
        Experiencia = 0;
        ExperienciaProximoNivel = CalcularXpProximoNivel(Nivel);
    }

    //C: Fórmula simples da curva de experiência: cada nível exige nivel * 100 de XP.
    //Nível 1 -> 100, Nível 2 -> 200, e assim por diante.
    static private int CalcularXpProximoNivel(int nivel)
    {
        return nivel * 100;
    }

    //C: Concede experiência ao jogador. Se acumular o suficiente, sobe de nível
    //(o while permite subir vários níveis de uma vez caso ganhe muito XP).
    static public void GanharExperiencia(int xp)
    {
        if (xp <= 0) return;

        Experiencia += xp;
        System.Console.WriteLine($"\n+{xp} de experiência! (EXP: {Experiencia}/{ExperienciaProximoNivel})");

        while (Experiencia >= ExperienciaProximoNivel)
        {
            Experiencia -= ExperienciaProximoNivel;
            SubirDeNivel();
        }
    }

    //C: Aplica os ganhos de subir de nível: mais vida, mais força, cura total,
    //recalcula o XP do próximo nível e avisa as habilidades desbloqueadas.
    static private void SubirDeNivel()
    {
        Nivel++;
        VidaMaxima += VidaPorNivel;
        Forca += ForcaPorNivel;
        VidaAtual = VidaMaxima; // recupera toda a vida ao subir de nível
        ExperienciaProximoNivel = CalcularXpProximoNivel(Nivel);

        System.Console.WriteLine($"\n★ NÍVEL UP! Você alcançou o nível {Nivel}!");
        System.Console.WriteLine($"  Vida máxima: {VidaMaxima} (+{VidaPorNivel})  |  Força: {Forca} (+{ForcaPorNivel})");

        //C: Mostra as habilidades que desbloqueiam exatamente neste novo nível.
        if (DadosRaca != null)
        {
            foreach (var hab in DadosRaca.Habilidades)
            {
                if (hab.NivelNecessario == Nivel)
                    System.Console.WriteLine($"  ✦ Nova habilidade desbloqueada: {hab.Nome}!");
            }
        }
    }

    //C: Retorna apenas as habilidades que o jogador já pode usar no nível atual.
    static public List<Habilidade> HabilidadesDisponiveis()
    {
        var disponiveis = new List<Habilidade>();
        if (DadosRaca == null) return disponiveis;

        foreach (var hab in DadosRaca.Habilidades)
        {
            if (hab.NivelNecessario <= Nivel)
                disponiveis.Add(hab);
        }
        return disponiveis;
    }

    // Exibe o status do jogador
    static public void ExibirStatus()
    {
        System.Console.Clear();
        System.Console.WriteLine($"\n═══════════════════════════════════════");
        System.Console.WriteLine($"           STATUS DO JOGADOR");
        System.Console.WriteLine($"═══════════════════════════════════════");
        System.Console.WriteLine($"\nRAÇA: {DadosRaca?.Nome ?? "Não definida"}");
        System.Console.WriteLine($"NÍVEL: {Nivel}");
        System.Console.WriteLine($"EXP: {Experiencia}/{ExperienciaProximoNivel}\n");

        System.Console.WriteLine("ATRIBUTOS:");
        System.Console.WriteLine($"  FOR: {Forca:D2}  "); //DEX: {Destreza:D2}  CON: {Constituicao:D2}
        //System.Console.WriteLine($"  INT: {Inteligencia:D2}  SAB: {Sabedoria:D2}  CAR: {Carisma:D2}");

        System.Console.WriteLine($"\nVIDA: {VidaAtual}/{VidaMaxima}");

        if (DadosRaca?.Habilidades.Count > 0)
        {
            System.Console.WriteLine("\nHABILIDADES:");
            foreach (var hab in DadosRaca.Habilidades)
            {
                //C: Habilidades já alcançadas aparecem normais; as de nível mais alto
                //aparecem como bloqueadas (🔒), indicando o nível necessário.
                if (hab.NivelNecessario <= Nivel)
                    System.Console.WriteLine($"  • {hab.Nome} - {hab.Descricao}");
                else
                    System.Console.WriteLine($"  🔒 {hab.Nome} (desbloqueia no nível {hab.NivelNecessario})");
            }
        }

        System.Console.WriteLine($"\n═══════════════════════════════════════");
        System.Console.WriteLine("Pressione qualquer tecla para continuar...");
        System.Console.ReadKey(true);
    }
}
