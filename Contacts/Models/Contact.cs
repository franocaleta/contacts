using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Models
{
   
    public class Contact
    {

        public int ContactId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

       
        public virtual List<Email> Emails { get; set; }
       
        public virtual List<PhoneNumber> PhoneNumbers { get; set; }

        public virtual List<Tag> Tags { get; set; }


    }

    public class Email
    {
        public int Id { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public virtual Contact contact { get; set; }

    }

    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public virtual Contact contact { get; set; }
      
    }
}