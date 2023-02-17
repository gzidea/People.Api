using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using People.Api.Data;

namespace People.Api.Controllers
{

    [Route("Api/people")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public PeoplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<People.Api.Models.People> Get()
        {
            return _context.Peoples.Include(type => type.peopleType).Include(prov => prov.state).ToList();
        }

        [HttpGet("{id}", Name = "GetPeople")]
        public People.Api.Models.People Get(int id)
        {
            return _context.Peoples.Where(x => x.PeopleId == id).FirstOrDefault();
        }

        [HttpGet("shuffle")]
        public People.Api.Models.People shuffle()
        {
            return _context.Peoples.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        }

        [HttpPost]
        public ActionResult Post([FromBody] People.Api.Models.People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetPeople", new { id = people.PeopleId }, people);
        }

        [HttpDelete("{id}")]
        public ActionResult<People.Api.Models.People> Delete(int id)
        {
            var people = _context.Peoples.FirstOrDefault(x => x.PeopleId == id);

            if (people == null)
            {
                return NotFound();
            }
            //tambien puede usarse context.Autor.Remove(autor);
            _context.Peoples.Remove(people);
            _context.SaveChanges();
            return people;
        }
    }
}
