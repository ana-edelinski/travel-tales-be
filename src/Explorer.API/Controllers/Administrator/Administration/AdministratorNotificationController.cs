﻿using Microsoft.AspNetCore.Authorization;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Administrator.Administration
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administrator/notification")]
    public class AdministratorNotificationController: BaseApiController
    {
        private readonly INotificationService _notificationService;

        public AdministratorNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet]
        public ActionResult<PagedResult<NotificationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _notificationService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<NotificationDto> Create([FromBody] NotificationDto notification)
        {
            var result = _notificationService.Create(notification);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<NotificationDto> Update([FromBody] NotificationDto notification)
        {
            var result = _notificationService.Update(notification);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _notificationService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("getall/{id:int}")]
        public ActionResult<PagedResult<NotificationDto>> GetAllByUser(int id, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _notificationService.GetAllByUser(id, page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("getunread/{id:int}")]
        public ActionResult<PagedResult<NotificationDto>> GetUnreadByUser(int id, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _notificationService.GetUnreadByUser(id, page, pageSize);
            return CreateResponse(result);
        }

    }
}
