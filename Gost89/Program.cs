using Gost89;

Console.WriteLine("Введите сообщение для шифрования");
var text = Console.ReadLine();
Console.WriteLine("Введите ключ (по умолчанию - AAAAAAAAAAAAAAAA)");
var key = Console.ReadLine();
if (string.IsNullOrEmpty(key) || key.Length != 16)
{
  key = "AAAAAAAAAAAAAAAA";
}

string cypherText;
if (text != null)
{
  Console.WriteLine("Шифрованный текст");
  var gostEncode = new GostEncode(text, key);
  cypherText = gostEncode.Encode();
  Console.WriteLine(cypherText);

  var gostDecoder = new GostDecode(cypherText, key);
  Console.WriteLine("Дешифрованный текст");
  Console.WriteLine(gostDecoder.Decode());
}

Console.ReadLine();