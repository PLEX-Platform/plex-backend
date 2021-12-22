using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlexBackend.WebApi.ViewModels;
using PlexBackend.Core.Interfaces;
using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using System.Threading.Tasks;
using System.Linq;

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentChoicesController : ControllerBase
    {
        private readonly IStudentChoiceService _studentChoiceService;
        private readonly IMapper mapper;

        public StudentChoicesController(IMapper mapper, IStudentChoiceService studentChoiceService)
        {
            _studentChoiceService = studentChoiceService;
            this.mapper = mapper;
        }

        /// <summary>
        /// HttpGet to return all the recorded Studentchoices
        /// </summary>
        // GET: api/StudentChoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentChoiceViewModel>>> GetStudentChoices()
        {
            IEnumerable<StudentChoice> studentChoices = await _studentChoiceService.FindAll();

            return Ok(mapper.Map<List<StudentChoice>, List<StudentChoiceViewModel>>(studentChoices.ToList()));
        }

        /// <summary>
        /// HttpGet to return a specific StudentChoice
        /// </summary>
        /// <param name="id">The Guid that identifies the choice in the database.</param>
        // GET: api/StudentChoices/5
        [HttpGet("{id}")]
        public ActionResult<StudentChoiceViewModel> GetStudentChoice(int id)
        {
            StudentChoice studentChoice = _studentChoiceService.GetById(id);

            if (studentChoice == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentChoice, StudentChoiceViewModel>(studentChoice));
        }

        /// <summary>
        /// HttpGet to return a specific students projectchoices
        /// </summary>
        /// <param name="PCN">Number that identifies the student.</param>
        // GET: api/StudentChoices/5
        [HttpGet("/GetChoicesByPCN/{PCN}")]
        public ActionResult<StudentChoiceByPCNViewModel> GetChoicesByPCN(int PCN)
        {
            List<StudentChoice> studentChoices = _studentChoiceService.FindByCondition(e => e.Student.StudentNumber == PCN);

            if (studentChoices.Count == 0)
            {
                return NotFound();
            }

            StudentChoiceByPCNViewModel vm = new StudentChoiceByPCNViewModel
            {
                ProjectPriorities = mapper.Map<List<StudentChoice>, List<ProjectPriority>>(studentChoices),
                StudentPCN = PCN
            };

            return Ok(vm);
        }

        // PUT: api/StudentChoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public IActionResult PutStudentChoice(int id, StudentChoiceViewModel studentChoiceVM)
        //{
        //    if (id != studentChoiceVM.Id)
        //    {
        //        return BadRequest();
        //    }

        //    StudentChoice studentChoiceDataModel = mapper.Map<StudentChoiceViewModel, StudentChoice>(studentChoiceVM);
        //    _studentChoiceRepository.Update(studentChoiceDataModel);

        //    try
        //    {
        //        _studentChoiceRepository.Save();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentChoiceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        /// <summary>
        /// HttpPost to submit a students projectchoice
        /// </summary>
        /// <param name="studentChoiceVM">The viewmodel containing the studentnumber and his choice of projects.</param>
        [HttpPost]
        public ActionResult<StudentSubmitChoiceViewModel> Post([FromBody]StudentSubmitChoiceViewModel studentChoiceVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ValidateStudentExists validateStudentExists = _studentChoiceService.VerifyUserExists(studentChoiceVM.StudentPCN);

                    if (!validateStudentExists.Exists)
                    {
                        return BadRequest("This student doesn't exist in our system");
                    }

                    List<StudentChoice> databaseInput = mapper.Map<List<ProjectPriority>, List<StudentChoice>>(studentChoiceVM.ProjectPriorities);

                    foreach (StudentChoice sc in databaseInput)
                    {
                        sc.StudentId =  validateStudentExists.Student.Id;
                    }

                    try
                    {
                        _studentChoiceService.AddRange(databaseInput);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return BadRequest("The input is not valid");
        }

        /// <summary>
        /// HttpGet to delete a specific studentchoice
        /// </summary>
        /// <param name="id">The Guid that identifies the studentchoice within the database.</param>
        // DELETE: api/StudentChoices/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentChoice(Guid id)
        {
            try
            {
                if (!_studentChoiceService.DeleteStudentChoice(id))
                {
                    return NotFound();
                }         
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }
    }
}
