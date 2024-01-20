using WebAppAdd.DTOs.SchoolDTOs;
using WebAppAdd.Models;

namespace WebAppAdd.Abstraction.IServices
{
    public interface ISchoolService
    {
        public Task<ResponseModel<List<SchoolGetDTO>>> GetAllSchools();
        public Task<ResponseModel<SchoolGetDTO>> GetSchoolById(int schoolId);
        public Task<ResponseModel<SchoolUpdateDTO>> UpdateSchool(SchoolUpdateDTO schoolupdateDTO);
        public Task<ResponseModel<bool>> DeleteSchoolById(int schoolId);
        public Task<ResponseModel<SchoolCreateDTO>> AddSchool(SchoolCreateDTO schoolCreateDTO);

    }
}
