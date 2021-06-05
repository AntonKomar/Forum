using Forum.Domain.Core.Entities;
using Forum.Domain.Interfaces;
using Forum.Infrastructure.Data.Context;
using Forum.Infrastructure.Data.Identity;
using Forum.Infrastructure.Data.Repositories;
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
        private object _userManager;
        private object _roleManager;

        #region Public properties

        public UnitOfWork()
        {
            _context = new ForumContext();
        }

        public IGenericRepository<Message> MessageRepository
        {
            get { return _messageRepository ?? (_messageRepository = new MessageRepository(_context)); }
        }

        public IGenericRepository<ClientProfile> ClientProfileRepository
        {
            get { return _clientProfileRepository ?? (_clientProfileRepository = new ClientProfileRepository(_context)); }
        }

        public IGenericRepository<Subject> SubjectRepository
        {
            get { return _subjectRepository ?? (_subjectRepository = new SubjectRepository(_context)); }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }

        public object UserManager
        {
            get { return _userManager ?? (_userManager = new AppUserManager(new UserStore<ApplicationUser>(_context))); }
        }

        public object RoleManager
        {
            get { return _roleManager ?? (_roleManager = new AppRoleManager(new RoleStore<ApplicationRole>(_context))); }
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
