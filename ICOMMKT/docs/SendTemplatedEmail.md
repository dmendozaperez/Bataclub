# IO.Swagger.Model.SendTemplatedEmail
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TemplateId** | **int?** | The template to use when sending this message. Required if TemplateAlias is not specified. | [optional] 
**TemplateAlias** | **string** | The alias of a template to use when sending this message. Required if TemplateID is not specified. | [optional] 
**TemplateModel** | **Object** | The model to be applied to the specified template to generate HtmlBody, TextBody, and Subject. | [optional] 
**InlineCss** | **bool?** | By default, if the specified template contains an HTMLBody, we will apply the style blocks as inline attributes to the rendered HTML content. You may opt-out of this behavior by passing false for this request field. | [optional] 
**From** | **string** | The sender email address. Must have a registered and confirmed Sender Signature. | [optional] 
**To** | **string** | Recipient email address. Multiple addresses are comma separated. Max 50. | [optional] 
**Cc** | **string** | Cc recipient email address. Multiple addresses are comma separated. Max 50. | [optional] 
**Bcc** | **string** | Bcc recipient email address. Multiple addresses are comma separated. Max 50. | [optional] 
**Tag** | **string** | Email tag that allows you to categorize outgoing emails and get detailed statistics. | [optional] 
**ReplyTo** | **string** | Reply To override email address. Defaults to the Reply To set in the sender signature. | [optional] 
**Headers** | **string** | List of custom headers to include. | [optional] 
**TrackOpens** | **bool?** | Activate open tracking for this email. | [optional] 
**TrackLinks** | **string** | Activate link tracking for links in the HTML or Text bodies of this email. Possible (None, HtmlAndText, HtmlOnly, TextOnly) | [optional] 
**Attachments** | [**List&lt;&gt;**](.md) | List of attachments. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

