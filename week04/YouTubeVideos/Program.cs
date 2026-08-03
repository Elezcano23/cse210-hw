class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            CreateCSharpVideo(),
            CreateCookingVideo(),
            CreateTravelVideo(),
            CreateMusicVideo()
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }

    static Video CreateCSharpVideo()
    {
        Video video = new Video("C# Classes in 10 Minutes", "Code Academy", 612);
        video.AddComment(new Comment("Sofia", "Clear explanation. Thank you!"));
        video.AddComment(new Comment("Mateo", "The examples were very helpful."));
        video.AddComment(new Comment("Lucia", "Please make a video about inheritance next."));
        return video;
    }

    static Video CreateCookingVideo()
    {
        Video video = new Video("Easy Homemade Pasta", "Chef Elena", 485);
        video.AddComment(new Comment("Daniel", "I made this tonight and it was delicious."));
        video.AddComment(new Comment("Valentina", "The sauce looks amazing!"));
        video.AddComment(new Comment("Noah", "Could I use whole-wheat flour?"));
        return video;
    }

    static Video CreateTravelVideo()
    {
        Video video = new Video("A Weekend in Patagonia", "Travel with Ana", 738);
        video.AddComment(new Comment("Camila", "Those landscapes are incredible."));
        video.AddComment(new Comment("Ethan", "Added this to my travel list."));
        video.AddComment(new Comment("Olivia", "What month did you visit?"));
        return video;
    }

    static Video CreateMusicVideo()
    {
        Video video = new Video("Acoustic Sunset Session", "River Sounds", 354);
        video.AddComment(new Comment("Leo", "This is so relaxing."));
        video.AddComment(new Comment("Emma", "Beautiful performance!"));
        video.AddComment(new Comment("Mia", "I would love a longer version."));
        return video;
    }
}
