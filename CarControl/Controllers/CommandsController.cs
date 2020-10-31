using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess;
using Models;

namespace CarControl2.Controllers
{
    public class CommandsController : ApiController
    {

        [HttpGet]
        public string PollNextCommand()
        {
            if (!Helper.HasPermission())
                return "Forbidden";

            var commandData = new CommandData();
            IEnumerable<Command> commands;

            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(100))
            {
                commands = commandData.SelectAll().Where(c => !c.CompleteDate.HasValue);

                if (commands.Any())
                {
                    var command = commands.First();
                    command.CompleteDate = DateTime.UtcNow;
                    commandData.Update(command);
                    return command.PayLoad;
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(50));
            }
            s.Stop();

            return "";
        }
        
        [HttpGet]
        public List<Command> CompletedItems()
        {
            var commandData = new CommandData();
            var completedCommands = commandData.SelectAll().Where(c => c.CompleteDate.HasValue);
            return completedCommands.ToList() ;
        }
        [HttpGet]
        public List<Command> TodoItems()
        {
            var commandData = new CommandData();
            var commands = commandData.SelectAll().Where(c => !c.CompleteDate.HasValue);
            return commands.ToList();
        }

        [HttpGet]
        public IHttpActionResult ClearAllTodoItems()
        {
            var commandData = new CommandData();
            var commands = commandData.SelectAll();

            foreach (var command in commands)
            {
                commandData.DeleteByID(command.Id);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        public IHttpActionResult Add(string command)
        {
            if (!Helper.HasPermission())
                return StatusCode(HttpStatusCode.Forbidden);

            var commandData = new CommandData();
            commandData.Create(new Command() { PayLoad = command, RequestDate = DateTime.UtcNow });
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        public IHttpActionResult Log(string command)
        {
            if (!Helper.HasPermission())
                return StatusCode(HttpStatusCode.Forbidden);
            var commandData = new CommandData();
            commandData.Create(new Command() { PayLoad = command, RequestDate = DateTime.UtcNow, CompleteDate = DateTime.UtcNow });
            return StatusCode(HttpStatusCode.OK);

        }

 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }

    }
}