﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class GeneralSetting
    {
        [Key]
        public int Id { get; set; }
        public string SingUpMessage { get; set; }
    }
}