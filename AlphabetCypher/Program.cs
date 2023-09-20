using AlphabetCypher;

class Program
{
  static void Main()
  {
    Console.WriteLine("Input string to cypher");
    Console.WriteLine("Только анлгийский язык");
    string inputString;
    inputString = Console.ReadLine();
    var HashString = CypherLib.Transform(inputString);
    //HASH
    Console.WriteLine(HashString);

    //Decoded:
    Console.WriteLine("Decoded:");
    Console.WriteLine(DecoderLib.DecodeString(HashString));
  }
}