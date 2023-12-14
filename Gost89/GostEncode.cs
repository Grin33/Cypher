using System.Text;

namespace Gost89;

public class GostEncode
{
  public string Msg { get; set; }
  public string Key { get; set; }

  public GostEncode(string message, string key)
  {
    this.Msg = message;
    this.Key = key;
  }

  public string Encode()
  {
    return Encoding.Unicode.GetString(
      Encode(
        Encoding.Unicode.GetBytes(this.Msg),
        Encoding.Unicode.GetBytes(this.Key))
    );
  }

  private byte[] Encode(byte[] data, byte[] key)
  {
    var subkeys = GostLib.GenerateKeys(key);
    var result = new byte[data.Length];
    var block = new byte[8];


    for (var i = 0; i < data.Length / 8; i++)
    {
      Array.Copy(data, 8 * i, block, 0, 8);
      Array.Copy(EncodeBlock(block, subkeys), 0, result, 8 * i, 8);
    }

    return result;
  }

  private byte[] EncodeBlock(byte[] block, uint[] keys)
  {
    // separate on 2 blocks.
    var N1 = BitConverter.ToUInt32(block, 0);
    var N2 = BitConverter.ToUInt32(block, 4);

    for (int i = 0; i < 32; i++)
    {
      var keyIndex = i < 24 ? (i % 8) : (7 - i % 8);
      var s = (N1 + keys[keyIndex]) % uint.MaxValue;
      s = GostLib.Substitution(s);
      s = (s << 11) | (s >> 21);
      s = s ^ N2;
      if (i < 31)
      {
        N2 = N1;
        N1 = s;
      }
      else
      {
        N2 = s;
      }
    }

    var output = new byte[8];
    var N1buff = BitConverter.GetBytes(N1);
    var N2buff = BitConverter.GetBytes(N2);

    for (var i = 0; i < 4; i++)
    {
      output[i] = N1buff[i];
      output[4 + i] = N2buff[i];
    }

    return output;
  }
}