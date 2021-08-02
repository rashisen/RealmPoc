using System;
using Realms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Realm_Api_Poc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarController : ControllerBase
    {

        private readonly ILogger<GuitarController> _logger;

        public GuitarController(ILogger<GuitarController> logger)
        {
            _logger = logger;
        }

        // create a new Guitar object
        [HttpPost]
        public Guid AddGuitar(GuitarDTO guitar)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(guitar);
            });

            return guitar.Id;
        }


        //get guitar object
        [HttpGet]
        public GuitarDTO GetGuitar(Guid id)
        {
            var realm = Realm.GetInstance();
            var specifiGuitarById = realm.Find<GuitarDTO>(id);
            return specifiGuitarById;
        }

        //update guitar object
        [HttpPut]
        public void UpdateGuitarPrice(Guid id, Double price)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                var specifiGuitarById = realm.Find<GuitarDTO>(id);
                specifiGuitarById.Price = price;
            });
        }

        //delete guitar object
        [HttpDelete]
        public void DeleteGuitarPrice(Guid id)
        {
            var realm = Realm.GetInstance();
            var specifiGuitarById = realm.Find<GuitarDTO>(id);
            realm.Write(() =>
            {
                realm.Remove(specifiGuitarById);
            });
        }

        // get guitar object
        // [HttpGet]
        // public List<GuitarDTO> GetGuitar()
        // {
        //     var realm = Realm.GetInstance();
        //     var allGuitars = realm.All<GuitarDTO>().ToList();
        //     return allGuitars;
        // }
    }
}
