using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HostGrpc.Shared.Model
{
    //public  class DataContract
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //}

    //[DataContract]
    //public class MyServiceResponse
    //{
    //    [DataMember(Order = 1)]
    //    public int id { get; set; }

    //    [DataMember(Order = 2)]
    //    public string Name { get; set; }

    //    [DataMember(Order = 3)]
    //    public string Email { get; set; }

   // }


    [DataContract]
    public class Person
    {
        [Key]
        [DataMember(Order = 1)]
        public int id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Email { get; set; }

    }
}
