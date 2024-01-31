using Microsoft.AspNetCore.Mvc;

using WebApiTest.EntityModels;
using WebApiTest.Models.DTO;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        private ProjectService projectService;

        public ProjectController(ProjectService _projectService)
        {
            projectService = _projectService;
        }

        [HttpGet()]
        public ActionResult<List<Project>> List(
            string orderBy = "id",
            int page = 1,
            int pageCount = 20,
            bool ascending = true
        )
        {
            return Ok(projectService.getAllProjects(page, pageCount, orderBy, ascending));
        }

        [HttpGet("{Id}")]
        public ActionResult<Project> ById(int Id)
        {
            return Ok(projectService.getProjectById(Id));
        }

        [HttpGet("Name")]
        public ActionResult<Project> ByName(string Name)
        {
            return Ok(projectService.getProjectByName(Name));
        }

        [HttpPost()]
        public ActionResult<User> AddProject(ProjectDto projectToAdd)
        {
            return Ok(projectService.addProject(projectToAdd));
        }

        [HttpDelete()]
        public ActionResult<bool> Delete(DeleteProjectRequestDto projectToDelete)
        {
            return Ok(projectService.deleteProject(projectToDelete));
        }

        [HttpPut()]
        public ActionResult<User> Update(ProjectDto projectToUpdate)
        {
            return Ok(projectService.updateProject(projectToUpdate));
        }


    }
}