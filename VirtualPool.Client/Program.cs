using System;
using System.Collections.Generic;
using VirtualPool.Manager;

namespace VirtualApp.Client
{
    class Program
    {
        static Program()
        {
            PoolManager = new VirtualPool.Manager.Data.PoolManager();
        }

        static void Main(string[] args)
        {
            string userId;

            if (args.Length < 2 || (userId = PoolManager.Login(args[0], args[1])) == null)
            {
                Console.WriteLine(Labels.Feedback.InvalidParameters);
                Console.ReadKey();
                return;
            } 

            try
            {
                string line;

                Console.WriteLine(Labels.Feedback.EnterAction);

                while (!Labels.Quit.Equals((line = Console.ReadLine().Trim())))
                {
                    string[] parameters = line.Split(' ');

                    Func<string, string, bool> action = null;

                    if (parameters.Length < 2 ||
                        !ActionsDictionary.TryGetValue(parameters[0], out action) ||
                        action == null)
                    {
                        Console.WriteLine(Labels.Feedback.InvalidAction);
                    }
                    else
                    {
                        bool result = action(userId, parameters[1]);

                        Console.WriteLine(
                            string.Format(Labels.Feedback.ResultAction,
                            parameters[0],
                            parameters[1],
                            userId,
                            Labels.Feedback.ResultToText(result)));
                    }

                    Console.WriteLine(Labels.Feedback.EnterAction);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Labels.Feedback.Error);
            }
            finally
            {
                Console.WriteLine(Labels.Feedback.Exit);

                PoolManager.Logout(userId);
            }
        }

        private static IPoolManager PoolManager = null;

        private static class Labels
        {
            public const string Quit = "quit";

            public static class Feedback
            {
                public const string InvalidParameters = "Invalid Parameters / Credentials";

                public const string EnterAction = "Please enter action (block / release) and article number";

                public const string InvalidAction = "Invalid action specification";

                public const string ResultAction = "{0} of Article {1} by User {2} was {3}";

                public const string Error = "An error had occured";


                public const string Exit = "Client quited";

                public static readonly Func<bool, string> ResultToText = m => m ? "Succesful" : "Unsuccessful";
            }
        }

        private static IDictionary<string, Func<string, string, bool>> ActionsDictionary =
            new Dictionary<string, Func<string, string, bool>>
            {
                { "block", (userId, articleId) => PoolManager.BlockArticle(userId, articleId) },
                { "release", (userId, articleId) => PoolManager.ReleaseArticle(userId, articleId) }
            };
    }
}
