# RPGd

## Descrição

RPGd é um jogo de RPG desenvolvido em C# como projeto da disciplina de Programação Orientada a Objetos. O jogo é executado em console e permite ao jogador escolher uma raça, explorar ambientes, enfrentar monstros, coletar equipamentos e evoluir seu personagem.

## Requisitos

Antes de compilar o projeto, certifique-se de possuir:

* .NET SDK 6.0 ou superior instalado;
* Sistema operacional Windows, Linux ou macOS;
* Terminal ou prompt de comando.

## Estrutura do Projeto

Os principais arquivos do projeto são:

* Program.cs – ponto de entrada da aplicação;
* Player.cs – gerenciamento do jogador;
* Racas.cs – definição das raças disponíveis;
* Combate.cs – sistema de combate;
* Fases.cs – gerenciamento das fases e progressão;
* Itens.cs e ClassesDeItens.cs – gerenciamento de itens e equipamentos.

## Compilação

1. Abra um terminal na pasta raiz do projeto.
2. Execute o comando:

bash
dotnet build


O .NET realizará a restauração das dependências e a compilação do projeto.

## Execução

Após a compilação, execute:

bash
dotnet run


Ou, caso deseje executar o binário compilado:

bash
dotnet bin/Debug/net6.0/RPGd.dll


> O caminho pode variar de acordo com a versão do .NET utilizada.

## Funcionalidades

* Escolha de diferentes raças;
* Sistema de combate baseado em atributos;
* Inventário e equipamentos;
* Habilidades específicas para cada classe;
* Progressão por fases;
* Monstros com comportamentos distintos;
* Utilização de conceitos de Programação Orientada a Objetos.

## Conceitos de POO Aplicados

* Encapsulamento;
* Herança;
* Polimorfismo;
* Abstração.
  
## Integrantes:
Augusto de Oliveira Amaral

Christian Augusto Soares Diniz

Jean Lucas Pereira de Assis

João Mateus Gomes Sales Barbosa

João Victor Batista Carneiro

Vitor Lucas Firmino Rezende
