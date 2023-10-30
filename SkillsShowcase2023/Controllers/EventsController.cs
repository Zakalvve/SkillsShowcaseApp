using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCSkillsShowcaseApp.Models;
using MVCSkillsShowcaseApp.Models.Events;
using MVCSkillsShowcaseApp.Services;

namespace MVCSkillsShowcaseApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IDbContext _dbContext;

        public EventsController(ILogger<EventsController> logger, IDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dbContext.LoadEvents());
        }

        [HttpGet]
        public IActionResult Event(int eventId)
        {
            ViewBag.EventId = eventId;

            var model = _dbContext.LoadEvent(eventId);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CreateEvent(model);

                return RedirectToAction("Index");
            }
            
            _logger.LogWarning("Model posted to CreateEvent was not valid");

            return View();
        }

        [HttpGet]
        public IActionResult CreatePoll(int eventId)
        {
            ViewBag.EventId = eventId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePoll(PollModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CreatePoll(model.EventId,model);

                return RedirectToAction("Event",new { eventId = model.EventId });
            } 

            _logger.LogWarning("Model posted to CreatePoll was not valid");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePollOption(int eventId,PollOptionModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CreatePollOption(model.PollId,model);
                return RedirectToAction("Event",new { eventId });
            }

            _logger.LogWarning("Model posted to CreatePollOption was not valid");

            return new EmptyResult();
        }


        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
