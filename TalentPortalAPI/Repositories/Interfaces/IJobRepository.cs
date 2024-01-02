using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> PostJob(Job job); // Works as intended
        Task<IEnumerable<Job>> ListAllJobs(); // Works as intended
        Task<Job> UpdateJob(int JobId, Job job); // Works as intended
        Task<IEnumerable<Job>> ListOfJobsPostedByUser(int UserId); // Works as intended
        // Task<Job> DeleteJob(int UserId, int JobId);
        Task<Job> DeleteJob(int JobId); // Works as intended
        Task<IEnumerable<Job>> GetJobsBySearchAsync(string searchText);
    }
}
