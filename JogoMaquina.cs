namespace JogoMaquina;

using Jogo;
using JogoDaVelha;
using System.Collections.Generic;
using System.Linq;
using System;

public class JogoContraMaquina
{
    public static void ModoFacil()
    {

Console.Clear();
Console.WriteLine("Digite seu nome: ");
string NomeJogador = Console.ReadLine()!;
Console.WriteLine("Digite o nome do computador: ");
string NomeMaquina = Console.ReadLine()!;

Char resposta = 's';
do
{
    Console.Clear();

    JogoVelha J = new JogoVelha();


    bool JogadorVenceu = false;
    bool MaquinaVenceu = false;


    Jogador jogador = new Jogador('X', NomeJogador);
    Maquina maquina = new Maquina('O', NomeMaquina);
    JogoVelha jogo = new JogoVelha();

    //Listas     
    List<int> JogadasJogador = new List<int>();
    List<int> JogadasMaquina = new List<int>();
    Random random = new Random();
    int JogadaAleatoriaMaquina;


    // tabuleiro
    foreach (int jogadas in JogadasJogador)
    {
        int linha = (jogadas - 1) / 3;
        int coluna = (jogadas - 1) % 3;
        jogo.Tabuleiro[linha, coluna] = 'X';
    }
    foreach (int jogadasM in JogadasMaquina)
    {
        int linhaM = (jogadasM - 1) / 3;
        int colunaM = (jogadasM - 1) % 3;
        jogo.Tabuleiro[linhaM, colunaM] = 'O';
    }
    //ganhador

    bool vitoriaJogador(List<int> JogadasJogador) =>
        new[]
        {
                new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
                new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
                new[] {1,5,9}, new[] {3,5,7}
        }.Any(c => c.All(j => JogadasJogador.Contains(j)));


    bool vitoriaMaquina(List<int> jogadas) =>
    new[]
    {
            new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
            new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
            new[] {1,5,9}, new[] {3,5,7}
    }.Any(c => c.All(j => jogadas.Contains(j)));

    //JOGADA DOS JOGADORES


    while (!JogadorVenceu &&
           !MaquinaVenceu &&
JogadasJogador.Count + JogadasMaquina.Count < 9)
    {
        int JogadaJogador = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("*****Jogo da velha*****");
            Console.WriteLine("Veja como escolher onde você deseja jogar: {1-9}");
            Console.WriteLine("1|2|3");
            Console.WriteLine("-+-+-");
            Console.WriteLine("4|5|6");
            Console.WriteLine("-+-+-");
            Console.WriteLine("7|8|9");
            Console.WriteLine("Você é o X e o computador é o O");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Tabuleiro atual:");
            jogo.MostrarTabuleiro();

            Console.Write("Digite aonde você deseja jogar: ");
            while (!int.TryParse(Console.ReadLine(), out JogadaJogador))
            {
                Console.WriteLine("Digite apenas números!");
            }
        } while (JogadasJogador.Contains(JogadaJogador) || JogadasMaquina.Contains(JogadaJogador));




        JogadasJogador.Add(JogadaJogador);
        JogadorVenceu = vitoriaJogador(JogadasJogador);

        if (JogadasJogador.Count + JogadasMaquina.Count < 9)
        {
            do
            {

                JogadaAleatoriaMaquina = random.Next(1, 10);

            } while (JogadasJogador.Contains(JogadaAleatoriaMaquina) || JogadasMaquina.Contains(JogadaAleatoriaMaquina));

            MaquinaVenceu = vitoriaMaquina(JogadasMaquina);
            JogadasMaquina.Add(JogadaAleatoriaMaquina);


            jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
        }

    }
    if (JogadorVenceu == true)
    {
        Console.Clear();
        jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
        jogo.MostrarTabuleiro();
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"O jogador {NomeJogador} venceu!!!");
        Console.WriteLine("----------------------------------");

    }
    else if (MaquinaVenceu == true)
    {
        Console.Clear();
        jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
        jogo.MostrarTabuleiro();
        Console.WriteLine("----------------------------------");

        Console.WriteLine($"O/A {NomeMaquina} venceu!!!");
        Console.WriteLine("----------------------------------");

    }
    else if (JogadorVenceu == false && MaquinaVenceu == false)
    {
        Console.Clear();
        jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
        jogo.MostrarTabuleiro();
        Console.WriteLine("----------------------------------");


        Console.WriteLine("Empate!!!");
        Console.WriteLine("----------------------------------");

    }
    Console.WriteLine("Deseja jogar novamente? (s/n): ");
    string entrada = Console.ReadLine()!;
    resposta = string.IsNullOrEmpty(entrada) ? 'n' : entrada.ToLower()[0];

} while (resposta == 's');
Console.WriteLine("Obrigado por jogar!!");



    }

}
