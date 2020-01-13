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

    public class TeacherController : ControllerBase
    {
         public static List<Class> DataClass = new List<Class>
        {
            new Class { IdClass = "1", NameClass = "admin1" },
            new Class { IdClass = "2", NameClass = "admin1" },
            new Class { IdClass = "3", NameClass = "admin1" },

        };
        public static List<Teacher> DataTeacher = new List<Teacher>
        {
            new Teacher { IdTeacher = "1", NameTeacher = "admin1",Class = DataClass.ToArray(),Username = "admin1", Password = "12356"},
            new Teacher { IdTeacher = "2", NameTeacher = "admin1",Class = DataClass.ToArray(),Username = "admin2", Password = "12356" },
            new Teacher { IdTeacher = "3", NameTeacher = "admin1",Class = DataClass.ToArray(),Username = "admin3", Password = "12356" },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeacherAll()
        {
            return DataTeacher.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> GetTeacherById(string id)
        {
            return DataTeacher.FirstOrDefault(it => it.IdTeacher == id.ToString());
        }

        [HttpPost]
        public Teacher AddTeacher([FromBody] Teacher Teacherx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Teacher
            {
                IdTeacher = id,
                NameTeacher = Teacherx.NameTeacher
               
                
            };

            DataTeacher.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Teacher EditStudent(string id, [FromBody] Teacher Teacherx)
        {
            var _id = DataTeacher.FirstOrDefault(it => it.IdTeacher == id.ToString());
            var item = new Teacher
            {
                IdTeacher = id,
                NameTeacher = Teacherx.NameTeacher
               
                
            };
            DataTeacher.Remove(_id);
            DataTeacher.Add(item);
            return item;

        }

        [HttpDelete("{id}")]
        public void DeleteTeacher(string id)
        {
            var delete = DataTeacher.FirstOrDefault(it => it.IdTeacher == id.ToString());
            DataTeacher.Remove(delete);
        }


    }

}