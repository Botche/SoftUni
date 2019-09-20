namespace SimpleSnake.Utilities
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;

    public static class ConsoleWindow
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.WindowHeight = 22;
            Console.WindowWidth = 60;

            Console.BufferHeight = 22;
            Console.BufferWidth = 60;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}
