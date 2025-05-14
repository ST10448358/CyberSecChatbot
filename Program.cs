using System.Collections.Generic;
using System.Media;
using System.Threading;
using System;


namespace CyberSecurityChatbot
{
    class CyberSecurityChatbot
    {
        static string userName = "";
        static Dictionary<string, string> memory = new Dictionary<string, string>();

        // tips for cybersecurity topics
      
        static List<string> phishingTips = new List<string>
    {
        "Be cautious of emails asking for personal information. Scammers often pretend to be trusted organisations.",
        "Never click on suspicious links or open attachments from unknown senders.",
        "Always verify the sender’s email address before taking any action.",
        "Hover over links to check the real URL before clicking."
    };

        static List<string> scamTips = new List<string>
    {
        "Beware of unsolicited phone calls or emails claiming you've won a prize.",
        "Never give out personal or financial info unless you're sure who you're dealing with.",
        "Look out for emails that seem too good to be true – they often are.",
        "Verify offers by contacting the organisation through official channels."
    };

        static List<string> safeBrowsingTips = new List<string>
    {
        "Ensure websites are secure—look for HTTPS in the URL.",
        "Avoid downloading files from untrusted websites.",
        "Use updated antivirus software and keep your browser current.",
        "Don’t enter personal info on public Wi-Fi unless using a VPN."
    };

        static List<string> passwordTips = new List<string>
    {
        "Use long, unique passwords with a mix of letters, numbers, and symbols.",
        "Avoid using personal information in your passwords.",
        "Use a password manager to store different passwords safely.",
        "Enable two-factor authentication wherever possible."
    };

        static List<string> privacyTips = new List<string>
    {
        "Check your social media privacy settings and limit who can see your posts.",
        "Be cautious about sharing personal information online.",
        "Use strong privacy settings on apps and websites.",
        "Regularly review the permissions you've granted to apps."
    };
        // Topic explanation (used in conversation mode)

        static Dictionary<string, string> topicExplanations = new Dictionary<string, string>
    {
        { "password", "Passwords are like a locked house. A strong password protects your personal data from being stolen." },
        { "phishing", "Phishing is when attackers trick you into giving away personal information through fake emails or websites." },
        { "scam", "A scam is a dishonest scheme used to deceive people into giving away money or personal details." },
        { "safe browsing", "Safe browsing means protecting yourself from online threats by avoiding risky websites and behaviors." },
        { "privacy", "Online privacy is about keeping your personal information secure and choosing what to share." }
    };
        // Analogies to simplify complex concepts
        static Dictionary<string, string> topicAnalogies = new Dictionary<string, string>
    {
        { "password", "Think of your password like a house key. If it's weak or shared, it's like leaving your door unlocked." },
        { "phishing", "It's like someone dressing as your friend to trick you into giving them your keys." },
        { "scam", "A scam is like a street con artist offering fake goods or stories to get your money." },
        { "safe browsing", "It’s like walking on a well-lit sidewalk versus a dark alley online." },
        { "privacy", "Your privacy online is like drawing the curtains on your windows—you control what others see." }
    };
        // Examples to illustrate concepts

        static Dictionary<string, string> topicExamples = new Dictionary<string, string>
    {
        { "password", "For instance, a strong password could be 'Mys3cur3$Pass!' instead of '12345'." },
        { "phishing", "For example getting an email from 'your bank' asking you to click a link to reset your password." },
        { "scam", "An example is someone calling you claiming you’ve won money, but asking for your card details." },
        { "safe browsing", "Avoiding downloading pirated movies from suspicious websites is part of safe browsing." },
        { "privacy", "Don’t post your ID number or home address on social media to protect your privacy." }
    };
        // Menu topic definitions for selection mode

        static Dictionary<string, string> menuTopicDefinitions = new Dictionary<string, string>
    {
        { "password", "Passwords are secret codes that protect your accounts. Creating strong passwords helps keep your personal data safe from hackers." },
        { "phishing", "Phishing is a trick used by attackers who pretend to be trusted sources to steal your sensitive information, like passwords or bank details." },
        { "scam", "A scam is a dishonest trick where someone tries to fool you into giving them money or private details." },
        { "safe browsing", "Safe browsing is the practice of using the internet in a cautious way to avoid malware, scams, or harmful websites." },
        { "privacy", "Privacy online means keeping control over your personal information and deciding what you share and with whom." }
    };
        // Display ASCII art for the chatbot
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

        static void TypeEffect(string message, int delay = 40)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
        // Start interaction with the user
        static void StartChatbot()
        {
            SoundPlayer player = new SoundPlayer("CyberSecurity.wav");
            player.PlaySync();

            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
            memory["name"] = userName;

            Console.WriteLine($"\nWELCOME TO THE CYBERSECURITY CHATBOT, {userName}!");
            Thread.Sleep(1000);

            TypeEffect($"How are you feeling today, {userName}?");
            string sentiment = Console.ReadLine().ToLower();
            RespondToSentiment(sentiment);

            ShowMenu();
        }
        //Display the main menu and options
        static void ShowMenu()
        {
            Console.WriteLine("\nWould you like to:");
            Console.WriteLine("1. Learn the purpose of this chatbot");
            Console.WriteLine("2. Choose a topic to learn about");
            Console.WriteLine("3. Chat about cybersecurity topics");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine().ToLower();

            if (choice.Contains("1") || choice.Contains("purpose"))
            {
                TypeEffect("This chatbot helps you stay safe online by providing cybersecurity awareness and best practices.");
                ShowMenu();
            }
            else if (choice.Contains("2") || choice.Contains("topic"))
            {
                MainConversationLoop();
            }
            else if (choice.Contains("3") || choice.Contains("chat"))
            {
                EnterConversationMode();
            }
            else if (choice.Contains("4") || choice.Contains("exit"))
            {
                Console.WriteLine("Stay safe online. Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("I didn't understand that. Returning to main menu.");
                ShowMenu();
            }
        }
        // Topic learning loop with menu-style selection
        static void MainConversationLoop()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a topic or type it yourself:");
                Console.WriteLine("A. Passwords");
                Console.WriteLine("B. Scams");
                Console.WriteLine("C. Privacy");
                Console.WriteLine("D. Phishing");
                Console.WriteLine("E. Safe browsing");
                Console.WriteLine("Type 'exit' to end or 'continue' to return to the main menu.");

                string input = Console.ReadLine().ToLower().Trim();

                if (input.Contains("exit"))
                {
                    Console.WriteLine("Stay safe online. Goodbye!");
                    Environment.Exit(0);
                }

                if (input.Contains("continue"))
                {
                    Console.WriteLine($"Seeing that you want to learn more excites me, {userName}! What would you like to know next?");
                    continue;
                }
                //Route to correct topic
                if (input == "a" || input.Contains("password"))
                {
                    ShowTopicDefinitionAndTips("password");
                    continue;
                }

                if (input == "b" || input.Contains("scam"))
                {
                    ShowTopicDefinitionAndTips("scam");
                    continue;
                }

                if (input == "c" || input.Contains("privacy"))
                {
                    ShowTopicDefinitionAndTips("privacy");
                    continue;
                }

                if (input == "d" || input.Contains("phishing"))
                {
                    ShowTopicDefinitionAndTips("phishing");
                    continue;
                }

                if (input == "e" || input.Contains("safe browsing"))
                {
                    ShowTopicDefinitionAndTips("safe browsing");
                    continue;
                }

                Console.WriteLine("I'm not sure I understand. Try selecting A–E or asking about phishing, scams, passwords, safe browsing, or privacy.");
            }
        }
        // display topic definition and tips
        static void ShowTopicDefinitionAndTips(string topic)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{char.ToUpper(topic[0]) + topic.Substring(1)}:");
            Console.ResetColor();

            if (menuTopicDefinitions.ContainsKey(topic))
                Console.WriteLine(menuTopicDefinitions[topic]);

            ShowAllTips(topic);
            ContinueOrExit();
        }
        // display detailed topic explanation with tips/examples/analogy
        static void ShowTopic(string topic)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{char.ToUpper(topic[0]) + topic.Substring(1)} Explanation:");
            Console.ResetColor();

            Console.WriteLine(topicExplanations[topic]);

            Console.WriteLine("\nWould you like tips or an example? (tip/example/skip)");
            string helpChoice = Console.ReadLine().ToLower();
            if (helpChoice.Contains("tip"))
            {
                ShowAllTips(topic);
            }
            else if (helpChoice.Contains("example"))
            {
                Console.WriteLine(topicExamples[topic]);
            }

            Console.WriteLine("Do you understand? (yes/no)");
            string understand = Console.ReadLine().ToLower();
            if (understand.Contains("no"))
            {
                Console.WriteLine("Let me explain it differently...");
                Console.WriteLine(topicAnalogies[topic]);
            }

            ContinueOrExit();
        }
        // Display tips for a given topic
        static void ShowAllTips(string topic)
        {
            List<string> tips = new List<string>();

            switch (topic)
            {
                case "password":
                    tips = passwordTips;
                    break;
                case "phishing":
                    tips = phishingTips;
                    break;
                case "scam":
                    tips = scamTips;
                    break;
                case "safe browsing":
                    tips = safeBrowsingTips;
                    break;
                case "privacy":
                    tips = privacyTips;
                    break;
                default:
                    Console.WriteLine("Sorry, I don't have tips for that topic.");
                    return;
            }

            Console.WriteLine("Here are some tips:");
            foreach (var tip in tips)
            {
                Console.WriteLine($"- {tip}");
            }
        }
        // Prompt the user to continue, go to main menu, or exit
        static void ContinueOrExit()
        {
            Console.WriteLine("\nWould you like to 'continue', return to the 'main menu', or 'exit'?");
            string input = Console.ReadLine().ToLower();

            if (input.Contains("continue"))
            {
                Console.WriteLine($"WOW, {userName}. I love your determination on learning how to say safe online! What would you like to know next?");
            }
            else if (input.Contains("main"))
            {
                ShowMenu();
            }
            else if (input.Contains("exit"))
            {
                Console.WriteLine("Stay safe online. Goodbye!");
                Environment.Exit(0);
            }
        }
        // Open-ended conversation mode interaction
        static void EnterConversationMode()
        {
            Console.WriteLine($"\nYou're now chatting with me! Ask about cybersecurity topics like passwords, phishing, scams, etc.");
            Console.WriteLine($"Okay {userName}, what would you like to talk about?");

            while (true)
            {
                Console.Write($"\n{userName}: ");
                string input = Console.ReadLine().ToLower();

                if (input.Contains("exit"))
                {
                    Console.WriteLine("Stay safe online. Goodbye!");
                    Environment.Exit(0);
                }

                bool matched = false;
                foreach (var topic in topicExplanations.Keys)
                {
                    if (input.Contains(topic))
                    {
                        ShowTopic(topic);
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    Console.WriteLine("I don't have information on that yet. Try asking about passwords, phishing, scams, etc.");
                }
            }
        }
        // Respond empathetically to the user emotion(didn't want to limit user
        
        static void RespondToSentiment(string sentiment)
        {
            if (sentiment.Contains("good") || sentiment.Contains("okay"))
                Console.WriteLine("Great to hear that!");
            else if (sentiment.Contains("not okay") || sentiment.Contains("not fine"))
                Console.WriteLine("I'm sorry to hear that. Let's try to make things better with some helpful cybersecurity tips.");
            else if (sentiment.Contains("bad") || sentiment.Contains("not good"))
                Console.WriteLine("I'm sorry to hear that. Let's try to make things better with some helpful cybersecurity tips.");
            else if (sentiment.Contains("worried"))
                Console.WriteLine("It’s okay to be worried. I’ll help you with some cybersecurity tips.");
            else if (sentiment.Contains("curious"))
                Console.WriteLine("Curiosity is great! Let’s explore cybersecurity together.");
            else if (sentiment.Contains("frustrated"))
                Console.WriteLine("Let’s see if we can make things clearer.");
            else if (sentiment.Contains("anxious"))
                Console.WriteLine("It’s okay to feel anxious. Let me help calm your nerves with some simple advice.");
            else if (sentiment.Contains("excited"))
                Console.WriteLine("I love your enthusiasm! Let’s dive into some exciting cybersecurity facts.");
            else if (sentiment.Contains("confused"))
                Console.WriteLine("I understand. Let me help clarify things for you with some examples.");
            else if (sentiment.Contains("happy"))
                Console.WriteLine("I’m glad you’re feeling happy! Let's keep it positive and learn more about staying safe online.");
            else if (sentiment.Contains("sad"))
                Console.WriteLine("I’m sorry you’re feeling sad. Let’s work through it together with some useful tips.");
            else if (sentiment.Contains("neutral") || sentiment.Contains("fine"))
                Console.WriteLine("Thanks for sharing. Let’s get started.");
            else
                Console.WriteLine("Thanks for sharing. Let’s get started.");
        }


        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8; //Emable emojis?(I think I removed them)
                DisplayAsciiArt(); // Show welcome banner
                StartChatbot(); //Begin chatbot session
            }
        }
    }


}
