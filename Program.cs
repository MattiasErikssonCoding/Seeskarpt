using System;

namespace XNATable
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 puppyOnTheRun = new Game1())
            {
                puppyOnTheRun.Run();
            }
        }
    }
#endif
}

