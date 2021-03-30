// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using FestivalManager;
    using FestivalManager.Entities;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        Stage stage = new Stage();
       
        [Test]
        public void Test_If_PerformerAge_IsLessThen_18YearsOld()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("pesho", "gosho", 14)));

        }

        [Test]
        public void Can_Not_Be_Null_Message_ThrowException()
        {

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void Add_Performer()
        {
            Performer performer = new Performer("pesho", "gosho", 55);

            stage.AddPerformer(performer);
            int expectedResult = stage.Performers.Count;

            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void Add_Song_ThrowException_If_SongLenght_Is_LessThen_1minute()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("shushu", new TimeSpan(0, 0, 59))));
        }

        [Test]
        public void Add_Song_CanNotBeNullMessage_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

        [Test]
        public void Add_Song()
        {
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));
            List<Song> songs = new List<Song>();
            songs.Add(song);
            stage.AddSong(song);

            Assert.That(songs.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Song_ToPerformer_ThrowException_ThrowExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, null));
        }

        [Test]
        public void Add_Song_ToPerformer()
        {
            Performer performer = new Performer("pesho", "gosho", 55);
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(performer.SongList.Count, Is.EqualTo(1));

            stage.AddSongToPerformer(song.Name, performer.FullName);

        }

        [Test]
        public void ThrowException_IfThereIsNoPerformer_WithThisName()
        {
            Performer performer = new Performer("pesho", "gosho", 55);
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "aaaa"));
        }

        [Test]
        public void ThrowException_IfThereIsNoSong_WithThisName()
        {
            Performer performer = new Performer("pesho", "gosho", 55);
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("bbbb", performer.FullName));
        }

        [Test]
        public void TestPlaySong()
        {
            Performer performer = new Performer("pesho", "gosho", 55);
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer.FullName);

            string result = stage.Play();

            var songsCount = stage.Performers.Sum(p => p.SongList.Count());

            Assert.AreEqual(result, $"{stage.Performers.Count} performers played {songsCount} songs");
        }

        [Test]
        public void TestAddSongToPerformer_ReturnString()
        {
            Performer performer = new Performer("pesho", "gosho", 55);
            Song song = new Song("aaaa", new TimeSpan(0, 4, 04));

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            
            string result = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual(result, $"{song} will be performed by {performer.FullName}");
        }

    }
}