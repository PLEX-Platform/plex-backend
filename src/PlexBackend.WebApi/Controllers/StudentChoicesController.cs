using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure;
using PlexBackend.Infrastructure.ContextModels;
using PlexBackend.WebApi.Converter;
using PlexBackend.WebApi.ViewModels;

namespace PlexBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentChoicesController : ControllerBase
    {
        private readonly IStudentChoiceRepository _studentChoiceRepository;
        private readonly IMapper mapper;

        public StudentChoicesController(IStudentChoiceRepository studentChoiceRepository, IMapper mapper)
        {
            _studentChoiceRepository = studentChoiceRepository;
            this.mapper = mapper;
        }

        // GET: api/StudentChoices
        [HttpGet]
        public ActionResult<IEnumerable<StudentChoiceViewModel>> GetStudentChoices()
        {
            List<StudentChoice> studentChoices = _studentChoiceRepository.FindAll().ToList();

            return Ok(mapper.Map<List<StudentChoice>, List<StudentChoiceViewModel>>(studentChoices));
        }

        // GET: api/StudentChoices/5
        [HttpGet("{id}")]
        public ActionResult<StudentChoiceViewModel> GetStudentChoice(int id)
        {
            StudentChoice studentChoice = _studentChoiceRepository.GetById(id);

            if (studentChoice == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentChoice, StudentChoiceViewModel>(studentChoice));
        }

        // GET: api/StudentChoices/5
        [HttpGet("/GetChoicesByPCN/{PCN}")]
        public ActionResult<StudentChoiceByPCNViewModel> GetChoicesByPCN(int PCN)
        {
            List<StudentChoice> studentChoices = _studentChoiceRepository.FindByCondition(e => e.StudentPCN == PCN).ToList();

            if (studentChoices.Count == 0)
            {
                return NotFound();
            }

            StudentChoiceByPCNViewModel vm =  ModelConverter.ContextModelsToStudentChoiceByPCN(PCN, studentChoices);

            return Ok(vm);
        }

        // PUT: api/StudentChoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutStudentChoice(int id, StudentChoiceViewModel studentChoiceVM)
        {
            if (id != studentChoiceVM.Id)
            {
                return BadRequest();
            }

            StudentChoice studentChoiceDataModel = mapper.Map<StudentChoiceViewModel, StudentChoice>(studentChoiceVM);
            _studentChoiceRepository.Update(studentChoiceDataModel);

            try
            {
                _studentChoiceRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentChoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public ActionResult<StudentSubmitChoiceViewModel> Post([FromBody]StudentSubmitChoiceViewModel studentChoiceVM)
        {
            if (ModelState.IsValid)
            {
                List<StudentChoice> databaseInput = new List<StudentChoice>();

                foreach (ProjectPriority kvp in studentChoiceVM.ProjectPriorities)
                {
                    StudentChoice studentChoiceDataModel = new()
                    {
                        StudentPCN = studentChoiceVM.StudentPCN,
                        ProjectId = kvp.ProjectId,
                        PriorityRank = kvp.PriorityRank
                    };

                    databaseInput.Add(studentChoiceDataModel);
                }

                try
                {
                    _studentChoiceRepository.AddRange(databaseInput);
                    _studentChoiceRepository.Save();
                    //return CreatedAtAction("GetChoicesByPCN", new { PCN = studentChoiceVM.StudentPCN }, new StudentChoiceViewModel());
                    return Ok();

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return BadRequest("The input is not valid");
        }

        // DELETE: api/StudentChoices/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentChoice(int id)
        {
            StudentChoice studentChoice = _studentChoiceRepository.GetById(id);

            if (studentChoice == null)
            {
                return NotFound();
            }

            _studentChoiceRepository.Delete(studentChoice);
            _studentChoiceRepository.Save();

            return Ok();
        }

        private bool StudentChoiceExists(int id)
        {
            if (_studentChoiceRepository.GetById(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
