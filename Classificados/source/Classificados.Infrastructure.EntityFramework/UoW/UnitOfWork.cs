using Classificados.Domain.Interfaces;
using Classificados.Infrastructure.EntityFramework.Contexts;

namespace Classificados.Infrastructure.EntityFramework.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClassificadosContext _context;

        public UnitOfWork(ClassificadosContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
