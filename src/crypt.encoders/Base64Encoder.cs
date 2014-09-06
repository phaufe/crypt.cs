/**
 * Implementation of the `Crypt.Encoders.Base64Encoder` class.
 * @module encoders.Base64Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the Base64 encoding method.
   * @class Crypt.Encoders.Base64Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Base64Encoder: IStringEncoder {
  
    public Base64Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Base64Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "Base64"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var bytes=Encoding.Default.GetBytes(text);
      return Convert.ToBase64String(bytes);
    }
  }
}