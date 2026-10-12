using System;
using System.ComponentModel.DataAnnotations;

namespace Unit4_MVC_rec.Models
{

    public class StudentModel : IStudentInterface
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Credits { get; set; }

        public StudentModel()
        {
            Id = -1;
            Name = "Non";
            Credits = -1;
        }

        public StudentModel(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }

    }
}
