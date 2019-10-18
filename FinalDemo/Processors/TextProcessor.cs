namespace FinalDemo.Processors
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class TextProcessor
    {
        private StreamReader reader;
        private StreamWriter writer;
        private readonly ILogger _logger;

        public TextProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public string ReadText(string filename)
        {
            try
            {
                using (this.reader = new StreamReader(filename, Encoding.UTF8))
                {
                    return this.reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
            }

            return null;
        }

        public void WriteText(string filename, string text)
        {
            try
            {
                using (this.writer = new StreamWriter(filename, true))
                {
                     this.writer.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
            }
        }
    }
}
