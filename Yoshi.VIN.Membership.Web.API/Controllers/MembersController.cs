using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoshi.VIN.Membership.Models;
using Yoshi.VIN.Membership.Web.API.Models;
using Yoshi.VIN.Membership.Repositories.Interfaces;

namespace Yoshi.VIN.Membership.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Members")]
    public class MembersController : Controller
    {
        private readonly IUnitOfWork _uow;


        public MembersController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        // GET: api/Members
        [HttpGet]
        public IEnumerable<Member> GetMember()
        {
            return _uow.MemberRepository.GetAll();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _uow.MemberRepository.SingleOrDefaultAsync(m => m.ID == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember([FromRoute] int id, [FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.ID)
            {
                return BadRequest();
            }

            try
            {
                _uow.MemberRepository.Update(member);
                await _uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.MemberRepository.Insert(member);
            await _uow.CommitAsync();

            return CreatedAtAction("GetMember", new { id = member.ID }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _uow.MemberRepository.SingleOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            _uow.MemberRepository.Delete(member);
            await _uow.CommitAsync();

            return Ok(member);
        }

        private bool MemberExists(int id)
        {
            return _uow.MemberRepository.MemberExists(id);
        }
    }
}