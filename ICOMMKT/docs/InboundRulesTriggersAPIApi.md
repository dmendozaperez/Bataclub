# IO.Swagger.Api.InboundRulesTriggersAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateInboundRuleTrigger**](InboundRulesTriggersAPIApi.md#createinboundruletrigger) | **POST** /triggers/inboundrules | Create an inbound rule trigger
[**DeleteSingleTrigger**](InboundRulesTriggersAPIApi.md#deletesingletrigger) | **DELETE** /triggers/inboundrules/{triggerid} | Delete a single trigger
[**GetInboundRuleTriggers**](InboundRulesTriggersAPIApi.md#getinboundruletriggers) | **GET** /triggers/inboundrules | List inbound rule triggers


<a name="createinboundruletrigger"></a>
# **CreateInboundRuleTrigger**
> InlineResponse20042 CreateInboundRuleTrigger (string contentType, string accept, string xTrxApiKey, CreateInboundRuleTrigger body)

Create an inbound rule trigger

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
    public class CreateInboundRuleTriggerExample
    {
        public void main()
        {
            var apiInstance = new InboundRulesTriggersAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new CreateInboundRuleTrigger(); // CreateInboundRuleTrigger | Create an inbound rule trigger

            try
            {
                // Create an inbound rule trigger
                InlineResponse20042 result = apiInstance.CreateInboundRuleTrigger(contentType, accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling InboundRulesTriggersAPIApi.CreateInboundRuleTrigger: " + e.Message );
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
 **body** | [**CreateInboundRuleTrigger**](CreateInboundRuleTrigger.md)| Create an inbound rule trigger | 

### Return type

[**InlineResponse20042**](InlineResponse20042.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletesingletrigger"></a>
# **DeleteSingleTrigger**
> InlineResponse20043 DeleteSingleTrigger (int? triggerid, string accept, string xTrxApiKey)

Delete a single trigger

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
    public class DeleteSingleTriggerExample
    {
        public void main()
        {
            var apiInstance = new InboundRulesTriggersAPIApi();
            var triggerid = 56;  // int? | 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 

            try
            {
                // Delete a single trigger
                InlineResponse20043 result = apiInstance.DeleteSingleTrigger(triggerid, accept, xTrxApiKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling InboundRulesTriggersAPIApi.DeleteSingleTrigger: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **triggerid** | **int?**|  | 
 **accept** | **string**| - application/json  | 
 **xTrxApiKey** | **string**| - Find your API KEY in your ICOMMKT Account  | 

### Return type

[**InlineResponse20043**](InlineResponse20043.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getinboundruletriggers"></a>
# **GetInboundRuleTriggers**
> InlineResponse20041 GetInboundRuleTriggers (string accept, string xTrxApiKey, int? count, int? offset)

List inbound rule triggers

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
    public class GetInboundRuleTriggersExample
    {
        public void main()
        {
            var apiInstance = new InboundRulesTriggersAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of servers to return per request. 
            var offset = 56;  // int? | - Number of servers to skip. 

            try
            {
                // List inbound rule triggers
                InlineResponse20041 result = apiInstance.GetInboundRuleTriggers(accept, xTrxApiKey, count, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling InboundRulesTriggersAPIApi.GetInboundRuleTriggers: " + e.Message );
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
 **count** | **int?**| - Number of servers to return per request.  | 
 **offset** | **int?**| - Number of servers to skip.  | 

### Return type

[**InlineResponse20041**](InlineResponse20041.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

