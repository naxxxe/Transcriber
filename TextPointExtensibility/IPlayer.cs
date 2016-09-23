using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    public interface IPlayer
    {
        void PlayPause();
        void Stop();
        void Load(string path);
        void Repeat(int sec);
        string Timestamp();
        string Filename();
        void Speed(double speed);
        double GetLength();


    }
}
