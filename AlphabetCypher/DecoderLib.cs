using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetCypher
{
  /// <summary>
  /// Класс Декодера строки
  /// </summary>
  public static class DecoderLib
  {
    /// <summary>
    /// Топ наиболее часто используемых букв в латиннице.
    /// </summary>
    private static readonly List<char> GlobalFrequencyList = new List<char>()
    {
      'e','t','a','o','i','n','s','h','r','d','l','c','u',
      'm','w','f','g','y','p','b','v','k','j','x','q','z'
    };

    /// <summary>
    /// Основной метод, который декодирует строку с помощью частотного анализа
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns>Результирующая строка</returns>
    public static string DecodeString(string inputString)
    {
      var inputStringFreqList = GetFrequencyList(inputString);
      var generetedReversedDict = GetEncryptDict(inputStringFreqList);
      //На лекции говорилось что алгоритм шифрования известен всегда
      return CypherLib.Transform(inputString, generetedReversedDict);
    }

    /// <summary>
    /// Получение таблицы замен на основе GlobalFrequencyList и списка часто используемых букв входной строки
    /// </summary>
    /// <param name="inputList"></param>
    /// <returns>Таблица замен</returns>
    private static Dictionary<char,char> GetEncryptDict(List<char> inputList)
    {
      var decodeDict = new Dictionary<char,char>();
      for(int i = 0; i < inputList.Count; i++)
        decodeDict.Add(inputList[i], GlobalFrequencyList[i]);
      return decodeDict;
    }

    /// <summary>
    /// Получение упорядоченного списка наиболее часто используемых букв 
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    private static List<char> GetFrequencyList(string inputString)
    {
      var Letters = new List<char>();
      var Let = new Dictionary<char, int>();
      foreach(var ch in inputString)
      {
        if (ch == ' ')
          continue;

        var fromDict = Let.Where(k => k.Key == ch).FirstOrDefault();
        //если такой буквы еще нет в списке
        if(fromDict.Key == '\0')
        {
          Let.Add(ch, 1);
        }
        else
        {
          var oldCount = fromDict.Value + 1;
          Let.Remove(ch);
          Let.Add(ch, oldCount);
        }

      }
      var quer = from elem in Let
                orderby elem.Value descending
                select elem.Key;
      Letters = quer.ToList();
      return Letters;
    }
  }
}
