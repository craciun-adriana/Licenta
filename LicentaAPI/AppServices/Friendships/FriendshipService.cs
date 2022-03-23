using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

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

        ///<inheritdoc/>
        public Friendship CreateFriendship(FriendshipCreate friendshipCreate)
        {
            var friendship = _mapper.Map<FriendshipCreate, Friendship>(friendshipCreate);
            friendship.Status = FriendshipStatus.Pending;
            friendship.LastUpdate = DateTime.UtcNow;
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
    }
}