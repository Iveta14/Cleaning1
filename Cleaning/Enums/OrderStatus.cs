using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cleaning.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Направена")]
        New = 1,
        [Display(Name = "Изпълнена")]
        Completed = 2,
        [Display(Name = "Отменена")]
        Cancelled = 3
    }
}
