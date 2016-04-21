using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RootFinderGUI {
    [StructLayout(LayoutKind.Sequential)]
    struct StepOutput {
        public double a;
        public double b;
        public double root;

        public StepOutput(double a, double b, double root) {
            this.a = a;
            this.b = b;
            this.root = root;
        }
    }

    internal static class Program {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //LibraryBridge.SomeFunction(@"Hello World!");


            /*int arraySize = LibraryBridge.GetArraySize();
            double[] theArray = new double[arraySize];

            LibraryBridge.GetArray(theArray);

            Console.WriteLine(@"Array Size: {0}", arraySize);

            for (int i = 0; i < arraySize; i++) {
                Console.WriteLine(@"#{0} {1}", i, theArray[i]);
            }
            */
            
            /*int arraySize = LibraryBridge.GetArraySize();
            StepOutput[] theArray = new StepOutput[arraySize];

            LibraryBridge.GetStepOutputs(theArray);

            Console.WriteLine(@"Array Size: {0}", arraySize);

            for (int i = 0; i < arraySize; i++) {
                Console.WriteLine(
                    @"#{0}{1}{2}{1}{3}{1}{4}{1}",
                    i,
                    Environment.NewLine,
                    theArray[i].a,
                    theArray[i].b,
                    theArray[i].root
                    );
            }
            */
        }
    }
}
