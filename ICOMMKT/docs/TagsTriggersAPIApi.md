# IO.Swagger.Api.TagsTriggersAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateTriggerForTag**](TagsTriggersAPIApi.md#createtriggerfortag) | **POST** /triggers/tags | Create a trigger for a tag
[**DeleteSingleATrigger**](TagsTriggersAPIApi.md#deletesingleatrigger) | **DELETE** /triggers/tags/{triggerid} | Delete a single trigger
[**EditSingleTrigger**](TagsTriggersAPIApi.md#editsingletrigger) | **PUT** /triggers/tags/{triggerid} | Edit a single trigger
[**GetSingleTrigger**](TagsTriggersAPIApi.md#getsingletrigger) | **GET** /triggers/tags/{triggerid} | Get a single trigger
[**SearchTriggers**](TagsTriggersAPIApi.md#searchtriggers) | **GET** /triggers/tags | Search triggers


<a name="createtriggerfortag"></a>
# **CreateTriggerForTag**
> InlineResponse20037 CreateTriggerForTag (string contentType, string accept, string xTrxApiKey, CreateTriggerForTag body)

Create a trigger for a tag

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
    public class CreateTriggerForTagExample
    {
        public void main()
        {
            var apiInstance = new TagsTriggersAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var body = new CreateTriggerForTag(); // CreateTriggerForTag | Create a trigger for a tag

            try
            {
                // Create a trigger for a tag
                InlineResponse20037 result = apiInstance.CreateTriggerForTag(contentType, accept, xTrxApiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsTriggersAPIApi.CreateTriggerForTag: " + e.Message );
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
 **body** | [**CreateTriggerForTag**](CreateTriggerForTag.md)| Create a trigger for a tag | 

### Return type

[**InlineResponse20037**](InlineResponse20037.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletesingleatrigger"></a>
# **DeleteSingleATrigger**
> InlineResponse20040 DeleteSingleATrigger (string accept, string xTrxApiKey, int? triggerid)

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
    public class DeleteSingleATriggerExample
    {
        public void main()
        {
            var apiInstance = new TagsTriggersAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var triggerid = 56;  // int? | 

            try
            {
                // Delete a single trigger
                InlineResponse20040 result = apiInstance.DeleteSingleATrigger(accept, xTrxApiKey, triggerid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsTriggersAPIApi.DeleteSingleATrigger: " + e.Message );
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
 **triggerid** | **int?**|  | 

### Return type

[**InlineResponse20040**](InlineResponse20040.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="editsingletrigger"></a>
# **EditSingleTrigger**
> InlineResponse20039 EditSingleTrigger (string contentType, string accept, string xTrxApiKey, int? triggerid, EditSingleTrigger body)

Edit a single trigger

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
    public class EditSingleTriggerExample
    {
        public void main()
        {
            var apiInstance = new TagsTriggersAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var triggerid = 56;  // int? | 
            var body = new EditSingleTrigger(); // EditSingleTrigger | Edit a single trigger

            try
            {
                // Edit a single trigger
                InlineResponse20039 result = apiInstance.EditSingleTrigger(contentType, accept, xTrxApiKey, triggerid, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsTriggersAPIApi.EditSingleTrigger: " + e.Message );
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
 **triggerid** | **int?**|  | 
 **body** | [**EditSingleTrigger**](EditSingleTrigger.md)| Edit a single trigger | 

### Return type

[**InlineResponse20039**](InlineResponse20039.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsingletrigger"></a>
# **GetSingleTrigger**
> InlineResponse20038 GetSingleTrigger (string accept, string xTrxApiKey, int? triggerid)

Get a single trigger

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
    public class GetSingleTriggerExample
    {
        public void main()
        {
            var apiInstance = new TagsTriggersAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var triggerid = 56;  // int? | 

            try
            {
                // Get a single trigger
                InlineResponse20038 result = apiInstance.GetSingleTrigger(accept, xTrxApiKey, triggerid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsTriggersAPIApi.GetSingleTrigger: " + e.Message );
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
 **triggerid** | **int?**|  | 

### Return type

[**InlineResponse20038**](InlineResponse20038.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchtriggers"></a>
# **SearchTriggers**
> InlineResponse20036 SearchTriggers (string contentType, string accept, string xTrxApiKey, int? count, int? offset, int? matchName)

Search triggers

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
    public class SearchTriggersExample
    {
        public void main()
        {
            var apiInstance = new TagsTriggersAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of records to return per request. 
            var offset = 56;  // int? | - Number of records to skip. 
            var matchName = 56;  // int? | - Filter by delivery tag. 

            try
            {
                // Search triggers
                InlineResponse20036 result = apiInstance.SearchTriggers(contentType, accept, xTrxApiKey, count, offset, matchName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsTriggersAPIApi.SearchTriggers: " + e.Message );
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
 **count** | **int?**| - Number of records to return per request.  | 
 **offset** | **int?**| - Number of records to skip.  | 
 **matchName** | **int?**| - Filter by delivery tag.  | 

### Return type

[**InlineResponse20036**](InlineResponse20036.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

