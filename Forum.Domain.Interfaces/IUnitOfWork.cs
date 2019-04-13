using Forum.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAppIdentity UserManager { get; }
        IAppIdentity RoleManager { get; }
        IGenericRepository<Message> MessageRepository { get; }
        IGenericRepository<ClientProfile> ClientProfileRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        Task SaveAsync();
    }
}
