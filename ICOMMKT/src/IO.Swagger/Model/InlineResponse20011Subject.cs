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
    /// InlineResponse20011Subject
    /// </summary>
    [DataContract]
    public partial class InlineResponse20011Subject :  IEquatable<InlineResponse20011Subject>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20011Subject" /> class.
        /// </summary>
        /// <param name="contentIsValid">contentIsValid.</param>
        /// <param name="validationErrors">validationErrors.</param>
        /// <param name="renderedContent">renderedContent.</param>
        public InlineResponse20011Subject(bool? contentIsValid = default(bool?), List<> validationErrors = default(List<>), string renderedContent = default(string))
        {
            this.ContentIsValid = contentIsValid;
            this.ValidationErrors = validationErrors;
            this.RenderedContent = renderedContent;
        }
        
        /// <summary>
        /// Gets or Sets ContentIsValid
        /// </summary>
        [DataMember(Name="ContentIsValid", EmitDefaultValue=false)]
        public bool? ContentIsValid { get; set; }

        /// <summary>
        /// Gets or Sets ValidationErrors
        /// </summary>
        [DataMember(Name="ValidationErrors", EmitDefaultValue=false)]
        public List<> ValidationErrors { get; set; }

        /// <summary>
        /// Gets or Sets RenderedContent
        /// </summary>
        [DataMember(Name="RenderedContent", EmitDefaultValue=false)]
        public string RenderedContent { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20011Subject {\n");
            sb.Append("  ContentIsValid: ").Append(ContentIsValid).Append("\n");
            sb.Append("  ValidationErrors: ").Append(ValidationErrors).Append("\n");
            sb.Append("  RenderedContent: ").Append(RenderedContent).Append("\n");
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
            return this.Equals(input as InlineResponse20011Subject);
        }

        /// <summary>
        /// Returns true if InlineResponse20011Subject instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20011Subject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20011Subject input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ContentIsValid == input.ContentIsValid ||
                    (this.ContentIsValid != null &&
                    this.ContentIsValid.Equals(input.ContentIsValid))
                ) && 
                (
                    this.ValidationErrors == input.ValidationErrors ||
                    this.ValidationErrors != null &&
                    this.ValidationErrors.SequenceEqual(input.ValidationErrors)
                ) && 
                (
                    this.RenderedContent == input.RenderedContent ||
                    (this.RenderedContent != null &&
                    this.RenderedContent.Equals(input.RenderedContent))
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
                if (this.ContentIsValid != null)
                    hashCode = hashCode * 59 + this.ContentIsValid.GetHashCode();
                if (this.ValidationErrors != null)
                    hashCode = hashCode * 59 + this.ValidationErrors.GetHashCode();
                if (this.RenderedContent != null)
                    hashCode = hashCode * 59 + this.RenderedContent.GetHashCode();
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
