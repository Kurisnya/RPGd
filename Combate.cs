namespace RPGd;

using System.Security.Cryptography.X509Certificates;
using ConsoleHelper;

//-----------------------------------------------STATUS----------------------------------------------
//DECLARAÇÃO DA CLASSE DE STATUSEFFECTS
public class StatusEffects
{
    public bool Stunned;
    public int Burn = 0;
    public int Weak = 0;

}




//-----------------------------------------------SKILLS---------------------------------------------
//DECLARAÇÃO DA CLASSE ABSTRATA DE SKILL
public abstract class Skill
{
    public string Nome;
    public abstract double Action(Monstro x);
}


//TODAS AS SKILLS:
public class GolpeMarcial : Skill
{
    public GolpeMarcial()
    {
        Nome = "Golpe Marcial";
    }
    public override double Action(Monstro x)
    {
        //RETORNA O ATAQUE DA ARMA DO JOGADOR
        if(Player.Arma is Arma armaTemp)
        return armaTemp.ataque + Player.DadosRaca.Forca;
        else
        return -1;
    }
}

public class CuraArcana : Skill
{
    public CuraArcana()
    {
        Nome= "Cura Arcana";
    }

    public override double Action(Monstro x)
    {
        Player.VidaAtual += 4;
        return 0;
    }
}

public class Ignite : Skill
{
    public Ignite()
    {
        Nome = "Ignite";
    }

    public override double Action(Monstro x)
    {
        //RETORNA O ATAQUE DA ARMA DO JOGADOR
        if(Player.Arma is Arma armaTemp)
        {
            x.status.Burn += 2;
            System.Console.WriteLine("Você inbui a sua arma com fogo e ataca!");
            return armaTemp.ataque;         
        }
        else
        return -1;
    }
}

//-------------------------------------------MONSTROS------------------------------------------------
//DECLARAÇÃO DA CLASSE DE MONSTROS
public abstract class Monstro
{
    public string Nome;
    public int XP;
    public double VidaMaxima;
    public double VidaAtual;
    public double Defesa;
    public Random random = new Random();
    public StatusEffects status = new StatusEffects();

    public string Imagem;
    public abstract void OnDeath();
    public abstract double RollAction();

        //STATUS EFFECTS E SEUS EFEITOS
        public void PassTurn()
    {
        if(this.status.Burn > 0)
        {
            this.VidaAtual -= 4;
            this.status.Burn --;            
        }
        if(this.status.Weak > 0)
            this.status.Weak --;
    }
}

//TODOS OS MONSTROS:
public class Esqueleto : Monstro
{
    public Esqueleto()
    {
        Nome= "Esqueleto";
        VidaMaxima= 15;
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
        int roll = base.random.Next(1,1);
        switch (roll)
        {
            case 1:
                {
                AllMenus.Interface._settings.IntroText=Imagem;
                System.Console.WriteLine("O esqueleto te ataca com suas garras.");
                return 3;
                } 
        }
        return 0;
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
        Console.WriteLine("O goblin ataca com uma adaga!");
        if(Player.DadosRaca.Nome=="Goblin")
        System.Console.WriteLine("Só tem espaço para um golin aqui!");
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
        Nome = "Zodd";
        VidaMaxima = 40;
        VidaAtual = 40;
        XP = 11;
        Defesa = 1;
        Imagem = @"
█████████████████████████████████████████████
█               .--.                        █
█              .'  .--.  '.                 █
█             /   (o  o)   \                █
█            |     .--.     |               █
█            |    /____\    |               █
█             \  .-====-.  /                █
█          .---'  .____.  '---.             █
█         /      /  ||  \      \            █
█        |      /   ||   \      |           █
█        |     /____||____\     |           █
█         \        /  \        /            █
█          '._   .'    '.   _.'             █
█                                           █
█████████████████████████████████████████████                               
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
█████████████████████████████████████████████
█                                           █
█    ▒         ▒▒      ▒▒▒           ▒      █
█   ▒▒       ▒▒           ▒▒           ▒    █
█   ▒      ▒▒                ▒     ▒    ▒▒  █
█   ▒▒    ▒▒                  ▒ ▒   ▒    ▒  █
█    ▒▒   ▒          (\_/)       ▒   ▒      █
█     ▒   ▒▒▒▒       (o.o)           ▒▒     █
█     ▒▒             /|_|\            ▒     █
█  ▒  ▒ ▒ ▒  ▒ ▒▒▒    | |   ▒▒▒▒ ▒     ▒    █
█▒▒ ▒▒   ▒                         ▒ ▒ ▒▒▒▒ █
█     ▒   ▒ ▒▒▒ ▒▒  ▒▒                ▒▒▒   █
█     ▒▒▒▒▒          ▒▒▒▒ ▒▒ ▒ ▒ ▒▒         █
█                                           █
█████████████████████████████████████████████";
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


public static class Combate
{
//-------------------------------MÉTODOS DO COMBATE---------------------------------------------------------
    //VERIFICAR SE TEM ALGUM MONSTRO VIVO
    private static int VerificarInimigosVivos(Monstro x)
    {
        if(x.VidaAtual > 0)
        return 1;
        else
        return 0;
    }
    //CRIAR NOME COM STATUS EFFECTS E VIDA
    private static string MontarNome(Monstro x)
    {
        string y =  $"{x.Nome}   #{x.VidaAtual}/{x.VidaMaxima}";
        //ADICIONA TAGS DE STATUS
        if(x.status.Burn > 0)
            y += " [BRN]";
        return y;
    }
    //LISTA DE MONSTROS QUE SERÃO COMBATIDOS(OS MONSTROS FICAM ARMAZENADOS NELA)
    public static List<Monstro> monstros = new List<Monstro>();
    static double DANO(double atq, double def)
    {
        return atq - def;
    }

    //LOOP BÁSICO
    public static void CombatLoop()
    {
        while (true)
        {
            AllMenus.Interface._settings.IntroText = @$"
█████████████████████████████████████████████
█                                           █
█   Nome: {Player.Nome}           Vida: {Player.VidaAtual}/{Player.VidaMaxima}
█   Arma: {Player.Arma.Nome}      XP: {Player.XP}
█   Armadura: {Player.Armadura.Nome}
█                                           █
█████████████████████████████████████████████";
            //ESCOLHENDO A AÇÃO (SKILL)
            //1.Limpo as opções da lista do menu
            AllMenus.InterfaceList.Clear();

            //2.Encho a lista com as opções DE SKILL
            foreach(Skill x in Player.InventárioSkills)
            {
                AllMenus.InterfaceList.Add(x.Nome);
            }

            //3.Limpo o menu e lanço a nova lista nele
            AllMenus.LimparEInserir();

            //LANÇO O MENU
            var choiceSkill = AllMenus.Interface.ReadChoice(true);


            //ESCOLHENDO O ALVO (MONSTRO)
            //1.Limpo as opções da lista do menu
            AllMenus.InterfaceList.Clear();

            //2.Encho a lista com as opções
            foreach(Monstro x in monstros)
            {
                AllMenus.InterfaceList.Add(MontarNome(x));
            }

            //3.Limpo o menu e lanço a nova lista nele
            AllMenus.LimparEInserir();

            //LANÇO O MENU
            var choiceMonstro = AllMenus.Interface.ReadChoice(true);

            //VALIDO A AÇÃO E GIRO O DANO (SKILL X NO MONSTRO X)
            foreach (Skill x in Player.InventárioSkills)
            {
                if(x.Nome == choiceSkill.Value)
                {   
                    int index = choiceMonstro.Value.IndexOf('#') - 3;
                    monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(index)).VidaAtual -= DANO(x.Action(monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(index))), monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(9)).Defesa);
                    monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(index)).PassTurn();
                }
            }

            
            //VERIFICA SE TEM ALGUM MONSTRO RESTANTE

            int res = 0;
            foreach(Monstro x in monstros)
            {
                res = VerificarInimigosVivos(x);
            }
            if(res == 0)
            {
                System.Console.WriteLine("Você venceu!");
                Console.ReadKey(true);
                //COLETANDO RECOMPENSAS
                foreach(Monstro x in monstros)
                {
                    x.OnDeath();
                }
                break;
            }

            //TURNO DOS INIMIGOS
            foreach(Monstro x in monstros)
            {

                double y;
                if(x.VidaMaxima > 0)
                if(Player.Armadura is Armadura armaduraTemp)
                    {
                        y = armaduraTemp.Defesa;
                        Player.VidaAtual -= x.RollAction() - y;
                        System.Console.WriteLine(x.Imagem);
                        Thread.Sleep(1000);
                        Console.ReadKey(true);
                    }
                
            }

            //VERIFICA SE O PLAYER MORREU
            if(Player.VidaAtual <= 0)
            {
                System.Console.WriteLine("Você morreu...");
                Environment.Exit(0);
                Console.ReadKey();
                break;
            }

            Console.ReadKey(true);
        }
        monstros.Clear();
    }

}
