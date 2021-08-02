using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realm_Api_Poc
{
    [ValidateNever]
    public class Guitar
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Owner { get; set; }
    }
}
