namespace WebAppAdd.DTOs.StudentDTOs
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
// entity change school student
// according to the video
// add entity + migration + update db
// 2 dtos crud 3dto cur -d 
// get dto automapper
// new folder service folder -> abstraction and implementation folders
// into the anstraction create services for each dtos 
// NEW* response model(generic)