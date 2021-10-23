using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_953501_Skavarodnik.Data;
using Web_953501_Skavarodnik.Entities;

[assembly: HostingStartup(typeof(Web_953501_Skavarodnik.Areas.Identity.IdentityHostingStartup))]
namespace Web_953501_Skavarodnik.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}