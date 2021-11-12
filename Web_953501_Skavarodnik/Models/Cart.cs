using System.Collections.Generic;
using System.Linq;
using Web_953501_Skavarodnik.Entities;

namespace Web_953501_Skavarodnik.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Volume
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Drink.Volume);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="drink">добавляемый объект</param>
        public virtual void AddToCart(Drink drink)
        {

            // если объект есть в корзине
            // то увеличить количество

            if (Items.ContainsKey(drink.DrinkId))
                Items[drink.DrinkId].Quantity++;
            // иначе - добавить объект в корзину

            else
                Items.Add(drink.DrinkId, new CartItem
                {
                    Drink = drink,
                    Quantity = 1
                });

        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Drink Drink { get; set; }
        public int Quantity { get; set; }
    }
}

