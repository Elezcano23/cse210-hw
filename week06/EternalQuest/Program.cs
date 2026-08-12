class Program
{
    static void Main(string[] args)
    {
        // Creativity: players level up every 500 points and receive a themed title
        // plus a celebration message whenever they reach a new level.
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
