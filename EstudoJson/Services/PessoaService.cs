    using EstudoJson.Models;

    namespace EstudoJson.Services;

    public static class PessoaService
    {
        public static void ExibirAtivos(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;
            int ativas = pessoas.Count(p => p.IsActive);
            int  inativas = pessoas.Count(p => !p.IsActive);
            Console.WriteLine($"Ativas: {ativas} | Inativas: {inativas}");
        }

        public static void ExibirTop10Salarios(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;
            var top10 = pessoas
                .OrderByDescending(p => p.Salary)
                .Take(10);
        
            Console.WriteLine("\nTop 10 maiores salários:");
            foreach (var p in top10)
                Console.WriteLine($"  {p}");
        }

       public static void TotalDePessoas(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;

            Console.WriteLine($"\nTotal de pessoas: {pessoas.Count}");
        }
       
        public static void MaiorEMenorSalario(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;
            Console.WriteLine($"Maior salário: {pessoas.Max(p => p.Salary):C}");
            Console.WriteLine($"Menor salário: {pessoas.Min(p => p.Salary):C}");
        }


       public static void ExibirTop5MaisVelhos(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;
            
                var top5Velhos = pessoas
                    .OrderByDescending(p => p.Age)
                    .Take(5)
                    .Select(p => new { p.Name, p.Age });
                Console.WriteLine("\nTop 5 mais velhos:");
                foreach (var p in top5Velhos)
                    Console.WriteLine($"  {p}");
        }
       
        public static void ExibirTop5MaisAmigos(List<Pessoa>? pessoas)
        {
            if (pessoas == null) return;
            
            var comAmigos = pessoas
                .Where(p => p.Friends.Length > 2)
                .Take(5);

            foreach (var p in comAmigos)
            {
                Console.WriteLine($"  {p.Name}");
                foreach (var amigo in p.Friends)
                    Console.WriteLine($"    → {amigo.Name}");
            }
        }
        
        public static void BuscarPorId(List<Pessoa>? pessoas) {   
            if (pessoas == null) return;
            Console.Write("\nDigite um ID para buscar: ");
            string id = Console.ReadLine()!;
            var encontrado = pessoas.SingleOrDefault(p => p.Id == id);

            if (encontrado is not null)
            {
                Console.WriteLine($"Nome: {encontrado.Name}");
                Console.WriteLine($"Idade: {encontrado.Age}");
                Console.WriteLine($"Salário: {encontrado.Salary:C}");
                Console.WriteLine($"Ativo: {encontrado.IsActive}");
                Console.WriteLine($"Registrado em: {encontrado.Registered:dd/MM/yyyy}");
                Console.WriteLine($"Fruta favorita: {encontrado.FavoriteFruit}");
                Console.WriteLine($"Tags: {string.Join(", ", encontrado.Tags)}");
                Console.WriteLine($"Amigos: {string.Join(", ", encontrado.Friends.Select(a => a.Name))}");
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada.");
            }
            
        }
        public static void ExibirPorGenero(List<Pessoa>? pessoas) {
            if (pessoas == null) return;
            
                var porGenero = pessoas
                    .GroupBy(p => p.Gender)
                    .Select(g => new { Genero = g.Key, Quantidade = g.Count() });

                Console.WriteLine("\nPessoas agrupadas por gênero:");
                foreach (var grupo in porGenero)
                    Console.WriteLine($"  {grupo.Genero}: {grupo.Quantidade}");
        }
       public static void ExibirTagsUnicas(List<Pessoa>? pessoas) {
            if (pessoas == null) return;
           
               var tagsUnicas = pessoas
                   .SelectMany(p => p.Tags)
                   .Distinct()
                   .OrderBy(t => t);

               Console.WriteLine("\nTags únicas:");
               foreach (var tag in tagsUnicas)
                   Console.WriteLine($"  #{tag}");
       }
    }