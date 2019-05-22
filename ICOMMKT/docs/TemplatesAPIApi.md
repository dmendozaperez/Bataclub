# IO.Swagger.Api.TemplatesAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateTemplate**](TemplatesAPIApi.md#createtemplate) | **POST** /templates | Create a template
[**DeleteTemplate**](TemplatesAPIApi.md#deletetemplate) | **DELETE** /templates/{templateIdOrAlias} | Delete a template
[**EditTemplate**](TemplatesAPIApi.md#edittemplate) | **PUT** /templates/{templateIdOrAlias} | Edit a template
[**GetListTemplates**](TemplatesAPIApi.md#getlisttemplates) | **GET** /templates | List templates
[**GetTemplate**](TemplatesAPIApi.md#gettemplate) | **GET** /templates/{templateIdOrAlias} | Get a template
[**SendBatchTemplatedEmail**](TemplatesAPIApi.md#sendbatchtemplatedemail) | **POST** /email/batchWithTemplates | Send batch with templates
[**SendTemplatedEmail**](TemplatesAPIApi.md#sendtemplatedemail) | **POST** /email/withTemplate | Send email with template
[**ValidateTemplate**](TemplatesAPIApi.md#validatetemplate) | **POST** /templates/validate | Validate a template


<a name="createtemplate"></a>
# **CreateTemplate**
> InlineResponse2008 CreateTemplate (string accept, string xTrxApiKey, CreateTemplate body)

Create a template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateTemplateExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new CreateTemplate(); // CreateTemplate | Create a template

            try
            {
                // Create a template
                InlineResponse2008 result = apiInstance.CreateTemplate(accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.CreateTemplate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **body** | [**CreateTemplate**](CreateTemplate.md)| Create a template | 

### Return type

[**InlineResponse2008**](InlineResponse2008.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletetemplate"></a>
# **DeleteTemplate**
> InlineResponse20010 DeleteTemplate (string accept, string xTrxApiKey, int? templateIdOrAlias)

Delete a template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTemplateExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var templateIdOrAlias = 56;  // int? | 

            try
            {
                // Delete a template
                InlineResponse20010 result = apiInstance.DeleteTemplate(accept, xTrxApiKey, templateIdOrAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.DeleteTemplate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **templateIdOrAlias** | **int?**|  | 

### Return type

[**InlineResponse20010**](InlineResponse20010.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="edittemplate"></a>
# **EditTemplate**
> InlineResponse2008 EditTemplate (string accept, string xTrxApiKey, int? templateIdOrAlias, EditTemplate body)

Edit a template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class EditTemplateExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var templateIdOrAlias = 56;  // int? | 
            var body = new EditTemplate(); // EditTemplate | Edit a template

            try
            {
                // Edit a template
                InlineResponse2008 result = apiInstance.EditTemplate(accept, xTrxApiKey, templateIdOrAlias, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.EditTemplate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **templateIdOrAlias** | **int?**|  | 
 **body** | [**EditTemplate**](EditTemplate.md)| Edit a template | 

### Return type

[**InlineResponse2008**](InlineResponse2008.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlisttemplates"></a>
# **GetListTemplates**
> InlineResponse2007 GetListTemplates (string accept, string xTrxApiKey, int? count, int? offset)

List templates

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetListTemplatesExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - The number of templates to return. 
            var offset = 56;  // int? | - The number of templates to \"skip\" before returning results. 

            try
            {
                // List templates
                InlineResponse2007 result = apiInstance.GetListTemplates(accept, xTrxApiKey, count, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.GetListTemplates: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **count** | **int?**| - The number of templates to return.  | 
 **offset** | **int?**| - The number of templates to \&quot;skip\&quot; before returning results.  | 

### Return type

[**InlineResponse2007**](InlineResponse2007.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettemplate"></a>
# **GetTemplate**
> InlineResponse2009 GetTemplate (string accept, string xTrxApiKey, int? templateIdOrAlias)

Get a template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTemplateExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var templateIdOrAlias = 56;  // int? | 

            try
            {
                // Get a template
                InlineResponse2009 result = apiInstance.GetTemplate(accept, xTrxApiKey, templateIdOrAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.GetTemplate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **templateIdOrAlias** | **int?**|  | 

### Return type

[**InlineResponse2009**](InlineResponse2009.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendbatchtemplatedemail"></a>
# **SendBatchTemplatedEmail**
> Object SendBatchTemplatedEmail (string contentType, string accept, string xTrxApiKey, SendBatchTemplatedEmail body)

Send batch with templates

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SendBatchTemplatedEmailExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new SendBatchTemplatedEmail(); // SendBatchTemplatedEmail | Send batch with templates

            try
            {
                // Send batch with templates
                Object result = apiInstance.SendBatchTemplatedEmail(contentType, accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.SendBatchTemplatedEmail: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **contentType** | **string**| - application/json  | 
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **body** | [**SendBatchTemplatedEmail**](SendBatchTemplatedEmail.md)| Send batch with templates | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendtemplatedemail"></a>
# **SendTemplatedEmail**
> InlineResponse20012 SendTemplatedEmail (string accept, string xTrxApiKey, SendTemplatedEmail body)

Send email with template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SendTemplatedEmailExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new SendTemplatedEmail(); // SendTemplatedEmail | Send email with template

            try
            {
                // Send email with template
                InlineResponse20012 result = apiInstance.SendTemplatedEmail(accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.SendTemplatedEmail: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **body** | [**SendTemplatedEmail**](SendTemplatedEmail.md)| Send email with template | 

### Return type

[**InlineResponse20012**](InlineResponse20012.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="validatetemplate"></a>
# **ValidateTemplate**
> InlineResponse20011 ValidateTemplate (string accept, string xTrxApiKey, ValidateTemplate body)

Validate a template

Authorization: Bearer X-Trx-Api-Key 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ValidateTemplateExample
    {
        public void main()
        {
            var apiInstance = new TemplatesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new ValidateTemplate(); // ValidateTemplate | Validate a template

            try
            {
                // Validate a template
                InlineResponse20011 result = apiInstance.ValidateTemplate(accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TemplatesAPIApi.ValidateTemplate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **body** | [**ValidateTemplate**](ValidateTemplate.md)| Validate a template | 

### Return type

[**InlineResponse20011**](InlineResponse20011.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

