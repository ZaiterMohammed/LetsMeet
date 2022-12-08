namespace LetsMeet.Abstractions.Models
{
    using System;

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

        public int IsVerified
        {
            get;
            set;
        }
    }
}
