using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<School> _schoolRepository;
        public SchoolService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._schoolRepository = _unitOfWork.GetRepository<School>();   
        }

        public async Task<ResponseModel<SchoolCreateDTO>> AddSchool(SchoolCreateDTO schoolCreateDTO)
        {
            try
            {
                if(schoolCreateDTO != null)
                {
                    await _schoolRepository.AddAsync(new()
                    {
                        Name = schoolCreateDTO.Name,    
                    });
                    var affectedRows = await _unitOfWork.SaveChangesAsync();
                    if(affectedRows > 0)
                    {
                        return new ResponseModel<SchoolCreateDTO>
                        {
                            Data = schoolCreateDTO,
                            StatusCode = 201
                        };
                    }
                    else
                    {
                        return new ResponseModel<SchoolCreateDTO>
                        {
                            Data = null,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<SchoolCreateDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
               
                return new ResponseModel<SchoolCreateDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            
            }
        }

        public async Task<ResponseModel<bool>> DeleteSchoolById(int schoolId)
        {
            try
            {
                School school = await _schoolRepository.GetByIdAsync(schoolId);
                if (schoolId != null)
                {
                    _schoolRepository.Remove(school);
                    var affectedRows = await _unitOfWork.SaveChangesAsync();
                    if (affectedRows > 0)
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
                            Data = true,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<bool>
                    {
                        Data = true,
                        StatusCode = 400
                    };
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<bool>
                {
                    Data = true,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<List<SchoolGetDTO>>> GetAllSchools()
        {
            try
            {
                List<School> schoolList = await _schoolRepository.GetAll().ToListAsync();

                if(schoolList.Count > 0)
                {
                    List<SchoolGetDTO> schools = _mapper.Map<List<SchoolGetDTO>>(schoolList);
                    return new ResponseModel<List<SchoolGetDTO>>
                    {
                        Data = schools,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<List<SchoolGetDTO>>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<List<SchoolGetDTO>>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<SchoolGetDTO>> GetSchoolById(int schoolId)
        {
            try
            {
                School school = await _schoolRepository.GetByIdAsync(schoolId); 
                if(school != null)
                {
                    SchoolGetDTO schoolGetDTO = _mapper.Map<SchoolGetDTO>(school);
                    return new ResponseModel<SchoolGetDTO>
                    {
                        Data = schoolGetDTO,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<SchoolGetDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<SchoolGetDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<SchoolUpdateDTO>> UpdateSchool(SchoolUpdateDTO schoolupdateDTO)
        {
            try
            {
                if(schoolupdateDTO != null)
                {
                    School school = await _schoolRepository.GetByIdAsync(schoolupdateDTO.ID);
                    if (school != null)
                    {
                        school.Name = schoolupdateDTO.Name;

                        _schoolRepository.Update(school);
                        var affectedRows = await _unitOfWork.SaveChangesAsync();

                        if(affectedRows > 0)
                        {
                            return new ResponseModel<SchoolUpdateDTO>
                            {
                                Data = schoolupdateDTO,
                                StatusCode = 200
                            };
                        }
                        else
                        {
                            return new ResponseModel<SchoolUpdateDTO>
                            {
                                Data = schoolupdateDTO,
                                StatusCode = 500
                            };
                        }
                    }
                    else
                    {
                        return new ResponseModel<SchoolUpdateDTO>
                        {
                            Data = schoolupdateDTO,
                            StatusCode = 400
                        };
                    }
                }
                else
                {
                    return new ResponseModel<SchoolUpdateDTO>
                    {
                        Data = schoolupdateDTO,
                        StatusCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + ex.InnerException);

                return new ResponseModel<SchoolUpdateDTO>
                {
                    Data = schoolupdateDTO,
                    StatusCode = 500
                };
            }
        }
    }
}