
public class PSFinder
{
    public double analyze(String password)
    {
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PSFinder psf = new PSFinder();
        while (true)
        {
            Console.WriteLine("Welcome to the Password Strength Finder. \n " +
                "This program runs locally so everything stays secure. \n " +
                "Your password will be analyzed and given a score (Bad, Meh, Good) based on how strong the password is. \n" +
                "Close the program to exit the app \n" +
                "Please type (or paste) your password:");
            String password = Console.ReadLine();
            if (password != null)
            {
                double result = psf.analyze(password);
                if (result > 66)
                    Console.WriteLine("Good");
                else if (result > 33)
                    Console.WriteLine("Meh");
                else Console.WriteLine("Bad");
            }
            else
            {
                 Console.WriteLine("Please try again");
            }
        }
    }
}
