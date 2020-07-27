using Dapper;
using ScheduleBotWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ScheduleBotWebApp.Database
{
    public class Schedule
    {

        private string ScheduleAdd = "insert into dbo.Schedule (UserId, EventDate, EventName, MinutesToAlertBefore, Completed, PhoneNumber) values (@UserId, @EventDate, @EventName, @MinutesToAlertBefore, 0, @PhoneNumber); select SCOPE_IDENTITY();";
        private string SchedulesGet = "select * from dbo.Schedule where Completed = 0 and eventdate < DATEADD(minute, minutestoalertbefore, DATEADD(hour, 5, getdate()))";
        private string ScheduleComplete = "update dbo.Schedule set Completed = 1 where ID = @ID";

        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public int AddSchedule(ScheduleBotWebApp.Models.Schedule schedule)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Execute(ScheduleAdd, schedule, commandType: CommandType.Text);
            }
        }

        public List<ScheduleBotWebApp.Models.Schedule> GetSchedules()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<ScheduleBotWebApp.Models.Schedule>(SchedulesGet, commandType: CommandType.Text).ToList();
            }

        }

        public void MarkScheduleAsCompleted(ScheduleBotWebApp.Models.Schedule schedule)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(ScheduleComplete, new { Id = schedule.ID }, commandType: CommandType.Text);
            }
        }
    }
}