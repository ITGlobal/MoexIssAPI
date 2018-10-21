using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace MoexIssAPI.Test
{
    public class IssResponsePayloadTests
    {
        [Fact]
        public void DeserializationTest()
        {
            var request = new EnginesRequest();
            foreach (var engine in request.Response.Engines.Data)
            {
                var marketsRequest = new MarketsRequest(engine["name"]);
                var response = marketsRequest.Response;
            }
        }

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
