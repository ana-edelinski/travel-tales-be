﻿

namespace Explorer.Stakeholders.API.Dtos
{
    public class AppReviewDto
    {
        public long UserId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
