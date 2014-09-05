/**
 * Implementation of the `Crypt.Encoders.DesEncoder` class.
 * @module encoders/DesEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Security.Cryptography;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the DES encoding method.
   * @class Crypt.Encoders.DesEncoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class DesEncoder: IStringEncoder {
  
    public DesEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.DesDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "DES"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var bytes=Encoding.Default.GetBytes(text);
      return Convert.ToBase64String(DES.Create().CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
    }
  }
}