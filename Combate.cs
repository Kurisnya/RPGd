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
        if(Player.Arma is Arma armaTemp)
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
        int roll = base.random.Next(1,2);
        switch (roll)
        {
            case 1:
                {
                AllMenus.Interface._settings.IntroText=Imagem;
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
//-------------------------------MÉTODOS DO COMBATE---------------------------------------------------------
    //VERIFICAR SE TEM ALGUM MONSTRO VIVO
    private static int VerificarInimigosVivos(Monstro x)
    {
        if(x.VidaAtual > 0)
        return 1;
        else
        return 0;
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
                AllMenus.InterfaceList.Add($"{x.Nome}   #Vida:{x.VidaAtual}/{x.VidaMaxima}");
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
                    monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(index)).VidaAtual -= DANO(x.Action(), monstros.Find(x => x.Nome == choiceMonstro.Value.Remove(9)).Defesa);
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
                break;
            }

            //TURNO DOS INIMIGOS
            foreach(Monstro x in monstros)
            {
                if(x.VidaMaxima > 0)
                Player.VidaAtual -= x.RollAction();
                Thread.Sleep(2000);
                Console.ReadKey();
            }

            //VERIFICA SE O PLAYER MORREU
            if(Player.VidaAtual <= 0)
            {
                System.Console.WriteLine("Você morreu...");
                Environment.Exit(0);
                Console.ReadKey();
                break;
            }

            //COLETANDO RECOMPENSAS
            foreach(Monstro x in monstros)
            {
                x.OnDeath();
            }
            Console.ReadKey(true);
        }
        monstros.Clear();
    }

}
