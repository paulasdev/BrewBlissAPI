using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewBlissInfo.Models;

namespace BrewBlissInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageFeedbackController : ControllerBase
    {
        private readonly BrewBlissInfoDbContext _context;

        public MessageFeedbackController(BrewBlissInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/messagefeedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageFeedback>>> GetAllFeedback()
        {
            return await _context.MessageFeedbacks.ToListAsync();
        }

        // GET: api/messagefeedback/contact/5?type=Request
        [HttpGet("contact/{contactId}")]
        public async Task<ActionResult<MessageFeedback>> GetByContactAndType(int contactId, string type)
        {
            var feedback = await _context.MessageFeedbacks
                .FirstOrDefaultAsync(f => f.ContactMessageId == contactId && f.Type == type);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // POST: api/messagefeedback
        [HttpPost]
        public async Task<ActionResult<MessageFeedback>> PostFeedback(MessageFeedback feedback)
        {
            feedback.ReviewedAt = DateTime.Now;

            _context.MessageFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByContactAndType), new { contactId = feedback.ContactMessageId, type = feedback.Type }, feedback);
        }
    }
}