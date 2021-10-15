using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace SpectreTree
{
    public class Options
    {
        [Value(0, Default = ".")]
        public string Path { get; set; }
    }
}
