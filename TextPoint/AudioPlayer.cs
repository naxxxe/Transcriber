using System;
using System.IO;
using System.Timers;
using WMPLib;

namespace TextPoint
{
    public class AudioPlayer : IPlayer
    {
        private readonly Timer _timer = new Timer();
        private bool _fileloaded;
        private bool _playing;
        private bool _repeat;
        private readonly WindowsMediaPlayer _player;
        private string _filename;
        private double _current;
        /// <summary>
        /// Initializes a Audioplayer
        /// </summary>
        public AudioPlayer()
        {
            _playing = false;
            _fileloaded = false;
            _repeat = false;
            _player = new WindowsMediaPlayer();
        }
        /// <summary>
        /// Gets the Filename from the file that's opened in the media player
        /// </summary>
        /// <returns>The filename of the opened file</returns>
        public string Filename()
        {
            return "[" + Path.GetFullPath(_filename) + "]";
        }
        /// <summary>
        /// Loads the file from the path
        /// </summary>
        /// <param name="path">The path of the file that will be loaded</param>
        public void Load(string path)
        {
            _filename = path;
            if (!File.Exists(path)) { throw new FileNotFoundException("File not found"); }
            if (File.Exists(path) && (path.EndsWith(".mp3") || path.EndsWith(".wav")))
            {
                _player.URL = path;
                _fileloaded = true;
                Stop();
                _playing = false;
                _repeat = false;
                _timer.Enabled = false;
            }
            else throw new FileLoadException("File not supported");
        }
        /// <summary>
        /// Plays or Pauses the mediafile if a file is loaded
        /// </summary>
        /// <returns>returns true if playing, false if not playing</returns>
        public bool PlayPause()
        {
            if (!_fileloaded) { return false; }
            
            else if (_playing)
            {
                _player.controls.pause();
                _playing = false;
                return false;
            }
            else
            {
                _player.controls.play();
                _playing = true;
                return true;
            }
        }
        /// <summary>
        /// Rewinds the player sec seconds
        /// </summary>
        /// <param name="sec">the number of seconds to rewind</param>
        public void SkipBack(int sec)
        {
            if (_player.controls.currentPosition < sec)//if less than sec 
            {
                _player.controls.currentPosition = 0;//Jumps to start (0)
            }
            else { _player.controls.currentPosition = _player.controls.currentPosition - sec; }//Jumps to "current position - sec"
        }
        public void SkipForward(int sec)
        {
            if (GetLength() < _player.controls.currentPosition + sec)//if currentpos  sec is more than the length of the file
            {
                _player.controls.currentPosition = GetLength();//Jumps to end
            }
            else { _player.controls.currentPosition = _player.controls.currentPosition + sec; }//Jumps to "current position + sec"
        }
        /// <summary>
        /// Repeats the number of seconds that is sent into the method
        /// </summary>
        /// <param name="sec">number of seconds to be repeated</param>
        /// <returns>true if repeating, false if not</returns>
        public bool Repeat(int sec)
        {
            if (_fileloaded)
            {
                _timer.Interval = sec * 1000;//Makes the input "sec" represent secouds instead of milliseconds

                if (_repeat)//repeat fuction is already on action
                {
                    _repeat = false;//repeat set to false
                    _timer.Enabled = false;
                    return _repeat;
                }
                else
                {
                    _repeat = true;
                    _current = _player.controls.currentPosition;//Saves the current time when the repeat is initated
                    _player.controls.currentPosition = _current - (_timer.Interval / 1000);//Sets the repeat length
                    if (!_playing) { _player.controls.play(); }
                    
                    _timer.Elapsed += Timer_Elapsed;//subscribe to the Timer_elapsed event
                    _timer.Enabled = true;
                    return _repeat;
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
            _player.controls.currentPosition = _current - (_timer.Interval/1000);
        }
        /// <summary>
        /// Stops the playing media file and resets the variables in the class if a file is loaded.
        /// </summary>
        public void Stop()
        {
            if (_fileloaded)
            {
                _player.controls.stop();
                _player.controls.currentPosition = 0;
                _playing = false;
                _repeat = false;
                _timer.Enabled = false;
            }
        }
        /// <summary>
        /// Returns a string of the current position of the playing media file
        /// </summary>
        /// <returns> a string in the format hh:mm:ss with a new line </returns>
        public string Timestamp()
        {
            if (_fileloaded)
            {
                TimeSpan timestamp = TimeSpan.FromSeconds(_player.controls.currentPosition);
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
            _player.settings.rate = speed;
        }
        public double GetSpeed()
        {
            return _player.settings.rate;
        }
        /// <summary>
        /// Get the duration of the media file
        /// </summary>
        /// <returns>An int with the length of the loaded media file in seconds</returns>
        public int GetLength()
        {
            return (int)_player.currentMedia.duration;
        }
        /// <summary>
        /// Changes the current position of the playing media file
        /// </summary>
        /// <param name="sec">The place from which the file should be played</param>
        public void PlayFrom(int sec)
        {
            _player.controls.currentPosition = sec;
        }
        /// <summary>
        /// Returns the current position of the playing media file
        /// </summary>
        /// <returns>An int which represents the current position of the loaded media file in seconds</returns>
        public int CurrentPosition()
        {
            return (int)_player.controls.currentPosition;
        }
    }
}
