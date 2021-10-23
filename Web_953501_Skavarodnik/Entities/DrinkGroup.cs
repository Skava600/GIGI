using System.Collections.Generic;

namespace Web_953501_Skavarodnik.Entities
{
    public class DrinkGroup
    {
        public int DrinkGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Drink> Drinks { get; set; }
    }
}
