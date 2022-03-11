using Dotnetsql.Models;
using Dotsql.Repositories;
using Microsoft.AspNetCore.Mvc;
using own.DTOs;
using likes.models;
using likes.Repositories;

namespace Likes.Controllers;

[ApiController]
[Route("api/Likes")]
public class LikesControllerController : ControllerBase
{


    private readonly ILogger<LikesControllerController> _logger;
    private readonly ILikesRepository _Likes;

    public LikesControllerController(ILogger<LikesControllerController> logger, ILikesRepository Likes)
    {
        _logger = logger;
        _Likes = Likes;
    }

    [HttpGet("{Likes_id}")]
    public async Task<ActionResult<Like>> GetLikesById([FromRoute] long Likes_id)
    {
        var Likes = await _Likes.GetById(Likes_id);
        if (Likes is null)
            return NotFound("No Likes found with given user id");


        return Ok(Likes);

    }
    // [HttpPost]
    // public async Task<ActionResult<Like>> CreateLikes([FromBody] Like Data)
    // {
    //     var toCreateLikes = new Like
    //     {

    //         UserId = Data.UserId,
    //         PostId = Data.PostId,
    //         CreatedDatetime = Data.CreatedDatetime,
    //      };
    //  var createdLikes = await _Likes.Create(toCreateLikes);
    //     return StatusCode(StatusCodes.Status201Created, createdLikes);
    
    // }

    [HttpDelete("{Likes_id}")]
    public async Task<ActionResult> DeleteLikes([FromRoute] long Likes_id)
    {
        var existing = await _Likes.GetById(Likes_id);
        if (existing is null)
            return NotFound("No Likes found with given Likes id");
        await _Likes.Delete(Likes_id);
        return NoContent();

    }




}