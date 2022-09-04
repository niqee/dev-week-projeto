using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  //os "using" estão organizados por tipo. Esses são do .NET
using System.Net;

using src.Models;
using src.Persistence;




namespace src.Controllers;

[ApiController]
[Route("[Controller]")]
public class PersonController: ControllerBase{

    private DatabaseContext _context  { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Person>> Get(){
        //Ok - 200, NotContent 204


        //Person pessoa = new Person("Maria",20,"123.456.789.10");
        //Contract NewContracts = new Contract("abc123",50.46);
        //pessoa.Contracts.Add(NewContracts);
        //return pessoa;

        var result = _context.Persons.Include(p => p.Contracts).ToList();
        if(!result.Any()) return NoContent();
        return Ok(result); 
    }

    [HttpPost]
    public ActionResult<Person> Post([FromBody]Person pessoa){
       

        try
        {
            _context.Persons.Add(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return BadRequest();
        }


       
       
        return Created("created",pessoa);
    }

    [HttpPut("{id}")]

    public ActionResult<object> Update(
        [FromRoute]int id,
        [FromBody] Person pessoa
        )
        
    {

         var result = _context.Persons.SingleOrDefault(e => e.Id == id);
        if(result is null){
            return NotFound(new{

                msg = "register not found",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
           _context.Persons.Update(pessoa);
        _context.SaveChanges(); 
        }
        catch (System.Exception)
        {
            
            return BadRequest(new {
            msg = "There was an error sending update request" + id + " updated",
            status = HttpStatusCode.OK
        } );
        }
        
        
        return Ok (new {
            msg = $"Data ID  {id} updated", //padrão de boa prática usar "modo $"
            status = HttpStatusCode.OK
        } );
    }

    [HttpDelete("{id}")]
   
    public ActionResult<string> Delete([FromRoute] int id)
    { 
     var result = _context.Persons.SingleOrDefault(e => e.Id == id);

    if(result is null){
        return BadRequest(new {
            msg = "Non-existent content, Invalid request",
            status = HttpStatusCode.BadRequest
        });
    }

     _context.Persons.Remove(result);
     _context.SaveChanges();
        
     return Ok(new {
        msg = "Id Person has deleted" + id,
        status = HttpStatusCode.OK
     });

     }
   
   
   
   
   
   // public string Delete([FromRoute] int id)
   // { 
   //     var result = _context.Persons.SingleOrDefault(e => e.Id == id);

   //     _context.Persons.Remove(result);
   //     _context.SaveChanges();
        
   //     return "id person has deleted " + id;
   //  }
    
 
    

}