using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReplacementGroup
    {
        public string text { get; set; }
        public string replacement { get; set; }

        public ReplacementGroup() { }

        public ReplacementGroup(string text, string replacement)
        {
            this.text = text;
            this.replacement = replacement;
        }
    }
}
