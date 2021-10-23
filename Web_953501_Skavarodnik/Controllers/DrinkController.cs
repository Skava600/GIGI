using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_953501_Skavarodnik.Entities;
using Web_953501_Skavarodnik.Models;

namespace Web_953501_Skavarodnik.Controllers
{
    public class DrinkController : Controller
    {
        List<Drink> _drinks;
        List<DrinkGroup> _drinkGroups;
        int _pageSize;
        public DrinkController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNo = 1)
        {
            var drinksFiltered = _drinks.Where(d => !group.HasValue || d.DrinkGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _drinkGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Drink>.GetModel(
                drinksFiltered, 
                pageNo,
                _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _drinkGroups = new List<DrinkGroup>
            {
            new DrinkGroup {DrinkGroupId=1, GroupName="Слабоалкогольные напитки"},
            new DrinkGroup {DrinkGroupId=2, GroupName="Крепкий алкоголь"},
            new DrinkGroup {DrinkGroupId=3, GroupName="Безалкогольные напитки"},
            new DrinkGroup {DrinkGroupId=4, GroupName="Коктейли"},
            };
            _drinks = new List<Drink>
            {
            new Drink {DrinkId = 1, DrinkName="Пыво",
            Description="Жидкое золото",
            Volume=568, DrinkGroupId=1, Image="https://company.unipack.ru/light_editor_img/images/2013-8-21/file1377071520.jpg" },
            new Drink { DrinkId = 2, DrinkName="Виски",
            Description="12-летний",
            Volume=50, DrinkGroupId=2, Image="https://vinepair.com/wp-content/uploads/2020/08/mcgregor_mobile-640x640.jpg" },
            new Drink { DrinkId = 3, DrinkName="Квас",
            Description="Векс Экзорт",
            Volume=1000, DrinkGroupId=3, Image="https://steamuserimages-a.akamaihd.net/ugc/1259267571728911112/CCF9BC99921AD7F2732103F441558C11A0EA8C9D/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
            new Drink { DrinkId = 4, DrinkName="Путинский шмурдяк",
            Description="двухкомпонентный",
            Volume=20, DrinkGroupId=4, Image="https://res.cloudinary.com/fleetnation/image/private/c_fill,g_center,h_640,w_640/v1503963328/fnm7zhhlamykgzosspvm.jpg" },
            new Drink { DrinkId = 5, DrinkName="Два-дорожник-Ў",
            Description="Отечественная вакцина в виде порошка для интраназального введения.",
            Volume=20, DrinkGroupId=4, Image="https://res.cloudinary.com/nextlevel/w_300,h_300,c_fill/Lustberg/2019/04/cocaine-possession-charges-new-jersey.jpg" },
            new Drink { DrinkId = 6, DrinkName="Спадарожнік-Ў",
            Description="Вакцина от НАН РБ, получаенная путем смешивания российского Спутник и китайского Vero Cell",
            Volume=20, DrinkGroupId=4, Image="https://im0-tub-by.yandex.net/i?id=2151b7d3b099b2d59991c1bff2a5f02c-l&n=13" }
            };

        }
    }
}
