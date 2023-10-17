using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {

        QuotesDbContext quotesDbContext = new QuotesDbContext();
        // GET: api/Quotes
        [HttpGet]
        public IHttpActionResult LoadQuotes()
        {
            var quotes = quotesDbContext.Quotes;
            return Ok(quotes);
        }

        /* [HttpGet]
         [Route("api/Quotes/PagingQuote/{pageNumber=}/{pageSize=}")]
         public IHttpActionResult PagingQuote(int pageNumber, int pageSize)
         {
             var quotes = quotesDbContext.Quotes.OrderBy(q => q.Id);
             return Ok(quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize));
         } */



        /*[HttpGet]
        [Route("api/Quotes/SearchQuote/{type=}")]
        public IHttpActionResult SearchQuote(string type)
        {
            var quotes = quotesDbContext.Quotes.Where(q => q.Title.StartsWith(type));
            return Ok(quotes);
        } */

        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if(quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } */
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
           var entity =  quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if(entity == null)
            {
                return BadRequest("No record found against this id");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            quotesDbContext.SaveChanges();
            return Ok("Post method working");
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok();
        }
    }
}
