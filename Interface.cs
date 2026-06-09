namespace Interface;

using Jogo;
using JogoMaquina;
using JogoDaVelha;


public class InterfaceJogo
{

    public static void InterfaceInicial()
    {
        Console.WriteLine("-_-_-_-_-_-_-_-_-Jogo da velha-_-_-_-_-_-_-_-_-");
        Console.WriteLine();
        Console.WriteLine("-----MODOS DE JOGO-----");
        Console.WriteLine();
        Console.WriteLine("1 - Jogador vs Jogador");
        Console.WriteLine("2 - Jogador vs Computador");
        Console.WriteLine();
        Console.WriteLine("Digite o modo de jogo desejado: ");
        int ModoJogo = int.Parse(Console.ReadLine()!);

        switch (ModoJogo)
        {
            case 1:
                ModoJogoJogador.JogadorVSJogador();
                break;
            case 2:
            JogoContraMaquina.JogoVSMaquina();
                break;

        }
    }



    public static void EscolhaJogada()
    {
        Console.Clear();
        Console.WriteLine("-_-_-_-_-_-_-_-_-Jogo da velha-_-_-_-_-_-_-_-_-");
        Console.WriteLine("VEJA COMO ESCOLHER ONDE DESEJA JOGAR: ");
        Console.WriteLine("              1|2|3");
        Console.WriteLine("              -+-+-");
        Console.WriteLine("              4|5|6");
        Console.WriteLine("              -+-+-");
        Console.WriteLine("              7|8|9");
        Console.WriteLine("VOCÊ É O 'X' E O COMPUTADOR É O 'O'");
        Console.WriteLine("----------------------------------");


    }



}




