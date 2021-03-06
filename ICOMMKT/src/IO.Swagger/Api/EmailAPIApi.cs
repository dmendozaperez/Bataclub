/* 
 * ICOMMKT Transactional API
 *
 * ICOMMKT Transactional API
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEmailAPIApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Send batch emails
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>InlineResponse2001</returns>
        InlineResponse2001 PostemailBatch (string accept, string xTrxApiKey, BatchEmail body);

        /// <summary>
        /// Send batch emails
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        ApiResponse<InlineResponse2001> PostemailBatchWithHttpInfo (string accept, string xTrxApiKey, BatchEmail body);
        /// <summary>
        /// Send a single email
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 PostemailSingle (string contentType, string xTrxApiKey, EmailBody body);

        /// <summary>
        /// Send a single email
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> PostemailSingleWithHttpInfo (string contentType, string xTrxApiKey, EmailBody body);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Send batch emails
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of InlineResponse2001</returns>
        System.Threading.Tasks.Task<InlineResponse2001> PostemailBatchAsync (string accept, string xTrxApiKey, BatchEmail body);

        /// <summary>
        /// Send batch emails
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> PostemailBatchAsyncWithHttpInfo (string accept, string xTrxApiKey, BatchEmail body);
        /// <summary>
        /// Send a single email
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> PostemailSingleAsync (string contentType, string xTrxApiKey, EmailBody body);

        /// <summary>
        /// Send a single email
        /// </summary>
        /// <remarks>
        /// Authorization: Bearer X-Trx-Api-Key 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> PostemailSingleAsyncWithHttpInfo (string contentType, string xTrxApiKey, EmailBody body);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class EmailAPIApi : IEmailAPIApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public EmailAPIApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAPIApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public EmailAPIApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Send batch emails Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>InlineResponse2001</returns>
        public InlineResponse2001 PostemailBatch (string accept, string xTrxApiKey, BatchEmail body)
        {
             ApiResponse<InlineResponse2001> localVarResponse = PostemailBatchWithHttpInfo(accept, xTrxApiKey, body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Send batch emails Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        public ApiResponse< InlineResponse2001 > PostemailBatchWithHttpInfo (string accept, string xTrxApiKey, BatchEmail body)
        {
            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling EmailAPIApi->PostemailBatch");
            // verify the required parameter 'xTrxApiKey' is set
            if (xTrxApiKey == null)
                throw new ApiException(400, "Missing required parameter 'xTrxApiKey' when calling EmailAPIApi->PostemailBatch");
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling EmailAPIApi->PostemailBatch");

            var localVarPath = "/email/batch";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (accept != null) localVarHeaderParams.Add("Accept", this.Configuration.ApiClient.ParameterToString(accept)); // header parameter
            if (xTrxApiKey != null) localVarHeaderParams.Add("X-Trx-Api-Key", this.Configuration.ApiClient.ParameterToString(xTrxApiKey)); // header parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PostemailBatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// Send batch emails Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of InlineResponse2001</returns>
        public async System.Threading.Tasks.Task<InlineResponse2001> PostemailBatchAsync (string accept, string xTrxApiKey, BatchEmail body)
        {
             ApiResponse<InlineResponse2001> localVarResponse = await PostemailBatchAsyncWithHttpInfo(accept, xTrxApiKey, body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Send batch emails Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accept">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of ApiResponse (InlineResponse2001)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2001>> PostemailBatchAsyncWithHttpInfo (string accept, string xTrxApiKey, BatchEmail body)
        {
            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling EmailAPIApi->PostemailBatch");
            // verify the required parameter 'xTrxApiKey' is set
            if (xTrxApiKey == null)
                throw new ApiException(400, "Missing required parameter 'xTrxApiKey' when calling EmailAPIApi->PostemailBatch");
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling EmailAPIApi->PostemailBatch");

            var localVarPath = "/email/batch";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (accept != null) localVarHeaderParams.Add("Accept", this.Configuration.ApiClient.ParameterToString(accept)); // header parameter
            if (xTrxApiKey != null) localVarHeaderParams.Add("X-Trx-Api-Key", this.Configuration.ApiClient.ParameterToString(xTrxApiKey)); // header parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PostemailBatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2001>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse2001) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2001)));
        }

        /// <summary>
        /// Send a single email Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 PostemailSingle (string contentType, string xTrxApiKey, EmailBody body)
        {
             ApiResponse<InlineResponse200> localVarResponse = PostemailSingleWithHttpInfo(contentType, xTrxApiKey, body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Send a single email Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse< InlineResponse200 > PostemailSingleWithHttpInfo (string contentType, string xTrxApiKey, EmailBody body)
        {
            // verify the required parameter 'contentType' is set
            if (contentType == null)
                throw new ApiException(400, "Missing required parameter 'contentType' when calling EmailAPIApi->PostemailSingle");
            // verify the required parameter 'xTrxApiKey' is set
            if (xTrxApiKey == null)
                throw new ApiException(400, "Missing required parameter 'xTrxApiKey' when calling EmailAPIApi->PostemailSingle");
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling EmailAPIApi->PostemailSingle");

            var localVarPath = "/email";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (contentType != null) localVarHeaderParams.Add("Content-Type", this.Configuration.ApiClient.ParameterToString(contentType)); // header parameter
            if (xTrxApiKey != null) localVarHeaderParams.Add("X-Trx-Api-Key", this.Configuration.ApiClient.ParameterToString(xTrxApiKey)); // header parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PostemailSingle", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

        /// <summary>
        /// Send a single email Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> PostemailSingleAsync (string contentType, string xTrxApiKey, EmailBody body)
        {
             ApiResponse<InlineResponse200> localVarResponse = await PostemailSingleAsyncWithHttpInfo(contentType, xTrxApiKey, body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Send a single email Authorization: Bearer X-Trx-Api-Key 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="contentType">- application/json </param>
        /// <param name="xTrxApiKey">- Find your API KEY in your ICOMMKT Account </param>
        /// <param name="body">Email body</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> PostemailSingleAsyncWithHttpInfo (string contentType, string xTrxApiKey, EmailBody body)
        {
            // verify the required parameter 'contentType' is set
            if (contentType == null)
                throw new ApiException(400, "Missing required parameter 'contentType' when calling EmailAPIApi->PostemailSingle");
            // verify the required parameter 'xTrxApiKey' is set
            if (xTrxApiKey == null)
                throw new ApiException(400, "Missing required parameter 'xTrxApiKey' when calling EmailAPIApi->PostemailSingle");
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling EmailAPIApi->PostemailSingle");

            var localVarPath = "/email";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json", 
                "application/x-www-form-urlencoded"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (contentType != null) localVarHeaderParams.Add("Content-Type", this.Configuration.ApiClient.ParameterToString(contentType)); // header parameter
            if (xTrxApiKey != null) localVarHeaderParams.Add("X-Trx-Api-Key", this.Configuration.ApiClient.ParameterToString(xTrxApiKey)); // header parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PostemailSingle", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

    }
}
