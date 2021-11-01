﻿using System.IO;

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
    }
}