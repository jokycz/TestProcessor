using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextProcessor.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using TextProcessor.Data;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace TextProcessor.Processor.Tests
{
    [TestClass()]
    public class BaseProcessorTests
    {
        [TestCase("s.r.o.", 3, 6, 0, false)]
        [TestCase("bude-li", 1, 7, 0, false)]
        [TestCase(" Mama.", 1, 6, 1, false)]
        [TestCase("Mama je s.r.o..", 5, 15, 1, false)]
        [TestCase("Jak to teda bude??", 4, 18, 1, false)]
        [TestCase("Napiš na seznam@seznam.cz", 5, 25, 0, false)]
        [TestCase("Rozsah čísel [1 ...].", 3, 21, 1, false)]
        [TestCase("", 0, 0, 0, false)]
        [TestCase("sama", 1, 4, 0, false)]
        [TestCase("! Jedu domu.", 2, 12, 2, true)]
        [TestCase(". Jedu domu.", 2, 12, 2, true)]

        public void AnalyzeLineTest(string line, int wordCount, int charCount, int senseCount, bool lastWord)
        {
            var bs = new BindingSource();
            var data = new FileStatisticData();

            bs.DataSource = data;

            var procesor = new BaseProcessor(bs);
            procesor.AnalyzeLine(line, lastWord);

            Assert.AreEqual(wordCount, data.WordsCount);
            Assert.AreEqual(charCount, data.CharactersCount);
            Assert.AreEqual(senseCount, data.NumberOfSentences);
        }

        [TestMethod()]
        public void ClearCounterTest()
        {
            var bs = new BindingSource();
            var data = new FileStatisticData();
            data.WordsCount = 10;
            data.CharactersCount = 20;
            data.NumberOfSentences = 30;
            data.LinesCount = 40;
            
            bs.DataSource = data;

            var procesor = new BaseProcessor(bs);
            procesor.ClearCounter();
            Assert.AreEqual(0, data.LinesCount);
            Assert.AreEqual(0, data.WordsCount);
            Assert.AreEqual(0, data.CharactersCount);
            Assert.AreEqual(0, data.NumberOfSentences);
        }
    }
}