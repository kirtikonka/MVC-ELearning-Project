using System;
using System.Collections.Generic;

namespace ElearningDB.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<SubCourse> SubCourses { get; set; } = new List<SubCourse>();

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
