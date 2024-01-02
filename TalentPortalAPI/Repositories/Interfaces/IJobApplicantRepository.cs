using Microsoft.AspNetCore.Mvc;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface IJobApplicantRepository
    {
        Task<IEnumerable<JobApplicant>> ListAllJobApplicants(); // works as intended
        Task<JobApplicant> PostJobApplication(JobApplicant jobapplicant);
        Task<JobApplicant> UpdateJobApplicationStatus(int UserId, int JobId, string newApplicationStatus);
        Task<JobApplicant> FindApplicationStatus(int UserId, int JobId); // works as intended
        Task<IEnumerable<Job>> ListApplicantJobs(int UserId); // works as intended

        // Task<JobApplicant> UpdateJobApplication(int UserId, int JobId, Byte[] UserResume);

        Task<JobApplicant> DeleteJobApplicant(int UserId, int JobId);
    }


}
