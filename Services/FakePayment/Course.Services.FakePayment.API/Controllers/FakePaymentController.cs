using Course.Share.ControllerBases;
using Course.Share.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Course.Services.FakePayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }


    }
}
