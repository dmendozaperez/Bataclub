# IO.Swagger.Api.EmailAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostemailBatch**](EmailAPIApi.md#postemailbatch) | **POST** /email/batch | Send batch emails
[**PostemailSingle**](EmailAPIApi.md#postemailsingle) | **POST** /email | Send a single email


<a name="postemailbatch"></a>
# **PostemailBatch**
> InlineResponse2001 PostemailBatch (string accept, string xTrxApiKey, BatchEmail body)

Send batch emails

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
    public class PostemailBatchExample
    {
        public void main()
        {
            var apiInstance = new EmailAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new BatchEmail(); // BatchEmail | Email body

            try
            {
                // Send batch emails
                InlineResponse2001 result = apiInstance.PostemailBatch(accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EmailAPIApi.PostemailBatch: " + e.Message );
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
 **body** | [**BatchEmail**](BatchEmail.md)| Email body | 

### Return type

[**InlineResponse2001**](InlineResponse2001.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postemailsingle"></a>
# **PostemailSingle**
> InlineResponse200 PostemailSingle (string contentType, string xTrxApiKey, EmailBody body)

Send a single email

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
    public class PostemailSingleExample
    {
        public void main()
        {
            var apiInstance = new EmailAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new EmailBody(); // EmailBody | Email body

            try
            {
                // Send a single email
                InlineResponse200 result = apiInstance.PostemailSingle(contentType, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EmailAPIApi.PostemailSingle: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **contentType** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 
 **body** | [**EmailBody**](EmailBody.md)| Email body | 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

