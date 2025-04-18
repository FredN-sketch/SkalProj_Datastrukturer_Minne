/* SVAR PÅ FRÅGA 1-3
1. Stacken är en trave eller stapel med minnespositioner, som kan lagra värden, eller adresser till heapen. Ordnad men långsam, man måste "lyfta av" minnespositioner för att komma åt den 
man är ute efter..Heapen är en mer oordnad samling av minnespositioner, men åtkomsten till dessa är snabb när man vet adressen till vad man letar efter. Heapen kräver garbage collection,
stacken håller ordning på sig själv.
2. En variabel av value type lagras på antingen stacken eller heapen och innehåller ett värde. För en variabel av reference type så sparas adressen till variabeln på stacken. 
Adressen pekar ut en minnesposition på heapen där värdet är lagrat. 
3. x och y är av värdetypen int. De sparas i det första exemplet på stacken som de är deklarerade. Y är en ny variabel som tilldelas samma värde som x. Men den har en egen minnesplats 
på stacken. När y ändras till 4 så är x fortfarande 3. 
I det andra exemplet är MyInt en klass, alltså en referenstyp. MyValue är en int, värdetyp, men ingår i ett objekt och sparas därför på heapen. x innehåller en minnesadress på heapen 
som innehåller värdet 3. När y sätts till x så får x och y samma innehåll: minnesadressen på heapen. När y.MyValue (som sparas på heapen) sätts till 4 ändras också x.MyValue till 4 
eftersom det är samma minnesposition. 

Svaren på frågorna till ExamineList och ExamineStack finns i kommentarerna vid resp metod.
 */


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
                        CheckParenthesis();
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
            /*  SVAR PÅ FRÅGA 2-6
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
                input =  Util.AskForString("string");
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
        
            do
            {
                Console.WriteLine("Enter +name to enqueue a customer. Enter - to dequeue. Type anything to list customers. Exit with 0");
                input = Util.AskForString("string");
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
            /*
            SVAR PÅ FRÅGA 1: Den som är först i kön blir inte betjänad förrän han är ensam i kön. Dvs alla som kommer efter blir betjänade före 
            (sist blir betjänad först, sedan den som var näst sist osv)            
            */

            Stack<string> customers = new Stack<string>();
            string input;
           
            do
            {
                Console.WriteLine("Enter +name to put a customer on the stack. Enter - to remove the last customer from the stack. Exit with 0");
                input = Util.AskForString("string");
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
            ReverseText(Util.AskForString("string"));
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

        static void CheckParenthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            string inputString = "(a){b}[c]";
            StackParentheses(inputString);
            inputString = "((so)le(n}skiner({[<)"; //ej välformad
            StackParentheses(inputString);
            inputString = "()solenskiner"; //välformad
            StackParentheses(inputString);
            inputString = "()(solenskiner)"; //välformad 
            StackParentheses(inputString);
            inputString = "[{}]({})";     //välformad
            StackParentheses(inputString);
            inputString = "[{}]{}";
            StackParentheses(inputString);
            inputString = "([{ }]({ }))";
            StackParentheses(inputString);
            inputString = "List<int> lista = new List<int>() { 2, 3, 4 };";
            StackParentheses(inputString);
            Console.Write("Please enter a string that you want to know if it's well shaped or not: ");
            inputString = Util.AskForString("string");
            StackParentheses(inputString);
        }

        private static void StackParentheses(string inputString)
        {
            Console.WriteLine(inputString);            
            string parenthesesExtracted = ExtractParenthesis(inputString);
            Stack<char> chars = new Stack<char>();
            bool wellShaped = true;
            foreach (char c in parenthesesExtracted)
            {
                if ("<({[".Contains(c))
                    chars.Push(c);
                else if (">)]}".Contains(c))
                {
                    if (chars.Count > 0)
                    {                        
                        if (c == RightParenthesis(chars.Peek())) //Peek returnerar den översta/senaste vänsterparentesen i stacken
                        {
                            chars.Pop();
                        }                        
                    }
                    else wellShaped = false; //högerparenteser kvar i parenthesesExtracted efter att alla vänterparenteser poppats, så ej välformad
                }
            }
            if (chars.Count > 0) wellShaped = false; //om inte alla tecken har poppats så finns det vänsterparenteser kvar, ej välformad
            if (wellShaped)
                Console.WriteLine("Well shaped!");
            else Console.WriteLine("Not well shaped...");
            Console.ReadLine();
        }            

        static string ExtractParenthesis(string input)
        {
            StringBuilder sb = new StringBuilder();
            string paranthesis = "(){}[]<>";
            foreach (char c in input)
            {
                if (paranthesis.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
        static char RightParenthesis(char left)
        {            
            switch (left)
            {
                case '(':
                    return ')';
                   
                case '{':
                    return '}';
                    
                case '[':
                    return ']';
                    
                case '<':
                    return '>';
                    
                default: //inte en parentes
                    return 'X';                    
            }
        }
    }
}

