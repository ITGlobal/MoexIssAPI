using MoexIssAPI.Helper;
using MoexIssAPI.Requests;
using Xunit;

namespace MoexIssAPI.Test
{
    /// <summary>
    /// Тестирование основных запросов
    /// </summary>
    public class MainRequestsTests
    {
        // private IWebProxy _proxy = new WebProxy(
        //     new Uri("socks5://130.193.43.137:3131"),
        //     true, 
        //     null, 
        //     new NetworkCredential("proxyuser", "")
        // );

        /// <summary>
        /// Тестирование получения списка торговых систем
        /// </summary>
        [Fact]
        public async Task EnginesListTest()
        {
            // var resp = await new EnginesRequest(webProxy: _proxy).Get();
            var resp = await new EnginesRequest().Get();
            Assert.Equal(9, resp.Engines.Data.Count);
        }

        /// <summary>
        /// Тестирование получение списка рынков одной из торговых систем
        /// </summary>
        [Fact]
        public async Task MarketsListTest()
        {
            var markets = await new MarketsRequest("stock").Get();
            Assert.Equal(17, markets.Markets.Data.Count);

            markets = await new MarketsRequest("futures").Get();
            Assert.Equal(5, markets.Markets.Data.Count);
        }

        /// <summary>
        /// Тестирование получение списка инструментов рынка
        /// </summary>
        //[Fact]
        public async Task SecuritiesListTest()
        {
            var response = await new MarketSecuritiesListRequest("stock", "bonds").Get();
            var ofz = new List<Dictionary<string, string>>();
            var types = new List<string>();
            foreach (var sec in response.Securities.Data)
            {
                var secType = sec["SECTYPE"];
                if (!types.Contains(secType))
                    types.Add(secType);

                if (secType == "3")
                {
                    ofz.Add(sec);
                    var secDefRequest = await new SecurityDefinitionRequest(sec["SECID"]).Get();
                    var type = secDefRequest.Description.Data.FirstOrDefault(_ => _["name"] == "TYPE")["value"];
                    var secDetailsRequest = await new SecurityDetailsRequest("stock", "bonds", sec["SECID"]).Get();
                }
            }
        }

        [Fact]
        public async Task FuturesListTest()
        {
            var response = await new MarketSecuritiesListRequest("futures", "forts").Get();
            var futures = response.Securities;
            Assert.True(futures.Data.Count > 300);
            response = await new MarketSecuritiesListRequest("futures", "options").Get();
            var options = response.Securities;
            Assert.True(options.Data.Count > 8500);
        }

        [Fact]
        public async Task FuturesDefinitionAndDetailsTest()
        {
            var request = await new MarketSecuritiesListRequest("futures", "forts").Get();
            var futures = request.Securities.Data[0];
            var secDefRequest = await new SecurityDefinitionRequest(futures["SECID"]).Get();
            var secDetailsRequest = await new SecurityDetailsRequest("futures", "forts", futures["SECID"]).Get();
        }


        [Fact]
        public async Task SecurityHistoryTest()
        {
            var resp = await new SecurityHistoryRequest("stock", "bonds", "SU26208RMFS7").Get();
            Assert.Equal(3166, resp.Object.Data.Count);
        }

        [Fact]
        public async Task ShouldGetOneSecurityTest()
        {
            var resp = await new SecurityHistoryRequest("stock", "bonds", "TQOB", "SU26208RMFS7").Get();
            Assert.Equal(1494, resp.Object.Data.Count);
        }

        [Fact]
        public async Task ShouldGetOneEngineMarketBoardSecurityTest()
        {
            var resp = await new EngineMarketBoardSecurityRequest("stock", "bonds", "TQBR", "SBER").Get();
            Assert.Equal(1, resp.Marketdata.Data.Count);
        }

        [Fact]
        public async Task BondCouponsTest()
        {
            var req = await new BondCouponsRequest("SU26208RMFS7", null).Get();
            Assert.Equal(14, req.Coupons.Data.Count);
        }

        
        [Fact]
        public void QueryHelperCompileTest()
        {
            string? undefined = null;
            var result = QueryHelper.Compile(new { some = "123", date = new DateTime(2000, 1, 1), undefined });
            Assert.Equal("?some=123&date=2000-01-01", result);
        }
    }
}
