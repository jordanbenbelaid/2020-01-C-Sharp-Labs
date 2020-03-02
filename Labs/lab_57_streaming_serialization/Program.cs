using System;
using System.IO;
using System.Text;

namespace lab_57_streaming_serialization
{
    //THIS LAB IS STREAMING ONLY
    //THIS LAB IS STREAMING ONLY
    //THIS LAB IS STREAMING ONLY
    //THIS LAB IS STREAMING ONLY
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("data.txt");

            //create a file (APPEND, UTF8, BUFFER SIZE)
            using (var writer = new StreamWriter("data.txt", true, Encoding.UTF8, 1024))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine($"New log item{i} at {DateTime.Now}");
                }
            }

            //also could use FOR STRING OR ARRAY OF STRINGS
            string OneExtraLine = "some more text";
            using(var writer = File.AppendText("data.txt"))
            {
                writer.WriteLine(OneExtraLine);
            }

            //read file
            string output = null;
            using (var reader = new StreamReader("data.txt"))
            {
                //3 ways to read data
                //while
                while ((output = reader.ReadLine()) != null)
                {
                    Console.WriteLine(output);
                }
            }
            Console.WriteLine("\n\nStart getting async data\n\n");
            ReadDataAsync();

            //Console.WriteLine("\nBinary buffer stream\n");
            ReadAndWriteDataToMemory();             //simulate encryption module

            Console.WriteLine("\nProgram has terminated\n");
            Console.ReadLine();
        }

        
        static async void ReadDataAsync()
        {
            string output2 = null;
            using (var asyncReader = new StreamReader("data.txt"))
            {
                while ((output2 = await asyncReader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(output2);
                }
            }
        }

        static void ReadAndWriteDataToMemory()
        {
            //wrapper around memory stream, used in security
            //destination assumed in RAM : system handle destination
            using(var memoryStream = new MemoryStream())
            {
                //memory only operated with BYTE STREAM of RAW BINARY 1/0
                //does not use character stream

                //byte array (empty at the moment)
                var buffer = new byte[5];
                //fill with binary data
                buffer[0] = (int)'h';
                buffer[1] = (int)'e';
                buffer[2] = (int)'l';
                buffer[3] = (int)'l';
                buffer[4] = (int)'o';

                //send fake data 10 times
                for (int i = 0; i<10; i++)
                {
                    memoryStream.Write(buffer);
                }

                memoryStream.Flush();

                //read back data with memory reader
                //but first reset pointer of stream to start
                memoryStream.Position = 0;
                using(var reader = new StreamReader(memoryStream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
