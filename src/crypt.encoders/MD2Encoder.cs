/**
 * Implementation of the `Crypt.Encoders.MD2Encoder` class.
 * @module encoders.MD2Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Text;
  using Mono.Security.Cryptography;
  
  /**
   * Represents the MD2 encoding method.
   * @class Crypt.Encoders.MD2Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class MD2Encoder: IStringEncoder {
  
    public MD2Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.MD2Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "MD2"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      var buffer=Encoding.Default.GetBytes(text);
      var hash=MD2.Create().ComputeHash(buffer);
      return HexCodec.GetString(hash);
    }
  }
}