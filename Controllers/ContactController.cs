using Microsoft.AspNetCore.Mvc;
using WebApi_Uygulama.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Uygulama.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
       
        private List<Contact> contacts = new List<Contact>
        {
            new Contact{ Id = 1,FirstName="Zehra",LastName="Boyan Afsin", NickName="BayanBoyan", Place="Istanbul"},
            new Contact{ Id = 2,FirstName="Fatih",LastName="Afsin", NickName="WingMan", Place="Istanbul"},
            new Contact{ Id = 3,FirstName="Jack",LastName="Sparrow", NickName="Captain", Place="Caribbean"}
        };
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/<ContactController>/2
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact contact= contacts.FirstOrDefault(x => x.Id == id);
            if (contact==null)
            {
                return NotFound("Contact has not been found.");
            }
            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public ActionResult<IEnumerable<Contact>> Post(Contact newContact)
        {
            contacts.Add(newContact);
            return Ok(contacts);
        }

        // PUT api/<ContactController>/2
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Contact>> Put(int id, Contact updatedContact)
        {
            Contact contact=contacts.FirstOrDefault(x=>x.Id==id);
            if (contact==null)
            {
                return NotFound();
            }

            contact.NickName=updatedContact.NickName;
            contact.IsDeleted = updatedContact.IsDeleted;
            return Ok(contact);
        }

        // DELETE api/<ContactController>/2
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Contact>> Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contacts.Remove(contact);
            return Ok(contacts);
        }
    }
}
