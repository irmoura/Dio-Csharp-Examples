using System;

namespace Revisao
{
    class Program
    {

        private static string ObterOpcaoUsuario()
        {
            string[] opcoes = { "1- Inserir novo aluno", "2- Listar alunos", "3- Calcular média geral", "X- Sair" };
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada:");
            foreach (var opcao in opcoes)
            {
                Console.WriteLine($"{opcao}");
            }
            Console.WriteLine("");
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");
                        aluno.Nota = decimal.TryParse(Console.ReadLine(), out decimal nota) ? nota : 0;
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach (var estudante in alunos)
                        {
                            if (!string.IsNullOrEmpty(estudante.Nome))
                            {
                                Console.WriteLine($"ALUNO: {estudante.Nome} - NOTA: {estudante.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;
                    case "X":
                        //TODO: sair
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
    }
}
