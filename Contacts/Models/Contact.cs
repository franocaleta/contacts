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

        public override bool Equals(Object obj)
        {
            Contact pt3 = obj as Contact;
            if (pt3 == null)
                return false;
            else if (!pt3.Address.Equals(this.Address)) return false;
            else if (!pt3.Name.Equals(this.Name)) return false;
            else if (!pt3.LastName.Equals(this.LastName)) return false;
            else
            {
                if (pt3.Emails.Count != this.Emails.Count) return false;
                else if (pt3.Tags.Count != this.Tags.Count) return false;
                else if (pt3.PhoneNumbers.Count != this.PhoneNumbers.Count) return false;

                for( int i = 0; i < pt3.Emails.Count; i++)
                {
                    if (!this.Emails.ElementAt(i).email.Equals(pt3.Emails.ElementAt(i).email)) return false;
                }

                for (int i = 0; i < pt3.PhoneNumbers.Count; i++)
                {
                    if (!this.PhoneNumbers.ElementAt(i).Number.Equals(pt3.PhoneNumbers.ElementAt(i).Number)) return false;
                }

                for (int i = 0; i < pt3.Tags.Count; i++)
                {
                    if (!this.Tags.ElementAt(i).Name.Equals(pt3.Tags.ElementAt(i).Name)) return false;
                }
                return true;
            }

        }

    }

    public class Email
    {
        public int Id { get; set; }
        public string email { get; set; }
      

    }

    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
      


    }
}