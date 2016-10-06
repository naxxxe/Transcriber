using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextPoint;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace TextPointunitTest
{
    [TestClass]
    public class AudioPlayerUnitTests
    {
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void LoadFileTest()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = "\\TestInterview.mp3";
            string expected = "[" + path + file + "]";
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            string result = player.Filename();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void LoadNotSupported()
        {
            string unsupported = "c:";
            IPlayer player = new AudioPlayer();
            player.Load(unsupported);

        }
        [TestMethod]
        public void PlayFileNotLoaded()
        {
            IPlayer player = new AudioPlayer();
            Assert.IsFalse(player.PlayPause());
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void PlayFileLoadedPlay()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            Assert.IsTrue(player.PlayPause());
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void PlayFileLoadedPause()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            player.PlayPause();
            Assert.IsFalse(player.PlayPause());
        }
        [TestMethod]
        public void RepeatFileNotLoaded()
        {
            IPlayer player = new AudioPlayer();
            Assert.IsFalse(player.Repeat(10));
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void RepeatFileLoaded()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            Assert.IsTrue(player.Repeat(10));
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void StopRepeatFileLoaded()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            player.Repeat(10);
            Assert.IsFalse(player.Repeat(1));
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void StopFileLoaded()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            
            player.PlayPause();
            player.PlayFrom(5);
            string expected = "(00:00:05)";
            string actual = player.Timestamp();
            Assert.AreEqual(expected, actual);
            player.Stop();
            Assert.AreEqual("(00:00:00)", player.Timestamp());
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void TimeStampTest()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            player.PlayPause();
            player.PlayFrom(5);
            Assert.AreEqual("(00:00:05)", player.Timestamp());
            player.PlayFrom(65);
            Assert.AreEqual("(00:01:05)", player.Timestamp());
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void CurrentPositionTest()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            player.PlayPause();
            player.PlayFrom(5);
            Assert.AreEqual(5, player.CurrentPosition());
            player.PlayFrom(65);
            Assert.AreEqual(65, player.CurrentPosition());
        }
        [TestMethod]
        [DeploymentItem(@"TestInterview.mp3")]
        public void SpeedTest()
        {
            IPlayer player = new AudioPlayer();
            player.Load("TestInterview.mp3");
            double actual = player.GetSpeed();
            Assert.AreEqual(1, actual);
            player.Speed(1.5);
            actual = player.GetSpeed();
            Assert.AreEqual(1.5, actual);
        }
    }
}
