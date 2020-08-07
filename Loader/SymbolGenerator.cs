namespace BestLoadingDisplayerEver
{
    internal class SymbolGenerator
    {
        private int _messageCounter = 0;
        private char[] _SYMBOLS = new char[] { '\\', '|', '/', '-' };

        public char Generate()
        {
            int symbolIndex = _messageCounter % _SYMBOLS.Length;
            _messageCounter++;
            return _SYMBOLS[symbolIndex];
        }
    }
}
