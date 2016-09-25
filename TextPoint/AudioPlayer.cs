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
        
        public AudioPlayer()
        {
            playing = false;
            fileloaded = false;
            repeat = false;
            player = new WindowsMediaPlayer();
        }
        
        public string Filename()
        {
            return Path.GetFileName(filename);
        }

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
                player.controls.currentPosition = player.controls.currentPosition - 5;
                player.controls.play();
                playing = true;
                return true;
            }
        }

        public void Repeat(int sec)
        {
            timer.Interval = sec * 1000;
            
            if (repeat)
            {
                repeat = false;
                timer.Enabled = false;
            }
            else {
                repeat = true;
                current = player.controls.currentPosition;
                player.controls.currentPosition = current - (timer.Interval / 1000);
                timer.Elapsed += Timer_Elapsed;
                timer.Enabled = true;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            player.controls.currentPosition = current - (timer.Interval/1000);
        }

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

        public string Timestamp()
        {
            if (fileloaded)
            {
                TimeSpan timestamp = TimeSpan.FromSeconds(player.controls.currentPosition);
                return "(" + timestamp.ToString(@"hh\:mm\:ss\:fff") +")" + "\n";
            }
            else { return ""; }
        }

        public void Speed(double speed)
        {
            player.settings.rate = speed;
        }
        public double GetLength()
        {
            return player.currentMedia.duration;
        }
        public void PlayFrom(int sec)
        {
            player.controls.currentPosition = sec;
        }
        public int CurrentPosition()
        {
            return (int)player.controls.currentPosition;
        }
    }
}
