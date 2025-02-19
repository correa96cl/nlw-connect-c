using Connect.Api.UseCases.User.Register;
using Connect.Communication.Requests;
using Connect.Communication.Responses;
using Connect.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {

            try
            {
                var useCase = new RegisterUserUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (TechLibraryException ex)
            {

                return BadRequest(new ResponseErrorMessagesJson{
                    Errors = ex.GetErrorMessages()
                });
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson{
                    Errors = ["Ocorreu um erro interno no servidor"]
                });
            }
        }
    }
}
