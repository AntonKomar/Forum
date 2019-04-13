using Forum.Domain.Core.Entities;
using Forum.Domain.Interfaces;
using Forum.Infrastructure.Data.Context;
using Forum.Infrastructure.Data.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ForumContext _context;

        private IGenericRepository<Message> _messageRepository;
        private IGenericRepository<ClientProfile> _clientProfileRepository;
        private IGenericRepository<Subject> _subjectRepository;
        private IGenericRepository<Category> _categoryRepository;
        private IAppIdentity _userManager;
        private IAppIdentity _roleManager;

        #region Public properties

        public UnitOfWork()
        {
            _context = new ForumContext();
        }

        public IGenericRepository<Message> MessageRepository
        {
            get { return _messageRepository ?? (_messageRepository = new GenericRepository<Message>(_context)); }
        }

        public IGenericRepository<ClientProfile> ClientProfileRepository
        {
            get { return _clientProfileRepository ?? (_clientProfileRepository = new GenericRepository<ClientProfile>(_context)); }
        }

        public IGenericRepository<Subject> SubjectRepository
        {
            get { return _subjectRepository ?? (_subjectRepository = new GenericRepository<Subject>(_context)); }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new GenericRepository<Category>(_context)); }
        }

        public IAppIdentity UserManager
        {
            get { return _userManager ?? (_userManager = new AppUserManager(new UserStore<ApplicationUser>())); }
        }

        public IAppIdentity RoleManager
        {
            get { return _roleManager ?? (_roleManager = new AppRoleManager(new RoleStore<ApplicationRole>())); }
        }

        #endregion

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region IDisposable implementation

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
