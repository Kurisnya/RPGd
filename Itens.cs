namespace RPGd;

using ConsoleHelper;
//C: A classe Itens será onde TODOS os itens e suas categorias serão verdadeiramente declarados
//a existir, desde classes para seus atributos ou até mesmo procedimentos separados para uso no
//inventário. Seja criativo. É bom que cada item tenha um desenho em ASCII para deixar o jogo mais
//legal.
public static class Itens
{
    //EQUIPAMENTOS
    public static Equipamento Nada;
    public static Equipamento Banana;
    public static Equipamento Faca;
    public static Equipamento Behelit;
    public static Equipamento EspadaEnferrujada;
    public static Equipamento Caixademarimbondo;
    static Itens()
    {
        Banana = new Equipamento
        {
            Nome = "Banana",
            Tipo = "Permanente",
            Descrição = "Como isso foi parar aqui?",
            Imagem = @"
█████████████████████
█▌  ▄▄ ▄▄▄         ▐█
█▌    █▒▒ █▄▄      ▐█
█▌     █▒▒▄ █▄     ▐█
█▌      █ ▄▒ █▄    ▐█
█▌      █▄ ▒▒ █    ▐█
█▌       █ ▄▒▄█    ▐█
█▌       █▒▒▄█     ▐█
█▌       █▀▀       ▐█
█████████████████████"
        };
        //-----------------------------------------------------------------------------------
        Faca = new Equipamento
        {
            Nome = "Faca",
            Tipo = "Arma",
            Atq = 3,
            Def = 1,
            Descrição = "Uma faca do tipo que se encontra em uma sala de cirurgia. Deve doer",
            Imagem = @"
████████████████████
█▌   ▄▄▄▄▄▄▄█     ▐█
█▌  █▒▒▒▒▒▒▒█■■   ▐█
█▌   ▀▀▀▀▀▀▀█     ▐█
████████████████████"
        };
        //---------------------------------------------------------------------------
        Nada = new Equipamento
        {
            Nome = "Nada",
            Tipo = "Nenhum",
            Descrição = "Não tem nada aqui.",
            Imagem = @"
████████████████████
█▌                ▐█
█▌                ▐█
█▌                ▐█
████████████████████"
        };
        //---------------------------------------------------------------------------
        Behelit = new Equipamento
        {
            Nome = "Behelit",
            Tipo = "Arma",
            Atq = 10,
            Def = -5,
            Descrição = "Um artefato vermelho e ovalado, com marcas que lembram um rosto humano. Dizem que ele tem o poder de conceder desejos, mas a um preço terrível.",
            Imagem = @"
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⢿⣣⢹⢽⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣟⡿⣜⢯⡿⠘⡿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⣗⡭⠯⠩⣷⣼⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣕⢾⢲⣦⡂⢦⡗⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣞⣿⠿⢰⡕⡞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣭⡿⢷⣧⡾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣽⣷⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
"
        };
        //---------------------------------------------------------------------------
        EspadaEnferrujada = new Equipamento
        {
            Nome = "EspadaEnferrujada",
            Tipo = "Arma",
            Atq = 2,
            Descrição = "Uma espada velha e enferrujada, mas ainda afiada o suficiente para ser usada em combate. Cuidado ela pode estar com tétano.",
            Imagem = @"
████████████████████
█▌   ▄▄▄▄▄█     ▐█
█▌  ▒▒▒▒▒▒█■■   ▐█
█▌   ▀▀▀▀▀█     ▐█
████████████████████"
        };
        //---------------------------------------------------------------------------
        Caixademarimbondo = new Equipamento
        {
            Nome = "Caixa de Marimbondo",
            Tipo = "Arma",
            Atq = 3,
            Descrição = "Uma caixa de madeira velha e suja, cheia de marimbondos furiosos. Cuidado ao abrir, eles podem atacar em enxame e causar dor intensa.",
            Imagem = @"  
                 
     XX  XX XXXX  XX        
     X    XXXXX XX  XX      
    X X    XXXX  XXX  X     
    X XX X  XX XX  X   X    
    X  X X  X X  X  X  XX   
    X   X XX  XX     X X    
    X    XXX XXX    XX X    
    XX    XX XX XX  X  X    
     X    XX  X    X  XX    
     XXX  X       XX XX     
        XXXXXXX XX   
        "

        };
    }
    //C: O método Stat é onde as descrições e imagens dos itens serão mostrados, caso o jogador queira
    //ver os detalhes de um item específico. Ele é chamado no MainLoop, dentro do loop do inventário, quando
    //o jogador seleciona um item para ver.
    public static void Stat(string ItemName)
    {
        switch (ItemName)
        {
            case "Banana":
                {
                    Console.WriteLine(Banana.Descrição);
                    Console.WriteLine(Banana.Imagem);
                    Console.ReadKey(true);
                }
                break;
            case "Faca":
                {
                    System.Console.WriteLine(Faca.Descrição);
                    System.Console.WriteLine(Faca.Imagem);
                    Console.ReadKey(true);
                }
                break;
            case "Behelit":
                {
                    System.Console.WriteLine(Behelit.Descrição);
                    System.Console.WriteLine(Behelit.Imagem);
                    Console.ReadKey(true);
                }
                break;
            case "EspadaEnferrujada":
                {
                    System.Console.WriteLine(EspadaEnferrujada.Descrição);
                    System.Console.WriteLine(EspadaEnferrujada.Imagem);
                    Console.ReadKey(true);
                }
                break;
        
            case "Caixademarimbondo":
                {
                    System.Console.WriteLine(Caixademarimbondo.Descrição);
                    System.Console.WriteLine(Caixademarimbondo.Imagem);
                    Console.ReadKey(true);
                }
                break;
        }
    }
}

