using AutoMapper;
using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Reporitories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // Repository
        private IContactRepository repository = new ContactRepository();

        // Mapper
        private readonly IMapper _mapper;

        // Get mapper singleton
        public ContactController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public ActionResult<IEnumerable<ContactDTO>> Get()
        {
            IEnumerable<Contact> c = repository.GetContacts();
            IEnumerable<ContactDTO> contactDTO = _mapper.Map<IEnumerable<ContactDTO>>(c);
            return Ok(contactDTO);
        }

        // POST api/<ContactController>
        [HttpPost("insert")]
        public ActionResult Post([FromBody][Bind("email,name,request_date,request_message,status")] ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                Contact contact = _mapper.Map<Contact>(contactDTO);
                repository.CreateContact(contact);
                return Ok();
            }

            return BadRequest(ModelState);
        }


        // PUT api/<ContactController>/5
        [HttpPost("update")]
        public ActionResult Put([FromBody][Bind("subject,contact_id,email,name,response_date,request_message,response_message,status")] ContactDTO contactDTO)
        {
            var contact = repository.FindContactById((int)contactDTO.ContactId);
            if (contact == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Contact c = _mapper.Map<Contact>(contactDTO);
            repository.UpdateContact(c);
            return Ok();
        }

    }
}
