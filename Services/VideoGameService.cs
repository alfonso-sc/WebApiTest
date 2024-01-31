using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class VideoGameService
    {

        List<VideoGame> OurVideoGames = new List<VideoGame>
        {
        new VideoGame
        {
            Id = 1,
            Title = "The Witcher 3: Wild Hunt",
            Studio = "CD Projekt Red",
            Genre = "Action RPG",
            Rating = "Mature",
            Price = 39.99m,
            ReleaseDate = new DateOnly(2015, 5, 19),
            CurrentRanking = 1
        },
        new VideoGame
        {
            Id = 2,
            Title = "The Legend of Zelda: Breath of the Wild",
            Studio = "Nintendo",
            Genre = "Action-Adventure",
            Rating = "Everyone 10+",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2017, 3, 3),
            CurrentRanking = 2
        },
        new VideoGame
        {
            Id = 3,
            Title = "Red Dead Redemption 2",
            Studio = "Rockstar Games",
            Genre = "Action-Adventure",
            Rating = "Mature",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2018, 10, 26),
            CurrentRanking = 3
        },
        new VideoGame
        {
            Id = 4,
            Title = "Super Mario Odyssey",
            Studio = "Nintendo",
            Genre = "Platformer",
            Rating = "Everyone 10+",
            Price = 49.99m,
            ReleaseDate = new DateOnly(2017, 10, 27),
            CurrentRanking = 4
        },
        new VideoGame
        {
            Id = 5,
            Title = "Grand Theft Auto V",
            Studio = "Rockstar Games",
            Genre = "Action-Adventure",
            Rating = "Mature",
            Price = 29.99m,
            ReleaseDate = new DateOnly(2013, 9, 17),
            CurrentRanking = 5
        },
        new VideoGame
        {
            Id = 6,
            Title = "Minecraft",
            Studio = "Mojang Studios",
            Genre = "Sandbox",
            Rating = "Everyone",
            Price = 19.99m,
            ReleaseDate = new DateOnly(2011, 11, 18),
            CurrentRanking = 6
        },
        new VideoGame
        {
            Id = 7,
            Title = "Overwatch",
            Studio = "Blizzard Entertainment",
            Genre = "First-Person Shooter",
            Rating = "Teen",
            Price = 39.99m,
            ReleaseDate = new DateOnly(2016, 5, 24),
            CurrentRanking = 7
        },
        new VideoGame
        {
            Id = 8,
            Title = "Fortnite",
            Studio = "Epic Games",
            Genre = "Battle Royale",
            Rating = "Teen",
            Price = 0.00m, // Free-to-play
            ReleaseDate = new DateOnly(2017, 7, 25),
            CurrentRanking = 8
        },
        new VideoGame
        {
            Id = 9,
            Title = "Call of Duty: Warzone",
            Studio = "Infinity Ward",
            Genre = "Battle Royale",
            Rating = "Mature",
            Price = 0.00m, // Free-to-play
            ReleaseDate = new DateOnly(2020, 3, 10),
            CurrentRanking = 9
        },
        new VideoGame
        {
            Id = 10,
            Title = "Among Us",
            Studio = "InnerSloth",
            Genre = "Social Deduction",
            Rating = "Everyone 10+",
            Price = 4.99m,
            ReleaseDate = new DateOnly(2018, 6, 15),
            CurrentRanking = 10
        }
    };

        public List<VideoGame> getAllVideoGames()
        {
            return OurVideoGames;
        }

        public VideoGame getOneVideoGame()
        {
            return OurVideoGames[0];
        }

        public VideoGame addVideoGame(VideoGame videoGame)
        {
            OurVideoGames.Add(videoGame);
            return videoGame;
        }

        public bool deleteVideoGameById(int Id)
        {

            if (OurVideoGames.Any((v) => v.Id.Equals(Id)))
            {
                VideoGame? videoGame = OurVideoGames.FirstOrDefault((v) => v.Id.Equals(Id));
                return OurVideoGames.Remove(videoGame!);
            }

            return false;
        }

        public VideoGame? getVideoGameById(int Id)
        {
            VideoGame? videoGame = OurVideoGames.Find((v) => v.Id == Id);
            return videoGame;
        }
    }
}