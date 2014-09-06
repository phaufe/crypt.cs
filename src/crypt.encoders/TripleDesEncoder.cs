/**
 * Implementation of the `Crypt.Encoders.TripleDesEncoder` class.
 * @module encoders.TripleDesEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Security.Cryptography;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the TripleDES encoding method.
   * @class Crypt.Encoders.TripleDesEncoder
   * @constructor
   * @uses Crypt.IStringEncoder
   */
  public class TripleDesEncoder: IStringEncoder {
  
    public TripleDesEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.TripleDesDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "TripleDES"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var bytes=Encoding.Default.GetBytes(text);
      return Convert.ToBase64String(TripleDES.Create().CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
    }
  }
}