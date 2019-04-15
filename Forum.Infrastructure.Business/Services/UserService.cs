using Forum.Domain.Core.Entities;
using Forum.Domain.Interfaces;
using Forum.Infrastructure.Business.DTO;
using Forum.Infrastructure.Business.Interfaces;
using Forum.Infrastructure.Data.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Business.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var appUserManager = (AppUserManager)Database.UserManager;

            var user = await appUserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await appUserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // add Role
                await appUserManager.AddToRoleAsync(user.Id, userDto.Role);
                // Create Client profile
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name, Date = userDto.CreationDate };
                Database.ClientProfileRepository.Insert(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            AppUserManager appUserManager = (AppUserManager)Database.UserManager;

            ClaimsIdentity claim = null;
            // find user
            ApplicationUser user = await appUserManager.FindAsync(userDto.Email, userDto.Password);
            // authorize user и return object ClaimsIdentity
            if (user != null)
                claim = await appUserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // start inialization of db
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            var appRoleManager = (AppRoleManager)Database.UserManager;

            foreach (string roleName in roles)
            {
                var role = await appRoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await appRoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
