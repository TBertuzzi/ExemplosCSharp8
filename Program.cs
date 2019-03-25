using System;

//Nullable Reference Types
#nullable enable


namespace ExemplosCSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static Local Functions - Funções estaticas Locais
             static int Soma(int valor1,int valor2) =>
               (valor1 + valor2);

            var total = Soma(5,7);
            Console.WriteLine($"Total:{total}");

            //Switch expressions = Chamando método
            Console.WriteLine($"Produtora:{QualConsole("Mario")}");

            //Using Declarations - utilizando o using sem a necessidade de um Bloco complexo

            /*
               //Antes

               using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("MinhaBase")))
                {
                    resultado = conexao.QueryFirstOrDefault<Usuario>(
                        "SELECT * FROM dbo.usuarios " +
                        "WHERE login = @login",
                        new { user = usuario });
                } 

                //Agora

            using SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("MinhaBase"));

                    resultado = conexao.Query<Usuario>(select * from usuarios);


             */

            //Nullable Reference Types - Com os novos tipos null agora podemos realizar melhores tratamentos
             string nomeUsuario = null;
            Console.WriteLine(
                $"Nome de Usuario: {nomeUsuario?.Substring(0, nomeUsuario.IndexOf(' '))}");


                //Ranges e Indices
                string[] tecnologias =
                new string[] { ".NET Core", "Angular", "ASP.NET Core", "Azure", "C#", "Docker" };

            ImprimirElementos(tecnologias[2..5],
                "Retornando elementos dos índices 2 a 4");

            Range range = 2..5;
            ImprimirElementos(tecnologias[range],
                "Retornando elementos dos índices 2 a 4 via struct Range");

            ImprimirElementos(tecnologias[0..5],
                "Retornando elementos dos índices 0 a 4");
            ImprimirElementos(tecnologias[..5],
                "Retornando até o elemento de posição 4 (desde a posição 0)");

            ImprimirElementos(tecnologias[1..^2],
                "Retornando elementos da posição 1 até o antepenúltimo");
            ImprimirElementos(tecnologias[1..^1],
                "Retornando elementos da posição 1 até o penúltimo");
            ImprimirElementos(tecnologias[..^1],
                "Retornando até o penúltimo elemento");
        
        }

        //Switch expressions - Implementação
        public static string QualConsole(
            string jogo) =>
        jogo switch
        {
            "Mario" => "Nintendo",
            "Uncharted" => "Sony",
            "Halo" => "Microsoft",
            _ => throw new ArgumentException("Nenhuma opção valida")
        };

        //Ranges e Indices - Método Auxiliar
         private static void ImprimirElementos(string[] selecaoTecnologias,
            string mensagem)
        {
            Console.Write($"{mensagem}: [");
            foreach (string tecnologia in selecaoTecnologias)
            {
                Console.Write($"  *{tecnologia}*");
            }
            Console.Write("  ]" + Environment.NewLine);
        }
    }
}
