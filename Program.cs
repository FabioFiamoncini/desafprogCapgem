using System;
using System.Collections.Generic;

namespace DesProgCapGem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Candidato: FÁBIO FIAMONCINI PASTÓRIO

            // Desafio de Programação - Academia Capgemini

            // VARIÁVEIS
            bool loopDesafio = true;
            int escolha = new int();          

            // DESAFIO
            Console.WriteLine("DESAFIO DE PROGRAMAÇÃO - ACADEMIA CAPGEMINI");

            while (loopDesafio)
            {

                Console.WriteLine("\r\n=================\r\n");
                Console.WriteLine("Questão (1) | Questão (2) | Questão (3) | Sair (9)\r\n");
                Console.WriteLine("Escolha a questão pelo seu número, ou digite '9' para encerrar o programa:");

                try
                {
                    escolha = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\r\nFormato inválido de caracter, digite um número!");
                }

                if (escolha == 9)
                {
                    Console.WriteLine("\r\nO programa foi encerrado.");
                    loopDesafio = false;
                }

                else if (escolha == 1)            // QUESTÃO 1
                {
                    Console.WriteLine("\r\nDigite um número para criar um triângulo: ");

                    int q1 = 0;

                    try
                    {
                        q1 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\r\nFormato inválido de caracter, digite um número!");
                    }
                    Console.WriteLine();

                    Questao01(q1);

                }

                else if (escolha == 2)            // QUESTÃO 2
                {
                    Console.WriteLine("\r\nInsira uma senha: ");

                    string pw = Console.ReadLine();

                    Questao02(pw);

                }

                else if (escolha == 3)            // QUESTÃO 3
                {
                    Console.WriteLine("\r\nDigite uma palavra: ");

                    string palavra = Console.ReadLine();

                    Questao03(palavra);

                }

                else
                {
                    Console.WriteLine("\r\nEscolha inválida! Voltando ao menu.");
                }
            }    
        }
            // MÉTODOS
        public static void Questao01(int valor)
        {
            for (int i = 1; i <= valor; i++)
            {
                for (int j = (valor - i); j > 0; j--)
                {
                    Console.Write(" ");
                }

                for (int k = i; k > 0; k--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void Questao02(string senha)
        {
            if (senha.Length < 6)
            {
                int charLeft = 6 - senha.Length;
                Console.WriteLine("\r\nAinda falta(m) no mínimo " + charLeft + " caractere(s) para sua senha ser considerada forte.\n\r");
            }
            else
            {
                Console.WriteLine("\r\nA senha possui o mínimo de caracteres necessários para ser considerada forte.\r\n");
            }
        }

        public static void Questao03(string palavra)
        {
            Dictionary<string, int> subs = new Dictionary<string, int>();

            for (int i = 0; i < palavra.Length; i++)
            {
                for (int j = i; j < palavra.Length; j++)  // Loops para montar as substrings
                {
                    char[] letrasArray = palavra.Substring(i, (j - i) + 1).ToCharArray();

                    Array.Sort(letrasArray);        // Organiza substrings com letras iguais para formar a mesma chave

                    string stringLetras = new string(letrasArray);

                    if (subs.ContainsKey(stringLetras) == false)    // Não havendo registro desta chave, adiciona na var dictionary
                    {
                        subs.Add(stringLetras, 1);
                    }
                    else                                        // Havendo registro, adiciona +1 na contagem do campo valor da chave
                    {
                        subs[stringLetras] += 1;
                    }
                }
            }

            int pares = 0;

            foreach (string sub in subs.Keys)           // Loop para somar as ocorrências de cada chave,
            {                                           // chaves com 2 ou mais ocorrências caracterizam um par de anagrama,
                int freqSubs = subs[sub];               // aumentando em +1 a contagem de pares da palavra

                if (freqSubs >= 2)
                {
                    pares += 1;
                }
            }

            Console.WriteLine("Número de pares de anagramas na palavra: " + pares);
        }
    }
}
