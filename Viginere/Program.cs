using Viginere;

var cypher = new ViginereLib();
Console.WriteLine("Введите текст для шифрования");
string? inputText = null;
while (string.IsNullOrEmpty(inputText))
{
  inputText = Console.ReadLine()?.ToLower();
}

Console.WriteLine("Введите ключ шифрования");
string? password = null;
while (string.IsNullOrEmpty(password))
{
  password = Console.ReadLine()?.ToLower();
}

Console.WriteLine("Зашифрованный текст");
var cypherText = cypher.Encrypt(inputText, password);
Console.WriteLine(cypherText);
Console.WriteLine("Дешифрованный текст");
Console.WriteLine(cypher.Decrypt(cypherText, password));
Console.ReadLine();