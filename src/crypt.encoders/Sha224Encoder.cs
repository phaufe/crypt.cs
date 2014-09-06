/**
 * Implementation of the `Crypt.Encoders.Sha224Encoder` class.
 * @module encoders.Sha224Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Text;
  using Mono.Security.Cryptography;
  
  /**
   * Represents the SHA-224 encoding method.
   * @class Crypt.Encoders.Sha224Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Sha224Encoder: IStringEncoder {
  
    public Sha224Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Sha224Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "SHA-224"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var buffer=Encoding.Default.GetBytes(text);
      var hash=SHA224.Create().ComputeHash(buffer);
      return HexCodec.GetString(hash);
    }
  }
}