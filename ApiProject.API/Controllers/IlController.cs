using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.API.Context;
using ApiProject.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlController : ControllerBase
    {
       private readonly IlContext _context;

       public IlController (IlContext context)
       {
           _context = context;
           if(_context.il.Count() == 0)
           {
               _context.il.Add(new Il{IlID =1, IlAdi = "Item1"});
               _context.SaveChanges();
           }
       }

    [HttpGet] // GET api/values
    public ActionResult<List<Il>> GetAll() 
    {
        return _context.il.OrderBy(k => k.IlID).ToList();
    }

    [HttpGet("{id}", Name = "GetIl")]
    public ActionResult<Il> GetSelected(int id) // GET api/values/5
    {
        //public string Get(int id)
        //{
        //    return "value";
        //}
        var selected = _context.il.Find(id);
        if(selected == null)
        {
            return NotFound();
        }
        return selected;
    }

    [HttpPost]
    public ActionResult Post(Il il)
    {
        var ils = new Il
        {
            IlID = il.IlID,
            IlAdi = il.IlAdi,
        };
        _context.il.Add(ils);
        _context.SaveChanges();
        return CreatedAtAction("GetSelected", new{id = il.IlID}, ils);
    }

    [HttpPut]
    public ActionResult Put(Il il) // PUT api/values/5
    {
        var selected = _context.il.Find(il.IlID);
         if(selected is null)
         {
             selected = new Il {IlID = il.IlID, IlAdi = il.IlAdi};
             _context.il.Add(selected);
             _context.SaveChanges();
             return CreatedAtRoute("GetSelected", new { id = selected.IlID }, selected);
         }
         selected.IlID = il.IlID;
         selected.IlAdi = il.IlAdi; 
         _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id) // DELETE api/values/5
    {
        var selected = _context.il.Find(id);
        if(selected is null)
        {
            return NotFound();
        }

        _context.il.Remove(selected);
        _context.SaveChanges();
        return RedirectToAction("GetAll");
    }
    }
}