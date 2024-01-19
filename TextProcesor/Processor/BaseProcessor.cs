using System.IO;
using System.Text;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class BaseProcessor
{
    internal FileStatisticData Data => (BsData.DataSource as FileStatisticData)!;

    private readonly List<string> listShortcut;
    internal CancellationToken token = CancellationToken.None;
    private int _position;

#pragma warning disable S3604
#pragma warning disable Roslyn.S3604
    internal readonly BindingSource BsData;
    public BaseProcessor(BindingSource bsData)
    {
        BsData = bsData;
        ClearCounter();
        //load file to list<string>  from directory application
        var filePath = "Dictionary/DictionaryShortcut.txt";
        listShortcut = File.ReadAllLines(filePath).ToList();
    }
#pragma warning restore Roslyn.S3604
#pragma warning restore S3604

    internal void UpdatePosition(Action<FileStatisticData> updateUi)
    {
        if (_position != Data.Position)
        {
            _position = Data.Position;
            updateUi.Invoke(Data);
        }
    }
    
    public void ClearCounter()
    {
        Data.CharactersCount = 0;
        Data.LinesCount = 0;
        Data.NumberOfSentences = 0;
        Data.WordsCount = 0;
        Data.Position = 0;
    }

    internal void TestCancelToken()
    {
        if (token.IsCancellationRequested)
        {
            Data.Abort = true;
            ClearCounter();
            throw new OperationCanceledException(token);
        }
    }


    public virtual bool AnalyzeLine(string line, bool lastWord)
    {
        if (string.IsNullOrEmpty(line)) return lastWord;

        Data.CharactersCount += line.Length;
        
        //Získání seznamu indexů nealfanumerických znaků
        var NonAlfaNumerics = FindNonAlphaNumeric(line);
        
        //Procházíme seznam nealfanumerických znaků
        for (var i = 0; i < NonAlfaNumerics.Count; i++)
        {
            var item = NonAlfaNumerics[i];
            var prevItem = i > 0 ? NonAlfaNumerics[i - 1] : null;

            //Pokud jsou nealfanumerické znaky za sebou není to slovo ani věta
            if ((item.Index - (prevItem?.Index ?? item.Index)) == 1 && !(prevItem?.Shortcut ?? false) && !item.Sense)
                continue;

            switch (item.Sign)
            {
                case '?':
                case '!':
                    //Pokud je znak na začátku řádky a je to a na konci poslední řádky bylo slovo je to věta
                    if (item.Index == 0 && lastWord)
                    {
                        Data.NumberOfSentences++;
                        continue;
                    }
                    
                    Data.WordsCount++; 
                    Data.NumberOfSentences++;
                    break;
                case '.':
                    //Pokud je znak na začátku řádky a je to a na konci poslední řádky bylo slovo je to věta
                    if (item.Index == 0 && lastWord)
                    {
                        Data.NumberOfSentences++;
                        continue;
                    }

                    if (item.Shortcut)
                    {
                        Data.WordsCount++;
                        continue;
                    }

                    Data.WordsCount += string.IsNullOrEmpty(item.Word) ? 0 : 1;
                    Data.NumberOfSentences += (item.Sense) ? 1 : 0;
                    
                    break;
                default:
                    Data.WordsCount += (string.IsNullOrEmpty(item.Word)) ? 0 : 1;
                    break;
            }
        }
        //zjištění jestli na konci řádky slovo pak vracím příznak
        var lastItem = NonAlfaNumerics.Last();

        return lastItem.Index != line.Length - 1;
    }

    internal List<IndexNonAlfaNumeric> FindNonAlphaNumeric(string str)
    {
        var index = 0;
        var result = new List<IndexNonAlfaNumeric>();
        
        var word = new StringBuilder(); 
        var shortcut = false;
        var sense = false;
        
        while (index < str.Length)
        {
            var c = str[index];
            // Check if the character is not a letter or a digit
            if (!char.IsLetter(c) && !char.IsDigit(c))
            {
                if (c == '-' && str.Length > index + 2)
                {
                    //Test li
                    var tmpChar = str.ElementAtOrDefault(index + 3);
                    var tmpWord = str.Substring(index + 1, 2);
                    if (tmpWord.Equals("li", StringComparison.CurrentCultureIgnoreCase) && (!char.IsLetter(tmpChar) && !char.IsDigit(tmpChar)))
                    {
                        word.Append('-');
                        word.Append(tmpWord);
                        c = tmpChar;
                        index += 3;
                    }
                }

                if (c == '.' && listShortcut.Contains(word.ToString() + c))
                {
                    word.Append(c);
                    shortcut = true;
                }

                if (c == '.' && (str.ElementAtOrDefault(index + 1) == ' ' || str.ElementAtOrDefault(index + 1) == '\0'))
                {
                    sense = true;
                }

                result.Add(new IndexNonAlfaNumeric(c, index, word.ToString(), shortcut, sense));
                sense = false;
                shortcut= false;
                word.Clear();
            }
            else
            {
                word.Append(c);
            }

            index++;
        }
        
        if (word.Length > 0)
        {
            result.Add(new IndexNonAlfaNumeric('\0', index, word.ToString(), false, false));
        }
        
        return result;
    }

}