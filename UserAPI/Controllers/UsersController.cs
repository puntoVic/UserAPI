using Business.Contracts;
using Common;
using Common.Helpers;
using Entities.Definitions;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserManager userManager;
        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDefinition user)
        {

            var errors = Validator.ValidateUser(user);

            if (errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            return await userManager.CreateUser(user);

        }


    }
}
