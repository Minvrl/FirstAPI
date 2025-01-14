﻿using FirstAPI.Data;
using FirstAPI.Data.Entities;
using FirstAPI.Dtos.GroupDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private UniDbContext _context;
        public GroupsController(UniDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult<List<GroupGetDto>> GetAll()
        {
            List<GroupGetDto> dtos = _context.Groups.Select(x => new GroupGetDto
            {
                Id = x.Id,
                No = x.No,
                Limit = x.Limit
            }).ToList();

            return StatusCode(200, dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<GroupGetDto> GetById(int id)
        {
            var data = _context.Groups.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (data == null)
            {
                return StatusCode(404);
            }

            GroupGetDto dto = new GroupGetDto
            {
                Id = data.Id,
                No = data.No,
                Limit = data.Limit
            };
            return StatusCode(200, dto);
        }
        [HttpPost("")]
        public ActionResult Create(GroupCreateDto createDto)
        {
            if (_context.Groups.Any(x => x.No == createDto.No && !x.IsDeleted))
                return StatusCode(409);

            var entity = new Group
            {
                Limit = createDto.Limit,
                No = createDto.No,
            };

            _context.Groups.Add(entity);
            _context.SaveChanges();


            return StatusCode(201, new { Id = entity.Id });
        }
    }
}
