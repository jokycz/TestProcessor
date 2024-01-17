using System.Globalization;
using System.IO;
using System.Text;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class AnalyzeProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi)
    {
        using var reader = new StreamReader(Data.InputFile);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        BsData.ResetBindings(false);

        var line = reader.ReadLine();
        var lastWord = false;
        while (line != null)
        {
            if (Data.LinesCount > 0)
                Data.CharactersCount += 2;
            
            line = reader.ReadLine();

            if (line == null) continue;

            line = RemoveDiacritics(line);

            lastWord = base.AnalyzeLine(line, lastWord);
            
            Data.LinesCount++;
            
            Data.Position = (int)(reader.BaseStream.Position * 100 / fileSize);
            
            if (Data.Abort)
            {
                break;
            }
            
            BsData.ResetBindings(false);

            updateUi.Invoke(Data);
        }

        reader.Close();
    }

    private static string RemoveDiacritics(string input)
    {
        var normalizedString = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in from c in normalizedString let category = CharUnicodeInfo.GetUnicodeCategory(c) where category != UnicodeCategory.NonSpacingMark select c)
        {
            stringBuilder.Append(c);
        }

        return stringBuilder.ToString();
    }

}