
using testone.Model;
using testone.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace testone.Controllers;
[Route("api/[controller]")]
[ApiController]

public class HomeController: ControllerBase  
{

    private readonly DbaseContext _dbContext;  
    public HomeController(DbaseContext dbaseContext)
    {
        _dbContext = dbaseContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ships = await _dbContext.TestShipping.ToListAsync();
        return Ok(ships);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var shipId = await _dbContext.TestShipping.FindAsync(id);
        return Ok(shipId);
    }

    [HttpPost]
    public async Task<IActionResult> InsertShip (Ship model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }        
            _dbContext.TestShipping.Add(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
    }
     
     [HttpPut]
     public async Task<IActionResult> UpdateShip(Ship model)
     {
        _dbContext.TestShipping.Update(model);
        await _dbContext.SaveChangesAsync();
        return  Ok(model);
     }


    [HttpDelete]
    [Route("id:int")]
    public async Task<IActionResult> DeleteShip(int id)
    {
        var shipdata =await _dbContext.TestShipping.FindAsync(id);
        if (shipdata  == null)
        {
            return NotFound();
            
        }
            _dbContext.TestShipping.Remove(shipdata);
            await _dbContext.SaveChangesAsync();
            return Ok();

    }
   

  
}
