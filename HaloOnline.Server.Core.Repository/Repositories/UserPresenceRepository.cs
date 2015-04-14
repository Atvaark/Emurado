﻿using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserPresenceRepository : IUserPresenceRepository
    {
        private readonly HaloDbContext _context;

        public UserPresenceRepository()
        {
            _context = new HaloDbContext();
        }

        public Task CreateAsync(UserPresence userPresence)
        {
            var newUserPresence = new Model.UserPresence
            {
                UserId = userPresence.User.Id,
                State = userPresence.Data.State,
                IsInvitable = userPresence.Data.IsInvitable
            };
            _context.UserPresences.Add(newUserPresence);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(UserPresence userPresence)
        {
            var foundUserPresence = _context.UserPresences.Find(userPresence.User.Id);
            if (foundUserPresence != null)
            {
                foundUserPresence.State = userPresence.Data.State;
                foundUserPresence.IsInvitable = userPresence.Data.IsInvitable;
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task DeleteAsync(UserPresence userPresence)
        {
            var foundUserPresence = _context.UserPresences.Find(userPresence.User.Id);
            if (foundUserPresence != null)
            {
                _context.UserPresences.Remove(foundUserPresence);
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task<UserPresence> FindByUserIdAsync(int userId)
        {
            var foundUserPresence = _context.UserPresences.Find(userId);
            if (foundUserPresence != null)
            {
                return Task.FromResult(new UserPresence
                {
                    User = new UserId(foundUserPresence.UserId),
                    Data = new UserPresenceData
                    {
                        State = foundUserPresence.State,
                        IsInvitable = foundUserPresence.IsInvitable
                    }
                });
            }
            return Task.FromResult<UserPresence>(null);
        }
    }
}