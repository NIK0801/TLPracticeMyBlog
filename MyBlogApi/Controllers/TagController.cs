﻿using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Tag = MyBlogApi.Domain.Tag;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [ExceptionFilter]
    public class TagController : ControllerBase
    {
        private readonly IService<Tag, TagDto> _tagsService;
        public TagController(IService<Tag, TagDto> service)
        {
            _tagsService = service;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            return Ok(_tagsService.GetAll()
                    .ConvertAll(tag => tag.ConvertToTagsDto()));          
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTag(int Id)
        {
            return Ok(_tagsService.GetById(Id).ConvertToTagsDto());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] TagDto tagsDto)
        {
            return Ok(_tagsService.Create(tagsDto));
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult Delete(int Id)
        {
            _tagsService.Delete(Id);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] TagDto tagsDto)
        {
            _tagsService.Update(tagsDto);
            return Ok();
        }
    }
}
