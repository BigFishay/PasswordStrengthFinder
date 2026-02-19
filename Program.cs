using Zxcvbn;

class Program
{
    static void Main(string[] args)
    {
        bool ex = true;
        PSFinder psf = new PSFinder();
        while (ex)
        {
            Console.WriteLine("Welcome to the Password Strength Finder. \n" +
                "This program runs locally so everything stays secure. \n" +
                "[0] Check password \n" +
                "[1] Add/remove banned words \n" +
                "[2] Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice){
                case 0:
                    Analyze(psf);
                    break;
                case 1:
                    AddWords(psf);
                    break;
                case 2:
                    ex = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void Analyze(PSFinder psf)
    {
        bool ex = true;
        while (ex)
        {
            Console.WriteLine("Your password will be analyzed and given a score (Bad, Meh, or Good) based on how strong the password is. \n" +
                "Please enter a password: ");
            string password = Console.ReadLine();
            if (password != null)
            {
                int result = psf.Analyze(password);
                if (result > 3)
                    Console.WriteLine("Good");
                else if (result > 2)
                    Console.WriteLine("Meh");
                else Console.WriteLine("Bad");
                ex = false;
            }
            else
            {
                Console.WriteLine("Please try again");
            }
        }
    }

    static void AddWords(PSFinder psf)
    {
        bool ex = true;
        while (ex)
        {
            Console.WriteLine("Here is the list of banned words: " + psf.Banned() + "\n" +
                "[0] Return \n" +
                "[1] Add word \n" +
                "[2] Remove word");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    ex = false;
                    break;
                case 1:
                    bool isValidAdd = false;
                    while (!isValidAdd)
                    {
                        Console.WriteLine("Please enter a word to be added: ");
                        isValidAdd = psf.AddBannedWord(Console.ReadLine());
                        if (!isValidAdd)
                        {
                            Console.WriteLine("Try again");
                        }
                    }
                    break;
                case 2:
                    bool isValidRemove = false;
                    while (!isValidRemove)
                    {
                        Console.WriteLine("Please enter a word to remove: ");
                        isValidRemove = psf.RemoveBannedWord(Console.ReadLine());
                        if (!isValidRemove)
                        {
                            Console.WriteLine("Try again");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
    }

    public class PSFinder
    {
        private LinkedList<string> bannedList = new LinkedList<string>();

        public bool AddBannedWord(string word)
        {
            if (!string.IsNullOrWhiteSpace(word) && !bannedList.Contains(word))
            {
                bannedList.AddLast(word);
                return true;
            }
            return false;
        }
        public bool RemoveBannedWord(string? word)
        {
            if (!string.IsNullOrWhiteSpace(word) && bannedList.Contains(word))
            {
                bannedList.Remove(word);
                return true;
            }
            return false;
        }

        public int Analyze(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password, bannedList).Score;
        }

        public string Banned()
        {
            return string.Join(", ", bannedList);
        }
    }
}
