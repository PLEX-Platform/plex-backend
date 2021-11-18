using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlexBackend.WebApi.ViewModels;
using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Interfaces;
using PlexBackend.Core.Services;
using PlexBackend.Core.MatchMaking;
using PlexBackend.Core.Entities;

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentChoicesController : ControllerBase
    {
        private readonly IStudentChoiceService studentChoiceService;
        private readonly IMapper mapper;

        public StudentChoicesController(IMapper mapper, IStudentChoiceService studentChoiceService)
        {
            this.studentChoiceService = studentChoiceService;
            this.mapper = mapper;
        }

        /// <summary>
        /// HttpGet to return all the recorded Studentchoices
        /// </summary>
        // GET: api/StudentChoices
        [HttpGet]
        public ActionResult<IEnumerable<StudentChoiceViewModel>> GetStudentChoices()
        {
            List<StudentChoice> studentChoices = studentChoiceService.FindAll();

            return Ok(mapper.Map<List<StudentChoice>, List<StudentChoiceViewModel>>(studentChoices));
        }

        /// <summary>
        /// HttpGet to return a specific StudentChoice
        /// </summary>
        /// <param name="id">The Guid that identifies the choice in the database.</param>
        // GET: api/StudentChoices/5
        [HttpGet("{id}")]
        public ActionResult<StudentChoiceViewModel> GetStudentChoice(int id)
        {
            StudentChoice studentChoice = studentChoiceService.GetById(id);

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
            List<StudentChoice> studentChoices = studentChoiceService.FindByCondition(e => e.StudentPCN == PCN);

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
                List<StudentChoice> databaseInput = mapper.Map<List<ProjectPriority>, List<StudentChoice>>(studentChoiceVM.ProjectPriorities);

                foreach (StudentChoice sc in databaseInput)
                {
                    sc.StudentPCN = studentChoiceVM.StudentPCN;
                }

                try
                {
                    studentChoiceService.AddRange(databaseInput);
                    return Ok();
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
                if (!studentChoiceService.DeleteStudentChoice(id))
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
