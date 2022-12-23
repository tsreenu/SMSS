using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSModels;

namespace SMSSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionDetailsController : ControllerBase
    {
        private readonly ISectionDetailsService sectionService;

        public SectionDetailsController(ISectionDetailsService sectionService)
        {
            this.sectionService = sectionService;
        }

        // GET: api/SectionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionDetails>>> GetSectionDetails()
        {
            try
            {
                return Ok(await sectionService.GetSectionDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        // GET: api/SectionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionDetails>> GetSectionDetails(int id)
        {
            try
            {
                var sectionDetails = await sectionService.GetSectionDetails(id);
                if (sectionDetails == null)
                {
                    return NotFound();
                }
                return Ok(sectionDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        // PUT: api/SectionDetails/5
        [HttpPut]
        public async Task<ActionResult<SectionDetails>> UpdateSectionDetails(SectionDetails sectionDetails)
        {
            try
            {
                var emp = await sectionService.GetSectionDetails(sectionDetails.SectionId);
                if (emp == null)
                {
                    return NotFound($"Section Id = {sectionDetails.SectionId} not found");
                }
                var res = await sectionService.UpdateSectionDetails(sectionDetails);
                return res;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }

        // POST: api/SectionDetails
      
        [HttpPost]
        public async Task<ActionResult<SectionDetails>> AddSectionDetails(SectionDetails sectionDetails)
        {
            try
            {
                if (sectionDetails == null)
                {
                    return BadRequest();
                }
                var createdSectionDetails = await sectionService.AddSectionDetails(sectionDetails);
                return CreatedAtAction(nameof(GetSectionDetails), new { id = createdSectionDetails.SectionId }, createdSectionDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
            return Ok();
        }

        // DELETE: api/SectionDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionDetails(int id)
        {
            try
            {
                var emp = sectionService.GetSectionDetails(id);
                if (emp == null)
                {
                    return NotFound($"Section Id = {id} not found");
                }
                await sectionService.DeleteSectionDetails(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retriving the data from database");
            }
        }
    }
}
