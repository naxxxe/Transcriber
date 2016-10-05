using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    /// <summary>
    /// Interface class for the AudioPlayer class, These are the methods the AudioPlayer needs to implement
    /// </summary>
    public interface IPlayer
    {
        bool PlayPause();
        void Stop();
        void Load(string path);
        bool Repeat(int sec);
        string Timestamp();
        string Filename();
        void Speed(double speed);
        int GetLength();
        void PlayFrom(int sec);
        int CurrentPosition();


    }
}
