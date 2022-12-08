using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.Abstractions.Models
{
    public class Role
    {
        public Guid RoleId
        {
            get;
            set;
        }
        public string RoleName
        {
            get;
            set;
        }

        public string IsVerified
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public Guid CompanyId
        {
            get;
            set;
        }

        public Guid OrganisationId
        {
            get;
            set;
        }
    }
}
