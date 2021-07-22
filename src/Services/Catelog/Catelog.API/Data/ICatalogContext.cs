﻿using Catelog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catelog.API.Data
{
    interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
