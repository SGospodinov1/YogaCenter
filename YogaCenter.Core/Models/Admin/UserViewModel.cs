﻿

namespace YogaCenter.Core.Models.Admin
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool IsAdministrator { get; set; } = false;

    }
}