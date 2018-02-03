namespace XComm.Enums
{
    public enum DllState : uint
    {
        Idle = 0,
        Login = 1,
        Logout = 2,
        Identity = 3,
        Download = 4,
        Start = 5,
        Stop = 6,
        ResetWarm = 7,
        ResetCold = 8,
        ResetOrigin = 9,
        Read = 10,
        Write = 11,
        ReadStatus = 16,
        ReadSymbols = 20,
        ReadVarDirect = 46,
        WriteVarDirect = 60,
        FileWriteStart = 47,
        FileWriteCont = 48,
        FileReadStart = 49,
        FileReadCont = 50
    }
}