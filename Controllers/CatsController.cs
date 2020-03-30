using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cat_api.Models;
using Microsoft.AspNetCore.Mvc;
using cat_api.db;
using Microsoft.Extensions.Logging;

namespace cat_api.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CatsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        return Ok(FakeDb.Cats);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(string id)
    {
      try
      {
        var cat = FakeDb.Cats.Find(c => c.id == id);
        if (cat is null)
        {
          throw new ArgumentNullException();
        }

        return Ok(cat);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("no such cat");
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Cat> Edit([FromBody]Cat newcat, string id)
    {
      try
      {
        var cat = FakeDb.Cats.Find(c => c.id == id);
        if (cat is null)
        {
          throw new ArgumentNullException();
        }
        cat.Name = newcat.Name;
        cat.Age = newcat.Age;
        cat.Hair = newcat.Hair;
        return Ok(cat);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("no such cat");
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    [HttpPost]
    public ActionResult<Cat> create([FromBody]Cat newcat)
    {
      try
      {
        FakeDb.Cats.Add(newcat);
        return Ok(newcat);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("no such cat");
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        var cat = FakeDb.Cats.Find(c => c.id == id);
        if (cat is null)
        {
          throw new ArgumentNullException();
        }
        FakeDb.Cats.Remove(cat);
        return Ok("successfully deleted cat");
      }
      catch (ArgumentNullException)
      {
        return BadRequest("could not find that cat");
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
