using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// public static class Group
// {
//     private static void GroupKeywords1()
//     {
//         IEnumerable<IGrouping<bool,string>> keywordGroups =
//         from word in CSharp.Keywords
//         group word by word.Contains('*');
//         IEnumerable<bool IsContextualKeyword,
//         IGrouping<bool, string> items)> selection = 
//         from groups in keywordGroups
//         select
//         (
//             IsContextualKeyword: groups.Key,
//             Items: groups
//         );

//         foreach (isContextualKeyword, IGrouping<bool, string>items in selection)
//         {
//             Console.WriteLine(Environment.NewLine + "{0}:",
//             isContextualKeyword ? "Contextual Keywords" : "Keywords");
//             foreach (string keyword in items)
//             {
//                 Console.Write(" " + keyword.Replace("*",null));
//             }
//         }
//     }
// }


    public class CSharp    {
        static public readonly string[] Keywords = new string[]{
        "abstract", "add*", "alias*", "as", "ascending*",
        "async*", "await*", "base", "bool", "break", "do",
        "double", "dynamic*", "else", "enum", "event",
        "equals*", "explicit", "extern", "false", "join*",
        "let*", "nameof*", "namespace", "new", "nonnull*",
        "null", "object", "on*", "operator", "orderby*",
        "out", "override", "params", "partial*", "private",
        "protected", "public", "readonly", "ref", "remove*",
        "return", "var*", "virtual", "unchecked", "void",
        "volatile", "where*", "while", "yield*"};
        
        public static string[] SentenceQuery =
        {
            "on an up",
            "at or so",
            "by if to",
            "of no it"
        };
        public static string ReverseString(string srtVarable)
        {
            return new string(srtVarable.Reverse().ToArray());
        }
        public static void ShowContextualKeySentence()
        {
            IEnumerable<string> selection =
            from word in SentenceQuery
            where word.Contains('o')
            select word;

            foreach (string keyWord in selection)
            {
                Console.Write($"\"{keyWord}\" ");
            }
            Console.WriteLine();
        }
        static void Main()
        {

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var BeginInVowelWordQuery =
                from sentence in SentenceQuery
                let words = sentence.Split(' ')
                from word in words
                let w = word.ToLower()
                where w[0] == 'a' || w[0] == 'e'
                    || w[0] == 'i' || w[0] == 'o'
                    || w[0] == 'u'
                select word;

            var EndInVowelWordQuery =
                from sentence in SentenceQuery
                let words = sentence.Split(' ')
                from word in words
                let w = ReverseString(word)
                where w[0] == 'a' || w[0] == 'e'
                    || w[0] == 'i' || w[0] == 'o'
                    || w[0] == 'u'
                select word;

            // Execute the query.
            foreach (var v in BeginInVowelWordQuery)
            {
                Console.WriteLine("\"{0}\" starts with a vowel", v);
            }
            foreach (var v in EndInVowelWordQuery)
            {
                Console.WriteLine("\"{0}\" ends with a vowel", v);
            }
            ShowContextualKeySentence();
            // GroupKeywords1();
            // Keep the console window open in debug mode.

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
// }