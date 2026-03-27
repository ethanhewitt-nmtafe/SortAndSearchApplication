// 4 Numbers | ranges from 1 - 20

int totalOfNumbers = 4;
int lowestValue = 1;
int highestValue = 20;
int winningCounter = 0; // Leave At 0

int[] userNumbers = new int[totalOfNumbers];

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


// Checks if User has correct number
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

// Welcome Text
void Welcome()
{
    Console.WriteLine("Welcome To The $1,000,000 Lottery!");
    Console.WriteLine();
    Console.WriteLine("Are You Lucky Enough To Win BIG?!");
    Console.WriteLine();
    Console.WriteLine("Choose " + totalOfNumbers + " Unique Numbers Between " + lowestValue + " and " + highestValue + "!");
    Console.WriteLine();
}

// Ouput Welcome Text
Welcome();

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

// Sorts Users Numbers
userNumbers.Sort();

// Output Text
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine("Are You Ready To See If You've Won?");
//Console.WriteLine();
//Console.Write("PRESS ANY KEY WHEN READY");
//Console.ReadKey(true);
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();



// Randomly Generates Winning numbers

Random rnd = new Random();
int[] computerNumbers = new int[totalOfNumbers];

for (int i = 0; i < totalOfNumbers; i++)
{
    int randomNumber = rnd.Next(lowestValue, highestValue + 1); // Added +1 as it didn't generate the highest number for some reason.. is this meant to be?
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

// Sorts Computer Numbers
computerNumbers.Sort();

// Outputs User's Numbers
Console.WriteLine();
Console.Write("YOUR NUMBERS: ");
foreach (int number in userNumbers)
{
    Console.Write(number + " ");
}
Console.WriteLine();

// Outputs The Winning numbers
Console.Write("WINNING NUMBERS: ");
foreach (int number in computerNumbers)
{
    Console.Write(number + " ");
}
Console.WriteLine();
Console.WriteLine();

// Searches For User Number in computerNumbers
for (int i = 0; i < totalOfNumbers; i++)
{ 
    int result = BinarySearch(computerNumbers, userNumbers[i], 0, computerNumbers.Length - 1);
    if (result == -1)
    {
        Console.WriteLine(userNumbers[i] + " IS NOT A WINNING NUMBER");
        
    }
    else
    {
        Console.WriteLine(userNumbers[i] + " IS A WINNING NUMBER!");
        winningCounter += 1;
    }
}
Console.WriteLine();

// Outputs Whether Or Not You Have Won
if (winningCounter == totalOfNumbers)
{
    Console.WriteLine("YOU HAVE WON!!!!!!!!");
} 
else
{
    Console.WriteLine("You Only Got " + winningCounter + "/" + totalOfNumbers + " Correct :(");
    Console.WriteLine("Better Luck Next Time!");
}