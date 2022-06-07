﻿using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Friendships
{
    /// <summary>
    /// Concrete implementation of <see cref="IFriendshipService"/>.
    /// </summary>
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepo _friendshipRepo;
        private readonly IMappingCoordinator _mapper;

        public FriendshipService(IFriendshipRepo friendshipRepo, IMappingCoordinator mapper)
        {
            _friendshipRepo = friendshipRepo;
            _mapper = mapper;
        }

        public Error AcceptFriendship(string idFriendship, string idReceiver)
        {
            var friendship = _friendshipRepo.GetById(idFriendship);
            if (friendship == null)
            {
                return new Error("Friendship was not found.", ErrorCode.NotFound);
            }
            if (friendship.IdReceiver != idReceiver)
            {
                return new Error("User is not authorize to accept friendship.", ErrorCode.NotAuthorized);
            }
            if (friendship.Status != FriendshipStatus.Pending)
            {
                return new Error("Friendship is not pending.", ErrorCode.BadRequest);
            }
            friendship.Status = FriendshipStatus.Accepted;
            friendship.LastUpdate = DateTime.UtcNow;
            _friendshipRepo.Update(friendship);
            return new Error("", ErrorCode.Ok);
        }

        public Error BlockFriendship(string idFriendship, string idReceiver)
        {
            var friendship = _friendshipRepo.GetById(idFriendship);
            if (friendship == null)
            {
                return new Error("Friendship was not found.", ErrorCode.NotFound);
            }
            if (friendship.IdReceiver != idReceiver)
            {
                return new Error("User is not authorize to block friendship.", ErrorCode.NotAuthorized);
            }
            if (friendship.Status != FriendshipStatus.Pending)
            {
                return new Error("Friendship is not pending.", ErrorCode.BadRequest);
            }
            friendship.Status = FriendshipStatus.Blocked;
            friendship.LastUpdate = DateTime.UtcNow;
            _friendshipRepo.Update(friendship);
            return new Error("", ErrorCode.Ok);
        }

        /// <inheritdoc/>
        public Friendship CreateFriendship(FriendshipCreate friendshipCreate)
        {
            var existingfriendship = _friendshipRepo.GetFriendshipBetweenUsers(friendshipCreate.IdReceiver, friendshipCreate.IdSender);

            if (existingfriendship != null)
            {
                return existingfriendship;
            }

            var friendship = _mapper.Map<FriendshipCreate, Friendship>(friendshipCreate);
            friendship.Status = FriendshipStatus.Pending;
            friendship.LastUpdate = DateTime.UtcNow;
            friendship.ID = Guid.NewGuid().ToString();
            try
            {
                _friendshipRepo.Add(friendship);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            return friendship;
        }

        /// <inheritdoc/>
        public IEnumerable<Friendship> FindFriendshipByIdReceiver(string idReceiver)
        {
            return _friendshipRepo.FindFriendshipByIdReceiver(idReceiver);
        }

        public Friendship GetFriendshipBetweenUsers(string idUser1, string idUser2)
        {
            if (idUser1 != null && idUser2 != null)
            {
                return _friendshipRepo.GetFriendshipBetweenUsers(idUser1, idUser2);
            }
            return null;
        }
    }
}