using LAB1.Data; 
using LAB1.Models.Domain; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumDBContext _context;

        public ForumController(ForumDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var topics = await _context.ForumTopics.ToListAsync(); // Отримати всі форумні теми
            return View(topics);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddForumTopic addTopicRequest)
        {
            var topic = new ForumTopic()
            {
                Id = Guid.NewGuid(),
                Title = addTopicRequest.Title,
                Description = addTopicRequest.Description,
                CreatedAt = DateTime.Now,
            };
            await _context.ForumTopics.AddAsync(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var topic = await _context.ForumTopics.FirstOrDefaultAsync(x => x.Id == id);


            if (topic != null)
            {
                var viewmodel = new UpdateTopicViewModel
                {
                    Id = topic.Id,
                    Title = topic.Title,
                    Description = topic.Description,
                };
                return await Task.Run(() => View("View", viewmodel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateTopicViewModel model)
        {
            var topic = await _context.ForumTopics.FindAsync(model.Id);

            if (topic != null)
            {
                topic.Title = model.Title;
                topic.Description = model.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateTopicViewModel model)
        {
            var topic = await _context.ForumTopics.FindAsync(model.Id);

            if (topic != null)
            {
                _context.ForumTopics.Remove(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
