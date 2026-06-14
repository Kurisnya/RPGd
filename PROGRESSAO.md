# Sistema de Progressão — Níveis e Habilidades

Documentação da funcionalidade **"Progressão com níveis e habilidades"**
(responsável: João Mateus Gomes Sales Barbosa).

Este documento descreve como o jogador evolui ao longo do jogo: ganha experiência,
sobe de nível e desbloqueia habilidades da sua raça/classe.

---

## 1. Visão geral

Cada personagem começa no **nível 1** com **0 de experiência (XP)**. Ao explorar e
concluir salas, o jogador ganha XP. Quando o XP acumulado atinge o necessário para o
próximo nível, ele **sobe de nível**, ficando mais forte e desbloqueando novas
habilidades.

```
Concluir sala  →  ganha XP  →  XP suficiente?  →  sobe de nível
                                                   ├─ + Vida máxima
                                                   ├─ + Força
                                                   ├─ cura total
                                                   └─ desbloqueia habilidade do nível
```

---

## 2. Experiência e curva de níveis

O XP necessário para o próximo nível é calculado por uma fórmula simples em
`Player.CalcularXpProximoNivel`:

```
XP necessário = nível atual × 100
```

| Nível atual | XP para o próximo nível |
|-------------|--------------------------|
| 1           | 100                      |
| 2           | 200                      |
| 3           | 300                      |
| ...         | ...                      |

- `Player.GanharExperiencia(int xp)` adiciona XP e, enquanto houver XP suficiente,
  chama `SubirDeNivel()` (um `while` permite subir **vários níveis de uma vez** se o
  ganho for grande).
- Atualmente o jogador ganha **50 de XP ao concluir uma sala** (em `Fases.cs`, quando
  a sala é marcada como concluída). Esse é o ponto de integração — quando o sistema de
  combate ficar pronto, basta chamar `Player.GanharExperiencia(...)` também ao derrotar
  inimigos.

---

## 3. O que muda ao subir de nível

Definido em `Player.SubirDeNivel()`:

| Ganho           | Valor por nível | Constante                |
|-----------------|-----------------|--------------------------|
| Vida máxima     | +5              | `Player.VidaPorNivel`    |
| Força           | +1              | `Player.ForcaPorNivel`   |
| Cura            | vida cheia      | —                        |

Além disso, o jogo avisa na tela quais habilidades foram desbloqueadas naquele nível.

---

## 4. Habilidades por nível

Cada raça (Mago, Cavaleiro, Necromante, Goblin) tem uma lista de habilidades, e **cada
habilidade exige um nível mínimo** para ser usada. As habilidades são representadas pela
classe `Habilidade`:

```csharp
public class Habilidade
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int NivelNecessario { get; set; }
}
```

Exemplo (Cavaleiro):

| Habilidade              | Nível necessário |
|-------------------------|------------------|
| Espada Divina Escanor   | 1                |
| Escudo Protetor         | 2                |
| Bigode Masculo          | 3                |

- `Player.HabilidadesDisponiveis()` retorna apenas as habilidades cujo
  `NivelNecessario <= Nivel` atual (as que o jogador já pode usar).
- Na tela de **Status**, habilidades ainda não alcançadas aparecem como bloqueadas
  (🔒) com o nível em que serão liberadas.

---

## 5. Como ver funcionando no jogo

1. Inicie o jogo e escolha uma raça.
2. Abra **Status**: você verá `NÍVEL: 1`, `EXP: 0/100` e as habilidades de nível maior
   que 1 marcadas como bloqueadas.
3. Vá em **Sala**, escolha **Graffiti** (pega a chave) e depois **Sair da Sala**:
   você recebe **+50 de XP**.
4. Repita até acumular 100 de XP — aparece a mensagem **★ NÍVEL UP!** e a habilidade
   do novo nível é desbloqueada.
5. Volte ao **Status** para conferir: nível maior, mais vida/força e a habilidade
   agora liberada.

---

## 6. Decisões de POO

A funcionalidade aplica os pilares de Orientação a Objetos pedidos no projeto:

- **Abstração:** a classe `Habilidade` representa o conceito de "habilidade" com apenas
  o que importa (nome, descrição, nível de desbloqueio).
- **Encapsulamento:** em `Player`, `Nivel`, `Experiencia` e `ExperienciaProximoNivel`
  têm `private set` — só podem ser alterados pelos métodos da classe
  (`GanharExperiencia` / `SubirDeNivel`), evitando estados inválidos.
- **Herança:** reutiliza a estrutura de raças existente (`DadosRaca`), agora com a
  lista de habilidades tipada como `List<Habilidade>`.
- **Polimorfismo:** `Habilidade` sobrescreve `ToString()` para exibir-se já formatada
  ("Nome (Nível X)").

---

## 7. Arquivos envolvidos

| Arquivo          | Papel na progressão                                            |
|------------------|---------------------------------------------------------------|
| `Habilidade.cs`  | Classe da habilidade (nome, descrição, nível necessário).     |
| `Player.cs`      | Nível, XP, `GanharExperiencia`, `SubirDeNivel`, status.       |
| `Racas.cs`       | Define as habilidades de cada raça e seus níveis.             |
| `Fases.cs`       | Concede XP ao concluir uma sala.                              |
