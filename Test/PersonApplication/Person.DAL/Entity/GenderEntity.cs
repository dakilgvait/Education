using System.ComponentModel.DataAnnotations.Schema;

namespace Person.DAL.Entity
{
    public enum GenderType
    {
        MALE,
        FEMALE
    }

    [Table("Genders")]
    public class GenderEntity : Lookup<GenderType> { }
}