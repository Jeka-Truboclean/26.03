namespace _26._03
{
    public interface ICloneable
    {
        object Clone();
    }
    public class Game
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Game(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public object Clone()
        {
            return new Game(Name, Price);
        }
    }
    public class GameStop
    {
        public string Name { get; set; }
        public int GamesCount { get; set; }
        public Game Game { get; set; }
        public GameStop(string name, int gamesCount, Game game)
        {
            Name = name;
            GamesCount = gamesCount;
            Game = game;
        }
        public object Clone()
        {
            return new GameStop(Name, GamesCount, (Game)Game.Clone());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Game("The Witcher 3", 29.99m);
            GameStop gameStop1 = new GameStop("GameStop A", 100, game1);
            Game game2 = (Game)game1.Clone();
            GameStop gameStop2 = (GameStop)gameStop1.Clone();
            game2.Name = "Cyberpunk 2077";
            game2.Price = 49.99m;
            gameStop2.Name = "GameStop B";
            gameStop2.GamesCount = 200;
            gameStop2.Game.Name = "Red Dead Redemption 2";
            gameStop2.Game.Price = 39.99m;
            Console.WriteLine("Original Game:");
            Console.WriteLine($"Name: {game1.Name}, Price: {game1.Price}");

            Console.WriteLine("\nCloned Game:");
            Console.WriteLine($"Name: {game2.Name}, Price: {game2.Price}");

            Console.WriteLine("\nOriginal GameStop:");
            Console.WriteLine($"Name: {gameStop1.Name}, Games Count: {gameStop1.GamesCount}, Game Name: {gameStop1.Game.Name}, Game Price: {gameStop1.Game.Price}");

            Console.WriteLine("\nCloned GameStop:");
            Console.WriteLine($"Name: {gameStop2.Name}, Games Count: {gameStop2.GamesCount}, Game Name: {gameStop2.Game.Name}, Game Price: {gameStop2.Game.Price}");
        }
    }
}
