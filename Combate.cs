namespace RPGd;

using System.Security.Cryptography.X509Certificates;
using ConsoleHelper;

//DECLARAÇÃO DA CLASSE ABSTRATA DE SKILL
public abstract class Skill
{
    public string Nome;
    public abstract double Action();
}


//TODAS AS SKILLS:
public class Atacar : Skill
{
    public Atacar()
    {
        Nome = "Atacar";
    }
    public override double Action()
    {
        //RETORNA O ATAQUE DA ARMA DO JOGADOR
        if (Player.Arma is Arma armaTemp)
            return armaTemp.ataque;
        else
            return -1;
    }
}

//DECLARAÇÃO DA CLASSE DE MONSTROS
public abstract class Monstro
{
    public string Nome;
    public int XP;
    public double VidaMaxima;
    public double VidaAtual;
    public double Defesa;
    public Random random = new Random();

    public string Imagem;
    public abstract void OnDeath();
    public abstract double RollAction();
}

//TODOS OS MONSTROS:
public class Esqueleto : Monstro
{
    public Esqueleto()
    {
        Nome = "Esqueleto";
        VidaMaxima = 15;
        VidaAtual = 15;
        XP = 10;
        Defesa = 0;
        Imagem = @"
██████████████████████████████████████████████
█    ▓ ▓  ▓   ▄██▀▀▒▀▒▀▀▒▒▒████        ▓▓   █
█ ▓▓▓▓  ▓▓▓  █▀▀▀      ▒▒▒▒█████ ▓▓▓▓▓  ▓ ▓ █
█ ▓▓ ▓ ▓▓▓ ██▒     ▒   ▒ ▄▄▄▄███▄  ▓▓▓▓ ▓▓▓▓█
█  ▓▓▓▓▓ ▄█▀▒▒▒▒▒▒▒▒▒   █▀    ▀██   ▓▓ ▓▓▓ ▓█
█ ▓▓ ▓▓ ██▒▒ ▒ ▒▒▒ ▄▄▄█▀▀      ██   ▓▓▓ ▓▓ ▓█
█ ▓ ▓▓ ▄█▒▒▒▒▒▒▒▒ ▄███    █  █ █▀   ▓▓▓ ▓▓▓▓█
█ ▓▓▓▓▓██▒▒▒▒▒▒  ▄██   █▀█▀  ▀██    ▓▓▓▓▓ ▓▓█
█ ▓▓▓▓▓██▒▒▒▒▒▒ ███▄ ▀▀▀▀▀▒ ▄██▀    ▓ ▓▓▓ ▓▓█
█  ▓▓ ██▒▒▒▒▒▒▒ ███  ▄    ▒▄██▄   ▓▓▓▓▓▓ ▓▓▓█
█ ▓▓▓ ██▒▄▄▄▄▒▒ ▀█████ ▄ ▄ ▄ ▄▓   ▓ ▓ ▓ ▓▓▓▓█
█  ▓▓ █▀▀▓▓▓ ▀█▄▄█░░░░▀▀▀█▀▀▀█▀  ▓▓▓▓▓  ▓▓▓ █
█  ▓███▓▓▓▓▓▓▓▓█░░░▄░▄░▄░▄▀█▓████ ▓▓▓▓ ▓▓▓  █
█ ███▓▓▓▓▓▓▓▓▓▓█▀▀▀▀▀▀▀▀▀▀▀▀█▓▓▓█████       █
█████████████████████████████████████████████";
    }

    public override void OnDeath()
    {
        Player.XP = this.XP;
    }
    public override double RollAction()
    {
        int roll = base.random.Next(1, 2);
        switch (roll)
        {
            case 1:
                {
                    AllMenus.Interface._settings.IntroText = Imagem;
                    System.Console.WriteLine("O esqueleto te ataca com suas garras.");
                    return 3;
                }
            case 2:
                {
                    this.VidaMaxima += 2;
                    return 0;
                }
        }
        return 0;
    }
}
public class Morte : Monstro
{
    public Morte()
    {
        Nome = "Morte";
        VidaMaxima = 10;
        VidaAtual = 10;
        XP = 11;
        Defesa = 1;
        Imagem = @"
 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                                   
 X      └──────┘└┘┘┘                         X                                   
 X       ██┘█████████  „_                    X                                   
 X       ┘└┘█┘    ┘   /_ ^~„                 X                                   
 X       ┘███ █  ┘ █ // `   \                X                                   
 X        └┘└┘┘ ┘┘█ //    `\|                X                                   
 X       └┘█┘█┘┘┘██//       `                X                                   
 X        ██ █┘█┘┘ -                         X                                   
 X            ██ ██                          X                                   
 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                                   
 ";
    }

    public override void OnDeath()
    {
        Player.XP += XP;
    }

    public override double RollAction()
    {
        Console.WriteLine("A (aprendiz) da Morte ataca com uma foice!");
        return 4;
    }
}

public class Zood : Monstro
{
    public Zood()
    {
        Nome = "Zood";
        VidaMaxima = 40;
        VidaAtual = 40;
        XP = 11;
        Defesa = 1;
        Imagem = @"
       .--.
      .'  .--.  '.
     /   (o  o)   \
    |     .--.     |
    |    /____\    |
     \  .-====-.  /
  .---'  .____.  '---.
 /      /  ||  \      \
|      /   ||   \      |
|     /____||____\     |
 \        /  \        /
  '._   .'    '.   _.'
                                              
 ";
    }

    public override void OnDeath()
    {
        Player.XP += XP;
    }

    public override double RollAction()
    {
        Console.WriteLine("O Zood ataca com seu corpo demoniaco!");
        return 2;
    }
}
public class Rato : Monstro
{
    public Rato()
    {
        Nome = "Rato";
        VidaMaxima = 10;
        VidaAtual = 10;
        XP = 15;
        Defesa = 1;
        Imagem = @"
 (\_/)
 (o.o)
 /|_|\
  | |";
    }

    public override void OnDeath()
    {
        Player.XP += XP;
    }

    public override double RollAction()
    {
        Console.WriteLine("O rato corrompido ataca com seus dentes!");
        return 5;
    }
}
public class Goblin : Monstro
{
    public Goblin()
    {
        Nome = "Goblin";
        VidaMaxima = 20;
        VidaAtual = 20;
        XP = 15;
        Defesa = 1;
        Imagem = @"
████████████████████████████████████████
█               ,      ,               █
█              /(.-""-.)\              █
█          |\  \/      \/  /|          █
█          | \ / =.  .= \ / |          █
█          \( \   o\/o   / )/          █
█           \_, '-/  \-' ,_/           █
█             /   \__/   \             █
█             \ \__/\__/ /             █
█           ___\ \|--|/ /___           █
█         /`    \      /    `\         █
█        /       '----'       \        █
████████████████████████████████████████";
    }

    public override void OnDeath()
    {
        Player.XP += XP;
    }

    public override double RollAction()
    {
        Console.WriteLine("O goblin ataca com sua adaga!");
        return 5;
    }
}

public class Fantasma : Monstro
{
    public Fantasma()
    {
        Nome = "Fantasma";
        VidaMaxima = 25;
        VidaAtual = 25;
        XP = 30;
        Defesa = 0;
        Imagem = @"
████████████████████████████████████████
█          .'``'.      ...             █
█         :o  o `....'`  ;             █
█          `. O         :'             █
█           `':          `.            █
█            `:.          `.           █
█            : `.         `.           █
█           `..'`...       `.          █
█                  `...     `.         █
█                     ``...  `.        █
█                         `````.       █
████████████████████████████████████████";
    }

    public override void OnDeath()
    {
        Console.WriteLine("O fantasma se dissipa no ar...");
        Player.XP += XP;
    }

    public override double RollAction()
    {
        int roll = base.random.Next(1, 4);

        switch (roll)
        {
            case 1:
                Console.WriteLine("O fantasma atravessa sua armadura e causa dano espiritual!");
                return 8;

            case 2:
                Console.WriteLine("O fantasma emite um grito assustador!");
                return 6;

            case 3:
                Console.WriteLine("O fantasma desaparece e reaparece atrás de você!");
                return 10;
        }

        return 0;
    }
}
public static class Combate
{
    public static List<Monstro> monstros = new List<Monstro>();

    static double DANO(double atq, double def)
    {
        double dano = atq - def;
        return dano < 0 ? 0 : dano;
    }

    public static void CombatLoop()
    {
        while (true)
        {
            // =========================
            // VERIFICA SE EXISTEM INIMIGOS
            // =========================
            if (monstros.Count == 0)
            {
                Console.WriteLine("Não há inimigos.");
                return;
            }

            // =========================
            // HUD DO PLAYER
            // =========================
            AllMenus.Interface._settings.IntroText = @$"
█████████████████████████████████████████████
█   Nome: {Player.Nome}   Vida: {Player.VidaAtual}/{Player.VidaMaxima}
█   Arma: {Player.Arma.Nome}   XP: {Player.XP}
█   Armadura: {Player.Armadura.Nome}
█████████████████████████████████████████████";

            // =========================
            // ESCOLHA SKILL
            // =========================
            AllMenus.InterfaceList.Clear();

            foreach (Skill x in Player.InventárioSkills)
                AllMenus.InterfaceList.Add(x.Nome);

            AllMenus.LimparEInserir();

            var choiceSkill = AllMenus.Interface.ReadChoice(true);

            Skill skillEscolhida =
                Player.InventárioSkills.FirstOrDefault(s => s.Nome == choiceSkill.Value);

            if (skillEscolhida == null)
                continue;

            // =========================
            // ESCOLHA MONSTRO
            // =========================
            AllMenus.InterfaceList.Clear();

            foreach (Monstro x in monstros)
                AllMenus.InterfaceList.Add($"{x.Nome} HP:{x.VidaAtual}/{x.VidaMaxima}");

            AllMenus.LimparEInserir();

            var choiceMonstro = AllMenus.Interface.ReadChoice(true);

            Monstro alvo = monstros
                .FirstOrDefault(m => $"{m.Nome} HP:{m.VidaAtual}/{m.VidaMaxima}" == choiceMonstro.Value);

            if (alvo == null)
                continue;
            // =========================
            // MOSTRAR INIMIGO
            // =========================
            Console.Clear();

            Console.WriteLine(alvo.Imagem);
            Console.WriteLine($"INIMIGO: {alvo.Nome}");
            Console.WriteLine($"VIDA: {alvo.VidaAtual}/{alvo.VidaMaxima}");
            Console.WriteLine($"DEFESA: {alvo.Defesa}");

            Console.ReadKey(true);

            // =========================
            // DANO DO PLAYER
            // =========================
            double dano = skillEscolhida.Action();
            alvo.VidaAtual -= DANO(dano, alvo.Defesa);

            if (Player.Arma is Behelit)
            {
                Player.VidaAtual -= 10;
                Console.WriteLine("O Behelit drena sua vida...");
            }

            // =========================
            // CHECA VITÓRIA
            // =========================
            bool vivos = monstros.Any(m => m.VidaAtual > 0);

            if (!vivos)
            {
                Console.WriteLine("Você venceu!");
                break;
            }

            // =========================
            // TURNO DOS INIMIGOS
            // =========================
            foreach (Monstro x in monstros)
            {
                if (x.VidaAtual > 0)
                    Player.VidaAtual -= x.RollAction();
            }

            // =========================
            // MORTE DO PLAYER
            // =========================
            if (Player.VidaAtual <= 0)
            {
                Console.WriteLine("Você morreu...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            // =========================
            // RECOMPENSA XP
            // =========================
            foreach (Monstro x in monstros)
            {
                if (x.VidaAtual <= 0)
                    x.OnDeath();
            }

            Console.ReadKey(true);
        }

        monstros.Clear();
    }
}