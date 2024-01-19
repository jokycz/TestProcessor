using System.IO;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class AnalyzeProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi, CancellationToken token)
    {
        ClearCounter();
        base.token = token;
        using var reader = new StreamReader(Data.InputFile);
        
        var fileInfo = new FileInfo(Data.InputFile);
        var fileSize = fileInfo.Length;
        
        var line = reader.ReadLine();
        var lastWord = false;
        var position = 0;
        var OldPosition = 0;
        while (line != null)
        {
            position += line.Length + 2;
            Data.Position = (int)(position * 100 / fileSize);

            lastWord = base.AnalyzeLine(line, lastWord);
            Data.LinesCount++;
            
            TestCancelToken();

            BsData.ResetBindings(false);

            UpdatePosition(updateUi);

            line = reader.ReadLine();
        }

        reader.Close();
    }
}