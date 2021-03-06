﻿using System;

namespace Mino.Core.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        public TaskPriority Priority { get; set; }

        public int? TagId { get; set; }

        public int? ProjectId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public bool IsDone { get; set; }

        public bool HasNotification { get; set; }

        public DateTime? DateTime { get; set; }

        public Tag Tag { get; set; }

        public Project Project { get; set; }

        public void Modify(string name, TaskPriority priority, int? projectId = null,
            int? tagId = null, DateTime? dateTime = null)
        {
            Name = name;
            ProjectId = projectId;
            TagId = tagId;
            DateTime = dateTime;
            Priority = priority;
        }

        public void Finish()
        {
            IsDone = true;
        }

        public void SetNotification()
        {
            HasNotification = true;
        }
    }
}