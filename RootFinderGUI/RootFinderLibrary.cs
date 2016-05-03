#if DEBUG
using System.Runtime.InteropServices;
#endif

namespace RootFinderGUI {
    public enum VerbosityLevels {
        None = 0,
        Fatal,
        Error,
        Warn,
        Info,
        Debug
    }

    internal static class RootFinderLibrary {
#if DEBUG
        private const string DllPath = @"D:\Dropbox\University\MATH 232\RootFinderLibrary\bin\Release\RootFinderLibrary.dll";
#else
        private const string DllPath = @"RootFinderLibrary.dll";
#endif

        /*
        [DllImport(DllPath, EntryPoint = "compile_expression", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CompileExpression([MarshalAs(UnmanagedType.LPStr)] string expression);

        [DllImport(DllPath, EntryPoint = "f", CallingConvention = CallingConvention.Cdecl)]
        public static extern double F(double x);

        [DllImport(DllPath, EntryPoint = "get_function_points", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFunctionPoints(double startValue, double endValue, double step);

        [DllImport(DllPath, EntryPoint = "free_compiled_expression", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeCompiledExpression();

        public static int CalculatePointsCount(double startValue, double endValue, double step)
        {
            return (int) (Math.Ceiling((endValue - startValue) / step) + 1);
        }
        */

#if DEBUG
        [DllImport(DllPath, EntryPoint = "set_verbosity_level", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVerbosityLevel(VerbosityLevels newVerbosityLevel);

        [DllImport(DllPath, EntryPoint = "get_verbosity_level", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVerbosityLevel();
#else
        public static void SetVerbosityLevel(VerbosityLevels newVerbosityLevel) { }

        public static int GetVerbosityLevel() {
            return 0;
        }
#endif


    }
}
