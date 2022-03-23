using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.GroupMembers.Model
{
    /// <summary>
    ///Class containing information about a <see cref="GroupMember"/>
    /// </summary>
    public class GroupMemberCreate
    {
        public string IdGroup { get; set; }

        public string IdUser { get; set; }

        public bool IsAdmin { get; set; }
    }
}