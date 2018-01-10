namespace FinalDemo.Processors
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class TextProcessor
    {
        private StreamReader reader;
        private StreamWriter writer;


        public string ReadText(string filename)
        {
            Logger.InitLogger();
            try
            {
                using (this.reader = new StreamReader(filename, Encoding.UTF8))
                {
                    return this.reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Unhandled exception", ex);
            }

            return null;
        }

        public void WriteText(string filename, string text)
        {
            Logger.InitLogger();
            try
            {
                using (this.writer = new StreamWriter(filename, true))
                {
                     this.writer.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Unhandled exception", ex);
            }
        }
    }
}
