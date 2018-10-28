using System;
using System.Collections.Generic;
using System.Linq;
using MoexIssAPI.Requests;
using Newtonsoft.Json;
using Xunit;

namespace MoexIssAPI.Test
{
    /// <summary>
    /// “естирование основных запросов
    /// </summary>
    public class MainRequestsTests
    {
        /// <summary>
        /// “естирование получени€ списка торговых систем
        /// </summary>
        [Fact]
        public void EnginesListTest()
        {
            var request = new EnginesRequest();
            Assert.Equal(6, request.Response.Engines.Data.Count);
        }

        /// <summary>
        /// “естирование получение списка рынков одной из торговых систем
        /// </summary>
        [Fact]
        public void MarketsListTest()
        {
            var marketsRequest = new MarketsRequest("stock");
            Assert.Equal(13, marketsRequest.Response.Markets.Data.Count);
        }

        /// <summary>
        /// “естирование получение списка инструментов рынка
        /// </summary>
        [Fact]
        public void SecuritiesListTest()
        {
            var request = new MarketSecuritiesListRequest("stock", "bonds");
            var ofz = new List<Dictionary<string, string>>();
            var types = new List<string>();
            foreach (var sec in request.Response.Securities.Data)
            {
                var secType = sec["SECTYPE"];
                if (!types.Contains(secType))
                    types.Add(secType);

                if (secType == "3")
                {
                    ofz.Add(sec);
                    var secDefRequest = new SecurityDefinitionRequest(sec["SECID"]);
                    var type = secDefRequest.Response.Description.Data.FirstOrDefault(_ => _["name"] == "TYPE")["value"];
                    if (type != "ofz_bond")
                        ;
                }
            }
        }
    }
}
