// See https://aka.ms/new-console-template for more information
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tamagotchi;

partial class Program
{
    static void Main(string[] args)
    {
        var URL_DA_API = "https://pokeapi.co/api/v2/pokemon-species/";
        var client = new RestClient(URL_DA_API);         // Obtem a lista de espécies de Pokémons
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Desserializa o JSON para a classe PokemonSpeciesResult
            var pokemonEspeciesResposta = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content!);

            if (pokemonEspeciesResposta != null)
            {
                Console.WriteLine("Escolha um Tamagotchi:");
                for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
                }

                int escolha;

                while (true)
                {
                    Console.WriteLine("\n");
                    Console.Write("Escolha um número: ");
                    if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
                    {
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                    }
                    else
                        break;
                }

                // Obter as características do Pokémon escolhido
                client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
                request = new RestRequest("", Method.Get);
                response = client.Execute(request);

                // Mostrar as características ao jogador
                Console.WriteLine(response.Content);
            }
        }
        else
        {
            Console.WriteLine($"Error: {response.ErrorMessage}");
        }
    }

}
