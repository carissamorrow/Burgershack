﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Burgershack
{
  public class Startup
  {
    private readonly string _connectionString = "";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      _connectionString = configuration.GetSection("DB").GetValue<string>("mySQLConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddTransient<BurgerRepository>();
      services.AddTransient<DrinkRepository>();
      services.AddTransient<MenuRepository>();
      services.AddTransient<SideRepository>();
      services.AddTransient<IDbConnection>(x => CreateDBContext());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    private IDbConnection CreateDBContext()
    {
      var connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }


}
