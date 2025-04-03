using System;
using System.Media;
using System.Threading;


namespace CyberSecurityChatbot
{

    class CyberSecurityChatbot
    {

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ███  █     █ ████    ████   ████    ████    ████    ███ ");
            Console.WriteLine("█       █ █   █   █   █      █   █   █       █      █    ");
            Console.WriteLine("█        █    ████    ████   ████    ████    ████   █    ");
            Console.WriteLine("█        █    █   █   █      █   █       █   █      █    ");
            Console.WriteLine(" ███     █    ████    ████   █    █  ████    ████    ███ ");
            Console.ResetColor();

        }
        // Simulates a typing effect by printing characters one by one with a delay.
        static void TypeEffect(string message, int delay = 70)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay); // Adjust delay for speed (default 70ms)
            }
            Console.WriteLine();
        }


        static void StartChatbot()
        {
            SoundPlayer player = new SoundPlayer(@"CyberSecurity.wav");
            player.PlaySync();



            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Thread.Sleep(1000); // Pause before the next message
            Console.WriteLine("\n" + char.ConvertFromUtf32(0x1F3C1) + " WELCOME TO THE CYBERSECURITY CHATBOT " + char.ConvertFromUtf32(0x1F3C1));
            Thread.Sleep(1000);
            TypeEffect($"Hello {name}, How are you? (I'm good / Not good)");


            string userResponse;
            while (true)
            {
                userResponse = Console.ReadLine().Trim().ToLower();

                if (userResponse == "i'm good" || userResponse == "im good")
                {

                    TypeEffect("I'm glad to hear that!");
                    break;

                }
                else if (userResponse == "not good")
                {
                    TypeEffect("I wish I was programmed to get deeper into why you are not good, but remember that there is nothing prayer can't fix.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I don't understand. Please enter 'I'm good' or 'Not good'.");
                    Console.ResetColor();
                }
            }
            Thread.Sleep(1000); // Pause before showing the tips
            Console.WriteLine("\nWould you like to know:");
            Console.WriteLine("1. The purpose of this cybersecurity chatbot");
            Console.WriteLine("2. What you can ask about");
            string choice = Console.ReadLine().ToLower();

            if (choice.Contains("1") || choice.Contains("purpose"))
            {
                TypeEffect("This chatbot is designed to help you stay safe online by providing cybersecurity awareness and best practices.");
                // Added prompt so the user knows what to do next
                Thread.Sleep(1000);
                Console.WriteLine("\nWould you like to ask about 'passwords', 'phishing', or 'safe browsing'? (Or type 'exit' to leave)");
            }

            else if (choice.Contains("2") || choice.Contains("ask about"))
            {
                ShowMenu(); // Displays the menu options for the chatbot.
            }


            while (true)
            {
                Console.Write($"\n{name}: ");
                string userInput = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hmm, looks like you forgot to enter something! Please enter a valid query.");
                    Console.ResetColor();
                    continue;
                }
                else if (userInput.Contains("1") || userInput.Contains("password"))
                {
                    Console.WriteLine("\n" + char.ConvertFromUtf32(0x1F512) + " PASSWORD SECURITY TIPS " + char.ConvertFromUtf32(0x1F512));
                    TypeEffect("Here are some tips to keep your passwords strong :");
                    Thread.Sleep(1100); // Pause before showing the tips
                    Console.WriteLine("1. Use long, unique passwords with a mix of upper and lowercase letters, numbers, and symbols.");
                    Thread.Sleep(1100);
                    Console.WriteLine("2. Avoid using easily guessed passwords like 'password123' or '123456'.");
                    Thread.Sleep(1100);
                    Console.WriteLine("3. Don't reuse passwords across different accounts!");
                    Thread.Sleep(1100);
                    Console.WriteLine("4. Enable two-factor authentication (2FA) whenever possible for extra security.");
                    Thread.Sleep(1100);
                    Console.WriteLine("5. Consider using a password manager to store and generate strong passwords.");
                    Thread.Sleep(1100);
                    Console.WriteLine("6. Change your passwords regularly, especially for sensitive accounts.");
                    Thread.Sleep(1100);

                    AskNextAction();
                    continue;
                }
                else if (userInput.Contains("2") || userInput.Contains("phishing"))
                {
                    Console.WriteLine("\n" + char.ConvertFromUtf32(0x26A0) + " PHISHING AWARENESS " + char.ConvertFromUtf32(0x26A0));
                    Thread.Sleep(1100);
                    Console.WriteLine($"\n{name}, beware of phishing!!!");
                    TypeEffect("Phishing is when cybercriminals trick you into revealing sensitive information like;\npasswords, credit card numbers, or personal data.");
                    Thread.Sleep(1100); // Pause before showing the tips
                    Console.WriteLine("\nWatch out for these signs :");
                    Thread.Sleep(1100);
                    Console.WriteLine("1. Suspicious-looking email addresses.");
                    Thread.Sleep(1100);
                    Console.WriteLine("2. Poor grammar or spelling mistakes in emails.");
                    Thread.Sleep(1100);
                    Console.WriteLine("3. Unexpected attachments or links in emails.");
                    Thread.Sleep(1100);
                    Console.WriteLine("4. Emails asking you to click on links or provide personal information.");

                    TypeEffect("\nTo protect yourself from phishing, remember to:");
                    Thread.Sleep(1100); // Pause before showing the tips
                    Console.WriteLine("1. Never click on suspicious links or attachments. ");
                    Thread.Sleep(1100);
                    Console.WriteLine("2. Always verify the sender's email address. ");
                    Thread.Sleep(1100);
                    Console.WriteLine("3. Be cautious when providing personal information online. ");
                    Thread.Sleep(1100);

                    AskNextAction();
                    continue;
                }
                else if (userInput.Contains("3") || userInput.Contains("safe browsing"))
                {
                    Console.WriteLine("\n" + char.ConvertFromUtf32(0x1F310) + " SAFE BROWSING TIPS " + char.ConvertFromUtf32(0x1F310));
                    Thread.Sleep(1100);
                    TypeEffect($"\nOkay, {name}, let's talk about safe browsing!");
                    Thread.Sleep(1100); // Pause before showing the tips
                    Console.WriteLine("\nSafe browsing is essential to protect your data and privacy online. Here's how you can browse safely:");
                    Thread.Sleep(1100);
                    Console.WriteLine("1. Look for HTTPS in the website address (a padlock symbol will appear in the browser). ");
                    Thread.Sleep(1100);
                    Console.WriteLine("2. Be cautious about the websites you visit. Stick to reputable sources.");
                    Thread.Sleep(1100);
                    Console.WriteLine("3. Avoid clicking on pop-ups or ads that seem too good to be true.");
                    Thread.Sleep(1100);
                    Console.WriteLine("4. Use a Virtual Private Network (VPN) when using public Wi-Fi networks.");
                    Thread.Sleep(1100);
                    Console.WriteLine("5. Keep your browser updated with the latest security patches.");
                    Thread.Sleep(1100);
                    Console.WriteLine("6. Enable browser security features like blocking third-party cookies.");
                    Thread.Sleep(1100);

                    AskNextAction();
                    continue;
                }
                else if (userInput.Contains("4") || userInput.Contains("exit"))
                {
                    TypeEffect($"{name}, Stay safe online! Goodbye! \u2728\uD83D\uDE4F And remember, JESUS LOVES YOU \u2764\uFE0F\u271D\uFE0F");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hmm, I didn't quite get that. Could you rephrase?");
                    Console.ResetColor();
                }

                ShowMenu();
            }
        }

        static void ShowMenu()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\nPlease choose one of the options:");
            Console.WriteLine("1. Learn about Password Safety");
            Console.WriteLine("2. Learn about Phishing");
            Console.WriteLine("3. Learn about Safe Browsing");
            Console.WriteLine("4. Exit the Chat");
        }

        // Asks the user whether they want to continue the chat or exit.
        static void AskNextAction()
        {
            TypeEffect("\nWould you like to talk about another topic or exit the chat?");
            Console.WriteLine("Type 'yes' to continue or 'exit' to leave.");
            string nextAction = Console.ReadLine().ToLower().Trim();

            if (nextAction == "yes")
            {
                ShowMenu(); // Show the menu again


            }
            else if (nextAction == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Stay safe online! Goodbye! \u2728\uD83D\uDE4F And remember, JESUS LOVES YOU \u2764\uFE0F\u271D\uFE0F");
                Console.ResetColor();
                Environment.Exit(0);  // Stops the program completely

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops! I didn't understand that. Let's try again.");
                Console.ResetColor();
                AskNextAction();
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8; //Emojis where not apprearing so I used this to enable them

                DisplayAsciiArt();
                StartChatbot();
            }
        }
    }
}

