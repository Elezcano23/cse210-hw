public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            choice = Prompt("Select a choice from the menu: ");

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Please enter a number from 1 to 6."); break;
            }
        } while (choice != "6");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level {GetPlayerLevel()}: {GetLevelTitle()}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        string type = Prompt("Which type of goal would you like to create? ");

        if (type is not ("1" or "2" or "3"))
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        string name = Prompt("What is the name of your goal? ");
        string description = Prompt("What is a short description of it? ");
        int points = PromptForPositiveInt("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = PromptForPositiveInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = PromptForNonNegativeInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int goalNumber = PromptForPositiveInt("Which goal did you accomplish? ");

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("That goal number does not exist.");
            return;
        }

        int previousLevel = GetPlayerLevel();
        int pointsEarned = _goals[goalNumber - 1].RecordEvent();
        if (pointsEarned == 0)
        {
            Console.WriteLine("This goal has already been completed.");
            return;
        }

        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");
        Console.WriteLine($"You now have {_score} points.");

        if (GetPlayerLevel() > previousLevel)
        {
            Console.WriteLine($"Level up! You are now Level {GetPlayerLevel()}: {GetLevelTitle()}!");
        }
    }

    public void SaveGoals()
    {
        string filename = Prompt("What is the filename for the goal file? ");
        try
        {
            List<string> lines = new List<string> { _score.ToString() };
            foreach (Goal goal in _goals)
            {
                lines.Add(goal.GetStringRepresentation());
            }

            File.WriteAllLines(filename, lines);
            Console.WriteLine("Goals saved.");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Could not save goals: {exception.Message}");
        }
    }

    public void LoadGoals()
    {
        string filename = Prompt("What is the filename for the goal file? ");
        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0 || !int.TryParse(lines[0], out int savedScore))
            {
                Console.WriteLine("The goal file is not valid.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = CreateGoalFromSaveString(lines[i]);
                if (goal != null)
                {
                    loadedGoals.Add(goal);
                }
            }

            _score = savedScore;
            _goals = loadedGoals;
            Console.WriteLine("Goals loaded.");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Could not load goals: {exception.Message}");
        }
    }

    private Goal CreateGoalFromSaveString(string line)
    {
        string[] typeAndData = line.Split(':', 2);
        if (typeAndData.Length != 2)
        {
            return null;
        }

        string[] parts = typeAndData[1].Split('|');
        if (parts.Length < 3 || !int.TryParse(parts[2], out int points))
        {
            return null;
        }

        return typeAndData[0] switch
        {
            "SimpleGoal" when parts.Length == 4 && bool.TryParse(parts[3], out bool complete)
                => new SimpleGoal(parts[0], parts[1], points, complete),
            "EternalGoal" => new EternalGoal(parts[0], parts[1], points),
            "ChecklistGoal" when parts.Length == 6
                && int.TryParse(parts[3], out int bonus)
                && int.TryParse(parts[4], out int target)
                && int.TryParse(parts[5], out int completed)
                => new ChecklistGoal(parts[0], parts[1], points, target, bonus, completed),
            _ => null
        };
    }

    private string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    private int GetPlayerLevel()
    {
        return (_score / 500) + 1;
    }

    private string GetLevelTitle()
    {
        int level = GetPlayerLevel();

        if (level >= 10)
        {
            return "Eternal Champion";
        }

        if (level >= 7)
        {
            return "Faithful Disciple";
        }

        if (level >= 4)
        {
            return "Goal Guardian";
        }

        return "Quest Beginner";
    }

    private int PromptForPositiveInt(string message)
    {
        int number;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);

        return number;
    }

    private int PromptForNonNegativeInt(string message)
    {
        int number;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number) || number < 0);

        return number;
    }
}
