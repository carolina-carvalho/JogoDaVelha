using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_Linhas = 3;
            int num_Colunas = 3;
            int qtdCasas = num_Linhas * num_Colunas;
            int qtdjogadores = 2;
            string[] nome = new string[qtdjogadores];
            int[] VerificarJogada = new int[qtdCasas];
            int contJogadaGeral = 0;
            char[] casa = new char[qtdCasas];
            int i, jogada, verificar;
            int jogadaA = 0;
            int jogadaB = 0;
            bool finalizar = false;


            Console.WriteLine("Bem vindo ao jogo da velha");

            //Inserção de nome dos jogadores
            for (i = 0; i < qtdjogadores; i++)
            {
                Console.Write("Insira o nome do {0}º jogador: ", i + 1);
                nome[i] = Console.ReadLine();
            }

            //informações sobre como jogar
            Console.WriteLine("Abaixo imagem com a numeração das casas para que os jogadores possam ter conhecimento da numeração das posições.");
            Console.WriteLine("[ 1 ][ 2 ][ 3 ]");
            Console.WriteLine("[ 4 ][ 5 ][ 6 ]");
            Console.WriteLine("[ 7 ][ 8 ][ 9 ]");

            //entrando no jogo
            for (i = 0; i < qtdCasas && jogadaA != 15 && jogadaB != 15 && finalizar == false; i++)
            {
                if (i == 0 || i % 2 == 0) //jogador 1 joga nos números pares
                {
                    Console.WriteLine("Vez dx {0}", nome[0]);
                }
                else  //jogador 2 joga nos números ímpares
                {
                    Console.WriteLine("Vez dx {0}", nome[1]);
                }

                //jogador "x" determina sua jogada
                do
                {
                    Console.Write("Insira o número da casa que deseja posicionar sua jogada: ");
                    jogada = int.Parse(Console.ReadLine());
                } while (jogada < 1 || jogada > 9);

                VerificarJogada[contJogadaGeral] = jogada; //iniciando a verificação das jogadas

                for (verificar = 0; verificar < qtdCasas; verificar++) //fazendo rodar para conferência de todas as casas já preenchidas
                {
                    if (verificar != contJogadaGeral) //só entra na verificação (de fato) se as duas variáveis não são iguais, já que eu comparo uma com a outra
                    {
                        if (VerificarJogada[contJogadaGeral] == VerificarJogada[verificar]) //caso as duas casas comparadas já tenham valores, entra no if para exibir msg de erro
                        {
                            Console.WriteLine("Você indicou uma casa já preenchida.");
                            do
                            {
                                Console.Write("Insira o número da casa que deseja posicionar sua jogada: "); //solicita nova jogada
                                jogada = int.Parse(Console.ReadLine());
                            } while (jogada < 1 || jogada > 9);
                        }
                    }
                }
                contJogadaGeral++; //somas um no contador geral pós verificação


                //preenchendo as casa para fins visuais
                if (i == 0 || i % 2 == 0)  //jogador 1
                {
                    switch (jogada)
                    {
                        case 1:
                            casa[0] = 'x';
                            break;
                        case 2:
                            casa[1] = 'x';
                            break;
                        case 3:
                            casa[2] = 'x';
                            break;
                        case 4:
                            casa[3] = 'x';
                            break;
                        case 5:
                            casa[4] = 'x';
                            break;
                        case 6:
                            casa[5] = 'x';
                            break;
                        case 7:
                            casa[6] = 'x';
                            break;
                        case 8:
                            casa[7] = 'x';
                            break;
                        case 9:
                            casa[8] = 'x';
                            break;
                    }
                }

                else //jogador 2
                {
                    switch (jogada)
                    {
                        case 1:
                            casa[0] = 'o';
                            break;
                        case 2:
                            casa[1] = 'o';
                            break;
                        case 3:
                            casa[2] = 'o';
                            break;
                        case 4:
                            casa[3] = 'o';
                            break;
                        case 5:
                            casa[4] = 'o';
                            break;
                        case 6:
                            casa[5] = 'o';
                            break;
                        case 7:
                            casa[6] = 'o';
                            break;
                        case 8:
                            casa[7] = 'o';
                            break;
                        case 9:
                            casa[8] = 'o';
                            break;
                    }
                }

                //demonstrando o preenchimento visual
                Console.WriteLine("[ {0} ][ {1} ][ {2} ]", casa[0], casa[1], casa[2]);
                Console.WriteLine("[ {0} ][ {1} ][ {2} ]", casa[3], casa[4], casa[5]);
                Console.WriteLine("[ {0} ][ {1} ][ {2} ]", casa[6], casa[7], casa[8]);

                //iniciando conferência de possibilidade de vitória.
                //JOGADOR 1

                if (contJogadaGeral >= 4) //só há necessidade de verificar se alguém ganhou após cinco jogadas, pois assim o jogador 1 já tera preenchido três casas, possibilitando uma combinação vencedora
                {

                    if (casa[0] == 'x') //partindo da casa 1
                    {
                        if (casa[1] == 'x') //horizontal
                        {
                            if (casa[2] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                        if (casa[4] == 'x') //diagonal
                        {
                            if (casa[8] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                        if (casa[3] == 'x') //vertical
                        {
                            if (casa[6] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                    }

                    if (casa[2] == 'x')  //partindo da casa 3
                    {
                        if (casa[4] == 'x') // diagonal
                        {
                            if (casa[6] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                        if (casa[5] == 'x') // vertical
                        {
                            if (casa[8] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                    }

                    if (casa[3] == 'x') //partindo da casa 4
                    {
                        if (casa[4] == 'x') // horizontal
                        {
                            if (casa[5] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                    }

                    if (casa[6] == 'x') //partindo da casa 7
                    {
                        if (casa[7] == 'x') //diagonal
                        {
                            if (casa[8] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                    }

                    if (casa[1] == 'x') //partindo da casa 2
                    {
                        if (casa[4] == 'x') //vertical
                        {
                            if (casa[7] == 'x')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaA = 15;
                            }
                        }
                    }

                    //jogador 2
                    if (casa[0] == 'o') //partindo da casa 1
                    {
                        if (casa[1] == 'o') //horizontal
                        {
                            if (casa[2] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                        if (casa[4] == 'o') //diagonal
                        {
                            if (casa[8] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                        if (casa[3] == 'o') //vertical
                        {
                            if (casa[6] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                    }

                    if (casa[2] == 'o')  //partindo da casa 3
                    {
                        if (casa[4] == 'o') // diagonal
                        {
                            if (casa[6] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                        if (casa[5] == 'o') // vertical
                        {
                            if (casa[8] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                    }

                    if (casa[3] == 'o') //partindo da casa 4
                    {
                        if (casa[4] == 'o') // horizontal
                        {
                            if (casa[5] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                    }

                    if (casa[6] == 'o') //partindo da casa 7
                    {
                        if (casa[7] == 'o') //diagonal
                        {
                            if (casa[8] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                    }

                    if (casa[1] == 'o') //partindo da casa 2
                    {
                        if (casa[4] == 'o') //vertical
                        {
                            if (casa[7] == 'o')
                            {
                                Console.WriteLine("{0} venceu", nome[0]);
                                jogadaB = 15;
                            }
                        }
                    }

                }
                if (contJogadaGeral == 7)
                {
                    Console.WriteLine("Velha");
                    finalizar = true;
                }



                Console.ReadKey();
            }
        }
    }
}
