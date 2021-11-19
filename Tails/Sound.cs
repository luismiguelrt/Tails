/**
 * Sound.cs 
 * 
 * Luis Miguel Rubio Toledo, 2015
 * 
 * Changes:
 * 0.05  28-05-2015: create class Sound (noly To Do)
 * 0.27  06-06-2015: implement methods
 */

using System;
using Tao.Sdl;

namespace Tails
{
    class Sound
    {
        IntPtr songPointer;

        /// <summary>
        /// constructor
        /// </summary>
        public Sound()
        {

        }

        /// <summary>
        /// constructor with param
        /// </summary>
        /// <param name="fileName"> name file</param>
        public Sound(string fileName)
        {
            songPointer = SdlMixer.Mix_LoadMUS(fileName);
        }

        /// <summary>
        /// use for play once
        /// </summary>
        public void PlayOnce()
        {
            SdlMixer.Mix_PlayMusic(songPointer, 1);
        }

        /// <summary>
        /// use for play Intro
        /// </summary>
        public void PlayIntro()
        {
            SdlMixer.Mix_PlayMusic(songPointer, -1);
        }

        public bool EnableMusic(ref bool onMusic)
        {
            if (onMusic == true)
            {
                onMusic = false;
            }
            else
            {
                onMusic = true;
            }
            return onMusic;
        }
    }
}
