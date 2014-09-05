/**
 * Implementation of the `Crypt.Encoders.Sha256Encoder` class.
 * @module encoders/Sha256Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the SHA-256 encoding method.
   * @class Crypt.Encoders.Sha256Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Sha256Encoder: IStringEncoder {
  
    public Sha256Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Sha256Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "SHA-256"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeSha256(text);
    }
  }
}