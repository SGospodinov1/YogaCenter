

namespace YogaCenter.Core.Models.Admin
{
    /// <summary>
    /// UserViewModel is model connected to entity AppUser
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Give Id of the AppUser
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Give FirstName of the AppUser
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Give LastName of the AppUser
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Give Email of the AppUser
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Give information if this AppUser is Administrator or not
        /// </summary>
        public bool IsAdministrator { get; set; } = false;

    }
}
