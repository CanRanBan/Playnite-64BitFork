using System;
using System.Runtime.InteropServices;

namespace Playnite.Native
{
    public class Shell32
    {
        private const string Shell32Dll = "shell32.dll";

        // Parameters for Known Folder = Saved Games
        private static readonly Guid KnownFolderIDSavedGames = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");
        private const uint KnownFolderRetrievalDefault = 0;
        private static readonly IntPtr s_knownFolderRequestForCurrentUser = IntPtr.Zero;

        [DllImport(Shell32Dll)]
        public static extern int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon,
            uint nIcons);

        /**
            HRESULT SHGetKnownFolderPath(
                [in] REFKNOWNFOLDERID rfid,
                [in] DWORD dwFlags,
                [in, optional] HANDLE hToken,
                [out] PWSTR* ppszPath
            );
        */
        [DllImport(Shell32Dll)]
        private static extern int SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)]
            [In] Guid rfid,
            [In] uint dwFlags,
            [In, Optional] IntPtr hToken,
            [Out] out IntPtr pszPath
        );

        public static string GetKnownFolderPathForSavedGames()
        {
            if (
                SHGetKnownFolderPath(
                    KnownFolderIDSavedGames,
                    KnownFolderRetrievalDefault,
                    s_knownFolderRequestForCurrentUser,
                    out IntPtr pszPath
                ) != 0
               )
            {
                return string.Empty;
            }

            string path = Marshal.PtrToStringUni(pszPath);
            Marshal.FreeCoTaskMem(pszPath);
            return path;
        }
    }
}
