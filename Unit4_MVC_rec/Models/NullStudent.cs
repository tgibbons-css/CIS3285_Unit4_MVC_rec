using Unit4_MVC_rec.Models;

namespace Unit4_MVC_rec.Models;

public class NullStudent : IStudentInterface
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Credits { get; set; }

    public NullStudent()
    {
        Id = -1;
        Name = "Null Student";
        Credits = -999;
    }
}