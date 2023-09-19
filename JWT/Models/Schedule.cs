using JWT.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT.Base
{

    public class Schedule : BaseModel
    {
     //  public int Id { get; set; }

        public DateOnly Date { get; set; }
        
        public int? ClassId { get; set; }
        public Models.Class? Class { get; set; }
    }

}


