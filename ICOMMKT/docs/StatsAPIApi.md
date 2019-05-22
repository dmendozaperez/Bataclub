# IO.Swagger.Api.StatsAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetBounceCounts**](StatsAPIApi.md#getbouncecounts) | **GET** /stats/outbound/bounces | Get bounce counts (Gets total counts of emails you’ve sent out that have been returned as bounced.)
[**GetBrowserPlatformUsage**](StatsAPIApi.md#getbrowserplatformusage) | **GET** /stats/outbound/clicks/platforms | Get browser platform usage (Gets an overview of the browser platforms used to open your emails. This is only recorded when Link Tracking is enabled for that email.)
[**GetBrowserUsage**](StatsAPIApi.md#getbrowserusage) | **GET** /stats/outbound/clicks/browserfamilies | Get browser usage (Gets an overview of the browsers used to open links in your emails. This is only recorded when Link Tracking is enabled for that email.)
[**GetClickCounts**](StatsAPIApi.md#getclickcounts) | **GET** /stats/outbound/clicks | Get click counts (Gets total counts of unique links that were clicked.)
[**GetClickLocation**](StatsAPIApi.md#getclicklocation) | **GET** /stats/outbound/clicks/location | Get click location (Gets an overview of which part of the email links were clicked from (HTML or Text). This is only recorded when Link Tracking is enabled for that email.)
[**GetEmailClientUsage**](StatsAPIApi.md#getemailclientusage) | **GET** /stats/outbound/opens/emailclients | Get email client usage (Gets an overview of the email clients used to open your emails. This is only recorded when open tracking is enabled for that email.)
[**GetEmailOpenCounts**](StatsAPIApi.md#getemailopencounts) | **GET** /stats/outbound/opens | Get email open counts (Gets total counts of recipients who opened your emails. This is only recorded when open tracking is enabled for that email.)
[**GetEmailPlatformUsage**](StatsAPIApi.md#getemailplatformusage) | **GET** /stats/outbound/opens/platforms | Get email platform usage (Gets an overview of the platforms used to open your emails. This is only recorded when open tracking is enabled for that email.)
[**GetEmailReadTimes**](StatsAPIApi.md#getemailreadtimes) | **GET** /stats/outbound/opens/readtimes | Get email read times (Gets the length of time that recipients read emails along with counts for each time. This is only recorded when open tracking is enabled for that email. Read time tracking stops at 20 seconds, so any read times above that will appear in the 20s+ field.)
[**GetOutboundOverview**](StatsAPIApi.md#getoutboundoverview) | **GET** /stats/outbound | Get outbound overview (Gets a brief overview of statistics for all of your outbound email.)
[**GetSentCounts**](StatsAPIApi.md#getsentcounts) | **GET** /stats/outbound/sends | Get sent counts (Gets a total count of emails you’ve sent out.)
[**GetSpamComplaints**](StatsAPIApi.md#getspamcomplaints) | **GET** /stats/outbound/spam | Get spam complaints (Gets a total count of recipients who have marked your email as spam.)
[**GetTrackedEmailCounts**](StatsAPIApi.md#gettrackedemailcounts) | **GET** /stats/outbound/tracked | Get tracked email counts (Gets a total count of emails you’ve sent with open tracking or link tracking enabled.)


<a name="getbouncecounts"></a>
# **GetBounceCounts**
> InlineResponse20025 GetBounceCounts (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get bounce counts (Gets total counts of emails you’ve sent out that have been returned as bounced.)

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
    public class GetBounceCountsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get bounce counts (Gets total counts of emails you’ve sent out that have been returned as bounced.)
                InlineResponse20025 result = apiInstance.GetBounceCounts(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetBounceCounts: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20025**](InlineResponse20025.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrowserplatformusage"></a>
# **GetBrowserPlatformUsage**
> InlineResponse20034 GetBrowserPlatformUsage (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get browser platform usage (Gets an overview of the browser platforms used to open your emails. This is only recorded when Link Tracking is enabled for that email.)

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
    public class GetBrowserPlatformUsageExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get browser platform usage (Gets an overview of the browser platforms used to open your emails. This is only recorded when Link Tracking is enabled for that email.)
                InlineResponse20034 result = apiInstance.GetBrowserPlatformUsage(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetBrowserPlatformUsage: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20034**](InlineResponse20034.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrowserusage"></a>
# **GetBrowserUsage**
> InlineResponse20033 GetBrowserUsage (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get browser usage (Gets an overview of the browsers used to open links in your emails. This is only recorded when Link Tracking is enabled for that email.)

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
    public class GetBrowserUsageExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get browser usage (Gets an overview of the browsers used to open links in your emails. This is only recorded when Link Tracking is enabled for that email.)
                InlineResponse20033 result = apiInstance.GetBrowserUsage(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetBrowserUsage: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20033**](InlineResponse20033.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getclickcounts"></a>
# **GetClickCounts**
> InlineResponse20032 GetClickCounts (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get click counts (Gets total counts of unique links that were clicked.)

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
    public class GetClickCountsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get click counts (Gets total counts of unique links that were clicked.)
                InlineResponse20032 result = apiInstance.GetClickCounts(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetClickCounts: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20032**](InlineResponse20032.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getclicklocation"></a>
# **GetClickLocation**
> InlineResponse20035 GetClickLocation (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get click location (Gets an overview of which part of the email links were clicked from (HTML or Text). This is only recorded when Link Tracking is enabled for that email.)

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
    public class GetClickLocationExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get click location (Gets an overview of which part of the email links were clicked from (HTML or Text). This is only recorded when Link Tracking is enabled for that email.)
                InlineResponse20035 result = apiInstance.GetClickLocation(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetClickLocation: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20035**](InlineResponse20035.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailclientusage"></a>
# **GetEmailClientUsage**
> InlineResponse20030 GetEmailClientUsage (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get email client usage (Gets an overview of the email clients used to open your emails. This is only recorded when open tracking is enabled for that email.)

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
    public class GetEmailClientUsageExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get email client usage (Gets an overview of the email clients used to open your emails. This is only recorded when open tracking is enabled for that email.)
                InlineResponse20030 result = apiInstance.GetEmailClientUsage(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetEmailClientUsage: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20030**](InlineResponse20030.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailopencounts"></a>
# **GetEmailOpenCounts**
> InlineResponse20028 GetEmailOpenCounts (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get email open counts (Gets total counts of recipients who opened your emails. This is only recorded when open tracking is enabled for that email.)

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
    public class GetEmailOpenCountsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get email open counts (Gets total counts of recipients who opened your emails. This is only recorded when open tracking is enabled for that email.)
                InlineResponse20028 result = apiInstance.GetEmailOpenCounts(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetEmailOpenCounts: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20028**](InlineResponse20028.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailplatformusage"></a>
# **GetEmailPlatformUsage**
> InlineResponse20029 GetEmailPlatformUsage (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get email platform usage (Gets an overview of the platforms used to open your emails. This is only recorded when open tracking is enabled for that email.)

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
    public class GetEmailPlatformUsageExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get email platform usage (Gets an overview of the platforms used to open your emails. This is only recorded when open tracking is enabled for that email.)
                InlineResponse20029 result = apiInstance.GetEmailPlatformUsage(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetEmailPlatformUsage: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20029**](InlineResponse20029.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailreadtimes"></a>
# **GetEmailReadTimes**
> InlineResponse20031 GetEmailReadTimes (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get email read times (Gets the length of time that recipients read emails along with counts for each time. This is only recorded when open tracking is enabled for that email. Read time tracking stops at 20 seconds, so any read times above that will appear in the 20s+ field.)

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
    public class GetEmailReadTimesExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get email read times (Gets the length of time that recipients read emails along with counts for each time. This is only recorded when open tracking is enabled for that email. Read time tracking stops at 20 seconds, so any read times above that will appear in the 20s+ field.)
                InlineResponse20031 result = apiInstance.GetEmailReadTimes(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetEmailReadTimes: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20031**](InlineResponse20031.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoutboundoverview"></a>
# **GetOutboundOverview**
> InlineResponse20023 GetOutboundOverview (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get outbound overview (Gets a brief overview of statistics for all of your outbound email.)

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
    public class GetOutboundOverviewExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get outbound overview (Gets a brief overview of statistics for all of your outbound email.)
                InlineResponse20023 result = apiInstance.GetOutboundOverview(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetOutboundOverview: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20023**](InlineResponse20023.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsentcounts"></a>
# **GetSentCounts**
> InlineResponse20024 GetSentCounts (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get sent counts (Gets a total count of emails you’ve sent out.)

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
    public class GetSentCountsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get sent counts (Gets a total count of emails you’ve sent out.)
                InlineResponse20024 result = apiInstance.GetSentCounts(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetSentCounts: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20024**](InlineResponse20024.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getspamcomplaints"></a>
# **GetSpamComplaints**
> InlineResponse20026 GetSpamComplaints (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get spam complaints (Gets a total count of recipients who have marked your email as spam.)

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
    public class GetSpamComplaintsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get spam complaints (Gets a total count of recipients who have marked your email as spam.)
                InlineResponse20026 result = apiInstance.GetSpamComplaints(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetSpamComplaints: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20026**](InlineResponse20026.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettrackedemailcounts"></a>
# **GetTrackedEmailCounts**
> InlineResponse20027 GetTrackedEmailCounts (string accept, string xTrxApiKey, string tag = null, string fromdate = null, string todate = null)

Get tracked email counts (Gets a total count of emails you’ve sent with open tracking or link tracking enabled.)

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
    public class GetTrackedEmailCountsExample
    {
        public void main()
        {
            var apiInstance = new StatsAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var fromdate = fromdate_example;  // string | - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  (optional) 
            var todate = todate_example;  // string | - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Get tracked email counts (Gets a total count of emails you’ve sent with open tracking or link tracking enabled.)
                InlineResponse20027 result = apiInstance.GetTrackedEmailCounts(accept, xTrxApiKey, tag, fromdate, todate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatsAPIApi.GetTrackedEmailCounts: " + e.Message );
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
 **tag** | **string**| - Filter by tag  | [optional] 
 **fromdate** | **string**| - Filter stats starting from the date specified (inclusive). e.g. 2014-01-01.  | [optional] 
 **todate** | **string**| - Filter stats up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20027**](InlineResponse20027.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

