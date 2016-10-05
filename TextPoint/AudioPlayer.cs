using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WMPLib;

namespace TextPoint
{
    class AudioPlayer : IPlayer
    {
        static Timer timer = new Timer();
        bool fileloaded, playing, repeat;
        WindowsMediaPlayer player;
        string filename;
        double current;
        /// <summary>
        /// Initializes a Audioplayer
        /// </summary>
        public AudioPlayer()
        {
            playing = false;
            fileloaded = false;
            repeat = false;
            player = new WindowsMediaPlayer();
        }
        /// <summary>
        /// Gets the Filename from the file that's opened in the media player
        /// </summary>
        /// <returns>The filename of the opened file</returns>
        public string Filename()
        {
            return Path.GetFullPath(filename);
        }
        /// <summary>
        /// Loads the file from the path
        /// </summary>
        /// <param name="path">The path of the file that will be loaded</param>
        public void Load(string path)
        {
            filename = path;
            player.URL = path;
            fileloaded = true;
            Stop();
            playing = false;
            repeat = false;
            timer.Enabled = false;
        }
        /// <summary>
        /// Plays or Pauses the mediafile if a file is loaded
        /// </summary>
        /// <returns>returns true if playing, false if not playing</returns>
        public bool PlayPause()
        {
            if (!fileloaded) { return false; }
            
            else if (playing)
            {
                player.controls.pause();
                playing = false;
                return false;
            }
            else
            {
                player.controls.play();
                playing = true;
                return true;
            }
        }
        /// <summary>
        /// Rewinds the player sec seconds
        /// </summary>
        /// <param name="sec">the number of seconds to rewind</param>
        public void Rewind(int sec)
        {
            if (player.controls.currentPosition < sec)//if less than 5 
            {
                player.controls.currentPosition = 0;//Jumps to start (0)
            }
            else { player.controls.currentPosition = player.controls.currentPosition - sec; }//Jumps to "current position - 5"
        }
        /// <summary>
        /// Repeats the number of seconds that is sent into the method
        /// </summary>
        /// <param name="sec">number of seconds to be repeated</param>
        /// <returns>true if repeating, false if not</returns>
        public bool Repeat(int sec)
        {
            if (fileloaded)
            {
                timer.Interval = sec * 1000;//Makes the input "sec" represent secouds instead of milliseconds

                if (repeat)//repeat fuction is already on action
                {
                    repeat = false;//repeat set to false
                    timer.Enabled = false;
                    return repeat;
                }
                else
                {
                    repeat = true;
                    current = player.controls.currentPosition;//Saves the current time when the repeat is initated
                    player.controls.currentPosition = current - (timer.Interval / 1000);//Sets the repeat length
                    if (!playing) { player.controls.play(); }
                    
                    timer.Elapsed += Timer_Elapsed;//subscribe to the Timer_elapsed event
                    timer.Enabled = true;
                    return repeat;
                }
            }
            else { return false; }//no file is loaded, nothing happens
        }
        /// <summary>
        /// A timer that "rewinds" the position of the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            player.controls.currentPosition = current - (timer.Interval/1000);
        }
        /// <summary>
        /// Stops the playing media file and resets the variables in the class if a file is loaded.
        /// </summary>
        public void Stop()
        {
            if (fileloaded)
            {
                player.controls.stop();
                playing = false;
                repeat = false;
                timer.Enabled = false;
            }
        }
        /// <summary>
        /// Returns a string of the current position of the playing media file
        /// </summary>
        /// <returns> a string in the format hh:mm:ss with a new line </returns>
        public string Timestamp()
        {
            if (fileloaded)
            {
                TimeSpan timestamp = TimeSpan.FromSeconds(player.controls.currentPosition);
                return "(" + timestamp.ToString(@"hh\:mm\:ss") +")";
            }
            else { return ""; }
        }
        /// <summary>
        /// Changes the playback speed
        /// </summary>
        /// <param name="speed">the new playback speed</param>
        public void Speed(double speed)
        {
            player.settings.rate = speed;
        }
        /// <summary>
        /// Get the duration of the media file
        /// </summary>
        /// <returns>An int with the length of the loaded media file in seconds</returns>
        public int GetLength()
        {
            return (int)player.currentMedia.duration;
        }
        /// <summary>
        /// Changes the current position of the playing media file
        /// </summary>
        /// <param name="sec">The place from which the file should be played</param>
        public void PlayFrom(int sec)
        {
            player.controls.currentPosition = sec;
        }
        /// <summary>
        /// Returns the current position of the playing media file
        /// </summary>
        /// <returns>An int which represents the current position of the loaded media file in seconds</returns>
        public int CurrentPosition()
        {
            return (int)player.controls.currentPosition;
        }
    }
}
