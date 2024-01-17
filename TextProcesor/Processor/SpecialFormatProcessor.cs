using System.IO;
using System.Text;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class SpecialFormatProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi)
    {
        using var reader = new StreamReader(Data.InputFile);
        using var writer = new StreamWriter(Data.OutputFile);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        BsData.ResetBindings(false);

        var line = reader.ReadLine();
        var position = 0;
        while (line != null)
        {
            position += line.Length + 2;
            Data.Position = (int)(position * 100 / fileSize);
            
            line = SpecialFormat(line);

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

        reader.Close();
        writer.Close();
    }

    public string SpecialFormat(string line)
    {
        if (string.IsNullOrEmpty(line)) return line;

        var NonAlfaNumerics = FindNonAlphaNumeric(line);
        
        var outString = new StringBuilder();

        //Procházíme seznam nealfanumerických znaků
        foreach (var item in NonAlfaNumerics.Where(c  => !string.IsNullOrEmpty(c.Word)))
        {
            var tmpWord = ToCamelCase(item.Word);
            outString.Append(tmpWord);
            Data.CharactersCount += tmpWord.Length;
            Data.WordsCount++;
        }
        return outString.ToString();
    }

    public static string ToCamelCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > 1)
        {
            return char.ToUpperInvariant(str[0]) + str.Substring(1).ToLowerInvariant();
        }
        return str.ToUpperInvariant();
    }


}