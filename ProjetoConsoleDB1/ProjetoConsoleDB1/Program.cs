using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsoleDB1
{
    public class Program
    {
        static void Main(string[] args)
        {


            var flagExercicio = "1";
            var flagPrograma = "1";

            while(flagPrograma != "0")
            {
                Console.WriteLine("ESCOLHA UM EXERCICIO");
                 Console.WriteLine("1. PARA EXERCICIO 1");
                 Console.WriteLine("2. PARA EXERCICIO 2");
                 Console.WriteLine("3. PARA EXERCICIO 3");
                 flagExercicio = Console.ReadLine();
                switch (flagExercicio)
                {
                    case "1":
                        Console.WriteLine(Exercicio1(13));
                        Console.WriteLine(Exercicio1(35655));

                        var maior_sequencia = 1;
                        for (int i = 1; i <= 1000000; i++)
                        {

                            if (Exercicio1(i) > maior_sequencia)
                            {
                                maior_sequencia = i;
                            }
                        }

                        Console.WriteLine("O número com maior sequencia no exercício 1 = " + maior_sequencia + " Com " + Exercicio1(maior_sequencia) + " termos.");
                        break;
                    case "2":
                        int[] prova1 = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
                        int[] prova2 = { 3,5,7,9,11,11,15,9,17,1123 };
                        int[] prova3 = { 2, 8, 34, 144 };
                        int[] prova4 = { 5, 117, 51, 69, 3, 99, 1021, 289, 77, 33, 991 };
                        Console.WriteLine("Para o array informado todos os elementos são impares? Resposta " + (Exercicio2(prova1) ? "Sim " : "Não ") +"{ 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 }");
                        Console.WriteLine("Para o array informado todos os elementos são impares? Resposta " + (Exercicio2(prova2) ? "Sim " : "Não ") +"{ 3,5,7,9,11,11,15,9,17,1123 }");
                        Console.WriteLine("Para o array informado todos os elementos são impares? Resposta " + (Exercicio2(prova3) ? "Sim " : "Não ") +"{ 2, 8, 34, 144 }");
                        Console.WriteLine("Para o array informado todos os elementos são impares? Resposta " + (Exercicio2(prova4) ? "Sim " : "Não ") + "{ 5, 117, 51, 69, 3, 99, 1021, 289, 77, 33, 991 }");
                        break;
                    case "3":
                         int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
                         int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

                         int[] terceiroArray = { 8,2,3,1,5,6,7,4,78,12 };
                         int[] quartoArray = { 1,2,3,4,5,6,12 };
                        var resultado1 = Exercicio3(primeiroArray,segundoArray);
                        Console.Write("Elementos que não estão no segundo array");

                        foreach (var item in resultado1)
                        {
                            Console.Write("\t " + item);
                        }

                        var resultado2 = Exercicio3(terceiroArray, quartoArray);

                        Console.Write("\n");
                        Console.Write("Elementos que não estão no segundo array");
                        foreach (var item in resultado2)
                        {
                            
                            Console.Write("\t " + item);
                        }

                        break;
                }
                Console.WriteLine("\n \n Digite 0 para sair, ou 1 para continuar");
                flagPrograma = Console.ReadLine();
            }
           
           
        }

        public static int Exercicio1(int numero)
        {
            //1. Para definir uma sequência a partir de um número inteiro o positivo, temos as seguintes
            //regras:
            // Se n é par, o próximo valor é n/2
            // Se n é ímpar, o próximo valor é 3n + 1
            //Usando a regra acima e iniciando com o número 13, geramos a seguinte sequência:
            //13  40  20  10  5  16  8  4  2  1
            //Podemos ver que esta sequência (iniciando em 13 e terminando em 1) contém 10 termos.
            //Embora ainda não tenha sido provado (este problema é conhecido como Problema de
            //Collatz), sabemos que com qualquer número que você começar, a sequência resultante
            //chega no número 1 em algum momento.
            //Desenvolva uma aplicação que descubra qual o número inicial entre 1 e 1 milhão que
            //produz a maior sequência.

            //DECLARE VARIAVEIS
            var contador = 1;

            if (numero < 0)
            {
                //Exception, numero deve inteiro o positivo

                throw new Exception("Permitido somente número positivo inteiro.");
            }
            else
            {
                while (numero > 1)
                {
                    //Par
                    if (numero % 2 == 0)
                    {
                        numero = (numero / 2);
                    }
                    else//Impar
                    {
                        numero = (3 * numero) + 1;
                    }

                    contador += 1;
                }

            }

            return contador;

        }

        public static bool Exercicio2(int[] numeros)
        {
            // Utilizando LINQ, elabore um método que defina se o seguinte array contém somente
            // números ímpares e demonstre o resultado no console:
            // int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            var verificador = false;

            verificador = !numeros.Any(x => x % 2 == 0);

            return verificador;
        }

        public static List<int> Exercicio3(int[] lista1, int[] lista2)
        {
           // Utilizando LINQ, elabore um método que traga somente os números do primeiro array que
           // não estejam contidos no segundo array e demonstre o resultado no console:
           // int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
           // int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };


            var listaRetorno = new List<int>();


            listaRetorno = lista1.Where(x => lista2.All(y => y != x)).ToList();

            return listaRetorno;
        }
    }
}
