﻿using Microsoft.AspNet.Identity;
using Mino.Core.Dtos;
using Mino.Core.Models;
using Mino.Persistence;
using System.Web.Http;

namespace Mino.Controllers.Api
{
    [Authorize]
    public class TasksController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public TasksController()
        {
            var context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpPost]
        public IHttpActionResult Create(TaskDto dto)
        {
            var task = new Tasks
            {
                Name = dto.Name,
                UserId = User.Identity.GetUserId()
            };

            _unitOfWork.Tasks.Add(task);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Edit(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetUserTask(User.Identity.GetUserId(), dto.TaskId);

            task.Modify(dto.Name,
                dto.Priority,
                dto.ProjectId,
                dto.TagId,
                dto.GetDateTime());

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetUserTask(User.Identity.GetUserId(), dto.TaskId);

            _unitOfWork.Tasks.Remove(task);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Finish(TaskDto dto)
        {
            var task =
                _unitOfWork.Tasks
                .GetUserTask(User.Identity.GetUserId(), dto.TaskId);

            task.Finish();
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Search(TaskDto dto)
        {


            return Ok();
        }
    }
}
