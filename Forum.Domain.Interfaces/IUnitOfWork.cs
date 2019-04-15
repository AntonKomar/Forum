using Forum.Domain.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Forum.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        object UserManager { get; }
        object RoleManager { get; }

        IGenericRepository<Message> MessageRepository { get; }
        IGenericRepository<ClientProfile> ClientProfileRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }

        Task SaveAsync();
        void Dispose();
    }
}
