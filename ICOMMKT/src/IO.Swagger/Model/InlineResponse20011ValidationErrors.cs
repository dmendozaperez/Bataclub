/* 
 * ICOMMKT Transactional API
 *
 * ICOMMKT Transactional API
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// InlineResponse20011ValidationErrors
    /// </summary>
    [DataContract]
    public partial class InlineResponse20011ValidationErrors :  IEquatable<InlineResponse20011ValidationErrors>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20011ValidationErrors" /> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="line">line.</param>
        /// <param name="characterPosition">characterPosition.</param>
        public InlineResponse20011ValidationErrors(string message = default(string), int? line = default(int?), int? characterPosition = default(int?))
        {
            this.Message = message;
            this.Line = line;
            this.CharacterPosition = characterPosition;
        }
        
        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name="Message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Line
        /// </summary>
        [DataMember(Name="Line", EmitDefaultValue=false)]
        public int? Line { get; set; }

        /// <summary>
        /// Gets or Sets CharacterPosition
        /// </summary>
        [DataMember(Name="CharacterPosition", EmitDefaultValue=false)]
        public int? CharacterPosition { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20011ValidationErrors {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Line: ").Append(Line).Append("\n");
            sb.Append("  CharacterPosition: ").Append(CharacterPosition).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as InlineResponse20011ValidationErrors);
        }

        /// <summary>
        /// Returns true if InlineResponse20011ValidationErrors instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20011ValidationErrors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20011ValidationErrors input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Line == input.Line ||
                    (this.Line != null &&
                    this.Line.Equals(input.Line))
                ) && 
                (
                    this.CharacterPosition == input.CharacterPosition ||
                    (this.CharacterPosition != null &&
                    this.CharacterPosition.Equals(input.CharacterPosition))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Line != null)
                    hashCode = hashCode * 59 + this.Line.GetHashCode();
                if (this.CharacterPosition != null)
                    hashCode = hashCode * 59 + this.CharacterPosition.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}