using System.Text.Json;

// Ler e desserializar o Json 
string jsonText = File.ReadAllText("Data/pessoas.json");
var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var pessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonText, opcoes);

// Count de pessoas ativas e inativas
int ativas = pessoas.Count(p => p.IsActive);
int  inativas = pessoas.Count(p => !p.IsActive);
Console.WriteLine($"Ativas: {ativas} | Inativas: {inativas}");

// Top 10 maiores salarios
var top10 = pessoas
    .OrderByDescending(p => p.Salary)
    .Take(10)
    .Select(p => new { p.Name, p.Age, p.Salary });
    
Console.WriteLine("\nTop 10 maiores salários:");
foreach (var p in top10)
    Console.WriteLine($"  {p.Name} | {p.Age} anos | {p.Salary:C}");

// total de pessoas 
Console.WriteLine($"\nTotal de pessoas: {pessoas.Count}");

// Maior e menor salário
Console.WriteLine($"Maior salário: {pessoas.Max(p => p.Salary):C}");
Console.WriteLine($"Menor salário: {pessoas.Min(p => p.Salary):C}");


// Maior e menor salário
Console.WriteLine($"Maior salário: {pessoas.Max(p => p.Salary):C}");
Console.WriteLine($"Menor salário: {pessoas.Min(p => p.Salary):C}");

// Top 5 mais velhos
var topcCincoVelhos = pessoas
    .OrderByDescending(p => p.Age)
    .Take(5)
    .Select(p => new { p.Name, p.Age });

Console.WriteLine("\nTop 5 mais velhos:");
foreach (var p in topcCincoVelhos)
    Console.WriteLine($"  {p.Name} | {p.Age} anos");

// Top 5 com mais de 2 amigos
var comAmigos = pessoas
    .Where(p => p.Friends.Count > 2)
    .Take(5)
    .Select(p => new { p.Name, p.Friends });

Console.WriteLine("\nPessoas com mais de 2 amigos:");
foreach (var p in comAmigos)
{
    Console.WriteLine($"  {p.Name}");
    foreach (var amigo in p.Friends)
        Console.WriteLine($"    → {amigo.Name}");
}

//  Buscar por ID 
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

// Agrupado por gênero 
var porGenero = pessoas
    .GroupBy(p => p.Gender)
    .Select(g => new { Genero = g.Key, Quantidade = g.Count() });

Console.WriteLine("\nPessoas agrupadas por gênero:");
foreach (var grupo in porGenero)
    Console.WriteLine($"  {grupo.Genero}: {grupo.Quantidade}");
    
// Lista de tags sem repetição 
var tagsUnicas = pessoas
    .SelectMany(p => p.Tags)
    .Distinct()
    .OrderBy(t => t);

Console.WriteLine("\nTags únicas:");
foreach (var tag in tagsUnicas)
    Console.WriteLine($"  #{tag}");