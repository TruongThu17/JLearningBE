﻿using AutoMapper;
using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reporitories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/blog-details")]
    [ApiController]
    public class BlogDetailController : ControllerBase
    {
        // Repository
        private IBlogDetailRepository repository = new BlogDetailRepository();

        // Mapper
        private readonly IMapper _mapper;

        // Get mapper singleton
        public BlogDetailController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // POST api/<BlogDetailController>
        [HttpPost("insert")]
        public ActionResult Post([FromBody][Bind("blog_id,blog_img_url,header,description")] BlogDetailDTO blogDetailDTO)
        {
            if (ModelState.IsValid)
            {
                BlogDetail blogDetail = _mapper.Map<BlogDetail>(blogDetailDTO);
                repository.CreateBlogDetail(blogDetail);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // PUT api/<BlogDetailController>/5
        [HttpPost("update")]
        public ActionResult Put([FromBody][Bind("blog_details_id,blog_id,blog_img_url,header,description")] BlogDetailDTO blogDetailDTO)
        {
            var blogDetail = repository.FindBlogDetailById(blogDetailDTO.BlogDetailsId);
            if (blogDetail == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BlogDetail b = _mapper.Map<BlogDetail>(blogDetailDTO);
            repository.UpdateBlogDetail(b);
            return Ok();
        }

        // DELETE api/<BlogDetailController>/5
        [HttpPost("delete")]
        public ActionResult Delete([FromBody] int blog_details_id)
        {
            var blogDetail = repository.FindBlogDetailById(blog_details_id);
            if (blogDetail == null) return NotFound();
            else
            {
                repository.DeleteBlogDetail(blogDetail);
                return Ok();
            }
        }
    }
}
