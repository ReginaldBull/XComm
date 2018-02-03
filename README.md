# XComm

C# wrapper for the XC Series of PLC's from the company Moeller.

### What is this repository for? ###

This repository contains a wrapper, that encapsulates the XC_Comm.dll, from the company Moeller for C#.

### Requirements ###

* SetupGatewayV2.3.9.36 - Not included in this repository (needed to get additional libraries for the communication)

* XC_Comm.dll - Not included in this repository

### Contents ###

Data structures that mimic the api structure.
Interop function calls for the api.

### Covered Functions ###

Note: The wrapper does not cover all the functions of the api but can be added easily.
The communication between the wrapper and the XC_Comm.dll is implemented over a callback. Communicating to the PLC is a asynchronous process where the single operation takes some time. 

The definition of the callback:

* delegate void GatewayCallback(uint arg0, uint arg1, uint arg2, IntPtr arg3)

Implemented function calls:

* bool XC_CommStop(uint ulChannel): Stops the target system (PLC).
* bool XC_CommStart(uint ulChannel): Start of the target system.
* void XC_CommSetCallback(GatewayCallback fCall): Providing the callback to get data back from the PLC.
* int XC_CommLogin(): Opens the XC_Comm.dll dialog to select the target PLC.
* uint XC_CommLoginTcpIp([MarshalAs(UnmanagedType.LPStr)] string ip): Opens a communication channel to the PLC over TCP connection.
* bool XC_CommReadPlcStatus(uint ulChannel): Reading out the state of the system.
* bool XC_CommGetDllState(): Returns the state of the internal state machine of the XC_Comm.dll.
* bool XC_CommClose(uint ulChannel): To perform a close of the communication channel .
* bool XC_CommGetVersion(uint ulChannel): Reads out the version of the PLC's OS.
* bool XC_CommReadUserFileFromPLCByPath(uint ulChannel, [MarshalAs(UnmanagedType.LPStr)] string pBuffer): Reading data from the PLC
* bool XC_CommReadUserFileFromPLC(uint ulChannel): Reading data from the PLC
* bool XC_CommUpdateValues(XCVarInfos pInfos): Refreshing the values of the variable list of the target system.
* uint XC_CommLoadSymbols(XCVarInfos pInfos): Loads the symbol file and generates the internal variable list. Following calls to this function deletes the previous variables list.
* bool XC_CommGetSymbol(XCVarInfos pInfos, uint ulNumber, StringBuilder pName, StringBuilder pWert, StringBuilder pOffset): Returns the value, name, datatype and offset of one variable.
* bool XC_WriteSymbolByName(XCVarInfos pInfos, [MarshalAs(UnmanagedType.LPStr)] string pSymbolName, byte[] pValue): Writes a value to a symbol (also overwrites a variable, that is marked as readonly).
