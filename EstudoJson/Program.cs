using System.Text.Json;
using EstudoJson.Models;
using EstudoJson.Services;

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


