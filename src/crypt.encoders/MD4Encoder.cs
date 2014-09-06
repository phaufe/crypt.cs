/**
 * Implementation of the `Crypt.Encoders.MD4Encoder` class.
 * @module encoders.MD4Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Text;
  using Mono.Security.Cryptography;
  
  /**
   * Represents the MD4 encoding method.
   * @class Crypt.Encoders.MD4Encoder
   * @constructor
   * @uses Crypt.IStringEncoder
   */
  public class MD4Encoder: IStringEncoder {
  
    public MD4Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.MD4Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "MD4"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var buffer=Encoding.Default.GetBytes(text);
      var hash=MD4.Create().ComputeHash(buffer);
      return HexCodec.GetString(hash);
    }
  }
}