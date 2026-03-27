

// 4 Numbers | ranges from 1 - 20

int totalOfNumbers = 4;
int lowestValue = 1;
int highestValue = 20;

int[] userNumbers = new int[totalOfNumbers];

Console.WriteLine("Welcome To The $1,000,000 Lottery.");
Console.WriteLine();
Console.WriteLine("Are You Luck Enough To Win BIG?!");
Console.WriteLine();
Console.WriteLine("Choose " + totalOfNumbers + " Unique Numbers Between " + lowestValue + " and " + highestValue + "!");
Console.WriteLine();


// Checks if User or Computer had already inputted that number
int LinearSearch(int[] array, int number)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == number)
        {
            return i;
        }
    }
    return -1;
}


// Lottery Check!

int BinarySearch(int[] array, int value, int low, int high)
{
    array.Sort();
    if (high >= low)
    {
        int mid = (high + low) / 2;

        if (array[mid] == value) return mid;

        if (array[mid] > value) return BinarySearch(array, value, low, mid - 1);

        return BinarySearch(array, value, mid + 1, high);
    }
    return -1;
}


// User Inputs Numbers

for (int i = 0; i < userNumbers.Length; i++)
{
    Console.Write("Enter A Number: ");
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out int number))
    {
        if (number >= lowestValue && number <= highestValue)
        {
            int result = LinearSearch(userNumbers, number);
            if (result == -1)
            {
                userNumbers[i] = number;
                continue;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter A New Number");
                Console.WriteLine();
                i -= 1;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please Enter A Valid Number");
            Console.WriteLine();
            i -= 1;

        }

    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter A Valid Number");
        Console.WriteLine();
        i -= 1;
    }
}

// Random Number Generator

Random rnd = new Random();

int[] computerNumbers = new int[totalOfNumbers];


for (int i = 0; i < totalOfNumbers; i++)
{
    int randomNumber = rnd.Next(lowestValue, highestValue);
    int result = LinearSearch(computerNumbers, randomNumber);
    if (result == -1)
    {
        computerNumbers[i] = randomNumber;
        continue;
    }
    else
    {
        i -= 1;
    }
}


foreach (int computerNumber in computerNumbers)
{
    Console.WriteLine(computerNumber);
}

// Searches For User Number in computerNumbers

for (int i = 0; i < totalOfNumbers; i++)
{
    int result = BinarySearch(computerNumbers, userNumbers[i], 0, computerNumbers.Length - 1);
    if (result == -1)
    {
        Console.WriteLine(userNumbers[i] + " is not in the winning numbers");
    }
    else
    {
        Console.WriteLine(userNumbers[i] + " is in the winning numbers");
    }
}

foreach (int computerNumber in computerNumbers)
{
    Console.WriteLine(computerNumber);
}

Console.Write("Your Numbers Are: ");
foreach (int number in userNumbers)
{
    Console.Write(number + " ");
}

