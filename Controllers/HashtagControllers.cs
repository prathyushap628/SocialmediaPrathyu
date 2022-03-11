using Dotnetsql.Models;
using Dotsql.Repositories;
using hashtag.models;
using Microsoft.AspNetCore.Mvc;
using own.DTOs;
using post.Repositories;

namespace Own.Controllers;

[ApiController]
[Route("api/Hashtag")]
public class HashtagControllerController : ControllerBase
{


    private readonly ILogger<HashtagControllerController> _logger;
    private readonly IHashtagRepository _Hashtag;
    private readonly IPostRepository _post;


    public HashtagControllerController(ILogger<HashtagControllerController> logger, IHashtagRepository Hashtag, IPostRepository post)
    {
        _logger = logger;
        _Hashtag = Hashtag;
        _post = post;
    }

    [HttpGet("{Hashtag_id}")]
    public async Task<ActionResult<Hashtag>> GetHashtagById([FromRoute] long Hashtag_id)
    {
        var Hashtag = await _Hashtag.GetById(Hashtag_id);
        if (Hashtag is null)
            return NotFound("No Hashtag found with given Hashtag id");

        //var dto = HashtagDto;
        Hashtag.posts = await _post.GetPostHashtag(Hashtag.HashtagId);
        return Ok(Hashtag);

    }
    [HttpPost]
    public async Task<ActionResult<Hashtag>> CreateHashtag([FromBody] Hashtag Data)
    {
        var toCreateHashtag = new Hashtag
        {

            HashtagName = Data.HashtagName.Trim(),
            // PostId = Data.PostId,
            // UserId = Data.UserId,
        };

        var createdHashtag = await _Hashtag.Create(toCreateHashtag);
        return StatusCode(StatusCodes.Status201Created, createdHashtag);
    }

    [HttpPut("{Hashtag_id}")]
    public async Task<ActionResult> UpdateHashtag([FromRoute] long Hashtag_id, [FromBody] Hashtag Data)
    {
        var existing = await _Hashtag.GetById(Hashtag_id);
        // if (existing is null)
        //     return NotFound("No Hashtag found with given employee number");
        // var toUpdateHashtag = existing with
        // {
        //     PostId = Data.PostId,
        //     UserId = Data.UserId,

        // };
        //var didUpdate = await _Hashtag.Update(toUpdateHashtag);
        //if (!didUpdate)

        //  return StatusCode(StatusCodes.Status500InternalServerError, "could not update Hashtag");

        return NoContent();
    }

    [HttpDelete("{Hashtag_id}")]
    public async Task<ActionResult> DeleteHashtag([FromRoute] long Hashtag_id)
    {
        var existing = await _Hashtag.GetById(Hashtag_id);
        if (existing is null)
            return NotFound("No Hashtag found with given Hashtag id");
        var didDelete = await _Hashtag.Delete(Hashtag_id);
        return NoContent();

    }




}