using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;


namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        private IBookBusiness business;

        public BooksController(IBookBusiness business)
        {
            this.business = business;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.business.findAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = this.business.findById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(this.business.create(book));
        }
        [HttpPut]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(this.business.update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.business.delete(id);
            return NoContent();
        }


    }
}