using System.Web.Http.Cors;

using Quizcous_Api.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Quizcous_Api.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly QuestionContext db;

        public QuestionController()
        {
            this.db = new QuestionContext();
        }

        [HttpGet]
        public async Task<Question> Get(int id)
        {
            return await this.db.Questions.FirstOrDefaultAsync(s => s.Id == id);
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public async Task<object> Count()
        {
            return new { Count = await this.db.Questions.LongCountAsync() };
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}