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
    /// InlineResponse20023
    /// </summary>
    [DataContract]
    public partial class InlineResponse20023 :  IEquatable<InlineResponse20023>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20023" /> class.
        /// </summary>
        /// <param name="bounceRate">bounceRate.</param>
        /// <param name="bounced">bounced.</param>
        /// <param name="opens">opens.</param>
        /// <param name="sMTPApiErrors">sMTPApiErrors.</param>
        /// <param name="sent">sent.</param>
        /// <param name="spamComplaints">spamComplaints.</param>
        /// <param name="spamComplaintsRate">spamComplaintsRate.</param>
        /// <param name="totalClicks">totalClicks.</param>
        /// <param name="totalTrackedLinksSent">totalTrackedLinksSent.</param>
        /// <param name="tracked">tracked.</param>
        /// <param name="uniqueLinksClicked">uniqueLinksClicked.</param>
        /// <param name="uniqueOpens">uniqueOpens.</param>
        /// <param name="withClientRecorded">withClientRecorded.</param>
        /// <param name="withLinkTracking">withLinkTracking.</param>
        /// <param name="withOpenTracking">withOpenTracking.</param>
        /// <param name="withPlatformRecorded">withPlatformRecorded.</param>
        /// <param name="withReadTimeRecorded">withReadTimeRecorded.</param>
        public InlineResponse20023(int? bounceRate = default(int?), int? bounced = default(int?), int? opens = default(int?), int? sMTPApiErrors = default(int?), int? sent = default(int?), int? spamComplaints = default(int?), int? spamComplaintsRate = default(int?), int? totalClicks = default(int?), int? totalTrackedLinksSent = default(int?), int? tracked = default(int?), int? uniqueLinksClicked = default(int?), int? uniqueOpens = default(int?), int? withClientRecorded = default(int?), int? withLinkTracking = default(int?), int? withOpenTracking = default(int?), int? withPlatformRecorded = default(int?), int? withReadTimeRecorded = default(int?))
        {
            this.BounceRate = bounceRate;
            this.Bounced = bounced;
            this.Opens = opens;
            this.SMTPApiErrors = sMTPApiErrors;
            this.Sent = sent;
            this.SpamComplaints = spamComplaints;
            this.SpamComplaintsRate = spamComplaintsRate;
            this.TotalClicks = totalClicks;
            this.TotalTrackedLinksSent = totalTrackedLinksSent;
            this.Tracked = tracked;
            this.UniqueLinksClicked = uniqueLinksClicked;
            this.UniqueOpens = uniqueOpens;
            this.WithClientRecorded = withClientRecorded;
            this.WithLinkTracking = withLinkTracking;
            this.WithOpenTracking = withOpenTracking;
            this.WithPlatformRecorded = withPlatformRecorded;
            this.WithReadTimeRecorded = withReadTimeRecorded;
        }
        
        /// <summary>
        /// Gets or Sets BounceRate
        /// </summary>
        [DataMember(Name="BounceRate", EmitDefaultValue=false)]
        public int? BounceRate { get; set; }

        /// <summary>
        /// Gets or Sets Bounced
        /// </summary>
        [DataMember(Name="Bounced", EmitDefaultValue=false)]
        public int? Bounced { get; set; }

        /// <summary>
        /// Gets or Sets Opens
        /// </summary>
        [DataMember(Name="Opens", EmitDefaultValue=false)]
        public int? Opens { get; set; }

        /// <summary>
        /// Gets or Sets SMTPApiErrors
        /// </summary>
        [DataMember(Name="SMTPApiErrors", EmitDefaultValue=false)]
        public int? SMTPApiErrors { get; set; }

        /// <summary>
        /// Gets or Sets Sent
        /// </summary>
        [DataMember(Name="Sent", EmitDefaultValue=false)]
        public int? Sent { get; set; }

        /// <summary>
        /// Gets or Sets SpamComplaints
        /// </summary>
        [DataMember(Name="SpamComplaints", EmitDefaultValue=false)]
        public int? SpamComplaints { get; set; }

        /// <summary>
        /// Gets or Sets SpamComplaintsRate
        /// </summary>
        [DataMember(Name="SpamComplaintsRate", EmitDefaultValue=false)]
        public int? SpamComplaintsRate { get; set; }

        /// <summary>
        /// Gets or Sets TotalClicks
        /// </summary>
        [DataMember(Name="TotalClicks", EmitDefaultValue=false)]
        public int? TotalClicks { get; set; }

        /// <summary>
        /// Gets or Sets TotalTrackedLinksSent
        /// </summary>
        [DataMember(Name="TotalTrackedLinksSent", EmitDefaultValue=false)]
        public int? TotalTrackedLinksSent { get; set; }

        /// <summary>
        /// Gets or Sets Tracked
        /// </summary>
        [DataMember(Name="Tracked", EmitDefaultValue=false)]
        public int? Tracked { get; set; }

        /// <summary>
        /// Gets or Sets UniqueLinksClicked
        /// </summary>
        [DataMember(Name="UniqueLinksClicked", EmitDefaultValue=false)]
        public int? UniqueLinksClicked { get; set; }

        /// <summary>
        /// Gets or Sets UniqueOpens
        /// </summary>
        [DataMember(Name="UniqueOpens", EmitDefaultValue=false)]
        public int? UniqueOpens { get; set; }

        /// <summary>
        /// Gets or Sets WithClientRecorded
        /// </summary>
        [DataMember(Name="WithClientRecorded", EmitDefaultValue=false)]
        public int? WithClientRecorded { get; set; }

        /// <summary>
        /// Gets or Sets WithLinkTracking
        /// </summary>
        [DataMember(Name="WithLinkTracking", EmitDefaultValue=false)]
        public int? WithLinkTracking { get; set; }

        /// <summary>
        /// Gets or Sets WithOpenTracking
        /// </summary>
        [DataMember(Name="WithOpenTracking", EmitDefaultValue=false)]
        public int? WithOpenTracking { get; set; }

        /// <summary>
        /// Gets or Sets WithPlatformRecorded
        /// </summary>
        [DataMember(Name="WithPlatformRecorded", EmitDefaultValue=false)]
        public int? WithPlatformRecorded { get; set; }

        /// <summary>
        /// Gets or Sets WithReadTimeRecorded
        /// </summary>
        [DataMember(Name="WithReadTimeRecorded", EmitDefaultValue=false)]
        public int? WithReadTimeRecorded { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20023 {\n");
            sb.Append("  BounceRate: ").Append(BounceRate).Append("\n");
            sb.Append("  Bounced: ").Append(Bounced).Append("\n");
            sb.Append("  Opens: ").Append(Opens).Append("\n");
            sb.Append("  SMTPApiErrors: ").Append(SMTPApiErrors).Append("\n");
            sb.Append("  Sent: ").Append(Sent).Append("\n");
            sb.Append("  SpamComplaints: ").Append(SpamComplaints).Append("\n");
            sb.Append("  SpamComplaintsRate: ").Append(SpamComplaintsRate).Append("\n");
            sb.Append("  TotalClicks: ").Append(TotalClicks).Append("\n");
            sb.Append("  TotalTrackedLinksSent: ").Append(TotalTrackedLinksSent).Append("\n");
            sb.Append("  Tracked: ").Append(Tracked).Append("\n");
            sb.Append("  UniqueLinksClicked: ").Append(UniqueLinksClicked).Append("\n");
            sb.Append("  UniqueOpens: ").Append(UniqueOpens).Append("\n");
            sb.Append("  WithClientRecorded: ").Append(WithClientRecorded).Append("\n");
            sb.Append("  WithLinkTracking: ").Append(WithLinkTracking).Append("\n");
            sb.Append("  WithOpenTracking: ").Append(WithOpenTracking).Append("\n");
            sb.Append("  WithPlatformRecorded: ").Append(WithPlatformRecorded).Append("\n");
            sb.Append("  WithReadTimeRecorded: ").Append(WithReadTimeRecorded).Append("\n");
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
            return this.Equals(input as InlineResponse20023);
        }

        /// <summary>
        /// Returns true if InlineResponse20023 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20023 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20023 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BounceRate == input.BounceRate ||
                    (this.BounceRate != null &&
                    this.BounceRate.Equals(input.BounceRate))
                ) && 
                (
                    this.Bounced == input.Bounced ||
                    (this.Bounced != null &&
                    this.Bounced.Equals(input.Bounced))
                ) && 
                (
                    this.Opens == input.Opens ||
                    (this.Opens != null &&
                    this.Opens.Equals(input.Opens))
                ) && 
                (
                    this.SMTPApiErrors == input.SMTPApiErrors ||
                    (this.SMTPApiErrors != null &&
                    this.SMTPApiErrors.Equals(input.SMTPApiErrors))
                ) && 
                (
                    this.Sent == input.Sent ||
                    (this.Sent != null &&
                    this.Sent.Equals(input.Sent))
                ) && 
                (
                    this.SpamComplaints == input.SpamComplaints ||
                    (this.SpamComplaints != null &&
                    this.SpamComplaints.Equals(input.SpamComplaints))
                ) && 
                (
                    this.SpamComplaintsRate == input.SpamComplaintsRate ||
                    (this.SpamComplaintsRate != null &&
                    this.SpamComplaintsRate.Equals(input.SpamComplaintsRate))
                ) && 
                (
                    this.TotalClicks == input.TotalClicks ||
                    (this.TotalClicks != null &&
                    this.TotalClicks.Equals(input.TotalClicks))
                ) && 
                (
                    this.TotalTrackedLinksSent == input.TotalTrackedLinksSent ||
                    (this.TotalTrackedLinksSent != null &&
                    this.TotalTrackedLinksSent.Equals(input.TotalTrackedLinksSent))
                ) && 
                (
                    this.Tracked == input.Tracked ||
                    (this.Tracked != null &&
                    this.Tracked.Equals(input.Tracked))
                ) && 
                (
                    this.UniqueLinksClicked == input.UniqueLinksClicked ||
                    (this.UniqueLinksClicked != null &&
                    this.UniqueLinksClicked.Equals(input.UniqueLinksClicked))
                ) && 
                (
                    this.UniqueOpens == input.UniqueOpens ||
                    (this.UniqueOpens != null &&
                    this.UniqueOpens.Equals(input.UniqueOpens))
                ) && 
                (
                    this.WithClientRecorded == input.WithClientRecorded ||
                    (this.WithClientRecorded != null &&
                    this.WithClientRecorded.Equals(input.WithClientRecorded))
                ) && 
                (
                    this.WithLinkTracking == input.WithLinkTracking ||
                    (this.WithLinkTracking != null &&
                    this.WithLinkTracking.Equals(input.WithLinkTracking))
                ) && 
                (
                    this.WithOpenTracking == input.WithOpenTracking ||
                    (this.WithOpenTracking != null &&
                    this.WithOpenTracking.Equals(input.WithOpenTracking))
                ) && 
                (
                    this.WithPlatformRecorded == input.WithPlatformRecorded ||
                    (this.WithPlatformRecorded != null &&
                    this.WithPlatformRecorded.Equals(input.WithPlatformRecorded))
                ) && 
                (
                    this.WithReadTimeRecorded == input.WithReadTimeRecorded ||
                    (this.WithReadTimeRecorded != null &&
                    this.WithReadTimeRecorded.Equals(input.WithReadTimeRecorded))
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
                if (this.BounceRate != null)
                    hashCode = hashCode * 59 + this.BounceRate.GetHashCode();
                if (this.Bounced != null)
                    hashCode = hashCode * 59 + this.Bounced.GetHashCode();
                if (this.Opens != null)
                    hashCode = hashCode * 59 + this.Opens.GetHashCode();
                if (this.SMTPApiErrors != null)
                    hashCode = hashCode * 59 + this.SMTPApiErrors.GetHashCode();
                if (this.Sent != null)
                    hashCode = hashCode * 59 + this.Sent.GetHashCode();
                if (this.SpamComplaints != null)
                    hashCode = hashCode * 59 + this.SpamComplaints.GetHashCode();
                if (this.SpamComplaintsRate != null)
                    hashCode = hashCode * 59 + this.SpamComplaintsRate.GetHashCode();
                if (this.TotalClicks != null)
                    hashCode = hashCode * 59 + this.TotalClicks.GetHashCode();
                if (this.TotalTrackedLinksSent != null)
                    hashCode = hashCode * 59 + this.TotalTrackedLinksSent.GetHashCode();
                if (this.Tracked != null)
                    hashCode = hashCode * 59 + this.Tracked.GetHashCode();
                if (this.UniqueLinksClicked != null)
                    hashCode = hashCode * 59 + this.UniqueLinksClicked.GetHashCode();
                if (this.UniqueOpens != null)
                    hashCode = hashCode * 59 + this.UniqueOpens.GetHashCode();
                if (this.WithClientRecorded != null)
                    hashCode = hashCode * 59 + this.WithClientRecorded.GetHashCode();
                if (this.WithLinkTracking != null)
                    hashCode = hashCode * 59 + this.WithLinkTracking.GetHashCode();
                if (this.WithOpenTracking != null)
                    hashCode = hashCode * 59 + this.WithOpenTracking.GetHashCode();
                if (this.WithPlatformRecorded != null)
                    hashCode = hashCode * 59 + this.WithPlatformRecorded.GetHashCode();
                if (this.WithReadTimeRecorded != null)
                    hashCode = hashCode * 59 + this.WithReadTimeRecorded.GetHashCode();
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