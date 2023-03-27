namespace Presentation.ViewModel.Converter.TextToTime
{
    public class SimpleTextToNumberConverter : ITextToNumberConverter
    {
        public int Convert(string text) =>
            int.TryParse(text, out int number) ? number : 0;
    }
}