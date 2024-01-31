using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class MusicService
    {
        List<Music> OurMusic = new List<Music>
        {
            new Music
            {
                Id = 1,
                Title = "Shape of You",
                Artist = "Ed Sheeran",
                Genre = "Pop",
                ReleaseDate = new DateOnly(2017, 1, 6),
                CurrentRanking = 1
            },
            new Music
            {
                Id = 2,
                Title = "Bohemian Rhapsody",
                Artist = "Queen",
                Genre = "Rock",
                ReleaseDate = new DateOnly(1975, 10, 31),
                CurrentRanking = 2
            },
            new Music
            {
                Id = 3,
                Title = "Billie Jean",
                Artist = "Michael Jackson",
                Genre = "Pop",
                ReleaseDate = new DateOnly(1983, 1, 2),
                CurrentRanking = 3
            },
            new Music
            {
                Id = 4,
                Title = "Hotel California",
                Artist = "Eagles",
                Genre = "Rock",
                ReleaseDate = new DateOnly(1977, 12, 8),
                CurrentRanking = 4
            },
            new Music
            {
                Id = 5,
                Title = "Smells Like Teen Spirit",
                Artist = "Nirvana",
                Genre = "Grunge",
                ReleaseDate = new DateOnly(1991, 9, 10),
                CurrentRanking = 5
            },
            new Music
            {
                Id = 6,
                Title = "Hello",
                Artist = "Adele",
                Genre = "Pop",
                ReleaseDate = new DateOnly(2015, 10, 23),
                CurrentRanking = 6
            },
            new Music
            {
                Id = 7,
                Title = "Stairway to Heaven",
                Artist = "Led Zeppelin",
                Genre = "Rock",
                ReleaseDate = new DateOnly(1971, 11, 8),
                CurrentRanking = 7
            },
            new Music
            {
                Id = 8,
                Title = "Uptown Funk",
                Artist = "Mark Ronson ft. Bruno Mars",
                Genre = "Funk",
                ReleaseDate = new DateOnly(2014, 11, 10),
                CurrentRanking = 8
            },
            new Music
            {
                Id = 9,
                Title = "Sweet Child o' Mine",
                Artist = "Guns N' Roses",
                Genre = "Rock",
                ReleaseDate = new DateOnly(1988, 8, 17),
                CurrentRanking = 9
            },
            new Music
            {
                Id = 10,
                Title = "Wonderwall",
                Artist = "Oasis",
                Genre = "Rock",
                ReleaseDate = new DateOnly(1995, 10, 30),
                CurrentRanking = 10
            }
        };

        public List<Music> getAllMusic()
        {
            return OurMusic;
        }

        public Music getOneMusic()
        {
            return OurMusic[0];
        }

        public List<Music> getTopThree()
        {
            return OurMusic.FindAll(
                (music) => music.CurrentRanking <= 3
            );
        }

        public List<Music> getByRank(int rank)
        {
            return OurMusic.FindAll(
                (music) => music.CurrentRanking == rank
            );
        }

        public List<Music> getByArtist(string artist)
        {
            return OurMusic.FindAll(
                (music) => music.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase)
            );
        }

        public Music addMusic(Music music)
        {
            OurMusic.Add(music);
            return music;
        }

        public bool deleteMusicById(int Id)
        {
            if (OurMusic.Any((m) => m.Id.Equals(Id)))
            {
                Music? music = OurMusic.FirstOrDefault((m) => m.Id.Equals(Id));
                return OurMusic.Remove(music!);
            }

            return false;
        }


        public Music? getMusicById(int Id)
        {
            Music? music = OurMusic.Find((m) => m.Id == Id);
            return music;
        }
    }
}
