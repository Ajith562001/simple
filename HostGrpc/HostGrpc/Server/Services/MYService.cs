using HostGrpc.Server.Entities;
using HostGrpc.Shared.Model;
using HostGrpc.Shared.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace HostGrpc.Server.Services
{
    public class MYService : IserviceContract
    {
        //public Task<List<Person>> GetMyServices()
        //{
        //    DemoContext context = new DemoContext();
        //    var pp = context.People.ToList();
        //    return Task.FromResult(q);

        //}

        public static Shared.Model.Person MAp(Entities.Person person)
        {
            Shared.Model.Person person1 = new Shared.Model.Person()
            {
                id = person.Id,
                Name = person.Name,
                Email= person.Email
            };

            return person1;

        }
        public static Entities.Person MAp(Shared.Model.Person person)
        {
            Entities.Person person1 = new Entities.Person()
            {
                Id = person.id,
                Name = person.Name,
                Email = person.Email
            };

            return person1;

        }

        public Task<Shared.Model.Person> PostMyServices(Shared.Model.Person person)
        {
            DemoContext context = new DemoContext();
            context.People.Add(MAp(person));
            context.SaveChanges();
            return Task.FromResult(person);
        }
        public Task<List<Shared.Model.Person>> GetMyServices()
        {
            DemoContext context = new DemoContext();
            List<Entities.Person> eperson = context.People.ToList();
            List<Shared.Model.Person> mperson = eperson.Select(MAp).ToList();
            return Task.FromResult(mperson);
        }

        public Task<Shared.Model.Person> PutMyServices(Shared.Model.Person person)
        {
            DemoContext context = new DemoContext();
            context.People.Update(MAp(person));
            context.SaveChanges();
            return Task.FromResult(person);
        }
        public Task<Shared.Model.Person> DeleteMyServices(Shared.Model.Person person)
        {
            DemoContext context = new DemoContext();
            context.People.Remove(MAp(person));
            context.SaveChanges();
            return Task.FromResult(person);
        }
    }
}

