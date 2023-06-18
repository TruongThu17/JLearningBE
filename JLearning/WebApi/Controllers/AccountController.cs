using AutoMapper;
using BusinessObjects.DTO;
using BusinessObjects.DTO.Account;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Reporitories;

namespace WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        // Repository
        private IAccountRepository repository = new AccountRepository();

        // Mapper
        private readonly IMapper _mapper;

        // Get mapper singleton
        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] GetAccountDTO account)
        {
            // Map dto to account
            Account acc = _mapper.Map<Account>(account);

            // Get result
            Account result = repository.SignIn(acc);

            AccountDTO accountDTO = _mapper.Map<AccountDTO>(result);

            Console.WriteLine("account: " + account.Email);

            if (result != null)
            {
                return Ok(new { user = accountDTO });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp([FromBody] InsertAccountDTO account)
        {
            // Map dto to account
            Account acc = _mapper.Map<Account>(account);
            bool status = repository.SignUp(acc);

            Console.Write(status);
            if (status == true)
            {
                return Ok();
            }

            return Unauthorized();
        }
        [HttpPost("update-info")]
        public ActionResult Put([FromBody][Bind("name,email,gender,phone,address,avatar_url,year_of_birth")] AccountDTO accountDTO)
        {
            var account = repository.FindAccountByEmail(accountDTO.Email);
            if (account == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            accountDTO.RoleId = account.RoleId;
            Account acc = _mapper.Map<Account>(accountDTO);
            acc.Password = account.Password;
            repository.UpdateAccount(acc);
            return Ok();
        }
    }
}
