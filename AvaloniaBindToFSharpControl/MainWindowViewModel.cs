using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaBindToFSharpControl
{
    public class MainWindowViewModel
    {
        public string FSharpMessage { get; } = "Hello from F#";
        public string CSharpMessage { get; } = "Hello from C#";
    }
}
