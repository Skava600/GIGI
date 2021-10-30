using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_953501_Skavarodnik.Entities;

namespace Web_953501_Skavarodnik.Data
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder app)

        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            var userManager = (UserManager<ApplicationUser>)serviceProvider.GetService(typeof(UserManager<ApplicationUser>));
            var roleManager = (RoleManager<IdentityRole>)serviceProvider.GetService(typeof(RoleManager<IdentityRole>));
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin

                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.DrinkGroups.Any())
            {
                context.DrinkGroups.AddRange(
                new List<DrinkGroup>
                {
                    new DrinkGroup {GroupName="Слабоалкогольные напитки"},
                    new DrinkGroup {GroupName="Крепкий алкоголь"},
                    new DrinkGroup {GroupName="Безалкогольные напитки"},
                    new DrinkGroup {GroupName="Коктейли"},
                });
                await context.SaveChangesAsync();

            }
            // проверка наличия объектов
            if (!context.Drinks.Any())
            {
                context.Drinks.AddRange(
                new List<Drink>
                {
                    new Drink {DrinkName="Пыво",
                    Description="Жидкое золото",
                    Volume=568, DrinkGroupId=1, Image="https://company.unipack.ru/light_editor_img/images/2013-8-21/file1377071520.jpg" },

                    new Drink {DrinkName="Виски",
                    Description="12-летний",
                    Volume=50, DrinkGroupId=2, Image="https://vinepair.com/wp-content/uploads/2020/08/mcgregor_mobile-640x640.jpg" },

                    new Drink {DrinkName="Квас",
                    Description="Векс Экзорт",
                    Volume=1000, DrinkGroupId=3, Image="https://steamuserimages-a.akamaihd.net/ugc/1259267571728911112/CCF9BC99921AD7F2732103F441558C11A0EA8C9D/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
                    new Drink {DrinkName="Путинский шмурдяк",
                    Description="двухкомпонентный",
                    Volume=20, DrinkGroupId=4, Image="https://res.cloudinary.com/fleetnation/image/private/c_fill,g_center,h_640,w_640/v1503963328/fnm7zhhlamykgzosspvm.jpg" },

                    new Drink {DrinkName="Два-дорожник-Ў",
                    Description="Отечественная вакцина в виде порошка для интраназального введения.",
                    Volume=20, DrinkGroupId=4,Image="https://res.cloudinary.com/nextlevel/w_300,h_300,c_fill/Lustberg/2019/04/cocaine-possession-charges-new-jersey.jpg" },

                    new Drink {DrinkName="Спадарожнік-Ў",
                    Description="Вакцина от НАН РБ, получаенная путем смешивания российского Спутник и китайского Vero Cell",
                    Volume=20, DrinkGroupId=4, Image="https://im0-tub-by.yandex.net/i?id=2151b7d3b099b2d59991c1bff2a5f02c-l&n=13" }});
                        await context.SaveChangesAsync();
            }
        }
    }
}
