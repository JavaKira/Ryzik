using System.IO;

namespace IO
{
    public class Reads
    {
        private readonly BinaryReader _input;

        public Reads(BinaryReader input)
        {
            _input = input;
        }

        public float Float()
        {
            return _input.ReadSingle();
        }

        public int Int()
        {
            return _input.ReadInt32();
        }

        public string String()
        {
            return _input.ReadString();
        }

        public bool Boolean()
        {
            return _input.ReadBoolean();
        }
    }
}