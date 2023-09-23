using Microsoft.EntityFrameworkCore.Storage;

namespace Data_Access_Layer.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        int Save();
        void Rollback();
        IDbContextTransaction BeginTransaction();
        Task<int> SaveAsyc();
    }
}
