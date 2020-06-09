﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.VmModel.Identity
{
    public class EditPasswordViewModel
    {
        [Display(Name = "Eski Şifre")]
        public string OldPassword { get; set; }
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }
    }
}
