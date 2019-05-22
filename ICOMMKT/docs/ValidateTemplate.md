# IO.Swagger.Model.ValidateTemplate
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Subject** | **string** | The subject content to validate. Must be specified if HtmlBody or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field. | [optional] 
**TextBody** | **string** | The html body content to validate. Must be specified if Subject or TextBody are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field. | [optional] 
**HtmlBody** | **string** | The text body content to validate. Must be specified if HtmlBody or Subject are not. See our &lt;a href&#x3D;\&quot;http://support.postmarkapp.com/article/1077-template-syntax\&quot;&gt;template language documentation&lt;/a&gt; for more information on the syntax for this field. | [optional] 
**TestRenderModel** | **string** | The model to be used when rendering test content. | [optional] 
**InlineCssForHtmlTestRender** | **string** | When HtmlBody is specified, the test render will have style blocks inlined as style attributes on matching html elements. You may disable the css inlining behavior by passing false for this parameter. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

