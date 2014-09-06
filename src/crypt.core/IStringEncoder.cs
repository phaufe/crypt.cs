/**
 * Implementation of the `Crypt.IStringEncoder` interface.
 * @module core.IStringEncoder
 */

namespace Crypt {
  using System;
  using System.Linq;
  
  /**
   * Represents a string encoder.
   * @class Crypt.IStringEncoder
   * @static
   */
  public interface IStringEncoder {
  
    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    string Description {
      get;
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    string Name {
      get;
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    string Encode(string text);
  }
}