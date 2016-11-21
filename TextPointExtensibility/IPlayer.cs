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
        double GetSpeed();
        int GetLength();
        void PlayFrom(int sec);
        int CurrentPosition();
        void SkipForward(int sec);
        void SkipBack(int sec);


    }
}
