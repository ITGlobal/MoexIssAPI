using System;
using System.Collections.Generic;
using System.Linq;
using MoexIssAPI.Requests;
using Newtonsoft.Json;
using Xunit;

namespace MoexIssAPI.Test
{
    /// <summary>
    /// ������������ �������� ��������
    /// </summary>
    public class MainRequestsTests
    {
        /// <summary>
        /// ������������ ��������� ������ �������� ������
        /// </summary>
        [Fact]
        public void EnginesListTest()
        {
            var request = new EnginesRequest();
            Assert.Equal(7, request.Response.Engines.Data.Count);
        }

        /// <summary>
        /// ������������ ��������� ������ ������ ����� �� �������� ������
        /// </summary>
        [Fact]
        public void MarketsListTest()
        {
            var marketsRequest = new MarketsRequest("stock");
            Assert.Equal(13, marketsRequest.Response.Markets.Data.Count);

            marketsRequest = new MarketsRequest("futures");
            Assert.Equal(5, marketsRequest.Response.Markets.Data.Count);
        }

        /// <summary>
        /// ������������ ��������� ������ ������������ �����
        /// </summary>
        //[Fact]
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

                    var secDetailsRequest = new SecurityDetailsRequest("stock", "bonds", sec["SECID"]);
                }
            }
        }

        [Fact]
        public void FuturesListTest()
        {
            var request = new MarketSecuritiesListRequest("futures", "forts");
            var futures = request.Response.Securities;
            Assert.True(futures.Data.Count>150);
            request = new MarketSecuritiesListRequest("futures", "options");
            var options = request.Response.Securities;
            Assert.True(options.Data.Count>8500);
        }



        [Fact]
        public void FuturesDefinitionAndDetailsTest()
        {
            var request = new MarketSecuritiesListRequest("futures", "forts");
            var futures = request.Response.Securities.Data[0];
            var secDefRequest = new SecurityDefinitionRequest(futures["SECID"]);
            var secDetailsRequest = new SecurityDetailsRequest("futures", "forts", futures["SECID"]);
        }


        [Fact]
        public void SecurityHistoryTest()
        {
            var req = new SecurityHistoryRequest("stock", "bonds", "SU26208RMFS7");
            var resp = req.Response;
            Assert.Equal(3166, resp.Object.Data.Count);

            req = new SecurityHistoryRequest("stock", "bonds", "TQOB", "SU26208RMFS7");
            resp = req.Response;
            Assert.Equal(1494, resp.Object.Data.Count);

        }

        [Fact]
        public void BondCouponsTest()
        {
            var req = new BondCouponsRequest("SU26208RMFS7");
            Assert.Equal(14, req.Response.Coupons.Data.Count);
        }

    }
}
