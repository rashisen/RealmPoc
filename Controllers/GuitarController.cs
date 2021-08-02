using System;
using Realms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using AutoMapper;

namespace Realm_Api_Poc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarController : ControllerBase
    {

        private readonly ILogger<GuitarController> _logger;
        private readonly IMapper _mapper;

        public GuitarController(ILogger<GuitarController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        // create a new Guitar object
        [HttpPost]
        public Guid AddGuitar(Guitar guitar)
        {
            var obj = _mapper.Map<GuitarDTO>(guitar);
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(obj);
            });

            return guitar.Id;
        }


        //get guitar object
        [HttpGet]
        public Guitar GetGuitar(Guid id)
        {
            var realm = Realm.GetInstance();
            var specifiGuitarById = realm.Find<GuitarDTO>(id);
            return _mapper.Map<Guitar>(specifiGuitarById);
        }

        //update guitar object
        [HttpPut]
        public Guitar UpdateGuitarPrice(Guid id, Double price)
        {
            var realm = Realm.GetInstance();
            GuitarDTO guitarobj = new GuitarDTO();
            realm.Write(() =>
            {
                guitarobj = realm.Find<GuitarDTO>(id);
                guitarobj.Price = price;
            });
            return _mapper.Map<Guitar>(guitarobj);
        }

        //delete guitar object
        [HttpDelete]
        public string DeleteGuitarPrice(Guid id)
        {
            var realm = Realm.GetInstance();
            var specifiGuitarById = realm.Find<GuitarDTO>(id);
            realm.Write(() =>
            {
                realm.Remove(specifiGuitarById);
            });
            return "Deleted Guitar "+id.ToString();
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
