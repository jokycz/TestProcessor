using System.IO;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class RemoveEmptyLineProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi, CancellationToken token)
    {
        base.token = token;
        using var reader = new StreamReader(Data.InputFile);
        using var writer = new StreamWriter(Data.OutputFile);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        BsData.ResetBindings(false);

        var line = reader.ReadLine();
        var lastWord = false;
        var position = 0;
        var OldPosition = 0;
        while (line != null)
        {
            position += line.Length + 2;
            Data.Position = (int)(position * 100 / fileSize);

            if (string.IsNullOrWhiteSpace(line))
            {
                line = reader.ReadLine();
                continue;
            }

            lastWord = base.AnalyzeLine(line, lastWord);
            
            Data.LinesCount++;
            
            TestCancelToken();
            
            BsData.ResetBindings(false);
            writer.WriteLine(line);
            UpdatePosition(updateUi);


            line = reader.ReadLine();
        }

        reader.Close();
        writer.Close();
    }
}