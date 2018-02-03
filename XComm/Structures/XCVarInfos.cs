using System;
using System.Runtime.InteropServices;
using XComm.Enums;

namespace XComm.Structures
{
    /// <summary>
    /// XCSymbolDesc is the basic structure that contains the data from the XC_Comm.dll. This structure needs the channelnumber to load symbols from the gateway.
    /// <example>
    /// var channelNumber = 1; // Comes from the login
    /// var info = new XCVarInfos{ulChannel = channelNumber};
    /// var symbolCount = XC_CommLoadSymbols(info);
    /// </example>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class XCVarInfos
    {
        public IntPtr hVarList;
        public IntPtr ppValues;
        public IntPtr ppSymbolList;
        public TypeClass pTypeClass;
        public uint ulNumberOfSymbols;
        public uint ulChannel;
    }
}