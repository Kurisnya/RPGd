# 🎮 Guia: Como Implementar Habilidades e Atributos em Combate

## 📋 Resumo
Você criou um sistema de raças com **atributos únicos** e **habilidades especiais**. Este guia mostra como integrar isso no sistema de combate.

---

## 1️⃣ Entendendo o Sistema Atual

### Estrutura de Combate
```csharp
// Combate.cs (ATUAL)
public static double Atacar(double atq, double def)
{
    return atq - def;  // Dano = Ataque - Defesa
}
```

**Problema**: Ignora completamente os atributos do player e da raça.

---

## 2️⃣ Criar Classe Inimigo

Primeiro, você precisa de uma classe para representar inimigos:

```csharp
// Inimigo.cs (NOVO)
public class Inimigo
{
    public string Nome { get; set; }
    public int VidaMaxima { get; set; }
    public int VidaAtual { get; set; }
    
    public int Forca { get; set; }
    public int Destreza { get; set; }
    public int Constituicao { get; set; }
    public int Inteligencia { get; set; }
    
    public int AtaquePorArma { get; set; }
    public int Defesa { get; set; }
    
    public List<string> Habilidades { get; set; } = new List<string>();
}
```

---

## 3️⃣ Expandir Sistema de Combate

### Opção A: Usar Atributos Básicos

```csharp
// Combate.cs (EXPANDIDO)
public static int CalcularDano(int forcaAtacante, int armaBonus, int defesaDefensor)
{
    // Dano base = Força + Bônus da Arma
    int danoBase = forcaAtacante + armaBonus;
    
    // Redução por defesa
    int danoFinal = danoBase - (defesaDefensor / 2);
    
    // Garante mínimo de 1 de dano
    return Math.Max(1, danoFinal);
}
```

**Uso no jogo:**
```csharp
int dano = Combate.CalcularDano(
    Player.Forca,                  // Atributo da raça
    Player.Arma.Dano,              // Bônus da arma equipada
    inimigo.Defesa                 // Defesa do inimigo
);
```

---

### Opção B: Implementar Crits (Ataques Críticos)

```csharp
public static bool VerificarCrit(int destreza)
{
    // Chance de crit = Destreza / 100
    // Goblin (DES 15) = 15% de chance
    // Mago (DES 12) = 12% de chance
    
    Random random = new Random();
    int chanceCrit = destreza;
    
    return random.Next(1, 101) <= chanceCrit;
}

public static int CalcularDanoComCrit(int forca, int armaBonus, int destreza, int defesa)
{
    int dano = CalcularDano(forca, armaBonus, defesa);
    
    if (VerificarCrit(destreza))
    {
        Console.WriteLine("💥 GOLPE CRÍTICO!");
        return dano * 2;  // Dobra o dano
    }
    
    return dano;
}
```

---

## 4️⃣ Implementar Habilidades Específicas da Raça

### Mago: Bolada Mágica
```csharp
public static int HabilidadeMagoBolada(int inteligencia)
{
    // Dano = 1d4 + Inteligência
    Random random = new Random();
    int dano = random.Next(1, 5) + inteligencia;
    Console.WriteLine($"🔮 Bolada Mágica! Dano: {dano}");
    return dano;
}
```

### Cavaleiro: Golpe Poderoso
```csharp
public static int HabilidadeCavalheiroGolpe(int forca)
{
    // Dano = 2d6 + Força
    Random random = new Random();
    int dado1 = random.Next(1, 7);
    int dado2 = random.Next(1, 7);
    int dano = dado1 + dado2 + forca;
    Console.WriteLine($"⚔️  Golpe Poderoso! Dano: {dano}");
    return dano;
}
```

### Necromante: Drenar Vida
```csharp
public static void HabilidadeNecromanteDrenar(Inimigo inimigo, int inteligencia)
{
    // Rouba vida = 1d6 + Inteligência
    Random random = new Random();
    int vidaRoubada = random.Next(1, 7) + inteligencia;
    
    inimigo.VidaAtual -= vidaRoubada;
    Player.VidaAtual += vidaRoubada;
    
    Console.WriteLine($"💀 Drenar Vida! Vida roubada: {vidaRoubada}");
}
```

### Goblin: Ataque Rápido
```csharp
public static int HabilidadeGoblinAtaque(int destreza)
{
    // Ataque adicional com bonus de destreza
    Random random = new Random();
    int dano = random.Next(1, 6) + (destreza / 2);
    Console.WriteLine($"⚡ Ataque Rápido! Dano: {dano}");
    return dano;
}
```

---

## 5️⃣ Integrar no Sistema de Combate

### Loop de Combate Exemplo

```csharp
public static void ExecutarCombate(Inimigo inimigo)
{
    while (Player.VidaAtual > 0 && inimigo.VidaAtual > 0)
    {
        Console.Clear();
        Console.WriteLine($"🎮 COMBATE - {inimigo.Nome}");
        Console.WriteLine($"Sua Vida: {Player.VidaAtual}/{Player.VidaMaxima}");
        Console.WriteLine($"Vida Inimigo: {inimigo.VidaAtual}\n");
        
        // Menu de ações
        AllMenus.InterfaceList.Clear();
        AllMenus.InterfaceList.Add("Atacar com Arma");
        AllMenus.InterfaceList.Add("Usar Habilidade");
        AllMenus.InterfaceList.Add("Defender");
        
        AllMenus.LimparEInserir();
        var acao = AllMenus.Interface.ReadChoice(true);
        
        switch (acao.Value)
        {
            case "Atacar com Arma":
                int dano = CalcularDanoComCrit(Player.Forca, Player.Arma.Dano, Player.Destreza, inimigo.Defesa);
                inimigo.VidaAtual -= dano;
                Console.WriteLine($"Você causou {dano} de dano!");
                break;
                
            case "Usar Habilidade":
                UsarHabilidadeRaca(inimigo);
                break;
                
            case "Defender":
                Console.WriteLine("Você se defende! Reduz dano em 30%");
                break;
        }
        
        // Inimigo ataca
        int danoInimigo = CalcularDano(inimigo.Forca, inimigo.AtaquePorArma, 5);
        Player.VidaAtual -= danoInimigo;
        Console.WriteLine($"Inimigo causa {danoInimigo} de dano!");
        
        Console.ReadKey();
    }
    
    if (Player.VidaAtual > 0)
        Console.WriteLine("✅ VITÓRIA!");
    else
        Console.WriteLine("❌ DERROTA!");
}
```

---

## 6️⃣ Usar Habilidades Específicas por Raça

```csharp
public static void UsarHabilidadeRaca(Inimigo inimigo)
{
    switch (Player.RacaEscolhida)
    {
        case TipoRaca.Mago:
            int danoBolada = HabilidadeMagoBolada(Player.Inteligencia);
            inimigo.VidaAtual -= danoBolada;
            break;
            
        case TipoRaca.Cavaleiro:
            int danoGolpe = HabilidadeCavalheiroGolpe(Player.Forca);
            inimigo.VidaAtual -= danoGolpe;
            break;
            
        case TipoRaca.Necromante:
            HabilidadeNecromanteDrenar(inimigo, Player.Inteligencia);
            break;
            
        case TipoRaca.Goblin:
            int danoAtaque = HabilidadeGoblinAtaque(Player.Destreza);
            inimigo.VidaAtual -= danoAtaque;
            break;
    }
}
```

---

## 7️⃣ Sistema de Cooldown (Opcional)

Se quiser limitar o uso de habilidades:

```csharp
public class HabilidadeComCooldown
{
    public string Nome { get; set; }
    public int UsosPorBatalha { get; set; }
    public int UsosRestantes { get; set; }
    
    public bool PodeUsar() => UsosRestantes > 0;
    
    public void Usar()
    {
        if (PodeUsar())
            UsosRestantes--;
    }
    
    public void Resetar() => UsosRestantes = UsosPorBatalha;
}
```

---

## 📝 Resumo do Fluxo

```
1. Jogador escolhe raça → atributos definidos
2. Jogador entra em combate
3. Cada turno:
   a) Jogador escolhe ação (Atacar, Habilidade, Defender)
   b) Sistema calcula dano baseado em ATRIBUTOS + ARMA + RAÇA
   c) Se usar habilidade especial:
      - Verifica qual raça é
      - Executa habilidade específica
      - Aplica efeito (dano, cura, etc)
   d) Inimigo ataca
4. Batalha termina quando um morre
```

---

## 🚀 Próximos Passos

1. ✅ Criar classe `Inimigo.cs`
2. ✅ Expandir `Combate.cs` com cálculos de atributos
3. ✅ Criar método `UsarHabilidadeRaca()`
4. ✅ Integrar em `Fases.cs` com `ExecutarCombate()`
5. ✅ Testar cada raça em combate

**Exemplo de teste:**
```csharp
// Criar inimigo
var goblin = new Inimigo 
{ 
    Nome = "Goblin Selvagem",
    VidaMaxima = 30,
    VidaAtual = 30,
    Forca = 10,
    Defesa = 5
};

// Executar combate
Combate.ExecutarCombate(goblin);
```

---

## 💡 Dicas Importantes

- **Use os atributos**: Cada raça tem força em diferentes áreas (Mago = INT, Cavaleiro = FOR)
- **Balance**: Certifique-se que todas as raças têm chance justa de vencer
- **Feedback visual**: Use emojis e cores para tornar o combate mais divertido
- **Scaling**: Aumente a dificuldade dos inimigos conforme o jogo progride

Bom coding! 🎮
