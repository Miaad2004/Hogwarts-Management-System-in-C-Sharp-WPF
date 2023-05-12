using System.ComponentModel.DataAnnotations;

namespace Hogwarts.Core.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; protected set; }
        public int SequentialIndex { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
