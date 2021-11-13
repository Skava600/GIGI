using System.Text.Json.Serialization;

namespace Web_953501_Skavarodnik.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("drinkName")]
        public string DrinkName { get; set; } // название блюда
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание блюда
        [JsonPropertyName("volume")]
        public int Volume { get; set; } // кол. калорий на порцию
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
