// 4 Numbers | ranges from 1 - 20
int totalOfNumbers = 4;
int lowestValue = 1;
int highestValue = 20;

// User Inputs Numbers

int[] userNumbers = new int[totalOfNumbers];

for (int i = 0; i < userNumbers.Length; i++)
{
    Console.Write("Enter A Number: ");
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out int number))
    {
        if(number >= lowestValue &&  number <= highestValue)
        {
            userNumbers[i] = number;
        }
        else
        {
            Console.WriteLine("Please Enter A Valid Number");
            i -= 1;

        }

    }
    else
    {
        Console.WriteLine("Please Enter A Valid Number");
        i -= 1;
    }
}

// Random Number Generator

Random rnd = new Random();

int[] computerNumbers = new int[totalOfNumbers];


for (int i = 0; i < totalOfNumbers; i++)
{
    int randomNumber = rnd.Next(lowestValue, highestValue);
    computerNumbers[i] = randomNumber;
}

foreach (int computerNumber in computerNumbers)
{
    Console.WriteLine(computerNumber);
}