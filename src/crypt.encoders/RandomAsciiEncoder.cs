/**
 * Implementation of the `Crypt.Encoders.RandomAsciiEncoder` class.
 * @module encoders/RandomAsciiEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the RandomASCII encoding method.
   * @class Crypt.Encoders.RandomAsciiEncoder
   * @extends Crypt.IStringEncoder
   */
  public class RandomAsciiEncoder: IStringEncoder {
    
    public RandomAsciiEncoder() {}
  
    /**
     * Instance used to generate a random number sequence.
     * @property random
     * @private
     */
    private Random random=new Random();

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.RandomAsciiDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "RandomASCII"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      if(string.IsNullOrEmpty(text)) return text;

      var builder=new StringBuilder(text.Length);
      foreach(var item in text) {
        if(this.random.Next(3)==0) builder.Append(item);
        else builder.Append(string.Format(CultureInfo.InvariantCulture, "&#{0};", (int) item));
      }

      return builder.ToString();
    }
  }
}