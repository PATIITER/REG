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
            new Class { IdClass = "001", NameClass = "Business Administration" },
            new Class { IdClass = "002", NameClass = "Computer Engineering" },
            new Class { IdClass = "003", NameClass = "International Business" },

        };
        public static List<Teacher> DataTeacher = new List<Teacher>
        {
            new Teacher { IdTeacher = "1", NameTeacher = "sdf",Class = DataClass.ToArray(),Username = "admin1", Password = "12356"},
            new Teacher { IdTeacher = "2", NameTeacher = "sdtrwgg",Class = DataClass.ToArray(),Username = "admin2", Password = "12356" },
            new Teacher { IdTeacher = "3", NameTeacher = "wtdfg",Class = DataClass.ToArray(),Username = "admin3", Password = "12356" },

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

         [HttpGet("{id}")]
        public ActionResult<Teacher> GetTeacherId( string id )
        {
            return DataTeacher.FirstOrDefault(it => it.Username == id.ToString());
        }

        [HttpPost]
        public Teacher AddTeacher([FromBody] Teacher Teacherx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Teacher
            {
                IdTeacher = id.ToString(),
                NameTeacher = Teacherx.NameTeacher,
                
                Username = Teacherx.Username,
                Password = Teacherx.Password

            };

            DataTeacher.Add(item);
            return item;
        }

         
                    //เพิ่มวิชาในอาจาร
         [HttpPut("{id}")]
        public Teacher AddTeacherClass(string id, [FromBody] Class Classx)
        {
            var data = DataTeacher.FirstOrDefault(it => it.IdTeacher == id.ToString());


            var AA =data.Class.ToList();
             Console.WriteLine(data.Class.ToList());

             var item =new Class{

                 IdClass =Classx.IdClass,
                 NameClass = Classx.NameClass

             };

             AA.Add(item);
             Console.WriteLine(AA.ToList());
           

            var item2 = new Teacher
            {
                IdTeacher = id.ToString(),
                NameTeacher = data.NameTeacher,
                Class = AA.ToArray(),
                Username = data.Username,
                Password = data.Password

                
            };
            DataTeacher.Remove(data);
            DataTeacher.Add(item2);
            return item2;

        }
        

        [HttpPut("{id}")]
        public Teacher EditTeacher(string id, [FromBody] Teacher Teacherx)
        {
            var _id = DataTeacher.FirstOrDefault(it => it.IdTeacher == id.ToString());
            var item = new Teacher
            {
                IdTeacher = id,
                NameTeacher = Teacherx.NameTeacher,
                Class = Teacherx.Class,
                Username = Teacherx.Username,
                Password = Teacherx.Password

                
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