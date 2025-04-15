using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            /*
                2. Listans kapacitet ökar när man lägger till ett element som gör att den nuvarande kapaciteten överskrids
                3. Den fördubblas
                4. Killgissning eller om det var för att Pontus sa det förra veckan: att utöka kapaciteten varje gång vore en onödigt resurskrävande (CPU-cykler) operation. 
                   Man väljer att slösa lite med minne istället
                5. Inte under tiden som jag kör programmet
                6. När man vet på förhand hur många objekt/element som behöver sparas, om man vet att det aldrig behöver ändras.             
             */

            List<string> theList = new List<string>();
            string input;
            Console.WriteLine($"Capacity: {theList.Capacity}");

            do 
            {
                Console.WriteLine("Enter a string that begins with + or -. Exit with 0");
                input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                               
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    default:               
                        break;
                }
                Console.WriteLine($"Content:");
                foreach (string str in theList) { Console.WriteLine(str); }
                Console.WriteLine($"Capacity: {theList.Capacity}{Environment.NewLine}");


            } while (input != "0");  
            
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> customers = new Queue<string>();
            string input;
         //   Console.WriteLine($"Capacity: {customers..Capacity}");

            do
            {
                Console.WriteLine("Enter +name to enqueue a customer. Enter - to dequeue. Type anything to list customers. Exit with 0");
                input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        customers.Enqueue(value);
                        break;
                    case '-':
                        if (customers.Count > 0)  //Dequeue kastar undantag om kön är tom
                            customers.Dequeue();
                        break;
                    default:                       
                        break;
                }
                Console.WriteLine($"{Environment.NewLine}Customers in queue:");
                foreach (var item in customers)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            } while (input != "0");

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<string> customers = new Stack<string>();
            string input;
            //   Console.WriteLine($"Capacity: {customers..Capacity}");

            do
            {
                Console.WriteLine("Enter +name to put a customer on the stack. Enter - to remove the last customer from the stack. Exit with 0");
                input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        customers.Push(value);
                        break;
                    case '-':
                        if (customers.Count > 0)  //Pop kastar undantag om kön är tom
                            customers.Pop();
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"{Environment.NewLine}Customers in stack:");
                foreach (var item in customers)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            } while (input != "0");
            Console.Write("Now enter a string that I will reverse for you: ");
            ReverseText(Console.ReadLine());
        }

        private static void ReverseText(string? v)
        {
            if (v != null)
            {
                Stack<char> inputString = new Stack<char>();
                foreach (char c in v)
                {
                    inputString.Push(c);
                }
                StringBuilder sb = new StringBuilder();
                while (inputString.Count > 0)
                {                    
                    sb.Append(inputString.First());
                    inputString.Pop();
                }
                Console.WriteLine(sb.ToString());
            }
            
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

