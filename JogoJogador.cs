using Jogo;
using JogoMaquina;
using JogoDaVelha;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.ConstrainedExecution;
using Interface;

public class ModoJogoJogador
{
    public static void JogadorVSJogador()
    {
        
Console.WriteLine("Digite o nome do jogador 1: ");
string NomeJogador1 = Console.ReadLine()!;
Console.WriteLine("Digite o nome do jogador 2: ");
string NomeJogador2 = Console.ReadLine()!;

Char resposta = 's';
do
{
    Console.Clear();

    JogoVelha J = new JogoVelha();
    Jogador1 jogador1 = new Jogador1('X', NomeJogador1);
    Jogador2 jogador2 = new Jogador2('O', NomeJogador2);

    bool Jogador1_Venceu = false;
    bool Jogador2_Venceu = false;

    List<int> JogadaJogador1 = new List<int>();
    List<int> JogadaJogador2 = new List<int>();

    //ganhador

    bool vitoriaJogador1(List<int> JogadaJogador1) =>
        new[]
        {
                new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
                new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
                new[] {1,5,9}, new[] {3,5,7}
        }.Any(c => c.All(j => JogadaJogador1.Contains(j)));


    bool vitoriaJogador2(List<int> JogadaJogador2) =>
    new[]
    {
            new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
            new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
            new[] {1,5,9}, new[] {3,5,7}
    }.Any(c => c.All(j => JogadaJogador2.Contains(j)));


    while (!Jogador1_Venceu &&
           !Jogador2_Venceu &&
           JogadaJogador1.Count + JogadaJogador2.Count < 9)
    {
        int EscolhaJogador1 = 0;
        int EscolhaJogador2 = 0;


        Console.Clear();
        Console.WriteLine("*****Jogo da velha*****");
        Console.WriteLine("Veja como escolher onde você deseja jogar: {1-9}");
        Console.WriteLine("1|2|3");
        Console.WriteLine("-+-+-");
        Console.WriteLine("4|5|6");
        Console.WriteLine("-+-+-");
        Console.WriteLine("7|8|9");
        Console.WriteLine($"Vez do Jogador {NomeJogador1}!! (X)");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Tabuleiro atual:");
        J.MostrarTabuleiro();

        Console.Write("Digite aonde você deseja jogar: ");

        while (!int.TryParse(Console.ReadLine(), out EscolhaJogador1))
        {
            Console.WriteLine("Digite apenas números!");
        }
        JogadaJogador1.Add(EscolhaJogador1);
        Jogador1_Venceu = vitoriaJogador1(JogadaJogador1);
        J.AtualizarTabuleiro(JogadaJogador1, JogadaJogador2);




        if (!Jogador1_Venceu &&
    !Jogador2_Venceu &&
    JogadaJogador1.Count + JogadaJogador2.Count < 9)
        {
            Console.Clear();
            Console.WriteLine("*****Jogo da velha*****");
            Console.WriteLine("Veja como escolher onde você deseja jogar: {1-9}");
            Console.WriteLine("1|2|3");
            Console.WriteLine("-+-+-");
            Console.WriteLine("4|5|6");
            Console.WriteLine("-+-+-");
            Console.WriteLine("7|8|9");
            Console.WriteLine($"Vez do Jogador {NomeJogador2}!! (O)");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Tabuleiro atual:");
            J.MostrarTabuleiro();

            Console.Write("Digite aonde você deseja jogar: ");

            while (!int.TryParse(Console.ReadLine(), out EscolhaJogador2))
            {
                Console.WriteLine("Digite apenas números!");
            }
            JogadaJogador2.Add(EscolhaJogador2);
            Jogador2_Venceu = vitoriaJogador2(JogadaJogador2);
            J.AtualizarTabuleiro(JogadaJogador1, JogadaJogador2);



        }

        if (Jogador1_Venceu == true)
        {
            Console.Clear();
            J.AtualizarTabuleiro(JogadaJogador1, JogadaJogador2);
            J.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"O jogador {NomeJogador1} venceu!!!");
            Console.WriteLine("----------------------------------");

        }
        else if (Jogador2_Venceu == true)
        {
            Console.Clear();
            J.AtualizarTabuleiro(JogadaJogador1, JogadaJogador2);
            J.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"O/A {NomeJogador2} venceu!!!");
            Console.WriteLine("----------------------------------");

        }
        else if (Jogador1_Venceu == false && Jogador2_Venceu == false)
        {
            Console.Clear();
            J.AtualizarTabuleiro(JogadaJogador1, JogadaJogador2);
            J.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");


            Console.WriteLine("Empate!!!");
            Console.WriteLine("----------------------------------");

        }

    }
    Console.WriteLine("Deseja jogar novamente? (s/n): ");
    string entrada = Console.ReadLine()!;
    resposta = string.IsNullOrEmpty(entrada) ? 'n' : entrada.ToLower()[0];

} while (resposta == 's');
Console.WriteLine("Obrigado por jogar!!");


    }
}