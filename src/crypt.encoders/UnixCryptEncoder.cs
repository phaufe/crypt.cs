/**
 * Implementation of the `Crypt.Encoders.UnixCryptEncoder` class.
 * @module encoders.UnixCryptEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using DigiWar.Security.Cryptography;
  
  /**
   * Represents the UNIXCrypt encoding method.
   * @class Crypt.Encoders.UnixCryptEncoder
   * @constructor
   * @uses Crypt.IStringEncoder
   */
  public class UnixCryptEncoder: IStringEncoder {
  
    public UnixCryptEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.UnixCryptDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "UNIXCrypt"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return UnixCrypt.Crypt(text);
    }
  }
}