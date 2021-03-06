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
    /// Validate a template
    /// </summary>
    [DataContract]
    public partial class ValidateTemplate :  IEquatable<ValidateTemplate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateTemplate" /> class.
        /// </summary>
        /// <param name="subject">The subject content to validate. Must be specified if HtmlBody or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field..</param>
        /// <param name="textBody">The html body content to validate. Must be specified if Subject or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field..</param>
        /// <param name="htmlBody">The text body content to validate. Must be specified if HtmlBody or Subject are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field..</param>
        /// <param name="testRenderModel">The model to be used when rendering test content..</param>
        /// <param name="inlineCssForHtmlTestRender">When HtmlBody is specified, the test render will have style blocks inlined as style attributes on matching html elements. You may disable the css inlining behavior by passing false for this parameter..</param>
        public ValidateTemplate(string subject = default(string), string textBody = default(string), string htmlBody = default(string), string testRenderModel = default(string), string inlineCssForHtmlTestRender = default(string))
        {
            this.Subject = subject;
            this.TextBody = textBody;
            this.HtmlBody = htmlBody;
            this.TestRenderModel = testRenderModel;
            this.InlineCssForHtmlTestRender = inlineCssForHtmlTestRender;
        }
        
        /// <summary>
        /// The subject content to validate. Must be specified if HtmlBody or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.
        /// </summary>
        /// <value>The subject content to validate. Must be specified if HtmlBody or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.</value>
        [DataMember(Name="Subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// The html body content to validate. Must be specified if Subject or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.
        /// </summary>
        /// <value>The html body content to validate. Must be specified if Subject or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.</value>
        [DataMember(Name="TextBody", EmitDefaultValue=false)]
        public string TextBody { get; set; }

        /// <summary>
        /// The text body content to validate. Must be specified if HtmlBody or Subject are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.
        /// </summary>
        /// <value>The text body content to validate. Must be specified if HtmlBody or Subject are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field.</value>
        [DataMember(Name="HtmlBody", EmitDefaultValue=false)]
        public string HtmlBody { get; set; }

        /// <summary>
        /// The model to be used when rendering test content.
        /// </summary>
        /// <value>The model to be used when rendering test content.</value>
        [DataMember(Name="TestRenderModel", EmitDefaultValue=false)]
        public string TestRenderModel { get; set; }

        /// <summary>
        /// When HtmlBody is specified, the test render will have style blocks inlined as style attributes on matching html elements. You may disable the css inlining behavior by passing false for this parameter.
        /// </summary>
        /// <value>When HtmlBody is specified, the test render will have style blocks inlined as style attributes on matching html elements. You may disable the css inlining behavior by passing false for this parameter.</value>
        [DataMember(Name="InlineCssForHtmlTestRender", EmitDefaultValue=false)]
        public string InlineCssForHtmlTestRender { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ValidateTemplate {\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  TextBody: ").Append(TextBody).Append("\n");
            sb.Append("  HtmlBody: ").Append(HtmlBody).Append("\n");
            sb.Append("  TestRenderModel: ").Append(TestRenderModel).Append("\n");
            sb.Append("  InlineCssForHtmlTestRender: ").Append(InlineCssForHtmlTestRender).Append("\n");
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
            return this.Equals(input as ValidateTemplate);
        }

        /// <summary>
        /// Returns true if ValidateTemplate instances are equal
        /// </summary>
        /// <param name="input">Instance of ValidateTemplate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidateTemplate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.TextBody == input.TextBody ||
                    (this.TextBody != null &&
                    this.TextBody.Equals(input.TextBody))
                ) && 
                (
                    this.HtmlBody == input.HtmlBody ||
                    (this.HtmlBody != null &&
                    this.HtmlBody.Equals(input.HtmlBody))
                ) && 
                (
                    this.TestRenderModel == input.TestRenderModel ||
                    (this.TestRenderModel != null &&
                    this.TestRenderModel.Equals(input.TestRenderModel))
                ) && 
                (
                    this.InlineCssForHtmlTestRender == input.InlineCssForHtmlTestRender ||
                    (this.InlineCssForHtmlTestRender != null &&
                    this.InlineCssForHtmlTestRender.Equals(input.InlineCssForHtmlTestRender))
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
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.TextBody != null)
                    hashCode = hashCode * 59 + this.TextBody.GetHashCode();
                if (this.HtmlBody != null)
                    hashCode = hashCode * 59 + this.HtmlBody.GetHashCode();
                if (this.TestRenderModel != null)
                    hashCode = hashCode * 59 + this.TestRenderModel.GetHashCode();
                if (this.InlineCssForHtmlTestRender != null)
                    hashCode = hashCode * 59 + this.InlineCssForHtmlTestRender.GetHashCode();
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
