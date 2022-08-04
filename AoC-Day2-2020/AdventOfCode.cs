public class AdventOfCode
{
    static void Main(string[] args)
    {
        string[] passwords = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "passwords.txt"));
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

            string[] passwordArray = password.ToCharArray().Select(c => c.ToString()).ToArray();

            int characterCounter = 0;

            for (int j = 0; j < passwordArray.Length; j++)
            {
                if (passwordArray[j] == characterLetter)
                {
                    characterCounter++;
                }
            }

            if (characterCounter >= Int32.Parse(minimumCharacter) && characterCounter <= Int32.Parse(maximumCharacter))
            {
                correctPasswords++;
            }
        }
        Console.WriteLine("Correct passwords: " + correctPasswords);

    }
}