using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeepScreenOn
{
    public partial class Form1 : Form
    {
        public Timer timer;
        protected bool zig = true;
        internal const int INPUT_MOUSE = 0;
        internal const int MOUSEEVENTF_MOVE = 0x0001;
        public Form1()
        {
            InitializeComponent();
            cmdDisable.Hide();
            cmdEnable.Show();
            
            timer = new Timer();
            timer.Interval = 15000;
            timer.Tick += Timer_Tick;
            timer.Enabled = false;
            
    }
        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y - 1);
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // jiggle
            if (cmdEnableKeys.TabIndex == 3)
                Jiggler.Jiggle(0, 0);
            else
            {
                if (this.zig)
                    Jiggler.Jiggle(4, 4);
                else // zag
                {
                    // I really don't know why this needs to be less to stay in the same
                    // place; if I was likely to use it again, then I'd worry.
                    Jiggler.Jiggle(-4, -4);
                }
            }
            this.zig = !this.zig;

            //IntPtr calculatorHandle = NativeMethods.FindWindow(null, "Calculator");

            //// Verify that Calculator is a running process.
            //if (calculatorHandle == IntPtr.Zero)
            //{
            //    Console.WriteLine("Calculator is not running.");
            //    return;
            //}

            //// Make Calculator the foreground application and send it 
            //// a set of calculations.
            //NativeMethods.SetForegroundWindow(calculatorHandle);
            //SendKeys.SendWait("1");
            //SendKeys.SendWait("+");
            //SendKeys.SendWait("1");
            //SendKeys.SendWait("=");
        }

        private void cmdDisable_Click(object sender, EventArgs e)
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);

            cmdDisable.Hide();
            cmdEnable.Show();
        }

        private void cmdEnable_Click(object sender, EventArgs e)
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
                                                  NativeMethods.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);


            cmdEnable.Hide();
            cmdDisable.Show();
        }

        private void cmdEnableKeys_Click(object sender, EventArgs e)
        {
            //MoveCursor();
            //System.Diagnostics.Process calc = System.Diagnostics.Process.Start("calc");
            if (this.cmdEnableKeys.TabIndex == 3)
                Jiggler.Jiggle(0, 0);
            else
            {
                if (this.zig)
                    Jiggler.Jiggle(4, 4);
                else // zag
                {
                    // I really don't know why this needs to be less to stay in the same
                    // place; if I was likely to use it again, then I'd worry.
                    Jiggler.Jiggle(-4, -4);
                }
            }

            this.zig = !this.zig;

            timer.Enabled = true;

            cmdEnableKeys.Hide();
            cmdDisableKeys.Show();
        }

        private void cmdDisableKeys_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Calculator"))
            {
                p.Kill();
                p.CloseMainWindow();
                p.Close();
            }

            timer.Enabled = false;

            cmdEnableKeys.Show();
            cmdDisableKeys.Hide();
        }
    }

    internal static partial class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001

            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
    }
    public class Win32
    {
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
    }
     public static class Jiggler
    {
        internal const int INPUT_MOUSE = 0;
        internal const int MOUSEEVENTF_MOVE = 0x0001;

        [DllImport ("user32.dll", SetLastError = true)]
        private static extern uint SendInput (uint nInputs, ref INPUT pInputs, int cbSize);

        public static void Jiggle (int dx, int dy)
        {
            var inp = new INPUT ();
            inp.TYPE = Jiggler.INPUT_MOUSE;
            inp.dx = dx;
            inp.dy = dy;
            inp.mouseData = 0;
            inp.dwFlags = Jiggler.MOUSEEVENTF_MOVE;
            inp.time = 0;
            inp.dwExtraInfo = (IntPtr) 0;

            if (SendInput (1, ref inp, 28) != 1)
                throw new Win32Exception ();
        }
    }

    /* This is a kludge, presetting all this, but WTF. It works.
     * And for a program this trivial, who's bothered? */

    internal struct INPUT
    {
        public int TYPE;
        public IntPtr dwExtraInfo;
        public int dwFlags;
        public int dx;
        public int dy;
        public int mouseData;
        public int time;
    }
    
}
