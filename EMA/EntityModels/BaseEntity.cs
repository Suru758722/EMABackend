using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.EntityModels
{
        public interface IBaseEntity
        {
            int Id { get; set; }

            DateTime CreatedDateUtc { get; set; }
            string CreatedBy { get; set; }
        }
        public class BaseEntity: IBaseEntity
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }

    }
}
