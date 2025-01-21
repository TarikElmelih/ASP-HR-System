using HR.Data;
using HR_Models.Models;
using HR_Models.Models.VM;

namespace HR.Repositry
{
    public class RepoCity : RepositryAllModels<City,CitySummary>
    {
        public RepoCity(HR_Context context) : base(context)
        {
        }
    }
}
