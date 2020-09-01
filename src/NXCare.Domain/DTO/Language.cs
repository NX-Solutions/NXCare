using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXCare.Domain.DTO
{
    public class Language
    {
        public string Name { get; set; }
        public string TwoDigit { get; set; }
        public string ThreeDigitNative { get; set; }
        public string ThreeDigitEnglish { get; set; }
    }
}
