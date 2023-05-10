using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
