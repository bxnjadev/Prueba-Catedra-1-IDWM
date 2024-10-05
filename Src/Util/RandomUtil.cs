using System.Text;

namespace P_Cat_1_IDWM.Util;

public class RandomUtil
{

    private static Random _random = new Random();

    public static int RandomNumbers(int length)
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            stringBuilder.Append(_random.Next(0, 9));
        }

        return Int32.Parse(stringBuilder.ToString());
    }
    
}