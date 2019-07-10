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
    /// InlineResponse20031
    /// </summary>
    [DataContract]
    public partial class InlineResponse20031 :  IEquatable<InlineResponse20031>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20031" /> class.
        /// </summary>
        /// <param name="_10s">_10s.</param>
        /// <param name="_1s">_1s.</param>
        /// <param name="_20s">_20s.</param>
        /// <param name="_3s">_3s.</param>
        /// <param name="_7s">_7s.</param>
        /// <param name="_8s">_8s.</param>
        /// <param name="days">days.</param>
        public InlineResponse20031(int? _10s = default(int?), int? _1s = default(int?), int? _20s = default(int?), int? _3s = default(int?), int? _7s = default(int?), int? _8s = default(int?), List<InlineResponse20031Days> days = default(List<InlineResponse20031Days>))
        {
            this._10s = _10s;
            this._1s = _1s;
            this._20s = _20s;
            this._3s = _3s;
            this._7s = _7s;
            this._8s = _8s;
            this.Days = days;
        }
        
        /// <summary>
        /// Gets or Sets _10s
        /// </summary>
        [DataMember(Name="10s", EmitDefaultValue=false)]
        public int? _10s { get; set; }

        /// <summary>
        /// Gets or Sets _1s
        /// </summary>
        [DataMember(Name="1s", EmitDefaultValue=false)]
        public int? _1s { get; set; }

        /// <summary>
        /// Gets or Sets _20s
        /// </summary>
        [DataMember(Name="20s+", EmitDefaultValue=false)]
        public int? _20s { get; set; }

        /// <summary>
        /// Gets or Sets _3s
        /// </summary>
        [DataMember(Name="3s", EmitDefaultValue=false)]
        public int? _3s { get; set; }

        /// <summary>
        /// Gets or Sets _7s
        /// </summary>
        [DataMember(Name="7s", EmitDefaultValue=false)]
        public int? _7s { get; set; }

        /// <summary>
        /// Gets or Sets _8s
        /// </summary>
        [DataMember(Name="8s", EmitDefaultValue=false)]
        public int? _8s { get; set; }

        /// <summary>
        /// Gets or Sets Days
        /// </summary>
        [DataMember(Name="Days", EmitDefaultValue=false)]
        public List<InlineResponse20031Days> Days { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20031 {\n");
            sb.Append("  _10s: ").Append(_10s).Append("\n");
            sb.Append("  _1s: ").Append(_1s).Append("\n");
            sb.Append("  _20s: ").Append(_20s).Append("\n");
            sb.Append("  _3s: ").Append(_3s).Append("\n");
            sb.Append("  _7s: ").Append(_7s).Append("\n");
            sb.Append("  _8s: ").Append(_8s).Append("\n");
            sb.Append("  Days: ").Append(Days).Append("\n");
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
            return this.Equals(input as InlineResponse20031);
        }

        /// <summary>
        /// Returns true if InlineResponse20031 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20031 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20031 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this._10s == input._10s ||
                    (this._10s != null &&
                    this._10s.Equals(input._10s))
                ) && 
                (
                    this._1s == input._1s ||
                    (this._1s != null &&
                    this._1s.Equals(input._1s))
                ) && 
                (
                    this._20s == input._20s ||
                    (this._20s != null &&
                    this._20s.Equals(input._20s))
                ) && 
                (
                    this._3s == input._3s ||
                    (this._3s != null &&
                    this._3s.Equals(input._3s))
                ) && 
                (
                    this._7s == input._7s ||
                    (this._7s != null &&
                    this._7s.Equals(input._7s))
                ) && 
                (
                    this._8s == input._8s ||
                    (this._8s != null &&
                    this._8s.Equals(input._8s))
                ) && 
                (
                    this.Days == input.Days ||
                    this.Days != null &&
                    this.Days.SequenceEqual(input.Days)
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
                if (this._10s != null)
                    hashCode = hashCode * 59 + this._10s.GetHashCode();
                if (this._1s != null)
                    hashCode = hashCode * 59 + this._1s.GetHashCode();
                if (this._20s != null)
                    hashCode = hashCode * 59 + this._20s.GetHashCode();
                if (this._3s != null)
                    hashCode = hashCode * 59 + this._3s.GetHashCode();
                if (this._7s != null)
                    hashCode = hashCode * 59 + this._7s.GetHashCode();
                if (this._8s != null)
                    hashCode = hashCode * 59 + this._8s.GetHashCode();
                if (this.Days != null)
                    hashCode = hashCode * 59 + this.Days.GetHashCode();
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