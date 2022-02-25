using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MemberRestApi.Repositories;
using MemberRestApi.Entities;
using System.Linq;
using System.Data.Common;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using MemberRestApi.Dtos;

namespace MemberRestApi.Controllers
{
    /// <summary>
    /// A controller providing methods for database management
    /// </summary>
    [ApiController]
    [Route("members")]

    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository repository;

        public MemberController(IMemberRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Request to fetch all the current member from the repository
        /// </summary>
        /// <returns>A collection of the DTOs of the members</returns>
        [HttpGet]
        public IEnumerable<MemberDto> GetMembers()
        {
            var items = repository.GetMembers().Select( item => item.AsDto());
            Logger.logInfo("GET request for all members has been processed");
            return items;
        }

        // GET /members/{id}
        [HttpGet("{id}")]
        public ActionResult<MemberDto> GetMember(Guid id)
        {
            var item = repository.GetMember(id);
            if(item is null)
            {
                return NotFound();
            }
            Logger.logInfo("GET request for member "+id+ " has been processed");
            return item.AsDto();
        }

        // POST /members
        [HttpPost]
        public ActionResult<MemberDto> CreateMember(CreateMemberDto itemDto)
        {
            Member item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Email = itemDto.Email,
                VipMember = itemDto.VipMember,
                Age = itemDto.Age,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateMember(item);
            Logger.logInfo("New member " + item.Id + " has been created");

            return CreatedAtAction(nameof(GetMember), new { id = item.Id}, item.AsDto());
        }

        // PUT /members/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMembers(Guid id, UpdateMemberDto memberDto)
        {
            var existingItem = repository.GetMember(id);

            if(existingItem is null)
            {
                return NotFound();
            }

            Member updatedItem = existingItem with {
                Name = memberDto.Name,
                Email = memberDto.Email,
                VipMember = memberDto.VipMember,
                Age = memberDto.Age
            };

            repository.UpdateMember(updatedItem);
            Logger.logInfo("Member " + updatedItem.Id + " has been updated");

            return NoContent();
        }

        // DELETE /members/
        [HttpDelete("{id}")]
        public ActionResult DeleteMember(Guid id)
        {
            var existingItem = repository.GetMember(id);

            if(existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteMember(id);
            Logger.logInfo("Member " + existingItem.Id + " has been deleted");

            return NoContent();
        }
    }
}