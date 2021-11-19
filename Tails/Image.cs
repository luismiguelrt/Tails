/**
 * Image.cs - To hide SDL image handling
 * 
 * Luis Miguel Rubio Toledo, 2015
 * Changes:
 * 0.02, 06-03-2013: Initial version
 */
using System;
using Tao.Sdl;


namespace Tails
{
    class Image
    {
        private IntPtr internalPointer;

        public Image(string fileName)  // Constructor
        {
            Load(fileName);
        }

        public void Load(string fileName)
        {
            internalPointer = SdlImage.IMG_Load(fileName);
            if (internalPointer == IntPtr.Zero)
                Hardware.FatalError("Image not found: " + fileName);
        }


        public IntPtr GetPointer()
        {
            return internalPointer;
        }
    }
}
