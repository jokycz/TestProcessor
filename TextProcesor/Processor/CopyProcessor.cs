﻿using System.IO;
using TextProcessor.Data;

namespace TextProcessor.Processor;

public class CopyProcessor(BindingSource bsData) : BaseProcessor(bsData), IProcessor
{
    public void Process(Action<FileStatisticData> updateUi, CancellationToken token)
    {
        base.token = token;
        using var reader = new StreamReader(Data.InputFile, detectEncodingFromByteOrderMarks: true);
        using var writer = new StreamWriter(Data.OutputFile, false, reader.CurrentEncoding);
        
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

            lastWord = base.AnalyzeLine(line, lastWord);
            
            Data.LinesCount++;

            TestCancelToken();

            BsData.ResetBindings(false);
            writer.WriteLine(line);

            UpdatePosition(updateUi);
            line = reader.ReadLine();
        }

        Data.Position = 100;
        reader.Close();
        writer.Close();
    }
}