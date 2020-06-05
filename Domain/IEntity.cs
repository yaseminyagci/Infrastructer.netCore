using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public interface IEntity : IDomain
    {
        [Key]
        int Id { get; set; }

        DateTime CreateDate { get; set; }
    }
}