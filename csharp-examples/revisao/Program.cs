using System;

namespace revisap
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUser = ObterOpcaoUser();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {
                    case "1":
                        // TODO: add alunos
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        // TODO: listar alunos
                        foreach (var a in alunos)

                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        break;

                    case "3":
                        // TODO: calcular a media geral dos alunos
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {

                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var MediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (MediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (MediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (MediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (MediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Media Geral : {MediaGeral} - Conceito : {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUser = ObterOpcaoUser();
            }

        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine(" 1 - Inserir novo aluno");
            Console.WriteLine(" 2 - Listar alumos");
            Console.WriteLine(" 3 - Calcular Média Geral");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine();
            Console.WriteLine();
            return opcaoUser;
        }
    }

    public enum Conceito
    {
        B,
        A,
        C,
        D,
        E
    }

}
