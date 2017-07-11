using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Contacts.Models;

namespace Contacts.Controllers
{
    public class ContactsController : ApiController
    {
        private ContactContext2 db = new ContactContext2();

        // GET: api/Contacts
        public IQueryable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        [HttpGet]
        [Route("search/{type}/{query}")]
        public List<Contact> Search(string type, string query)
        {
            List<Contact> result = new List<Contact>();
            switch (type)
            {
                case "Name":
                    result = (from c in db.Contacts
                           where c.Name.StartsWith(query)
                           select c).ToList();
                    break;
                case "LastName":
                    result = (from c in db.Contacts
                           where c.LastName.StartsWith(query)
                           select c).ToList();
                    break;
                case "Tags":
                    List<Tag> tags = (from c in db.Tags
                           where c.Name.StartsWith(query)
                           select c).ToList();
                    foreach(Tag tag in tags){

                        List<Contact> contacts = tag.Contacts;
                        foreach(Contact con in contacts)
                        {
                            if (!result.Contains(con))
                            {
                                result.Add(con);
                            }
                        }
                      
                    }
                    break;
            }
            return result;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetContact(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }


            
            List<PhoneNumber> phs = new List<PhoneNumber>();
            phs.AddRange(contact.PhoneNumbers);
            List<Email> ems = new List<Email>();
            ems.AddRange(contact.Emails);
            List<Tag> tgs = new List<Tag>();
            tgs.AddRange(contact.Tags);

            db.Contacts.Attach(contact);
            db.Entry(contact).Collection(p => p.Tags).Load();
            db.Entry(contact).Collection(p => p.PhoneNumbers).Load();
            db.Entry(contact).Collection(p => p.Emails).Load();

            var numbers = new PhoneNumber[contact.PhoneNumbers.Count];
            contact.PhoneNumbers.CopyTo(numbers);

           
            foreach (PhoneNumber phone in numbers)
            {

                if (phone.Id == 0)
                {
                    db.PhoneNumbers.Add(phone);
                    await db.SaveChangesAsync();
                    contact.PhoneNumbers.Add(phone);
                 }
                else if (!phs.Contains(phone))
                {
                    db.PhoneNumbers.Remove(phone);
                    await db.SaveChangesAsync();
                }
                else {
                   db.Entry(phone).State = EntityState.Modified;
                   await db.SaveChangesAsync();
                   
                }


            }

            var emails = new Email[contact.Emails.Count];
            contact.Emails.CopyTo(emails);
           
            foreach (Email email in emails)
            {

                if (email.Id == 0)
                {
                    db.Emails.Add(email);
                    await db.SaveChangesAsync();
                    contact.Emails.Add(email);
                }
                else if (!ems.Contains(email))
                {
                    db.Emails.Remove(email);
                    await db.SaveChangesAsync();
                }
                else
                { 
                    db.Entry(email).State = EntityState.Modified;
                    await db.SaveChangesAsync();                 
                }
             }

          

            var tags = new Tag[contact.Tags.Count];
            contact.Tags.CopyTo(tags);

            foreach (Tag tag in tags)
            {

                if (tag.TagId == 0)
                {
                    Tag dbEntry = db.Tags.FirstOrDefault(p => p.Name == tag.Name);
                    if (dbEntry != null)
                    {
                        contact.Tags.Add(dbEntry);
                    }
                   else
                    {
                        db.Tags.Add(tag);
                        await db.SaveChangesAsync();
                        contact.Tags.Add(tag);

                    }
                }
                else if (!tgs.Contains(tag))

                {
                    contact.Tags.Remove(tag);
                }
                else
                {
                  db.Entry(tag).State = EntityState.Modified;
                  await db.SaveChangesAsync();
                      
                }            

            }

                db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tags = new Tag[contact.Tags.Count];
            contact.Tags.CopyTo(tags);
            foreach(Tag elem in tags)
            {
                var dbEntry = db.Tags.FirstOrDefault(tag => tag.Name == elem.Name);
                if (dbEntry != null)
                {
                    contact.Tags.Remove(elem);
                    contact.Tags.Add(dbEntry);
                }
           }

          

            db.Contacts.Add(contact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.ContactId == id) > 0;
        }
    }
}