using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Email { get; set; }
        public string ?Phone { get; set; }
        public string ?Cpf { get; set; }
        public DateTime ?BirthDate { get; set; }
        public string ?sex { get; set; }
        public string ?MaritalStatus { get; set; }
        public string ?Cep { get; set; }
        public string ?City { get; set; }
        public string ?Neighborhood { get; set; }
        public string ?State { get; set; }
        public string ?Street { get; set; }
        public string ?Number { get; set; }
        public string ?Complement { get; set; }
        public string ?Password { get; set; }

        public Client() { }

       
    }
}
