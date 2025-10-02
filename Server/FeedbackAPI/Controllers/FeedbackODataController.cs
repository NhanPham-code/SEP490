using FeedbackAPI.Data;
using FeedbackAPI.Models; // dùng model gốc
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FeedbackAPI.Controllers
{
    public class FeedbackODataController : ODataController
    {
        private readonly FeedbackDbContext _context;

        public FeedbackODataController(FeedbackDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Feedback> Get()
        {
            return _context.Feedbacks;
        }

        [EnableQuery]
        public SingleResult<Feedback> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_context.Feedbacks.Where(f => f.Id == key));
        }
    }
}
