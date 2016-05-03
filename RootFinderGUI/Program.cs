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
            Function inst1 = new Function("x");
            Function inst2 = new Function("x+2");



            return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            return;

            // TODO Get expression from user
            string expression = @"x^2-3";
            int compileResult = RootFinderLibrary.CompileExpression(expression);

            if (0 == compileResult) {
                //Console.WriteLine(RootFinderLibrary.F(4));

                // TODO Get these values from user
                double startValue = 1f,
                    endValue = 6.4f,
                    step = 0.5f;

                int pointsCount = RootFinderLibrary.CalculatePointsCount(startValue, endValue, step);
                double[] points = new double[pointsCount];
                IntPtr pointsPtr = RootFinderLibrary.GetFunctionPoints(startValue, endValue, step);
                Marshal.Copy(pointsPtr, points, 0, pointsCount);

                foreach (double point in points) {
                    Console.WriteLine(point);
                }

                RootFinderLibrary.FreeCompiledExpression();
            } else {
                Console.WriteLine(@"Error occured on col {0} while compiling expression.", compileResult);
            }
        }
    }
}
