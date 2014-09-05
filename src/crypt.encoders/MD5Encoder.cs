/**
 * Implementation of the `Crypt.Encoders.MD5Encoder` class.
 * @module encoders/MD5Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the MD5 encoding method.
   * @class Crypt.Encoders.MD5Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class MD5Encoder: IStringEncoder {
  
    public MD5Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.MD5Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "MD5"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeMD5(text);
    }
  }
}