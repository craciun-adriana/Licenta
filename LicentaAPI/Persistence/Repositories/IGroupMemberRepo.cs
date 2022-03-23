using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    public interface IGroupMemberRepo : IGenericRepo<GroupMember>
    {
        public IEnumerable<GroupMember> FindGroupMembersByIdGroup(string idGroup);
    }
}