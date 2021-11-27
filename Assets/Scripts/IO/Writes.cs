using System.IO;

namespace IO
{
    public class Writes
    {
        private readonly BinaryWriter _output;

        public Writes(BinaryWriter output)
        {
            _output = output;
        }

        public void Int(int i)
        {
            _output.Write(i);
        }

        public void Float(float f)
        {
            _output.Write(f);
        }

        public void String(string s)
        {
            _output.Write(s);
        }
    }
}