# IO.Swagger.Model.BatchEmail
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**From** | **string** | The sender email address. Must have a registered and confirmed Sender Signature. | 
**To** | **string** | Recipient email address. Multiple addresses are comma separated. | 
**Cc** | **string** | Cc recipient email address. Multiple addresses are comma separated. | [optional] 
**Bcc** | **string** | Bcc recipient email address. Multiple addresses are comma separated. | [optional] 
**Subject** | **string** | Email subject. | [optional] 
**Tag** | **string** | Email tag that allows you to categorize outgoing emails and get detailed statistics. | [optional] 
**HtmlBody** | **string** | If TextBody is not specified HTML email message | [optional] 
**TextBody** | **string** | If HtmlBody is not specified Plain text email message. | [optional] 
**ReplyTo** | **string** | Reply To override email address. Defaults to the Reply To set in the sender signature. | [optional] 
**Headers** | **string** | List of custom headers to include. | [optional] 
**TrackOpens** | **bool?** | Activate open tracking for this email. | [optional] 
**TrackLinks** | **string** | Activate link tracking for links in the HTML or Text bodies of this email. Possible options None HtmlAndText HtmlOnly TextOnly. | [optional] 
**Attachments** | [**List&lt;&gt;**](.md) | List of attachments | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

