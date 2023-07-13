using HostGrpc.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostGrpc.Shared.Service
{
    [ServiceContract]
    public interface IserviceContract
    {
        public Task<List<Person>> GetMyServices();

        public Task<Person> PostMyServices(Person person);

        public Task<Person> PutMyServices(Person person);

        public Task<Person> DeleteMyServices(Person person);
    }
}
