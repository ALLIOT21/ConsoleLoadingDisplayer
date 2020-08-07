using System;

namespace BestLoadingDisplayerEver
{
    internal class MessageBuilder
    {        
        private string _message;
        private SymbolGenerator symbolGenerator = new SymbolGenerator();

        public MessageBuilder(string message)
        {
            _message = message;
        }

        public string CreateMessage()
        {            
            char symbol = symbolGenerator.Generate();
            
            return String.Format("\r{0} {1}", _message, symbol);
        }
    }
}
