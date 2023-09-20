using System.Text;

namespace AlphabetCypher
{
  public static class CypherLib
  {
    /// <summary>
    /// Таблица замен
    /// </summary>
    private static readonly Dictionary<char, char> EncryptTable = new Dictionary<char, char>()
    {
      //atmhxwfzjgeprulokvscnyidbq
      { 'a' , 'a' }, { 'b', 't' }, { 'c', 'm' }, { 'd', 'h' } , { 'e', 'x' },
      { 'f' , 'w' }, { 'g', 'f' }, { 'h', 'z' }, { 'i', 'j' } , { 'j', 'g' },
      { 'k' , 'e' }, { 'l', 'p' }, { 'm', 'r' }, { 'n', 'u' } , { 'o', 'l' },
      { 'p' , 'o' }, { 'q', 'k' }, { 'r', 'v' }, { 's', 's' } , { 't', 'c' },
      { 'u' , 'n' }, { 'v', 'y' }, { 'w', 'i' }, { 'x', 'd' } , { 'y', 'b' }, { 'z', 'q' }
    };

    /// <summary>
    /// Метод для получения зашифрованной строки
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="EncryptTable"></param>
    /// <returns>Зашифрованная строка</returns>
    public static string Transform(string inputString, Dictionary<char,char> EncryptTable)
    {
      var sb = new StringBuilder();
      if (inputString == string.Empty)
        return inputString;
      foreach (var symb in inputString)
      {
        if (EncryptTable.ContainsKey(symb))
        {
          sb.Append(EncryptTable[symb]);
          continue;
        }
        sb.Append(symb);
      }
      return sb.ToString();
    }

    /// <summary>
    /// Метод для получения зашифрованной строки
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns>Зашифрованная строка</returns>
    public static string Transform(string inputString)
    {
      var sb = new StringBuilder();
      if (inputString == string.Empty)
        return inputString;
      foreach (var symb in inputString)
      {
        if (EncryptTable.ContainsKey(symb))
        {
          sb.Append(EncryptTable[symb]);
          continue;
        }
        sb.Append(symb);
      }
      return sb.ToString();
    }
  }
}
