namespace JogoDaVelha;
using Jogo;
using JogoMaquina;
using JogoDaVelha;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.ConstrainedExecution;


public class JogoVelha
{
  
    public char[,] Tabuleiro = new char[3, 3];

    public JogoVelha()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)

                Tabuleiro[i, j] = ' ';
        
        }
    }


  public void MostrarTabuleiro()
  {
      for (int i = 0; i < 3; i++)
      {
          for (int j = 0; j < 3; j++)
          {
              Console.Write(Tabuleiro[i, j]);

              if (j < 2)
                  Console.Write(" | ");
          }

          Console.WriteLine();

          if (i < 2)
              Console.WriteLine("--+---+--");
              
      }
  }
  public void AtualizarTabuleiro(List<int> jogadasJogador, List<int> jogadasMaquina)
  {
      // limpa o tabuleiro
      for (int i = 0; i < 3; i++)
          for (int j = 0; j < 3; j++)
              Tabuleiro[i, j] = ' ';

      // jogador
      foreach (int jogada in jogadasJogador)
      {
          int linha = (jogada - 1) / 3;
          int coluna = (jogada - 1) % 3;
          Tabuleiro[linha, coluna] = 'X';
      }

      // máquina
      foreach (int jogada in jogadasMaquina)
      {
          int linha = (jogada - 1) / 3;
          int coluna = (jogada - 1) % 3;
          Tabuleiro[linha, coluna] = 'O';
      }

      
  }
}


