using System;

namespace RootFinderGUI {
    public class Function {
        private IntPtr _handle = IntPtr.Zero;

        public Function(string expression) {
            // TODO Get handle from the library and save for future use
            // TODO Compile expression
        }

        ~Function() {
Console.WriteLine(@"Destructing via handle {0}.", _handle);

            RootFinderLibrary.FreeCompiledExpression(_handle);
            // TODO Add other freeing function calls here
        }
    }
}
