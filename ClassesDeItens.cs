namespace RPGd;

//Este .cs é onde ficam declaradas todas as classes de itens existentes, pare que eles sejam criados
//em outras partes do código. Todos os itens existentes DEVEM ser declarados aqui.
public abstract class ObjetoFísico //CLASSE PRIMÁRIA: Todo objeto físico vem dessa classe
{
    public string Nome;
    public string Descrição;
    public string Imagem;
}

public abstract class Arma : ObjetoFísico
{
    public double ataque;
    abstract public double atacar();

}

public abstract class Armadura : ObjetoFísico
{
    public double Defesa;

}



//OBJETOS REAIS
//ARMAS
public class Adaga : Arma
{
    public Adaga()
    {
        //ATRIBUTOS
        Nome = "Adaga";
        ataque = 5;
        Descrição = "É só uma adaga. Nada demais";
        Imagem = @"
█████████████████████████████████████████████
█ ░░░░░░░░░░░░░    ░░░░░░░  ░░░░░░░░░       █
█ ░░   ▄▄▄    ░░░░░░     ░░░░░░░░░░░░░░░░   █
█  ░░  ▄▄█▄▄▄▄▄▄▄ ░░░░  ▄█   ░░░░░░░░░░░░░  █
█░░ ░░  █▄▄░░░░░▄▄▄▄▄▄▄▄█     ░░░░░░░░ ░░░  █
█ ░░░░░░   ▄▄  ░░░░░░▄▄██       ░░░░░░░░░░░ █
█    ░░░░░░ █▄▄▄▄▄▄▄▄▄█████▄     ░░░░░  ░░  █
█       ░░░░░░     ▄██  ▀▀▀███▄▄ ░░░░░░░░░░ █
█           ░░░    █  ░░░░░ ▀▀▀  ░░░░░░     █
█████████████████████████████████████████████";
    }
    public override double atacar()
    {

        return ataque;
    }
}

public class Trapos : Armadura
{
    public Trapos()
    {
        Defesa= 1;
        Imagem=@"
█████████████████████████████████████████████
█       ▒▒▒▒▒▒                     ▒        █
█  ▒▒▒ ▒▒       █▀▀▀▀▄▄▄▄▄▄▄▄▀▀█▀  ▒  ▒▒▒   █
█  ▒▒▒    ▀▀█▀▀▀  ▒▒  ▒    ▒ ▒ ▀█  ▒▒▒ ▒▒▒▒▒█
█ ▒▒▒▒▒▒   ▀▀▀█▀▀ ▒  ▒▒  ▒▒▒ ▒ █▀      ▒  ▒ █
█    ▒▒     ▀█▀ ▀▀  ▒▒   ▒   ▒▒█▀     ▒  ▒▒ █
█   ▒▒▒▒   ▀██▀▀█▀▒▒▒ █▀█ █▀▀█  ▀█    ▒▒▒▒  █
█   ▒▒     ▀▀   █  ▀█▀  ▀ █   ▀▀▀▀▀ ▒▒▒ ▒▒  █
█   ▒▒▒         ▀▀▀▀     ▀▀   ▒▒▒▒▒▒▒       █
█████████████████████████████████████████████";
        Nome= "Trapos";
        Descrição= "Um monte de trapos que você coloca sobre seu corpo para se aquecer. Não te protege de nada.";
    }
}

public class EspadaEnferrujada : Arma
{
    public EspadaEnferrujada()
    {
        Nome = "Espada Enferrujada";
        Descrição = "Uma espada velha e enferrujada, mas ainda afiada o suficiente para ser usada em combate. Cuidado ela pode estar com tétano.";
        ataque = 2;
        Imagem = @"
█████████████████████████████████████████████
█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█
█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█
█ ▒                       ▄▄▄           ▒▒  █
█▒   ▒▀▀▀▀▀▄▀▀▀▀▀▀▀▀▄▀▄▀▀▀████▄▄▄▄███▄ ▒▒▒  █
█  ▀▒ ▒▄▒▒▒▒▒▒▒▒▄▒▒▒▒▒▒▒▒▀████████████   ▒▒▒█
█ ▒▒  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀███▀    ▀▀▀  ▒▒▒▒ █
█  ▒▒                                  ▒▒   █
█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█
█████████████████████████████████████████████";

    }

    public override double atacar()
    {
        //COLOCAR CHANCE PEQUENA DE INFECÇÃO NO ALVO
        return ataque;
    }
}

public class EspadaReta : Arma
{
    public EspadaReta()
    {
        Nome = "Espada Reta";
        Descrição = "Uma espada reta, bem cuidada e afiada o suficiente para uso em campo de batalha";
        ataque = 7;
        Imagem = @"
█████████████████████████████████████████████
█                                           █
█                                           █
█          />                               █
█ ()      //-----------------------------(  █
█(*)OXOXO(*>                              \ █
█ ()      \\-------------------------------)█
█          \>                               █
█                                           █
█████████████████████████████████████████████";

    }

    public override double atacar()
    {
        return ataque;
    }
}

public class Machado : Arma
{
    public Machado()
    {
        Nome = "Machado";
        Descrição = "Um machado feito para cortar madeira";
        ataque = 6;
        Imagem = @"
█████████████████████████████████████████████
█                                           █
█   ____________________________.---.______ █
█  ()__________________________(_o o_(____()█
█                          .___.'. .'.___.  █
█                          \ o    Y    o /  █
█                           \ \__   __/ /   █
█                            '.__'-'__.'    █
█                                '''        █
█████████████████████████████████████████████";

    }

    public override double atacar()
    {
        return ataque;
    }
}

public class Arco : Arma
{
    public Arco()
    {
        Nome = "Arco";
        Descrição = "Um arco feito de madeira. Permite disparar flechas a distância";
        ataque = 6;
        Imagem = @"
█████████████████████████████████████████████
█                                           █
█                 /════════\                █
█              ///          \\\             █
█           ///                \\\          █
█         ///                    \\\        █
█     ////                          \\\\    █
█    /__________________________________\   █
█                                           █
█████████████████████████████████████████████";

    }

    public override double atacar()
    {
        return ataque;
    }
}

public class Behelit : Arma
{
    public Behelit()
    {
        Nome = "Behelit";
        ataque = 15;
        Descrição= "Um artefato misterioso vermelho e ovalado, com marcas que lembram um rosto humano. Dizem que ele tem o poder de conceder desejos, mas a um preço terrível.";
        Imagem= @"
█████████████████████████████████████████████
█   ▒▒▒▒▒▒▒ ▒▒    ▌     ▌       ▒▒          █
█ ▒▒▒▒ ▒▒▒         ▀▄▄▄▀ ▒▒▒▒▒   ▒▒▒     ▒  █
█ ▒▒▒ ▒▒     ▒     ▄▀ ▀▀▄    ▒▒    ▒▒   ▒▒▒ █
█ ▒▒ ▒▒     ▒▒    ▄█▀▀▀▀▀▄▄    ▒    ▒   ▒▒▒ █
█▒▒▒ ▒▒     ▒    ▄█ ▄█ ▒█ █   ▒▒    ▒  ▒▒▒▒ █
█▒ ▒  ▒▒    ▒▒   ██ █ █▒  █   ▒        ▒▒▒▒ █
█▒ ▒   ▒▒    ▒▒  █▄▄▒▒ ▄▄█    ▒     ▒▒▒▒▒▒▒ █
█       ▒     ▒    █▄▄▄█         ▒▒▒  ▒▒▒   █
█████████████████████████████████████████████";
    }
    public override double atacar()
    {
        Player.VidaAtual -= 10;
        System.Console.WriteLine("O Behelit drena a sua vida...");
        return ataque;
    }
}

public class CaixaDeMarimbondo : Arma
{
    public CaixaDeMarimbondo()
    {   
        Nome = "Caixa de Marimbondo";
        Descrição = "Uma caixa de madeira velha e suja, cheia de marimbondos furiosos. Cuidado ao abrir, eles podem atacar em enxame e causar dor intensa.";
        ataque = 3;
        Imagem = @"
█████████████████████████████████████████████
█▒  ▄  ▒ ▄  ▒    ▄▄▄▄▄▄▄▄▄▄      ▄  ▄ ▒▒  ▒▒█
█▒▒▒  ▄   ▄   ▄▄█▄    ▒▒ ▄ █▄▄▄▄▄     ▒ ▄ ▒ █
█  ▒▒  ▒   ▄ ▄█▄▄  ▒▒▒▒  ▄ ▒ ▄  ▄█  ▒ ▄   ▒ █
█ ▄ ▒ ▄▄   ▄▄█  ▒▄▄▄▄▄▄▄▄▄  ▄▄  █  ▒    ▒ ▒ █
█  ▒▒▒    ▄█ ▄▒ ▒▒▒▒▒▒▒ ▒▒▄▄▄▒▒▄█  ▄   ▄▒▒▒ █
█ ▒▒ ▄    █▄ ▒ ▄▄▄▄▄▄ ▄▄▄▄  ▒▒▄█ ▒   ▄  ▒▒▒ █
█▒ ▄▄  ▄   █▄▄▄▄▄▄▒ ▒▒▒▒▒▒▒▒▄▄█▄▄  ▄     ▒▒ █
█        ▒    █▄▄▄▄▄▄▄▄▄▄▄▄█  ▒   ▒  ▒  ▄   █
█████████████████████████████████████████████";
    }
        public override double atacar()
    {
        return ataque;
    }
}

public class Nada : Arma
{
    public Nada()
    {
        Nome = "Nada";
        Descrição = "Nadica";
    }

    public override double atacar()
    {
        return 0;
    }
}
