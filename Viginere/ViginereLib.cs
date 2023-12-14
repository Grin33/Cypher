using System.Text;

namespace Viginere;

public class ViginereLib(string? alphabet = null)
{
  private const string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
  private readonly string letters = string.IsNullOrEmpty(alphabet) ? Alphabet : alphabet;

  private string GetKey(string password, int len)
  {
    var p = password;
    while (p.Length < len)
    {
      p += p;
    }

    return p[..len];
  }

  private string Vigenere(string text, string password, bool isEncrypting)
  {
    var key = GetKey(password, text.Length);
    var retValue = new StringBuilder();
    var q = letters.Length;

    for (var i = 0; i < text.Length; i++)
    {
      var letterIndex = letters.IndexOf(text[i]);
      var codeIndex = letters.IndexOf(key[i]);
      retValue.Append(
        letterIndex < 0
          ? text[i].ToString()
          : letters[(q + letterIndex + ((isEncrypting ? 1 : -1) * codeIndex)) % q].ToString());
    }

    return retValue.ToString();
  }

  public string Encrypt(string message, string password)
  {
    return Vigenere(message, password, true);
  }

  public string Decrypt(string message, string password)
  {
    return Vigenere(message, password, false);
  }
}