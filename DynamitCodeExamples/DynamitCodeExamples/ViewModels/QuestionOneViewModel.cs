using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DynamitCodeExamples.ViewModels
{
    public class QuestionOneViewModel
    {
        // Constructor
        public QuestionOneViewModel()
        {
            OriginalParagraph = Properties.Resources.Paragraph;
            GetWordCounts();
        }

        // Properties
        public string OriginalParagraph { get; set; }
        public List<WordCount> WordCounts { get; set; }

        // Private Helper Method(s)
        private void GetWordCounts()
        {
            // Special characters in the paragraph
            string[] specialCharacters = new string[] { "\"", ".", ",", "?", "-", "—", Environment.NewLine };

            /* Note: If this were reading from a user selected text file the code could read the file line by line
             * and ignore empty lines. For this example I put the Paragraph.txt file in the project as a Resource
             * for the convenience of being able to run the application without having to specify the file path. */

            string paragraph = OriginalParagraph;

            // Strip out special characters that aren't part of a word
            foreach (string character in specialCharacters)
                paragraph = paragraph.Replace(character, " ");

            // Split the paragraph into individual words, removing blank space, and make the words uppercase for uniformity
            char[] splitChar = new char[] { ' ' };
            IEnumerable<string> words = paragraph
                .Split(splitChar, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Trim().ToUpperInvariant());

            // Do numbers and times count as words? 
            // I didn't specifically exclude these, but it would be easy enough to add checks using regular expressions for numbers
            // and exclude them. The same goes for times.

            // Get the word counts by grouping by each word and getting the count of the occurrences
            WordCounts = words
                .GroupBy(b => b)
                .Select(c => new WordCount { Word = c.Key, Count = c.Count() })
                .OrderByDescending(d => d.Count).ThenBy(d => d.Word).ToList();
        }
    }

    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
