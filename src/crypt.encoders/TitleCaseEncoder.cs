/**
 * Implementation of the `Crypt.Encoders.TitleCaseEncoder` class.
 * @module encoders.TitleCaseEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;

  using Crypt.Encoders.Properties;
  using MiniFramework;
  
  /**
   * Represents the TitleCase encoding method.
   * @class Crypt.Encoders.TitleCaseEncoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class TitleCaseEncoder: IStringEncoder {
  
    public TitleCaseEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.TitleCaseDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "TitleCase"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      if(text==null) throw new ArgumentNullException("text");
      return text.CapitalizeWords();
    }
  }
}