using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using phoneBook_API.Data.Context;
using phoneBook_API.Data.DTO;
using phoneBook_API.Models;

namespace phoneBook_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class phoneBook : Controller
    {
        private PhoneContext _context;
        private IMapper _mapper;

        public phoneBook(PhoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        [HttpPost]
        public IActionResult addContact([FromBody] PhoneDTO phoneDTO)
        {
            Phone phone = _mapper.Map<Phone>(phoneDTO);

            if(verifyIfPhoneAlreadyExists(phone.PhoneNumber) == null)
            {
                _context.Phones.Add(phone);
                _context.SaveChanges();
                return Ok(phone);
            }
            else
            {
                return BadRequest("Contato já existe");
            }
        }

        [HttpGet]
        public IEnumerable<Phone> getAllContactsOfList([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _context.Phones.Skip(skip).Take(take).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult getContact(string id)
        {
            var phone = listById(id);

            if(phone == null)
            {
                return NotFound("Não foi encontrado nenhum contanto com esse Id...");
            }

            return Ok(phone);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateContact(string id, [FromBody] UpdatePhoneDTO phoneDTO)
        {
            var phone = listById(id);

            if (phone == null)
            {
                return NotFound("Contato não encontrado.");
            }

            try
            {
                phoneDTO.PhoneNumber ??= phone.PhoneNumber;
                phoneDTO.AlternativePhone ??= phone.AlternativePhone;
                phoneDTO.Description ??= phone.Description;
                phoneDTO.ContactName ??= phone.ContactName;

                _mapper.Map(phoneDTO, phone);
                _context.SaveChanges();
                return Ok("Contato Editado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(string id)
        {
            var phoneExists = listById(id);

            if (phoneExists == null)
            {
                return NotFound("Contato não encontrado.");
            }

            try
            {
                _context.Phones.Remove(phoneExists);
                _context.SaveChanges();
                return Ok("Contato Excluído");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        private Phone listById(string id)
        {
            return _context.Phones.FirstOrDefault(phone => phone.Id == id);
        }
        private Phone verifyIfPhoneAlreadyExists(string phoneNumber)
        {
            return _context.Phones.FirstOrDefault(phone => phone.PhoneNumber == phoneNumber);
        }
    }
}
