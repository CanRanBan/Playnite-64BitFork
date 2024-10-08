﻿using System;
using System.Runtime.InteropServices;

namespace Playnite.Native
{
    public class Wintrust
    {
        internal sealed class UnmanagedPointer : IDisposable
        {
            private IntPtr m_ptr;
            private WINTRUST_DATA.AllocMethod m_meth;

            internal UnmanagedPointer(IntPtr ptr, WINTRUST_DATA.AllocMethod method)
            {
                m_meth = method;
                m_ptr = ptr;
            }

            ~UnmanagedPointer()
            {
                Dispose(false);
            }

            private void Dispose(bool disposing)
            {
                if (m_ptr != IntPtr.Zero)
                {
                    if (m_meth == WINTRUST_DATA.AllocMethod.HGlobal)
                    {
                        Marshal.FreeHGlobal(m_ptr);
                    }
                    else if (m_meth == WINTRUST_DATA.AllocMethod.CoTaskMem)
                    {
                        Marshal.FreeCoTaskMem(m_ptr);
                    }

                    m_ptr = IntPtr.Zero;
                }

                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }

            public void Dispose()
            {
                Dispose(true);
            }

            public static implicit operator IntPtr(UnmanagedPointer ptr)
            {
                return ptr.m_ptr;
            }
        }
    }

    internal struct WINTRUST_FILE_INFO : IDisposable
    {
        public uint cbStruct;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pcwszFilePath;
        public IntPtr hFile;
        public IntPtr pgKnownSubject;

        public WINTRUST_FILE_INFO(string fileName, Guid subject)
        {
            cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_FILE_INFO));
            pcwszFilePath = fileName;
            if (subject != Guid.Empty)
            {
                pgKnownSubject = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid)));
                Marshal.StructureToPtr(subject, pgKnownSubject, true);
            }
            else
            {
                pgKnownSubject = IntPtr.Zero;
            }

            hFile = IntPtr.Zero;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (pgKnownSubject != IntPtr.Zero)
            {
                Marshal.DestroyStructure(pgKnownSubject, typeof(Guid));
                Marshal.FreeHGlobal(pgKnownSubject);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WINTRUST_DATA : IDisposable
    {
        public enum AllocMethod
        {
            HGlobal,
            CoTaskMem
        };

        public enum UnionChoice
        {
            File = 1,
            Catalog,
            Blob,
            Signer,
            Cert
        };

        public enum UiChoice
        {
            All = 1,
            NoUI,
            NoBad,
            NoGood
        };

        public enum RevocationCheckFlags
        {
            None = 0,
            WholeChain
        };

        public enum StateAction
        {
            Ignore = 0,
            Verify,
            Close,
            AutoCache,
            AutoCacheFlush
        };

        public enum TrustProviderFlags
        {
            UseIE4Trust = 1,
            NoIE4Chain = 2,
            NoPolicyUsage = 4,
            RevocationCheckNone = 16,
            RevocationCheckEndCert = 32,
            RevocationCheckChain = 64,
            RecovationCheckChainExcludeRoot = 128,
            Safer = 256,
            HashOnly = 512,
            UseDefaultOSVerCheck = 1024,
            LifetimeSigning = 2048
        };

        public enum UIContext
        {
            Execute = 0,
            Install
        };

        public WINTRUST_DATA(WINTRUST_FILE_INFO fileInfo)
        {
            cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_DATA));
            pInfoStruct = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINTRUST_FILE_INFO)));
            Marshal.StructureToPtr(fileInfo, pInfoStruct, false);
            dwUnionChoice = UnionChoice.File;
            pPolicyCallbackData = IntPtr.Zero;
            pSIPCallbackData = IntPtr.Zero;
            dwUIChoice = UiChoice.NoUI;
            fdwRevocationChecks = RevocationCheckFlags.None;
            dwStateAction = StateAction.Ignore;
            hWVTStateData = IntPtr.Zero;
            pwszURLReference = IntPtr.Zero;
            dwProvFlags = TrustProviderFlags.Safer;
            dwUIContext = UIContext.Execute;
        }

        public uint cbStruct;
        public IntPtr pPolicyCallbackData;
        public IntPtr pSIPCallbackData;
        public UiChoice dwUIChoice;
        public RevocationCheckFlags fdwRevocationChecks;
        public UnionChoice dwUnionChoice;
        public IntPtr pInfoStruct;
        public StateAction dwStateAction;
        public IntPtr hWVTStateData;
        private IntPtr pwszURLReference;
        public TrustProviderFlags dwProvFlags;
        public UIContext dwUIContext;

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (dwUnionChoice == UnionChoice.File)
            {
                WINTRUST_FILE_INFO info = new WINTRUST_FILE_INFO();
                Marshal.PtrToStructure(pInfoStruct, info);
                info.Dispose();
                Marshal.DestroyStructure(pInfoStruct, typeof(WINTRUST_FILE_INFO));
            }

            Marshal.FreeHGlobal(pInfoStruct);
        }
    }
}
