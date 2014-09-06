/**
 * Implementation of the `Crypt.Encoders.Crc32Encoder` class.
 * @module encoders.Crc32Encoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Globalization;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /**
   * Represents the CRC32 encoding method.
   * @class Crypt.Encoders.Crc32Encoder
   * @constructor
   * @uses Crypt.IStringEncoder
   */
  public class Crc32Encoder: IStringEncoder {
  
    public Crc32Encoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.Crc32Description; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "CRC32"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HashUtility.ComputeCrc32(text).ToString(CultureInfo.InvariantCulture);
    }
  }
}