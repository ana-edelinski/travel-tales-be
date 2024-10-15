﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/clubInvitation")]
    public class ClubInvitationController : BaseApiController
    {

        private readonly IClubInvitationService _clubInvitationService;
        public ClubInvitationController(IClubInvitationService clubInvitationService)
        {
            _clubInvitationService = clubInvitationService;
        }

        [HttpGet]
        public ActionResult<PagedResult<ClubInvitationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _clubInvitationService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ClubInvitationDto> Create([FromBody] ClubInvitationDto clubInvitation)
        {
            var result = _clubInvitationService.Create(clubInvitation);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubInvitationDto> Update([FromBody] ClubInvitationDto clubInvitation)
        {
            var result = _clubInvitationService.Update(clubInvitation);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _clubInvitationService.Delete(id);
            return CreateResponse(result);
        }
    }
}
