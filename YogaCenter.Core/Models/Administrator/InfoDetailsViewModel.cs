using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{
    /// <summary>
    /// InfoDetailsViewModel collect information that Teacher fill in the form and gives information when Teacher want to edit the Teacher.
    /// </summary>
    public class InfoDetailsViewModel
    {
        /// <summary>
        /// Give Id of the Teacher
        /// </summary>
        [Required]
        public int Id { get; set; }


        /// <summary>
        /// Give Description for the Teacher
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
