using System.Globalization;
using System.IO;
using System.Text;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class RemoveDiacriticsProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi)
    {
        using var reader = new StreamReader(Data.InputFile);
        using var writer = new StreamWriter(Data.OutputFile);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        BsData.ResetBindings(false);

        var line = reader.ReadLine();
        var lastWord = false;
        var position = 0;

        while (line != null)
        {
            line = RemoveDiacritics(line);

            position += line.Length + 2;
            Data.Position = (int)(position * 100 / fileSize);

            lastWord = base.AnalyzeLine(line, lastWord);
            
            Data.LinesCount++;
            
            if (Data.Abort)
            {
                break;
            }
            
            BsData.ResetBindings(false);
            writer.WriteLine(line);

            updateUi.Invoke(Data);
            line = reader.ReadLine();
        }

        Data.Position = 100;

        reader.Close();
        writer.Close();
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