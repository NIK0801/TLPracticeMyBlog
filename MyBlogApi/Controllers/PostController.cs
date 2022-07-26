﻿using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Post = MyBlogApi.Domain.Post;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [ExceptionFilter]
    public class PostController : ControllerBase
    {
        private readonly IService<Post, PostDto> _postsService;
        public PostController(IService<Post, PostDto> service)
        {
            _postsService = service;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            return Ok(_postsService.GetAll()
                    .ConvertAll(post => post.ConvertToPostsDto()));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPost(int Id)
        {
            return Ok(_postsService.GetById(Id).ConvertToPostsDto());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] PostDto postsDto)
        {
            return Ok(_postsService.Create(postsDto));
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult Delete(int Id)
        {
            _postsService.Delete(Id);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] PostDto postsDto)
        {

            _postsService.Update(postsDto);
            return Ok();
        }
    }
}
