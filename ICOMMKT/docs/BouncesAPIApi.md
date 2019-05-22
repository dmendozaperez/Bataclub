# IO.Swagger.Api.BouncesAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateBounce**](BouncesAPIApi.md#activatebounce) | **PUT** /bounces/{bounceid}/activate | Activate a bounce
[**GetBounceDump**](BouncesAPIApi.md#getbouncedump) | **GET** /bounces/{bounceid}/dump | Get bounce dump
[**GetBounceSingle**](BouncesAPIApi.md#getbouncesingle) | **GET** /bounces/{bounceid} | Get a single bounce
[**GetBounces**](BouncesAPIApi.md#getbounces) | **GET** /bounces | Get bounces
[**GetTags**](BouncesAPIApi.md#gettags) | **GET** /bounces/tags | Get an array of tags that have generated bounces for a given server.
[**GetdeliveryStatus**](BouncesAPIApi.md#getdeliverystatus) | **GET** /deliverystats | Get delivery Status


<a name="activatebounce"></a>
# **ActivateBounce**
> InlineResponse2005 ActivateBounce (string contentType, string accept, string xTrxApiKey, int? bounceid)

Activate a bounce

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
    public class ActivateBounceExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var contentType = contentType_example;  // string | - application/json 
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var bounceid = 56;  // int? | 

            try
            {
                // Activate a bounce
                InlineResponse2005 result = apiInstance.ActivateBounce(contentType, accept, xTrxApiKey, bounceid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.ActivateBounce: " + e.Message );
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
 **bounceid** | **int?**|  | 

### Return type

[**InlineResponse2005**](InlineResponse2005.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbouncedump"></a>
# **GetBounceDump**
> InlineResponse2004 GetBounceDump (string accept, string xTrxApiKey, int? bounceid)

Get bounce dump

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
    public class GetBounceDumpExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var bounceid = 56;  // int? | 

            try
            {
                // Get bounce dump
                InlineResponse2004 result = apiInstance.GetBounceDump(accept, xTrxApiKey, bounceid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.GetBounceDump: " + e.Message );
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
 **bounceid** | **int?**|  | 

### Return type

[**InlineResponse2004**](InlineResponse2004.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbouncesingle"></a>
# **GetBounceSingle**
> InlineResponse2003 GetBounceSingle (string accept, string xTrxApiKey, int? bounceid)

Get a single bounce

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
    public class GetBounceSingleExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var bounceid = 56;  // int? | ID of the bounce 

            try
            {
                // Get a single bounce
                InlineResponse2003 result = apiInstance.GetBounceSingle(accept, xTrxApiKey, bounceid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.GetBounceSingle: " + e.Message );
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
 **bounceid** | **int?**| ID of the bounce  | 

### Return type

[**InlineResponse2003**](InlineResponse2003.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbounces"></a>
# **GetBounces**
> InlineResponse2003 GetBounces (string accept, string xTrxApiKey, int? count, int? offset, string type = null, bool? inactive = null, string emailFilter = null, string tag = null, string messageID = null, string fromdate = null, string todate = null)

Get bounces

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
    public class GetBouncesExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of bounces to return per request. Max 500. 
            var offset = 56;  // int? | - Number of bounces to skip. 
            var type = type_example;  // string | - Filter by type of bounce.  (optional) 
            var inactive = true;  // bool? | - Filter by emails that were deactivated by ICOMMKT due to the bounce. Set to true or false. If this isn’t specified it will return both active and inactive.  (optional) 
            var emailFilter = emailFilter_example;  // string | - Filter by email address.  (optional) 
            var tag = tag_example;  // string | - Filter by tag.  (optional) 
            var messageID = messageID_example;  // string | - Filter by messageID.  (optional) 
            var fromdate = fromdate_example;  // string | - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  (optional) 
            var todate = todate_example;  // string | - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.     (optional) 

            try
            {
                // Get bounces
                InlineResponse2003 result = apiInstance.GetBounces(accept, xTrxApiKey, count, offset, type, inactive, emailFilter, tag, messageID, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.GetBounces: " + e.Message );
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
 **count** | **int?**| - Number of bounces to return per request. Max 500.  | 
 **offset** | **int?**| - Number of bounces to skip.  | 
 **type** | **string**| - Filter by type of bounce.  | [optional] 
 **inactive** | **bool?**| - Filter by emails that were deactivated by ICOMMKT due to the bounce. Set to true or false. If this isn’t specified it will return both active and inactive.  | [optional] 
 **emailFilter** | **string**| - Filter by email address.  | [optional] 
 **tag** | **string**| - Filter by tag.  | [optional] 
 **messageID** | **string**| - Filter by messageID.  | [optional] 
 **fromdate** | **string**| - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  | [optional] 
 **todate** | **string**| - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.     | [optional] 

### Return type

[**InlineResponse2003**](InlineResponse2003.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettags"></a>
# **GetTags**
> InlineResponse2006 GetTags (string accept, string xTrxApiKey)

Get an array of tags that have generated bounces for a given server.

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
    public class GetTagsExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 

            try
            {
                // Get an array of tags that have generated bounces for a given server.
                InlineResponse2006 result = apiInstance.GetTags(accept, xTrxApiKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.GetTags: " + e.Message );
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

### Return type

[**InlineResponse2006**](InlineResponse2006.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdeliverystatus"></a>
# **GetdeliveryStatus**
> InlineResponse2002 GetdeliveryStatus (string accept, string xTrxApiKey)

Get delivery Status

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
    public class GetdeliveryStatusExample
    {
        public void main()
        {
            var apiInstance = new BouncesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 

            try
            {
                // Get delivery Status
                InlineResponse2002 result = apiInstance.GetdeliveryStatus(accept, xTrxApiKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BouncesAPIApi.GetdeliveryStatus: " + e.Message );
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

### Return type

[**InlineResponse2002**](InlineResponse2002.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

