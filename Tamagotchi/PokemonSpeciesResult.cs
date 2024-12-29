using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/*
é uma notação de como a coluna está sendo referenciada na API,
se não usar essa notação então tem que nomear a propriedade da
classe exatamente como está sendo retornado da API
*/

namespace Tamagotchi
{
    public class PokemonSpeciesResult
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonResult> Results { get; set; }
    }
}
