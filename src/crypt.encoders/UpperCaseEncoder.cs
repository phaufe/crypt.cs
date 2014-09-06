/**
 * Implementation of the `Crypt.Encoders.UpperCaseEncoder` class.
 * @module encoders.UpperCaseEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the UpperCase encoding method.
   * @class Crypt.Encoders.UpperCaseEncoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class UpperCaseEncoder: IStringEncoder {
  
    public UpperCaseEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.UpperCaseDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "UpperCase"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      if(text==null) throw new ArgumentNullException("text");
      return text.ToUpperInvariant();
    }
  }
}