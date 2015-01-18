/**
 * Implementation of the `Crypt.Encoders.LowerCaseEncoder` class.
 * @module encoders.LowerCaseEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the LowerCase encoding method.
   * @class Crypt.Encoders.LowerCaseEncoder
   * @constructor
   * @uses Crypt.IStringEncoder
   */
  public class LowerCaseEncoder: IStringEncoder {
  
    public LowerCaseEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.LowerCaseDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "LowerCase"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     * @throws {System.ArgumentNullException} The specified string is `null`.
     */
    public string Encode(string text) {
      if(text==null) throw new ArgumentNullException("text");
      return text.ToLowerInvariant();
    }
  }
}