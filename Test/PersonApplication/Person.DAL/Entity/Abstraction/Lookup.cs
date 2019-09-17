using System.ComponentModel.DataAnnotations;

namespace Person.DAL.Entity
{
    public abstract class Lookup<T> : Entity
    {
        [Required]
        public T Code { get; set; }

        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}