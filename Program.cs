using Jogo;
using JogoDaVelha;
using System.Collections.Generic;
using System.Linq;
using System;




class Program
{
    public static void Main(string[] args)
    {

   
        Console.WriteLine("-_-_-_-_-_-_-_-_-Jogo da velha-_-_-_-_-_-_-_-_-");
        Console.WriteLine();
        Console.WriteLine("-----MODOS DE JOGO-----");       
        Console.WriteLine();
        Console.WriteLine("1 - Jogador vs Jogador");
        Console.WriteLine("2 - Jogador vs Computador");
        Console.WriteLine();
        Console.WriteLine("Digite o modo de jogo desejado: ");
        int ModoJogo = int.Parse(Console.ReadLine());



        if(ModoJogo == 2){
            
            Console.Clear();
            Console.WriteLine("Digite seu nome: ");
            string NomeJogador = Console.ReadLine();
            Console.WriteLine("Digite o nome do computador: ");
            string NomeMaquina = Console.ReadLine();
            
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
      

        //bool
            bool JogadorVenceu = false;
            bool MaquinaVenceu = false;
        
        Char resposta = 's';    
         do{
             Console.Clear();


        Jogador jogador = new Jogador('X', NomeJogador);
        Maquina maquina = new Maquina('O', NomeMaquina);
        JogoVelha jogo = new JogoVelha();


        //Listas     
        List<int> JogadasJogador = new List<int>();
        List<int> JogadasMaquina = new List<int>();
        Random random = new Random();


        int JogadaMaquina1; 
        int JogadaMaquina2;
        int JogadaMaquina3;
        int JogadaMaquina4;
        // tabuleiro
        foreach (int jogadas in JogadasJogador)
        {
        int linha = (jogadas - 1) / 3 ; 
        int coluna= (jogadas - 1) % 3 ;
        jogo.Tabuleiro[linha, coluna] = 'X';
        }
        foreach (int jogadasM in JogadasMaquina)
        {
        int linhaM = (jogadasM - 1) / 3;
        int colunaM = (jogadasM -1) % 3;
        jogo.Tabuleiro[linhaM, colunaM] = 'O';
        }    
        //ganhador
        
        bool vitoriaJogador(List<int> jogadas) =>
            new[]
            {
                new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
                new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
                new[] {1,5,9}, new[] {3,5,7}
            }.Any(c => c.All(j => jogadas.Contains(j)));


        bool vitoriaMaquina(List<int> jogadas) =>
        new[]
        {
            new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9},
            new[] {1,4,7}, new[] {2,5,8}, new[] {3,6,9},
            new[] {1,5,9}, new[] {3,5,7}
        }.Any(c => c.All(j => jogadas.Contains(j)));

        //jogada dos caba ai
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
        int JogadaJogador1 = int.Parse(Console.ReadLine());
        JogadasJogador.Add(JogadaJogador1);
            JogadorVenceu = vitoriaJogador(JogadasJogador);

    
         do{
        JogadaMaquina1 = new Random().Next(1, 10);
            }while  (JogadaMaquina1 == JogadaJogador1 );
        JogadasMaquina.Add(JogadaMaquina1);
          MaquinaVenceu = vitoriaMaquina(JogadasMaquina);



        if (JogadorVenceu == false && MaquinaVenceu == false)
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
            jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
            Console.WriteLine("Tabuleiro atual:");
            jogo.MostrarTabuleiro();

            Console.Write("Digite aonde você deseja jogar: ");
            int JogadaJogador2 = int.Parse(Console.ReadLine());
            JogadasJogador.Add(JogadaJogador2);
            JogadorVenceu = vitoriaJogador(JogadasJogador);

            
           do{
            JogadaMaquina2 = new Random().Next(1, 10);
               }while( JogadaMaquina2 == JogadaJogador1 || JogadaMaquina2 == JogadaJogador2|| JogadaMaquina1 == JogadaMaquina2);
            JogadasMaquina.Add(JogadaMaquina2);
              MaquinaVenceu = vitoriaMaquina(JogadasMaquina);


            
            if (JogadorVenceu == false && MaquinaVenceu == false)
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
                jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
                jogo.MostrarTabuleiro();

                Console.Write("Digite aonde você deseja jogar: ");
                int JogadaJogador3 = int.Parse(Console.ReadLine());
                JogadasJogador.Add(JogadaJogador3);
                JogadorVenceu = vitoriaJogador(JogadasJogador);

                
                do{
                JogadaMaquina3 = new Random().Next(1, 10);
                    
                }while(JogadaMaquina3 == JogadaJogador1 || JogadaMaquina3 == JogadaJogador2 || JogadaMaquina3 == JogadaJogador3 || JogadaMaquina3 == JogadaMaquina2 || JogadaMaquina3 == JogadaMaquina1);
                JogadasMaquina.Add(JogadaMaquina3);        
                  MaquinaVenceu = vitoriaMaquina(JogadasMaquina);


                
                if (JogadorVenceu == false && MaquinaVenceu == false)
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
                    jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
                    Console.WriteLine("Tabuleiro atual:");
                    jogo.MostrarTabuleiro();

                    Console.Write("Digite aonde você deseja jogar: ");
                    int JogadaJogador4 = int.Parse(Console.ReadLine());
                    JogadasJogador.Add(JogadaJogador4);
                    JogadorVenceu = vitoriaJogador(JogadasJogador);


                    do{
                    JogadaMaquina4 = new Random().Next(1, 10);
                        }while(JogadaMaquina4 == JogadaJogador1 || JogadaMaquina4 == JogadaJogador2 || JogadaMaquina4 == JogadaJogador3 || JogadaMaquina4 == JogadaJogador4 ||JogadaMaquina4 == JogadaMaquina3 || JogadaMaquina4 == JogadaMaquina2 || JogadaMaquina4 == JogadaMaquina1);
                    JogadasMaquina.Add(JogadaMaquina4);
                      MaquinaVenceu = vitoriaMaquina(JogadasMaquina);


                    if (JogadorVenceu == false && MaquinaVenceu == false)
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
                        jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
                        Console.WriteLine("Tabuleiro atual:");
                        jogo.MostrarTabuleiro();

                        Console.Write("Digite aonde você deseja jogar: ");
                        int JogadaJogador = int.Parse(Console.ReadLine());
                        JogadasJogador.Add(JogadaJogador);
                        JogadorVenceu = vitoriaJogador(JogadasJogador);

                    }
                }
            }
        }
        if(JogadorVenceu == true)
        {
            Console.Clear();
            jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
            jogo.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"O jogador {NomeJogador} venceu!!!");
            Console.WriteLine("----------------------------------");

        }
        if(MaquinaVenceu == true)
        {
            Console.Clear();
            jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
            jogo.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"O/A {NomeMaquina} venceu!!!");
            Console.WriteLine("----------------------------------");

        }
             if (JogadorVenceu == false && MaquinaVenceu == false)
             {
            Console.Clear();
            jogo.AtualizarTabuleiro(JogadasJogador, JogadasMaquina);
            jogo.MostrarTabuleiro();
            Console.WriteLine("----------------------------------");

            
            Console.WriteLine("Empate!!!");
            Console.WriteLine("----------------------------------");

        }
             Console.WriteLine("Deseja jogar novamente? (s/n): ");
             string entrada = Console.ReadLine();
             resposta = string.IsNullOrEmpty(entrada) ? 'n' : entrada.ToLower()[0];

             }while (resposta == 's');
             Console.WriteLine("Obrigado por jogar!!");

        
    }
}
    }