using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Repositories.Interfaces
{
    public interface IRecruiterRepository
    {
        Task<IEnumerable<Recruiter>> GetAllRecruiters();
        Task<Recruiter> AddRecruiter(int UserId, int Jobid);
        Task<Recruiter> DeleteRecruiter(int UserId, int JobId);

    }
}
