using System.Runtime.InteropServices;

namespace XComm.Structures
{
    /// <summary>
    ///
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XCSymbolDesc
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszName;

        [MarshalAs(UnmanagedType.LPStr)]
        public string pszType;

        public ushort uRefId;
        public uint ulOffset;
        public uint ulSize;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] szAccess;
    }
}