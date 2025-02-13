﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cleaning.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Полето \"Потребителско име\" е задължително!")]
        [DisplayName("Потребителско име")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Полето \"Име\" е задължително!")]
        [DisplayName("Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето \"Фамилия\" е задължително!")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето \"Имейл\" е задължително!")]
        [DisplayName("Имейл")]
        public string Email { get; set; }

        [DisplayName("Парола")]
        public string Password { get; set; }

        [DisplayName("Повтори паролата")]
        public string ConfirmPassword { get; set; }

        public void PopulateEmployee(Entities.ApplicationUser employee) //за създаването на служител
        {
            employee.UserName = UserName;
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.Email = Email;
            employee.PasswordHash = Password;
        }

        public void PopulateFromEmployeeEntity(Entities.ApplicationUser? employee) //за редактирането на служител
        {
            if (employee == null)
                return;

            Id = employee.Id;
            UserName = employee.UserName;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Email = employee.Email;
            Password = employee.PasswordHash;
        }
    }
}
