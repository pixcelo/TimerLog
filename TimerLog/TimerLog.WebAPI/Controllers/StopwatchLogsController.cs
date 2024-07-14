using Microsoft.AspNetCore.Mvc;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Services;

namespace TimerLog.WebAPI.Controllers
{
    /// <summary>
    /// ストップウォッチログコントローラ
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StopwatchLogsController : ControllerBase
    {
        private readonly IStopwatchLogsService logService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logService"></param>
        public StopwatchLogsController(IStopwatchLogsService logService)
        {
            this.logService = logService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var logs = this.logService.Find();

                if (logs is null || logs.Count == 0)
                {
                    return NotFound();
                }

                return Ok(logs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        public ActionResult Post([FromBody] T_StopwatchLogs log)
        {            
            try
            {
                this.logService.Insert(log);
                return CreatedAtAction(nameof(Post), new { id = log.LogId }, log);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] T_StopwatchLogs log)
        {            
            try
            {
                this.logService.Insert(log);
                return CreatedAtAction(nameof(Put), new { id = log.LogId }, log);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                this.logService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
