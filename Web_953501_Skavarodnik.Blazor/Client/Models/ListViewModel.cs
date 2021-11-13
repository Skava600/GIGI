using System.Text.Json.Serialization;

namespace Web_953501_Skavarodnik.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("drinkId")]
        public int DrinkId { get; set; } // id блюда
        [JsonPropertyName("drinkName")]

        public string DrinkName { get; set; } // название блюда
    }
    
}
