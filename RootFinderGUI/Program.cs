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

            return;

            // TODO Get expression from user
            string expression = @"x^2-3";
            int compileResult = LibraryBridge.CompileExpression(expression);

            if (0 == compileResult) {
                //Console.WriteLine(LibraryBridge.F(4));

                // TODO Get these values from user
                double startValue = 1f,
                    endValue = 6.4f,
                    step = 0.5f;

                int pointsCount = LibraryBridge.CalculatePointsCount(startValue, endValue, step);
                double[] points = new double[pointsCount];
                IntPtr pointsPtr = LibraryBridge.GetFunctionPoints(startValue, endValue, step);
                Marshal.Copy(pointsPtr, points, 0, pointsCount);

                foreach (double point in points) {
                    Console.WriteLine(point);
                }

                LibraryBridge.FreeCompiledExpression();
            } else {
                Console.WriteLine(@"Error occured on col {0} while compiling expression.", compileResult);
            }

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
