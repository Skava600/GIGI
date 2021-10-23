namespace Web_953501_Skavarodnik.Entities
{
    public class Drink
    {
        public int DrinkId { get; set; } 
        public string DrinkName { get; set; } 
        public string Description { get; set; } 
        public int Volume { get; set; } // объем
        public string Image { get; set; } // имя файла изображения
                                          // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int DrinkGroupId { get; set; }
        public DrinkGroup Group { get; set; }
    }
}
