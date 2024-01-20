using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Abstraction.IServices;
using WebAppAdd.Abstraction.IUnitOfWorks;
using WebAppAdd.Data;
using WebAppAdd.DTOs.SchoolDTOs;
using WebAppAdd.DTOs.StudentDTOs;
using WebAppAdd.Entities;
using WebAppAdd.Models;

namespace WebAppAdd.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly WebAppAddDbContext _webAppAddDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<School> _schoolRepository;
        public StudentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._studentRepository = _unitOfWork.GetRepository<Student>();
            this._schoolRepository = _unitOfWork.GetRepository<School>();
        }

        public async Task<ResponseModel<StudentCreateDTO>> AddStudent(StudentCreateDTO studentCreateDTO)
        {
            try
            {
                if(studentCreateDTO != null)
                {
                    await _studentRepository.AddAsync(new()
                    {
                        Name = studentCreateDTO.Name,
                        Email = studentCreateDTO.Email,
                        Sch = studentCreateDTO.SchoolID
                    });
                    var affectedRows = await _unitOfWork.SaveChangesAsync();
                    if(affectedRows > 0)
                    {
                        return new ResponseModel<StudentCreateDTO>
                        {
                            Data = studentCreateDTO,
                            StatusCode = 201
                        };
                    }
                    else
                    {
                        return new ResponseModel<StudentCreateDTO>
                        {
                            Data = null,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<StudentCreateDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<StudentCreateDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<bool>> ChangeSchool(int studentID, int newSchoolID)
        {
            var studentData =  await _studentRepository.GetByIdAsync(studentID);
            if(studentData == null)
            {
                return new ResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 400
                };
            }
            studentData.Sch = newSchoolID;
            _studentRepository.Update(studentData);
            int rowAffected = await _unitOfWork.SaveChangesAsync();
            if(rowAffected > 0)
            {
                return new ResponseModel<bool>
                {
                    Data = true,
                    StatusCode = 200
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<bool>> DeleteStudent(int studentId)
        {
            try
            {
                Student student = await _studentRepository.GetByIdAsync(studentId);
                if(student != null)
                {
                    _studentRepository.Remove(student);
                    var affectedRows = await _unitOfWork.SaveChangesAsync();
                    if(affectedRows > 0)
                    {
                        return new ResponseModel<bool> { Data = true, StatusCode = 200 };
                    }
                    else
                    {
                        return new ResponseModel<bool> { Data = false, StatusCode = 500 };
                    }
                }
                else
                {
                    return new ResponseModel<bool> { Data = false, StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<bool> { Data = false, StatusCode = 500 };

            }
        }

        public Task<ResponseModel<List<StudentGetDTO>>> GetAllStudentBySchoolId(string SchoolId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<StudentCreateDTO>>> GetAllStudents()
        {
            try
            {
                List<Student> studentList = await _studentRepository.GetAll().Include(x => x.School).ToListAsync();
                if(studentList.Count > 0)
                {
                    List<StudentGetDTO> students = _mapper.Map<List<StudentGetDTO>>(studentList);
                    return new ResponseModel<List<StudentGetDTO>>{ Data = students, StatusCode = 200 };
                }
                else
                {
                    return new ResponseModel<List<StudentGetDTO>> { Data = null, StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<List<StudentGetDTO>> { Data = null, StatusCode = 500 };

            }
        }

        public async Task<ResponseModel<StudentGetDTO>> GetStudentById(int SchoolId)
        {
            try
            {
                var students = await _studentRepository.GetAll().Where(s => s.)
            }
            catch (Exception ex)
            {

            }
        }

        public Task<Student> GetStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
