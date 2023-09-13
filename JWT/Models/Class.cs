using JWT.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    public class Class : BaseModel
    {
        
    //  public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Школьники
        /// </summary>
        public List<AppUser>? Student { get; set; }

        /// <summary>
        /// Классный руководитель
        /// </summary>
        public AppUser? ClassTeacher { get; set; }

        public string? ClassTeacherId { get; set; }
    }
}
