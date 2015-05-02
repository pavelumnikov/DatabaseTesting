using System;
using System.Text;

namespace DatabaseTesting.Forms
{
    public class ExceptionForMessageBox
    {
        private readonly Exception _exception;
        private readonly bool _inner;

        public ExceptionForMessageBox(Exception e, bool inner)
        {
            if(e == null)
                throw new ArgumentNullException("e");

            _exception = e;
            _inner = inner;

            BuildDisplayString();
            BuildValueString();
        }

        public string Display { get; private set; }

        public string Value { get; private set; }

        private void BuildDisplayString()
        {
            var displayStrBuilder = new StringBuilder(120);
            displayStrBuilder.AppendFormat("[{0}]", _exception.GetType().Name);
            if (_inner)
                displayStrBuilder.Append("(Inner)");

            Display = displayStrBuilder.ToString();
        }

        private void BuildValueString()
        {
            var strBuilder = new StringBuilder(500);
            strBuilder.AppendFormat("Source: [{0}]\r\n\r\n", _exception.Source);
            strBuilder.AppendFormat("Message: {0}\r\n\r\n", _exception.Message);
            strBuilder.AppendFormat("Stack trace: [{0}]", _exception.StackTrace);

            Value = strBuilder.ToString();
        }
    }
}
