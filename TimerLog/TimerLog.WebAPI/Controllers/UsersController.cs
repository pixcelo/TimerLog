using Microsoft.AspNetCore.Mvc;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Services;

namespace TimerLog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="usersService"></param>
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public List<M_Users> Get()
        {
            return this.usersService.Get();
        }

        [HttpPost]
        public int Post([FromBody] M_Users user)
        {
            return this.usersService.Insert(user);
        }

        [HttpPut]
        public int Put([FromBody] M_Users user)
        {
            return this.usersService.Update(user);
        }

        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            return this.usersService.Delete(id);
        }

    }
}
