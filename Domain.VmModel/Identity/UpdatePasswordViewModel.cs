﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.VmModel.Identity
{
    public class UpdatePasswordViewModel
    {
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
