using System.Text.Json;
using EstudoJson.Models;
using EstudoJson.Services;

try
{

    string jsonText = File.ReadAllText("Data/pessoas.json");
    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var pessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonText, opcoes);

    PessoaService.ExibirAtivos(pessoas);
    PessoaService.ExibirTop10Salarios(pessoas);
    PessoaService.TotalDePessoas(pessoas);
    PessoaService.MaiorEMenorSalario(pessoas);
    PessoaService.ExibirTop5MaisVelhos(pessoas);
    PessoaService.ExibirTop5MaisAmigos(pessoas);
    PessoaService.ExibirPorGenero(pessoas);
    PessoaService.ExibirTagsUnicas(pessoas);
    PessoaService.BuscarPorId(pessoas);
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"Diretório não encontrado: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Arquivo pessoas.json não encontrado:  {ex.FileName}");
}
catch (JsonException ex)
{
    Console.WriteLine($"Erro ao ler o JSON: {ex.Message}");
}
catch (Exception ex) 
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}