using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using XComm.Enums;
using XComm.Structures;

namespace XComm
{
    /*
     * Setup:
     * For this wrapper the XC_Comm.dll is needed. This dll can be placed anywhere. You can dynamically load it with the NativeMethods class.
     * To start communicating with the Device, there are some more dll's needed to copied into the system32 or the SysWow64 directory.
     * Also needed is the Gateway.exe and the GatewayDDE.exe located in the directories mentioned above.
     */

    /// <summary>
    /// Wrapper for XC_Comm.dll. This interops the native functions to provide a API. It requires the
    /// XC_Comm.dll and CodeSys on the targeted pc.
    /// </summary>
    public static class Wrapper
    {
        public static DllState MappingNumberToState(uint value)
        {
            var type = typeof(DllState);

            return type.GetEnumValues().Cast<DllState>().FirstOrDefault(i => (int)i == value);
        }

        private const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;

        public const int MaxPath = 260;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GatewayCallback(uint arg0, uint arg1, uint arg2, IntPtr arg3);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommStop",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommStop(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommStart",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommStart(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommSetCallback",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern void XC_CommSetCallback(GatewayCallback fCall);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommLogin",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern int XC_CommLogin();

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommLoginTcpIp",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern uint XC_CommLoginTcpIp([MarshalAs(UnmanagedType.LPStr)] string ip);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommReadPlcStatus",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommReadPlcStatus(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommGetDllState",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern int XC_CommGetDllState();

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommClose",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommClose(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommGetVersion",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommGetVersion(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommReadUserFileFromPLCByPath",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommReadUserFileFromPLCByPath(uint ulChannel, [MarshalAs(UnmanagedType.LPStr)] string pBuffer);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommReadUserFileFromPLC",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommReadUserFileFromPLC(uint ulChannel);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommUpdateValues",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommUpdateValues(XCVarInfos pInfos);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommLoadSymbols",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern uint XC_CommLoadSymbols(XCVarInfos pInfos);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_CommGetSymbol",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_CommGetSymbol(XCVarInfos pInfos, uint ulNumber, StringBuilder pName, StringBuilder pWert, StringBuilder pOffset);

        [DllImport(@"XC_Comm.dll",
            CharSet = CharSet.Ansi,
            EntryPoint = "XC_WriteSymbolByName",
            SetLastError = true,
            CallingConvention = CallingConvention)]
        public static extern bool XC_WriteSymbolByName(XCVarInfos pInfos, [MarshalAs(UnmanagedType.LPStr)] string pSymbolName, byte[] pValue);
    }
}