# IO.Swagger.Api.MessagesAPIApi

All URIs are relative to *https://api.trx.icommarketing.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BypassRulesForBlockedInboundMessage**](MessagesAPIApi.md#bypassrulesforblockedinboundmessage) | **PUT** /messages/inbound/{messageid}/bypass | Bypass rules for a blocked inbound message
[**GetClicksForSingleMessage**](MessagesAPIApi.md#getclicksforsinglemessage) | **GET** /messages/outbound/clicks/{messageid} | Clicks for a single message
[**GetInboundMessageDetails**](MessagesAPIApi.md#getinboundmessagedetails) | **GET** /messages/inbound/{messageid}/details | Inbound message details
[**GetInboundMessageSearch**](MessagesAPIApi.md#getinboundmessagesearch) | **GET** /messages/inbound | Inbound message search
[**GetMessageClicks**](MessagesAPIApi.md#getmessageclicks) | **GET** /messages/outbound/clicks | Message clicks
[**GetMessageOpens**](MessagesAPIApi.md#getmessageopens) | **GET** /messages/outbound/opens | Message opens
[**GetOpensForSingleMessage**](MessagesAPIApi.md#getopensforsinglemessage) | **GET** /messages/outbound/opens/{messageid} | Opens for a single message
[**GetOutboundMessageDetails**](MessagesAPIApi.md#getoutboundmessagedetails) | **GET** /messages/outbound/{messageid}/details | Outbound message details
[**GetOutboundMessageDump**](MessagesAPIApi.md#getoutboundmessagedump) | **GET** /messages/outbound/{messageid}/dump | Outbound message dump
[**GetOutboundMessageSearch**](MessagesAPIApi.md#getoutboundmessagesearch) | **GET** /messages/outbound | Outbound message search
[**RetryFailedInboundMessageForProcessing**](MessagesAPIApi.md#retryfailedinboundmessageforprocessing) | **PUT** /messages/inbound/{messageid}/retry | Retry a failed inbound message for processing


<a name="bypassrulesforblockedinboundmessage"></a>
# **BypassRulesForBlockedInboundMessage**
> InlineResponse20018 BypassRulesForBlockedInboundMessage (string accept, string xTrxApiKey, int? messageid)

Bypass rules for a blocked inbound message

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
    public class BypassRulesForBlockedInboundMessageExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 

            try
            {
                // Bypass rules for a blocked inbound message
                InlineResponse20018 result = apiInstance.BypassRulesForBlockedInboundMessage(accept, xTrxApiKey, messageid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.BypassRulesForBlockedInboundMessage: " + e.Message );
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
 **messageid** | **int?**|  | 

### Return type

[**InlineResponse20018**](InlineResponse20018.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getclicksforsinglemessage"></a>
# **GetClicksForSingleMessage**
> InlineResponse20022 GetClicksForSingleMessage (string accept, string xTrxApiKey, int? messageid, int? count, int? offset)

Clicks for a single message

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
    public class GetClicksForSingleMessageExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 
            var count = 56;  // int? | - Number of message opens to return per request. Max 500. 
            var offset = 56;  // int? | - Number of messages to skip 

            try
            {
                // Clicks for a single message
                InlineResponse20022 result = apiInstance.GetClicksForSingleMessage(accept, xTrxApiKey, messageid, count, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetClicksForSingleMessage: " + e.Message );
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
 **messageid** | **int?**|  | 
 **count** | **int?**| - Number of message opens to return per request. Max 500.  | 
 **offset** | **int?**| - Number of messages to skip  | 

### Return type

[**InlineResponse20022**](InlineResponse20022.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getinboundmessagedetails"></a>
# **GetInboundMessageDetails**
> InlineResponse20017 GetInboundMessageDetails (string accept, string xTrxApiKey, int? messageid)

Inbound message details

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
    public class GetInboundMessageDetailsExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 

            try
            {
                // Inbound message details
                InlineResponse20017 result = apiInstance.GetInboundMessageDetails(accept, xTrxApiKey, messageid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetInboundMessageDetails: " + e.Message );
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
 **messageid** | **int?**|  | 

### Return type

[**InlineResponse20017**](InlineResponse20017.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getinboundmessagesearch"></a>
# **GetInboundMessageSearch**
> InlineResponse20016 GetInboundMessageSearch (string accept, string xTrxApiKey, int? count, int? offset, string recipient = null, string fromemail = null, string tag = null, string subject = null, string mailboxhash = null, string status = null, string todate = null, string fromdate = null)

Inbound message search

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
    public class GetInboundMessageSearchExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of records to return per request. Max 500. 
            var offset = 56;  // int? | - Number of records to skip. 
            var recipient = recipient_example;  // string | - Filter by the user who was receiving the email.  (optional) 
            var fromemail = fromemail_example;  // string | - Filter by the sender email address.  (optional) 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var subject = subject_example;  // string | - Filter by email subject.  (optional) 
            var mailboxhash = mailboxhash_example;  // string | - Filter by mailboxhash.  (optional) 
            var status = status_example;  // string | - Filter by status (blocked, processed / sent, queued, failed, scheduled)  (optional) 
            var todate = todate_example;  // string | - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 
            var fromdate = fromdate_example;  // string | - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Inbound message search
                InlineResponse20016 result = apiInstance.GetInboundMessageSearch(accept, xTrxApiKey, count, offset, recipient, fromemail, tag, subject, mailboxhash, status, todate, fromdate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetInboundMessageSearch: " + e.Message );
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
 **count** | **int?**| - Number of records to return per request. Max 500.  | 
 **offset** | **int?**| - Number of records to skip.  | 
 **recipient** | **string**| - Filter by the user who was receiving the email.  | [optional] 
 **fromemail** | **string**| - Filter by the sender email address.  | [optional] 
 **tag** | **string**| - Filter by tag  | [optional] 
 **subject** | **string**| - Filter by email subject.  | [optional] 
 **mailboxhash** | **string**| - Filter by mailboxhash.  | [optional] 
 **status** | **string**| - Filter by status (blocked, processed / sent, queued, failed, scheduled)  | [optional] 
 **todate** | **string**| - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 
 **fromdate** | **string**| - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20016**](InlineResponse20016.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmessageclicks"></a>
# **GetMessageClicks**
> InlineResponse20022 GetMessageClicks (string accept, string xTrxApiKey, int? count, int? offset, string recipient = null, string tag = null, string clientName = null, string clientCompany = null, string clientFamily = null, string osName = null, string osFamily = null, string osCompany = null, string platform = null, string country = null, string region = null, string city = null)

Message clicks

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
    public class GetMessageClicksExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of message opens to return per request. Max 500. 
            var offset = 56;  // int? | - Number of messages to skip 
            var recipient = recipient_example;  // string | - Filter by To, Cc, Bcc  (optional) 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var clientName = clientName_example;  // string | - Filter by client name, i.e. Outlook, Gmail  (optional) 
            var clientCompany = clientCompany_example;  // string | - Filter by company, i.e. Microsoft, Apple, Google  (optional) 
            var clientFamily = clientFamily_example;  // string | - Filter by client family, i.e. OS X, Chrome  (optional) 
            var osName = osName_example;  // string | - Filter by full OS name and specific version, i.e. OS X 10.9 Mavericks, Windows 7  (optional) 
            var osFamily = osFamily_example;  // string | - Filter by kind of OS used without specific version, i.e. OS X, Windows  (optional) 
            var osCompany = osCompany_example;  // string | - Filter by company which produced the OS, i.e. Apple Computer, Inc., Microsoft Corporation  (optional) 
            var platform = platform_example;  // string | - Filter by platform, i.e. webmail, desktop, mobile  (optional) 
            var country = country_example;  // string | - Filter by country messages were opened in, i.e. Denmark, Russia  (optional) 
            var region = region_example;  // string | - Filter by full name of region messages were opened in, i.e. Moscow, New York  (optional) 
            var city = city_example;  // string | - Filter by full name of city messages were opened in, i.e. Minneapolis, Philadelphia  (optional) 

            try
            {
                // Message clicks
                InlineResponse20022 result = apiInstance.GetMessageClicks(accept, xTrxApiKey, count, offset, recipient, tag, clientName, clientCompany, clientFamily, osName, osFamily, osCompany, platform, country, region, city);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetMessageClicks: " + e.Message );
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
 **count** | **int?**| - Number of message opens to return per request. Max 500.  | 
 **offset** | **int?**| - Number of messages to skip  | 
 **recipient** | **string**| - Filter by To, Cc, Bcc  | [optional] 
 **tag** | **string**| - Filter by tag  | [optional] 
 **clientName** | **string**| - Filter by client name, i.e. Outlook, Gmail  | [optional] 
 **clientCompany** | **string**| - Filter by company, i.e. Microsoft, Apple, Google  | [optional] 
 **clientFamily** | **string**| - Filter by client family, i.e. OS X, Chrome  | [optional] 
 **osName** | **string**| - Filter by full OS name and specific version, i.e. OS X 10.9 Mavericks, Windows 7  | [optional] 
 **osFamily** | **string**| - Filter by kind of OS used without specific version, i.e. OS X, Windows  | [optional] 
 **osCompany** | **string**| - Filter by company which produced the OS, i.e. Apple Computer, Inc., Microsoft Corporation  | [optional] 
 **platform** | **string**| - Filter by platform, i.e. webmail, desktop, mobile  | [optional] 
 **country** | **string**| - Filter by country messages were opened in, i.e. Denmark, Russia  | [optional] 
 **region** | **string**| - Filter by full name of region messages were opened in, i.e. Moscow, New York  | [optional] 
 **city** | **string**| - Filter by full name of city messages were opened in, i.e. Minneapolis, Philadelphia  | [optional] 

### Return type

[**InlineResponse20022**](InlineResponse20022.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmessageopens"></a>
# **GetMessageOpens**
> InlineResponse20020 GetMessageOpens (string accept, string xTrxApiKey, int? count, int? offset, string recipient = null, string tag = null, string clientName = null, string clientCompany = null, string clientFamily = null, string osName = null, string osFamily = null, string osCompany = null, string platform = null, string country = null, string region = null, string city = null)

Message opens

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
    public class GetMessageOpensExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of message opens to return per request. Max 500. 
            var offset = 56;  // int? | - Number of messages to skip 
            var recipient = recipient_example;  // string | - Filter by To, Cc, Bcc  (optional) 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var clientName = clientName_example;  // string | - Filter by client name, i.e. Outlook, Gmail  (optional) 
            var clientCompany = clientCompany_example;  // string | - Filter by company, i.e. Microsoft, Apple, Google  (optional) 
            var clientFamily = clientFamily_example;  // string | - Filter by client family, i.e. OS X, Chrome  (optional) 
            var osName = osName_example;  // string | - Filter by full OS name and specific version, i.e. OS X 10.9 Mavericks, Windows 7  (optional) 
            var osFamily = osFamily_example;  // string | - Filter by kind of OS used without specific version, i.e. OS X, Windows  (optional) 
            var osCompany = osCompany_example;  // string | - Filter by company which produced the OS, i.e. Apple Computer, Inc., Microsoft Corporation  (optional) 
            var platform = platform_example;  // string | - Filter by platform, i.e. webmail, desktop, mobile  (optional) 
            var country = country_example;  // string | - Filter by country messages were opened in, i.e. Denmark, Russia  (optional) 
            var region = region_example;  // string | - Filter by full name of region messages were opened in, i.e. Moscow, New York  (optional) 
            var city = city_example;  // string | - Filter by full name of city messages were opened in, i.e. Minneapolis, Philadelphia  (optional) 

            try
            {
                // Message opens
                InlineResponse20020 result = apiInstance.GetMessageOpens(accept, xTrxApiKey, count, offset, recipient, tag, clientName, clientCompany, clientFamily, osName, osFamily, osCompany, platform, country, region, city);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetMessageOpens: " + e.Message );
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
 **count** | **int?**| - Number of message opens to return per request. Max 500.  | 
 **offset** | **int?**| - Number of messages to skip  | 
 **recipient** | **string**| - Filter by To, Cc, Bcc  | [optional] 
 **tag** | **string**| - Filter by tag  | [optional] 
 **clientName** | **string**| - Filter by client name, i.e. Outlook, Gmail  | [optional] 
 **clientCompany** | **string**| - Filter by company, i.e. Microsoft, Apple, Google  | [optional] 
 **clientFamily** | **string**| - Filter by client family, i.e. OS X, Chrome  | [optional] 
 **osName** | **string**| - Filter by full OS name and specific version, i.e. OS X 10.9 Mavericks, Windows 7  | [optional] 
 **osFamily** | **string**| - Filter by kind of OS used without specific version, i.e. OS X, Windows  | [optional] 
 **osCompany** | **string**| - Filter by company which produced the OS, i.e. Apple Computer, Inc., Microsoft Corporation  | [optional] 
 **platform** | **string**| - Filter by platform, i.e. webmail, desktop, mobile  | [optional] 
 **country** | **string**| - Filter by country messages were opened in, i.e. Denmark, Russia  | [optional] 
 **region** | **string**| - Filter by full name of region messages were opened in, i.e. Moscow, New York  | [optional] 
 **city** | **string**| - Filter by full name of city messages were opened in, i.e. Minneapolis, Philadelphia  | [optional] 

### Return type

[**InlineResponse20020**](InlineResponse20020.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getopensforsinglemessage"></a>
# **GetOpensForSingleMessage**
> InlineResponse20021 GetOpensForSingleMessage (string accept, string xTrxApiKey, int? messageid, int? count, int? offset)

Opens for a single message

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
    public class GetOpensForSingleMessageExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 
            var count = 56;  // int? | - Number of message opens to return per request. Max 500. 
            var offset = 56;  // int? | - Number of messages to skip 

            try
            {
                // Opens for a single message
                InlineResponse20021 result = apiInstance.GetOpensForSingleMessage(accept, xTrxApiKey, messageid, count, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetOpensForSingleMessage: " + e.Message );
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
 **messageid** | **int?**|  | 
 **count** | **int?**| - Number of message opens to return per request. Max 500.  | 
 **offset** | **int?**| - Number of messages to skip  | 

### Return type

[**InlineResponse20021**](InlineResponse20021.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoutboundmessagedetails"></a>
# **GetOutboundMessageDetails**
> InlineResponse20014 GetOutboundMessageDetails (string accept, string xTrxApiKey, int? messageid)

Outbound message details

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
    public class GetOutboundMessageDetailsExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 

            try
            {
                // Outbound message details
                InlineResponse20014 result = apiInstance.GetOutboundMessageDetails(accept, xTrxApiKey, messageid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetOutboundMessageDetails: " + e.Message );
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
 **messageid** | **int?**|  | 

### Return type

[**InlineResponse20014**](InlineResponse20014.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoutboundmessagedump"></a>
# **GetOutboundMessageDump**
> InlineResponse20015 GetOutboundMessageDump (string accept, string xTrxApiKey, int? messageid)

Outbound message dump

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
    public class GetOutboundMessageDumpExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 

            try
            {
                // Outbound message dump
                InlineResponse20015 result = apiInstance.GetOutboundMessageDump(accept, xTrxApiKey, messageid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetOutboundMessageDump: " + e.Message );
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
 **messageid** | **int?**|  | 

### Return type

[**InlineResponse20015**](InlineResponse20015.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoutboundmessagesearch"></a>
# **GetOutboundMessageSearch**
> InlineResponse20013 GetOutboundMessageSearch (string accept, string xTrxApiKey, int? count, int? offset, string subject, string recipient = null, string fromemail = null, string tag = null, string status = null, string todate = null, string fromdate = null)

Outbound message search

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
    public class GetOutboundMessageSearchExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var count = 56;  // int? | - Number of records to return per request. Max 500. 
            var offset = 56;  // int? | - Number of records to skip. 
            var subject = subject_example;  // string | - Filter by email subject. 
            var recipient = recipient_example;  // string | - Filter by the user who was receiving the email.  (optional) 
            var fromemail = fromemail_example;  // string | - Filter by the sender email address.  (optional) 
            var tag = tag_example;  // string | - Filter by tag  (optional) 
            var status = status_example;  // string | - Filter by status (queued or sent / processed). Note that sent and processed will return the same results and can be used interchangeably.  (optional) 
            var todate = todate_example;  // string | - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.  (optional) 
            var fromdate = fromdate_example;  // string | - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  (optional) 

            try
            {
                // Outbound message search
                InlineResponse20013 result = apiInstance.GetOutboundMessageSearch(accept, xTrxApiKey, count, offset, subject, recipient, fromemail, tag, status, todate, fromdate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.GetOutboundMessageSearch: " + e.Message );
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
 **count** | **int?**| - Number of records to return per request. Max 500.  | 
 **offset** | **int?**| - Number of records to skip.  | 
 **subject** | **string**| - Filter by email subject.  | 
 **recipient** | **string**| - Filter by the user who was receiving the email.  | [optional] 
 **fromemail** | **string**| - Filter by the sender email address.  | [optional] 
 **tag** | **string**| - Filter by tag  | [optional] 
 **status** | **string**| - Filter by status (queued or sent / processed). Note that sent and processed will return the same results and can be used interchangeably.  | [optional] 
 **todate** | **string**| - Filter messages up to the date specified (inclusive). e.g. 2014-02-01.  | [optional] 
 **fromdate** | **string**| - Filter messages starting from the date specified (inclusive). e.g. 2014-02-01.  | [optional] 

### Return type

[**InlineResponse20013**](InlineResponse20013.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retryfailedinboundmessageforprocessing"></a>
# **RetryFailedInboundMessageForProcessing**
> InlineResponse20019 RetryFailedInboundMessageForProcessing (string accept, string xTrxApiKey, int? messageid)

Retry a failed inbound message for processing

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
    public class RetryFailedInboundMessageForProcessingExample
    {
        public void main()
        {
            var apiInstance = new MessagesAPIApi();
            var accept = accept_example;  // string | - application/json 
            var xTrxApiKey = xTrxApiKey_example;  // string | - Find your API KEY in your ICOMMKT Account 
            var messageid = 56;  // int? | 

            try
            {
                // Retry a failed inbound message for processing
                InlineResponse20019 result = apiInstance.RetryFailedInboundMessageForProcessing(accept, xTrxApiKey, messageid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessagesAPIApi.RetryFailedInboundMessageForProcessing: " + e.Message );
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
 **messageid** | **int?**|  | 

### Return type

[**InlineResponse20019**](InlineResponse20019.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

