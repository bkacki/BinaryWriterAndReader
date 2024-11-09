namespace BinaryWriterAndReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intValue = 148123;
            string stringValue = "Witaj!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695F;
            char charValue = 'E';

            using(var output = File.Create("danebinarne.dat"))
            using (var writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);
            }

            byte[] dataWritten = File.ReadAllBytes("danebinarne.dat");
            foreach (byte b in dataWritten)
                Console.Write($"{b:x2} ");
            Console.WriteLine($"\nLiczba bajtów: {dataWritten.Length}\n");

            using(var input = File.OpenRead("danebinarne.dat"))
            using(var reader = new BinaryReader(input))
            {
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.WriteLine($"int: {intRead}, string: {stringRead}, byte: {String.Join(" ", byteArrayRead)}, float: {floatRead}, char: {charRead}");
            }
        }
    }
}
