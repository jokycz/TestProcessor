using System.IO;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class CopyProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi)
    {
        using var reader = new StreamReader(Data.InputFile, detectEncodingFromByteOrderMarks: true);
        using var writer = new StreamWriter(Data.OutputFile, false, reader.CurrentEncoding);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        BsData.ResetBindings(false);

        var line = reader.ReadLine();
        var lastWord = false;
        var position = 0;
        while (line != null)
        {
            position += line.Length + 2;
            Data.Position = (int)(position * 100 / fileSize);

            lastWord = base.AnalyzeLine(line, lastWord);
            
            Data.LinesCount++;
            
            if (Data.Abort)
            {
                ClearCounter();
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
}