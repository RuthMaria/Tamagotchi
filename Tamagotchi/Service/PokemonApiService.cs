﻿using RestSharp;
using System.Text.Json;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            try
            {
                // Obter a lista de espécies de Pokémons

                var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    var pokemonEspeciesResposta = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content!);

                    return pokemonEspeciesResposta.Results;
                }

                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
                return null;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;
            }
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
        {
            try
            {
                // Obter as características do Pokémon escolhido
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content!);
                }

                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.Content}");
                return null;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro de solicitação: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return null;
            }
        }
    }
}
