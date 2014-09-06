/**
 * Implementation of the `Crypt.Encoders.Sha512Encoder` class.
 * @module encoders.Sha512Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the SHA-512 encoding method.
   * @class Crypt.Encoders.Sha512Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Sha512Encoder: IStringEncoder {
  
    public Sha512Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Sha512Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "SHA-512"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeSha512(text);
    }
  }
}