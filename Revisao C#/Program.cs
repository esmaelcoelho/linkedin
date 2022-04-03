using System;

namespace Revisao //minha class
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")//Toupper determina se a string é minuscula e Maiusculo fazendo assim que verifique as 2 opções 
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o Nome do Aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");
                        
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))//TryParse Verifica se o número será decimal junto ao out
                        {
                            aluno.Nota = nota ;
                        }
                        else
                        {
                            throw new ArgumentException("valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;// verifica na var aluno o numero que está gerando e a seguir contara aluno++ para ser digitado o proximo
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)// foreach = para cada 
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}"); // com o $ conseguinmos usar as var e mencionalas utilizando o chaves colchete {}
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)//A Length propriedade retorna o número de Char objetos nessa instância
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Média Geral:{mediaGeral} - Conceito:{conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

               opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
 