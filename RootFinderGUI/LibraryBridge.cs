using System;
using System.Runtime.InteropServices;

namespace RootFinderGUI {
    internal static class LibraryBridge {
        private const string DllPath = @"RootFinderLibrary.dll";

        /*[DllImport(DllPath, EntryPoint = "SomeFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SomeFunction(string sometext);

        [DllImport(DllPath, EntryPoint = "get_array_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetArraySize();

        [DllImport(DllPath, EntryPoint = "get_array", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetArray([In, Out] double[] darr);

        [DllImport(DllPath, EntryPoint = "get_step_outputs", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetStepOutputs([In, Out] StepOutput[] arr);*/

        [DllImport(DllPath, EntryPoint = "compile_expression", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CompileExpression([MarshalAs(UnmanagedType.LPStr)] string expression);

        [DllImport(DllPath, EntryPoint = "f", CallingConvention = CallingConvention.Cdecl)]
        public static extern double F(double x);

        [DllImport(DllPath, EntryPoint = "get_function_points", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFunctionPoints(double startValue, double endValue, double step);

        [DllImport(DllPath, EntryPoint = "free_compiled_expression", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeCompiledExpression();

        public static int CalculatePointsCount(double startValue, double endValue, double step) {
            return (int) (Math.Ceiling((endValue - startValue) / step) + 1);
        }
    }
}
