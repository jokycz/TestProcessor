using TextProcessor.Data;

namespace TextProcessor.Processor;

public interface IProcessor
{
    void Process(Action<FileStatisticData> updateUi, CancellationToken token);
}