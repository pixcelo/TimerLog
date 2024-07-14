using Microsoft.AspNetCore.Mvc;
using TimerLog.WebAPI.Services;

namespace TimerLog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerTypesController : ControllerBase
    {
        private readonly ITimerTypesService service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        public TimerTypesController(ITimerTypesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var list = this.service.Find();

                if (list is null || list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
