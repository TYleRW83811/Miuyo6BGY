// 代码生成时间: 2025-09-13 23:01:44
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MAUIApp
{
    /// <summary>
    /// Text file analyzer that processes text files and extracts useful information.
    /// </summary>
    public class TextFileAnalyzer
    {
        /// <summary>
        /// Analyzes the content of a text file.
        /// </summary>
        /// <param name="filePath">The path to the text file to analyze.</param>
        /// <returns>A TextFileAnalysisResult containing the file's content analysis.</returns>
        public TextFileAnalysisResult AnalyzeFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file was not found.", filePath);
            }

            string fileContent;
            try
            {
                fileContent = File.ReadAllText(filePath);
            }
            catch (IOException ex)
            {
                throw new IOException("An error occurred while reading the file.", ex);
            }

            return AnalyzeContent(fileContent);
        }

        /// <summary>
        /// Analyzes the content of a text file.
        /// </summary>
        /// <param name="content">The content of the text file to analyze.</param>
        /// <returns>A TextFileAnalysisResult containing the file's content analysis.</returns>
        private TextFileAnalysisResult AnalyzeContent(string content)
        {
            var result = new TextFileAnalysisResult
            {
                Lines = content.Split(new[] { "
" }, StringSplitOptions.None).Length,
                Words = CountWords(content),
                UniqueWords = CountUniqueWords(content),
                Sentences = CountSentences(content)
            };

            return result;
        }

        /// <summary>
        /// Counts the number of words in the text content.
        /// </summary>
        /// <param name="content">The text content to analyze.</param>
        /// <returns>The number of words.</returns>
        private int CountWords(string content)
        {
            return Regex.Matches(content, @"\b\w+\b").Count;
        }

        /// <summary>
        /// Counts the number of unique words in the text content.
        /// </summary>
        /// <param name="content">The text content to analyze.</param>
        /// <returns>The number of unique words.</returns>
        private int CountUniqueWords(string content)
        {
            var uniqueWords = new HashSet<string>(content.Split(new char[] { ' ', '.', '?', '!', ','}, StringSplitOptions.RemoveEmptyEntries), StringComparer.OrdinalIgnoreCase);
            return uniqueWords.Count;
        }

        /// <summary>
        /// Counts the number of sentences in the text content.
        /// </summary>
        /// <param name="content">The text content to analyze.</param>
        /// <returns>The number of sentences.</returns>
        private int CountSentences(string content)
        {
            return Regex.Matches(content, @"[.?!]\s").Count + 1;
        }

        /// <summary>
        /// Represents the result of a text file analysis.
        /// </summary>
        public class TextFileAnalysisResult
        {
            public int Lines { get; set; }
            public int Words { get; set; }
            public int UniqueWords { get; set; }
            public int Sentences { get; set; }
        }
    }
}
