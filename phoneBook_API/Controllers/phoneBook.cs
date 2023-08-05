using Microsoft.AspNetCore.Mvc;
using phoneBook_API.Models;

namespace phoneBook_API.Controllers
{
    public class phoneBook : Controller
    {
        List<Phone> phones = new List<Phone>();


        [HttpPost]
        public IActionResult addContact([FromBody] Phone phone)
        {
            if(verifyIfPhoneAlreadyExists(phone.PhoneNumber) == null)
            {
                return NotFound("Contato não encontrado");
            }
            else
            {
                phones.Add(phone);
                return Ok(phone);
            }
        }

        [HttpGet]
        public IEnumerable<Phone> getAllContactsOfList([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return phones.Skip(skip).Take(take).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult getContact(string id)
        {
            var phone = phones.FirstOrDefault(phone => phone.Id == id);

            if(phone == null)
            {
                return NotFound("Não foi encontrado nenhum contanto com esse Id...");
            }

            return Ok(phone);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateContact(string id, [FromBody] Phone phone)
        {
            var phoneExists = listById(id);

            if (phoneExists == null)
            {
                return NotFound("Contato não encontrado.");
            }

            try
            {
                phone.PhoneNumber ??= phoneExists.PhoneNumber;
                phone.AlternativePhone ??= phoneExists.AlternativePhone;
                phone.Description ??= phoneExists.Description;
                phone.ContactName ??= phoneExists.ContactName;

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
                phones.Remove(phoneExists);
                return Ok("Contato Excluído");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        private Phone listById(string id)
        {
            return phones.FirstOrDefault(phone => phone.Id == id);
        }
        private Phone verifyIfPhoneAlreadyExists(string phoneNumber)
        {
            return phones.FirstOrDefault(phone => phone.PhoneNumber == phoneNumber);
        }
    }
}
