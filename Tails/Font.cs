/**
 * Font.cs - To hide SDL TTF font handling
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.01, 06-03-2013: Initial version, based on SdlMuncher 0.14
 */

using System;
using Tao.Sdl;

namespace Tails
{
    class Font
    {
        private IntPtr internalPointer;

        public Font(string fileName, short sizePoints)
        {
            Load(fileName, sizePoints);
        }

        public void Load(string fileName, short sizePoints)
        {
            internalPointer = SdlTtf.TTF_OpenFont(fileName, sizePoints);
            if (internalPointer == IntPtr.Zero)
                Hardware.FatalError("Font not found: " + fileName);
        }

        public IntPtr GetPointer()
        {
            return internalPointer;
        }
    }
}