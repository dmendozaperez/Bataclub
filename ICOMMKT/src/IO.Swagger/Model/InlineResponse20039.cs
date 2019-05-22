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
    /// InlineResponse20039
    /// </summary>
    [DataContract]
    public partial class InlineResponse20039 :  IEquatable<InlineResponse20039>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20039" /> class.
        /// </summary>
        /// <param name="matchName">matchName.</param>
        /// <param name="trackOpens">trackOpens.</param>
        public InlineResponse20039(string matchName = default(string), bool? trackOpens = default(bool?))
        {
            this.MatchName = matchName;
            this.TrackOpens = trackOpens;
        }
        
        /// <summary>
        /// Gets or Sets MatchName
        /// </summary>
        [DataMember(Name="MatchName", EmitDefaultValue=false)]
        public string MatchName { get; set; }

        /// <summary>
        /// Gets or Sets TrackOpens
        /// </summary>
        [DataMember(Name="TrackOpens", EmitDefaultValue=false)]
        public bool? TrackOpens { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20039 {\n");
            sb.Append("  MatchName: ").Append(MatchName).Append("\n");
            sb.Append("  TrackOpens: ").Append(TrackOpens).Append("\n");
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
            return this.Equals(input as InlineResponse20039);
        }

        /// <summary>
        /// Returns true if InlineResponse20039 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20039 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20039 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.MatchName == input.MatchName ||
                    (this.MatchName != null &&
                    this.MatchName.Equals(input.MatchName))
                ) && 
                (
                    this.TrackOpens == input.TrackOpens ||
                    (this.TrackOpens != null &&
                    this.TrackOpens.Equals(input.TrackOpens))
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
                if (this.MatchName != null)
                    hashCode = hashCode * 59 + this.MatchName.GetHashCode();
                if (this.TrackOpens != null)
                    hashCode = hashCode * 59 + this.TrackOpens.GetHashCode();
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
