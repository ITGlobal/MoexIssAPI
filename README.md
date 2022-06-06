MoexIssAPI

# Usage

get engines list

```csharp
var engines = (await new EnginesRequest().Get()).Engines.Data;
```

get markets list

```csharp
var markets = (await new MarketsRequest(engine).Get()).Markets.Data;
```

get securities list

```csharp
var securities = (await new MarketSecuritiesListRequest(engine, market).Get()).Securities.Data;
```

get security history data

```csharp
var history = (await new SecurityHistoryRequest(engine,market, security).Get()).Object.Data;
```
or 

```csharp
var history = (await new SecurityHistoryRequest(engine,market,board,security).Get()).Object.Data;
```
bond coupons

```csharp
var history = (await new BondCopunsRequest(security).Get()).Coupons.Data;
```
