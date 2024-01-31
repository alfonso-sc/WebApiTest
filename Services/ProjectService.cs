using Microsoft.EntityFrameworkCore;

using WebApiTest.EntityModels;
using WebApiTest.Models.DTO;

namespace WebApiTest.Services
{

    public class ProjectService
    {
        private BillingTimeContext billingTimeContext;

        public ProjectService(BillingTimeContext _billingTimeContext)
        {
            billingTimeContext = _billingTimeContext;
        }

        public List<Project> getAllProjects(int page, int pageCount, string orderBy, bool ascending)
        {
            // TODO: figure out what to include
            var query = billingTimeContext
                .Projects
                .Include((p) => p.Subprojects)
                // .Include(p => p.Company)
                // .Include(p => p.Entries)
                .AsQueryable();

            // TODO: figure out more sensible order bys
            switch (orderBy)
            {
                case "name":
                    query =
                        ascending ?
                            query.OrderBy((p) => p.Name) :
                            query.OrderByDescending((p) => p.Name);
                    break;
                case "id":
                default:
                    query =
                        ascending ?
                        query.OrderBy((p) => p.Id) :
                        query.OrderByDescending((p) => p.Id);
                    break;

            }
            int skip = (page - 1) * pageCount;
            return query
                .Skip(skip)
                .Take(pageCount)
                .ToList();
        }

        public Project? getProjectById(int Id)
        {
            // TODO: figure out what to include
            return billingTimeContext
                .Projects
                .Where((p) => p.Id == Id)
                .Include((p) => p.Subprojects)
                // .Include(p => p.Company)
                // .Include(p => p.Entries)
                .FirstOrDefault();
        }


        public Project? getProjectByName(string Name)
        {
            // TODO: figure out what to include
            // TODO: figure out how to search by substring ignore case
            return billingTimeContext
                .Projects
                .Where((p) => p.Name == Name)
                // .Include(p => p.Company)
                // .Include(p => p.Entries)
                .FirstOrDefault();
        }

        public Project? addProject(ProjectDto projectToAdd)
        {
            var newDbProject = new Project()
            {
                Name = projectToAdd.Name,
                ChargingRate = projectToAdd.ChargingRate,
                Active = projectToAdd.Active,
                CompanyId = projectToAdd.CompanyId,
                ManagerId = projectToAdd.ManagerId,
                FixedBid = projectToAdd.FixedBid,
                Subprojects = billingTimeContext.Subprojects.Where((sp) => projectToAdd.SubprojectIds.Contains(sp.Id)).ToList()
            };
            billingTimeContext.Add(newDbProject);
            billingTimeContext.SaveChanges();
            return newDbProject;


        }
        public bool deleteProject(DeleteProjectRequestDto projectToDelete)
        {
            var existingProject =
                billingTimeContext
                .Projects
                .Include((p) => p.Subprojects)
                .Include((p) => p.Entries)
                .FirstOrDefault((p) => p.Id == projectToDelete.Id);
            if (existingProject != null)
            {
                existingProject!.Manager = null;
                // existingProject!.Subprojects.Clear();
                // // billingTimeContext.FavoritesXrefs.RemoveRange(existingUser.FavoritesXrefs);

                billingTimeContext.Entries.RemoveRange(existingProject.Entries);
                billingTimeContext.Subprojects.RemoveRange(existingProject.Subprojects);
                // billingTimeContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Project updateProject(ProjectDto projectToUpdate)
        {
            var updatedDbProject = new Project()
            {
                Id = projectToUpdate.Id,
                Name = projectToUpdate.Name,
                ChargingRate = projectToUpdate.ChargingRate,
                Active = projectToUpdate.Active,
                CompanyId = projectToUpdate.CompanyId,
                ManagerId = projectToUpdate.ManagerId,
                FixedBid = projectToUpdate.FixedBid,
                Subprojects = billingTimeContext.Subprojects.Where((sp) => projectToUpdate.SubprojectIds.Contains(sp.Id)).ToList()
            };
            billingTimeContext.Update(updatedDbProject);
            billingTimeContext.SaveChanges();
            return updatedDbProject;

        }

    }


}
