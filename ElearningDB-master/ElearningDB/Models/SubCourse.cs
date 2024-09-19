using System;
using System.Collections.Generic;

namespace ElearningDB.Models;

public partial class SubCourse
{
    public int SubCourseId { get; set; }

    public string SubCourseName { get; set; } = null!;

    public decimal Price { get; set; }

    public int CourseId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
