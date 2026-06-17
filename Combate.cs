namespace RPGd;
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
    public double VidaMaxima;
    public double Defesa;
    public Random random = new Random();

    public abstract double RollAction();
}

//TODOS OS MONSTROS:
public class Esqueleto : Monstro
{
    public Esqueleto()
    {
        Nome= "Esqueleto";
        VidaMaxima= 100;
        Defesa = 0;
    }

    public override double RollAction()
    {
        int roll = base.random.Next(1,2);
        switch (roll)
        {
            case 1:
                return 3;                    
            case 2:
                {
                this.VidaMaxima += 2;
                return 0;
                }
        }
        return 0;
    }
}


public static class Combate
{
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

            //ESCOLHENDO O ALVO
            //1.Limpo as opções da lista do menu
            AllMenus.InterfaceList.Clear();

            //2.Encho a lista com as opções
            foreach(Monstro x in monstros)
            {
                AllMenus.InterfaceList.Add(x.Nome);
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
                    monstros.Find(x => x.Nome == choiceMonstro.Value).VidaMaxima -= DANO(x.Action(), monstros.Find(x => x.Nome == choiceMonstro.Value).Defesa);
                }
            }

            //VERIFICO SE ALGUM MONSTRO MORREU
            foreach(Monstro x in monstros)
            {
                if(x.VidaMaxima <= 0)
                {
                    monstros.Remove(x);
                }
            }
            //VERIFICA SE TEM ALGUM MONSTRO RESTANTE
            if(monstros.Count() == 0)
            {
                System.Console.WriteLine("Você venceu.");
                Console.ReadKey();
                break;
            }

            //TURNO DOS INIMIGOS
            foreach(Monstro x in monstros)
            {
                Player.VidaMaxima -= x.RollAction();
            }

            //VERIFICA SE O PLAYER MORREU
            if(Player.VidaAtual <= 0)
            {
                System.Console.WriteLine("Você morreu...");
                Console.ReadKey();
                break;
            }

            foreach(Monstro x in monstros)
            {
                System.Console.WriteLine(x.VidaMaxima);
            }
            Console.ReadKey(true);
        }
    }

}