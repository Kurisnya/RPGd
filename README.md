# Projeto RPG D&D

## Descrição:
O projeto RPG D&D consiste em um jogo de RPG em console desenvolvido em C#, inspirado em jogos roguelike e nos sistemas clássicos de RPG de mesa, Dungeons & Dragons. O objetivo do jogo é permitir que o jogador explore salas, gerencie equipamentos e inventário, evolua personagens e enfrente desafios através de mecânicas baseadas em atributos, itens, escolhas e combate.

Se inspirando em jogos como Stone Story RPG, Warsim the Realm of Aslona e Dwarf Fortress, o jogo foi pensado para funcionar inicialmente em ambiente de terminal/console, utilizando menus interativos e elementos visuais em ASCII para facilitar a navegação do usuário.

## Progressão de Níveis e Habilidades:
O jogador começa no nível 1 e ganha experiência (XP) ao concluir salas. Ao acumular XP suficiente, sobe de nível, aumentando vida máxima e força, sendo curado por completo e desbloqueando novas habilidades da sua raça/classe.

- Cada habilidade tem um nível mínimo para ser usada (classe `Habilidade`).
- O XP necessário para o próximo nível segue a fórmula `nível × 100`.
- A tela de Status mostra o nível, a barra de experiência e as habilidades já liberadas (e as ainda bloqueadas 🔒).

Detalhes completos em [PROGRESSAO.md](PROGRESSAO.md).

## Integrantes:
Augusto de Oliveira Amaral

Christian Augusto Soares Diniz

Jean Lucas Pereira de Assis

João Mateus Gomes Sales Barbosa

João Victor Batista Carneiro

Vitor Lucas Firmino Rezende
