
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Contacts.Models
{
    public class Tag
    {

        public int TagId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Contact> Contacts { get; set; }
    }
}