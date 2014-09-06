/**
 * Implementation of the `Crypt.Encoders.Sha1Encoder` class.
 * @module encoders.Sha1Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the SHA-1 encoding method.
   * @class Crypt.Encoders.Sha1Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Sha1Encoder: IStringEncoder {
  
    public Sha1Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Sha1Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "SHA-1"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeSha1(text);
    }
  }
}