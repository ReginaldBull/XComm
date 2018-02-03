using System.Runtime.InteropServices;

namespace XComm.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XCVarValue
    {
        public uint ulTimeStamp;

        public char bQuality;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public char[] byData;
    }
}