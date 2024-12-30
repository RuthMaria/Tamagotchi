using RestSharp;
using System.Text.Json;
using Tamagotchi.Model;


namespace Tamagotchi.Service
{
    public class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            // Obter a lista de espécies de Pokémons

            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            var pokemonEspeciesResposta = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content!);

            return pokemonEspeciesResposta.Results;
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
        {
            // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            return JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content!);
        }
    }
}
