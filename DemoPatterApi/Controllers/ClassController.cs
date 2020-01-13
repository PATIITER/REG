using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPatterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoPatterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ClassController : ControllerBase
    {
        public static List<Class> DataClass = new List<Class>
        {
            new Class { IdClass = "1", NameClass = "admin1" },
            new Class { IdClass = "2", NameClass = "admin1" },
            new Class { IdClass = "3", NameClass = "admin1" },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Class>> GetClassAll()
        {
            return DataClass.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Class> GetUserById(string id)
        {
            return DataClass.FirstOrDefault(it => it.IdClass == id.ToString());
        }

        [HttpPost]
        public Class AddUser([FromBody] Class Classx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Class
            {
                IdClass = id,
                NameClass = Classx.NameClass
               
                
            };

            DataClass.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Class EditUser(string id, [FromBody] Class Classx)
        {
            var _id = DataClass.FirstOrDefault(it => it.IdClass == id.ToString());
            var item = new Class
            {
                IdClass = id,
                NameClass = Classx.NameClass
               
                
            };
            DataClass.Remove(_id);
            DataClass.Add(item);
            return item;

        }

        [HttpDelete("{id}")]
        public void DeleteClass(string id)
        {
            var delete = DataClass.FirstOrDefault(it => it.IdClass == id.ToString());
            DataClass.Remove(delete);
        }


    }

}