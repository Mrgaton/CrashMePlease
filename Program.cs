using System;
using System.Runtime.InteropServices;

namespace CrashMePlease
{
    internal static class Program
    {
        private static void Main() => CrashPc();

        [DllImport("ntdll")] private static extern IntPtr RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll")] private static extern IntPtr NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        private static void CrashPc()
        {
            RtlAdjustPrivilege(19, true, false, out bool previousValue);
            NtRaiseHardError(0xC0000420, 0, 0, IntPtr.Zero, 6, out uint response);
        }
    }
}