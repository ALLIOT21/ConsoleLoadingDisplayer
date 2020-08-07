namespace BestLoadingDisplayerEver
{
    internal class MessageBuilder
    {
        private readonly CircularSequenceGenerator<string> _sequenceGenerator = new CircularSequenceGenerator<string>(new[] { @"\", "|", "/", "-" });

        public string CreateMessage()
        {            
            string symbol = _sequenceGenerator.Next();
            
            return $"\r{symbol}";
        }
    }
}
