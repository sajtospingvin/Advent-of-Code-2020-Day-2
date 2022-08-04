public class AdventOfCode
{
    static void Main(string[] args)
    {
        // Read the file
        string[] passwords = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "passwords.txt"));

        //Write out the results
        Console.WriteLine(AssessmentOne(passwords));
        Console.WriteLine(AssessmentTwo(passwords));
    }

    public static int AssessmentOne(string[] passwords)
    {
        // Counter of correct passwords
        int correctPasswords = 0;

        for (int i = 0; i < passwords.Length; i++)
        {
            // Formatting
            string[] policy = passwords[i].Split(":");
            string[] charNumber = policy[0].Split(" ");
            string[] splitCharNumber = charNumber[0].Split("-");

            string password = policy[1].Trim();
            string characterLetter = charNumber[1];
            string minimumCharacter = splitCharNumber[0].Trim();
            string maximumCharacter = splitCharNumber[1].Trim();

            // Convert the password string to array
            string[] passwordArray = password.ToCharArray().Select(c => c.ToString()).ToArray();

            int characterCounter = 0;

            for (int j = 0; j < passwordArray.Length; j++)
            {
                // Increase te counter if an element of the array equals the character
                if (passwordArray[j] == characterLetter)
                {
                    characterCounter++;
                }
            }

            // Correct password: if the counter is bigger than the minimum or smaller than the maximum
            if (characterCounter >= Int32.Parse(minimumCharacter) && characterCounter <= Int32.Parse(maximumCharacter))
            {
                correctPasswords++;
            }
        }

        return correctPasswords;

    }

    public static int AssessmentTwo(string[] passwords)
    {
        int correctPasswords = 0;

        for (int i = 0; i < passwords.Length; i++)
        {
            string[] policy = passwords[i].Split(":");
            string[] charNumber = policy[0].Split(" ");
            string[] splitCharNumber = charNumber[0].Split("-");

            string password = policy[1].Trim();
            string characterLetter = charNumber[1];
            string minimumCharacter = splitCharNumber[0].Trim();
            string maximumCharacter = splitCharNumber[1].Trim();

            // The first and the second parameter letter e.g. 1-3 a: abcde --> a and c
            string letterOne = password[Int32.Parse(minimumCharacter) - 1].ToString();
            string letterTwo = password[Int32.Parse(maximumCharacter) - 1].ToString();

            if ((letterOne == characterLetter) && (letterTwo != characterLetter) || (letterOne != characterLetter) && (letterTwo == characterLetter))
            {
                correctPasswords++;
            }
        }
        return correctPasswords;
    }
}