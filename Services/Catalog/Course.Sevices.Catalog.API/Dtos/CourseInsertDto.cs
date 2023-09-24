using System;

namespace Course.Sevices.Catalog.API.Dtos
{
    public class CourseInsertDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
        public string CategoryId { get; set; }
        public FeatureDto Feature { get; set; }
    }
}
