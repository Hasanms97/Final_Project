using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankvisaController : ControllerBase
    {
        private readonly IBankvisaServices _bankvisaServices;

        public BankvisaController(IBankvisaServices bankvisaServices)
        {
            _bankvisaServices = bankvisaServices;
        }


        [HttpPost("CheckBankVISA")]
        public Bankvisa CheckBankVISA(Bankvisa bankvisa)
        {
            var result = _bankvisaServices.CheckBankVISA(bankvisa);
            if(result == null)
            {
                return result;
            }
            else
            {
                return result;
            }
            
        }
    }
}
