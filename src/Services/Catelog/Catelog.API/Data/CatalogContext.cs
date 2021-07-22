using Catelog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catelog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        // best place to make connection using mongo driver.
        // create client
        public CatalogContext(IConfiguration configuration)
        {
            // gettind con string values.
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString")); // cleate mongo client.
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName")); //  creating datatabase.s

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName")); // use interface and populate product.
            CatalogContextSeed.SeedData(Products); // for seed data.
        }

        public IMongoCollection<Product> Products { get; }
    }
}
}
