using WebAppAdd.DTOs.StudentDTOs;
using WebAppAdd.Entities;
using WebAppAdd.Models;

    public interface IStudentService
    {
        Task<ResponseModel<StudentCreateDTO>> AddStudent(StudentCreateDTO studentCreateDTO);
        Task<ResponseModel<List<StudentCreateDTO>>> GetAllStudents();
        Task<ResponseModel<bool>> DeleteStudent(int studentId);
        Task<ResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO);
        Task<ResponseModel<StudentGetDTO>> GetStudentById(int studentId);
        Task<ResponseModel<List<StudentGetDTO>>> GetAllStudentBySchoolId(string SchoolId);
        Task<ResponseModel<bool>> ChangeSchool(int studentID, int schoolID);
        Task<Student> GetStudentId(int studentId);

    }

