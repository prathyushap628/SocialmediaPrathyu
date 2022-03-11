using Dotnetsql.Models;
using Dotsql.Repositories;
using Microsoft.AspNetCore.Mvc;
using own.DTOs;
using post.Dtos;
using post.models;
using post.Repositories;

namespace post.Controllers;

[ApiController]
[Route("api/post")]
public class PostControllerController : ControllerBase
{


    private readonly ILogger<PostControllerController> _logger;
    private readonly IPostRepository _post;

    public PostControllerController(ILogger<PostControllerController> logger, IPostRepository post)
    {
        _logger = logger;
        _post = post;
    }

    [HttpGet("{post_id}")]
    public async Task<ActionResult<PostDto>> GetPostById([FromRoute] long post_id)
    {
        var post = await _post.GetById(post_id);
        if (post is null)
            return NotFound("No post found with given post id");

        PostDto postDto = new PostDto();
        postDto.UserId = post.UserId;
        //postDto.CreatedDatetime = post.CreatedDatetime;
        postDto.MediaLocation = post.MediaLocation;
        postDto.WrittenText = post.WrittenText;

        return Ok(postDto);
    }

    [HttpPost]
    public async Task<ActionResult<PostCreateDto>> CreatePost([FromBody] PostCreateDto Data)
    {
        var toCreatePost = new Post
        {
            UserId = Data.UserId,
            WrittenText = Data.WrittenText.Trim(),
            MediaLocation = Data.MediaLocation.Trim(),
            // CreatedDatetime = Data.CreatedDatetime.ut,
        };


        var createdPost = await _post.Create(toCreatePost);
        PostCreateDto postCreateDto = new PostCreateDto();
        postCreateDto.MediaLocation = createdPost.MediaLocation;
        //postCreateDto.CreatedDatetime = createdPost.CreatedDatetime;
        postCreateDto.UserId = createdPost.UserId;

        return StatusCode(StatusCodes.Status201Created, createdPost);
    }


    [HttpDelete("{post_id}")]
    public async Task<ActionResult> DeletePost([FromRoute] long post_id)
    {
        var existing = await _post.GetById(post_id);
        if (existing is null)
            return NotFound("No post found with given post id");
        await _post.Delete(post_id);
        return NoContent();

    }
    
  



}