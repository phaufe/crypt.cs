/**
 * Implementation of the `Crypt.Encoders.Sha384Encoder` class.
 * @module encoders/Sha384Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the SHA-384 encoding method.
   * @class Crypt.Encoders.Sha384Encoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class Sha384Encoder: IStringEncoder {
  
    public Sha384Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Sha384Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "SHA-384"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeSha384(text);
    }
  }
}