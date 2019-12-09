using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Core.Enum
{
    public enum Gender
    {
        [DescriptionAttribute("Female")]
        Female = 1,
        [DescriptionAttribute("Male")]
        Male = 2,
        [DescriptionAttribute("Neutral")]
        Neutral = 3
    }
}
