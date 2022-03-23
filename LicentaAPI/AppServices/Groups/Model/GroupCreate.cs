using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Groups.Model
{
    /// <summary>
    /// Class containing information needed to create a <see cref="Group"/>.
    /// </summary>
    public class GroupCreate
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}