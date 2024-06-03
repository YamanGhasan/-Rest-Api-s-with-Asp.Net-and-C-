using quotesApiCourse.Data;
using quotesApiCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Results;

namespace quotesApiCourse.Controllers
{
    public class QuotesController : ApiController

    {
        // QuotesDbContext responsible for database CRUD operations and will interact with db behind the sence so we should create an instance of it here

        QuotesDbContext quotesDbContext = new QuotesDbContext();

        // GET: api/Quotes
        [HttpGet]
        public IHttpActionResult loaderQuotes()
        {
            var quote = quotesDbContext.Quotes;
            return Ok(quote);
        }

        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);

        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody] Quote quote)
        {
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.Created);
        }


        // PUT : api/Qoutes/5 
        public IHttpActionResult Put(int id, [FromBody] Quote quote) {


            var entity = quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (entity == null)
            {
                return BadRequest("No Record found !!!!");
            }
            entity.Title = quote.Title;
            entity.Description = quote.Description;
            entity.Author = quote.Author;
            quotesDbContext.SaveChanges();
            return Ok("Record updated successfully");
        }


        // DELETE : API/Quotes/5
        public IHttpActionResult Delete(int id) {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return BadRequest("No Record found !");
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Quote deleted");
        }

        [HttpGet]
        [Route("api/Quotes/PagingQuote/{pageNumber=1}/{pageSize=2}")]
        public IHttpActionResult PagingQuotes(int pageNumber, int pageSize) 
        {
            var quotes = quotesDbContext.Quotes.OrderBy(q => q.Id);
        return Ok(quotes.Skip((pageNumber -1 )* pageSize).Take(pageSize));
        }


        [HttpGet]
        [Route("api/Quotes/SearchQuote/{Title=}")]
        public IHttpActionResult SearchQuote(string Title)
        {
            var quotes = quotesDbContext.Quotes.Where(q => q.Title.StartsWith(Title));
            return Ok(quotes);
        }

    }
}
