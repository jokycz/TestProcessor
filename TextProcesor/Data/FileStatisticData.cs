namespace TextProcessor.Data;

public class FileStatisticData
{
    public int LinesCount { get; set; }
    public int WordsCount { get; set; }
    public int CharactersCount { get; set; }

    public int NumberOfSentences { get; set; }

    public string InputFile { get; set; } = string.Empty;

    public string OutputFile { get; set; } = string.Empty;

    public int Position { get; set;} = 75;
    
    public bool Abort { get; set; }
    
    public string WordCountStr => $"Počet slov: {WordsCount}";

    public string LinesCountStr => $"Počet řádků: {LinesCount}";
    
    public string CharactersCountStr => $"Počet znaků: {CharactersCount}";

    public string NumberOfSentencesStr => $"Počet vět: {NumberOfSentences}";

    public OperationProcessor Operation { get; set; } = OperationProcessor.None;

}