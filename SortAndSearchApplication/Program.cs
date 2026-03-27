// 4 Numbers | ranges from 1 - 45
int totalOfNumbers = 4;
int[] userNumbers = new int[totalOfNumbers];

for(int i = 0; i < userNumbers.Length; i++)
{
    Console.Write("Enter A Number: ");
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out int number))
    {
        userNumbers[i] = number;
    }
    else
    {
        Console.WriteLine("Please Enter A Valid Number");
        i -= 1;
    }
}