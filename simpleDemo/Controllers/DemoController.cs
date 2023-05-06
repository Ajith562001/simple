using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simpleDemo.Entities;
using System.Linq;

namespace simpleDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        //private readonly CapstoneProjectContext _projectContext;
        //public DemoController(CapstoneProjectContext projectContext)
        //{
        //    _projectContext = projectContext;
        //}
        [HttpGet]
        public ActionResult<IEnumerable<Demo>> Get()
        //{
        //    return _projectContext.Demos.ToList();
        //}
        {
         Entities.CapstoneProjectContext demoo = new Entities.CapstoneProjectContext();
            var da = (from a in demoo.Demos
                      where a.Name.Length > 6
                      select a ).ToList();
            return Ok(da);
        }
        [HttpPost]
        public ActionResult<DTO> Post([FromBody] DTO demo)
        {

            Entities.CapstoneProjectContext demoo = new Entities.CapstoneProjectContext();

            Demo demo1 = new Demo();
            demo1.Name = demo.Name;
            demo1.Email = demo.Email;

            demoo.Demos.Add(demo1);
            demoo.SaveChanges();
            return Ok(demo);
        }
        [HttpGet("par")]
        public ActionResult<Entities.Demo> getp(int id)
        {
            Entities.CapstoneProjectContext demoo = new Entities.CapstoneProjectContext();
            var e = demoo.Demos.Where(i => i.Id == id).FirstOrDefault();
            return Ok(e);
        }
        [HttpPut]
        public ActionResult<Demo> put([FromBody]Demo demo,int id)
        {
            Entities.CapstoneProjectContext demoo = new Entities.CapstoneProjectContext();
           // var e = demoo.Demos.Where(i => i.Id == id).FirstOrDefault();
           //if(demo == null || id != demo.Id)
           // {
           //     return BadRequest();
           // }
            //var e = demoo.Demos.Find(id);
            //Demo demo1 = new Demo();
            
            //demo1.Name = demo.Name;
            //demo1.Email = demo.Email;

            demoo.Demos.Update(demo);
            demoo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public ActionResult<Entities.Demo> delete(int id)
        {
            Entities.CapstoneProjectContext demoo = new CapstoneProjectContext();
            var r = demoo.Demos.Find(id);
            demoo.Demos.Remove(r);
            demoo.SaveChanges();
            return Ok();
        }
    }
}
