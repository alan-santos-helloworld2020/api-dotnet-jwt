using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.Models;
using back.HashConfiguration;
using Microsoft.AspNetCore.Authorization;
namespace back.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{
    private readonly DatabaseContext db;

    public UserController(DatabaseContext Userdb)
    {
        db = Userdb;
    }

    [HttpGet]
    public async Task<IActionResult> findAll()
    {
        var users = db.users.ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> findById(int id)
    {
        var user = await db.users.FindAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(user);
        }
    }

    [HttpPost]
    public async Task<IActionResult> save(User user)
    {
        HashConfig hash = new HashConfig();
        string result = hash.passwordEncoder(user);
        user.Password = result;
        db.Add(user);
        var res = await db.SaveChangesAsync();
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> update(int id, User user)
    {
        HashConfig hash = new HashConfig();
        var old = await db.users.FindAsync(id);
        if (old is null)
        {
            return NotFound();
        }
        else
        {
            old.Username = user.Username;
            old.Email = user.Email;
            old.Password = hash.passwordEncoder(user);
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var user = await db.users.FindAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        else
        {
            db.users.Remove(user);
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }
    }





}