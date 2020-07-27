using ScheduleBotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScheduleBotWebApp.Controllers
{
    public class SchedulerApiController : ApiController
    {
        ScheduleBotWebApp.Database.Schedule _schedule = new Database.Schedule();

        [Route("SaveSchedule")]
        [HttpPost]
        public IHttpActionResult SaveSchedule([FromBody] Schedule schedule)
        {
            try
            {
                var id = _schedule.AddSchedule(schedule);
                return Ok(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("GetSchedules")]
        [HttpGet]
        public IHttpActionResult GetSchedules()
        {
            try
            {
                var schedules = _schedule.GetSchedules();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("CompleteSchedule")]
        [HttpPost]
        public IHttpActionResult CompleteSchedules([FromBody]Schedule schedule)
        {
            try
            {
                _schedule.MarkScheduleAsCompleted(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
