namespace TextProcessor.Data;
#pragma warning disable S3604
#pragma warning disable Roslyn.S3604


public class IndexNonAlfaNumeric(char sign, int index, string word, bool shortcut, bool sense)
{
    public char Sign { get; set; } = sign;
    public int Index { get; set; } = index;
    
    public string Word { get; set; } = word;

    public bool Shortcut { get; set; } = shortcut;
    
    public bool Sense { get; set; } = sense;
}
#pragma warning restore Roslyn.S3604
#pragma warning restore S3604

