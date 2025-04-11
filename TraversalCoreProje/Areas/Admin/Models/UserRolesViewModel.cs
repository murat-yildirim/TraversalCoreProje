using System.Collections.Generic;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
       
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
