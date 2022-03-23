using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.GroupMembers
{
    public interface IGroupMemberService
    {
        public GroupMember CreateGroupMember(GroupMemberCreate groupMemberCreate);
    }
}