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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing InboundRulesTriggersAPIApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class InboundRulesTriggersAPIApiTests
    {
        private InboundRulesTriggersAPIApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new InboundRulesTriggersAPIApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of InboundRulesTriggersAPIApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' InboundRulesTriggersAPIApi
            //Assert.IsInstanceOfType(typeof(InboundRulesTriggersAPIApi), instance, "instance is a InboundRulesTriggersAPIApi");
        }

        
        /// <summary>
        /// Test CreateInboundRuleTrigger
        /// </summary>
        [Test]
        public void CreateInboundRuleTriggerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string contentType = null;
            //string accept = null;
            //string xTrxApiKey = null;
            //CreateInboundRuleTrigger body = null;
            //var response = instance.CreateInboundRuleTrigger(contentType, accept, xTrxApiKey, body);
            //Assert.IsInstanceOf<InlineResponse20042> (response, "response is InlineResponse20042");
        }
        
        /// <summary>
        /// Test DeleteSingleTrigger
        /// </summary>
        [Test]
        public void DeleteSingleTriggerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? triggerid = null;
            //string accept = null;
            //string xTrxApiKey = null;
            //var response = instance.DeleteSingleTrigger(triggerid, accept, xTrxApiKey);
            //Assert.IsInstanceOf<InlineResponse20043> (response, "response is InlineResponse20043");
        }
        
        /// <summary>
        /// Test GetInboundRuleTriggers
        /// </summary>
        [Test]
        public void GetInboundRuleTriggersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string accept = null;
            //string xTrxApiKey = null;
            //int? count = null;
            //int? offset = null;
            //var response = instance.GetInboundRuleTriggers(accept, xTrxApiKey, count, offset);
            //Assert.IsInstanceOf<InlineResponse20041> (response, "response is InlineResponse20041");
        }
        
    }

}