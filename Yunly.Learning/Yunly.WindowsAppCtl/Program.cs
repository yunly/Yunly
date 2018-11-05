using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Yunly.WindowsAppCtl
{
    class Program
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        const int WM_SETTEXT = 0x000c;

        static void Main(string[] args)
        {
            var notepadProcess = getNotepadProcessID();
            if (notepadProcess != 0)
            {
                Trace.WriteLine(string.Format("Notepad is running, with process ID : {0} and Process name : {1}", notepadProcess, getProcessName(notepadProcess)));
                var hWndToEdit = FindEditInNotepad();
                if (hWndToEdit != IntPtr.Zero)
                {
                    var SendMsgResult = SendContentToNotepad(hWndToEdit, "Content That We want to send to Notepad");
                    Trace.WriteLine("Result : " + SendMsgResult);
                }
            }
        }

        public static int SendContentToNotepad(IntPtr hWndToEdit, string txtToSend)
        {
            var result = SendMessage(hWndToEdit, WM_SETTEXT, 0, txtToSend);
            return result;
        }

        public static int getNotepadProcessID()
        {
            int notepadID = 0;
            Process[] pname = Process.GetProcessesByName("notepad");
            if (pname.Length != 0)
                notepadID = pname[0].Id;
            return notepadID;
        }

        public static string getProcessName(int processID)
        {
            var process = Process.GetProcessById(processID);
            return process.ProcessName;
        }

        public static IntPtr FindEditInNotepad()
        {
            IntPtr hWndToEdit = IntPtr.Zero;
            string NotepadParentClass = "Notepad";
            string NotepadParentWindowCaption = "Untitled - Notepad";
            string NotepadEditClass = "Edit";

            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr hWnd = new IntPtr(0);
            ParenthWnd = FindWindow(NotepadParentClass, NotepadParentWindowCaption);
            if (ParenthWnd.Equals(IntPtr.Zero))
                Trace.WriteLine("Notepad Not Running");
            else
            {
                hWnd = FindWindowEx(ParenthWnd, hWnd, NotepadEditClass, "");
                if (hWnd.Equals(IntPtr.Zero))
                    Trace.WriteLine("Can't find Edit component in Notepad");
                else
                {
                    Trace.WriteLine(String.Format("Notepad Window: {0} in Hex: {1}", ParenthWnd.ToString(), ParenthWnd.ToString("X")));
                    Trace.WriteLine(String.Format("Edit Control: {0} in Hex: {1}", hWnd.ToString(), hWnd.ToString("X")));
                    hWndToEdit = hWnd;
                }
            }
            return hWndToEdit;
        }

    }
}
