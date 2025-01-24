using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cleaning.Areas.Admin.ViewModels
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Полето \"Наименование\" е задължително!")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето \"Описание\" е задължително!")]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето \"Цена на квадратен метър\" е задължително!")]
        [DisplayName("Цена на квадратен метър")]
        public decimal Price { get; set; }

        [DisplayName("Снимкa преди услугата")]
        [ValidateNever]
        public string PhotoBeforePath { get; set; }

        [DisplayName("Снимкa след услугата")]
        [ValidateNever]
        public string PhotoAfterPath { get; set; }

        [DisplayName("Снимкa на услугата")]
        [ValidateNever]
        public string ThumbnailImagePath { get; set; }

        public void PopulateServiceEntity(Entities.Service service) //за създаването на услуга
        {
            service.Name = Name;
            service.Description = Description;
            service.Price = Price;
            service.PhotoBeforePath = PhotoBeforePath;
            service.PhotoAfterPath = PhotoAfterPath;
            service.ThumbnailImagePath = ThumbnailImagePath;
        }
    }
}
