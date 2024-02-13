using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenantAuthenticator.Entity.Auth;
using TenantAuthenticator.Interface;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        public IMainDbContext DbContext { get; }
        public ITokenService TokenService { get; }
        public TestController(ITokenService tokenService, IMainDbContext dbContext)
        {
            TokenService = tokenService;
            DbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = DbContext.Books.ToList();
            return Ok(books);
        }
        [HttpGet]
        [SystemAuthorize(AuthorizeEnum.ChangePassword)]
        [SystemAuthorize(AuthorizeEnum.ChangeAccountPicture)]
        [SystemAuthorize(AuthorizeEnum.AddRole)]
        public async Task<IActionResult> GetToken()
        {
            string username = "Pourya";
            string password = "131313";
            return Ok(await TokenService.CreateToken(username, password));
        }
    }
}
