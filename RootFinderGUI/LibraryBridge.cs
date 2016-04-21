using System.Runtime.InteropServices;

namespace RootFinderGUI {
    static class LibraryBridge {
        private const string DllPath = @"D:\Dropbox\University\MATH 232\RootFinderLibrary\bin\Debug\RootFinderLibrary.dll";

        [DllImport(DllPath, EntryPoint = "SomeFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SomeFunction(string sometext);

        [DllImport(DllPath, EntryPoint = "get_array_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetArraySize();

        [DllImport(DllPath, EntryPoint = "get_array", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetArray([In, Out] double[] darr);

        [DllImport(DllPath, EntryPoint = "get_step_outputs", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetStepOutputs([In, Out] StepOutput[] arr);
    }
}
