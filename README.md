# MoexIssAPI

# Usage

get engines list

```csharp
var engines = new EnginesRequest().Response.Engines.Data;
```

get markets list

```csharp
var markets = new MarketsRequest(engine).Response.Markets.Data;
```

get securities list

```csharp
var securities = new MarketSecuritiesListRequest(engine, market).Response.Securities.Data;
```

get security history data

```csharp
var history = new SecurityHistoryRequest(engine,market, security).Response.Object.Data;
```
or 

```csharp
var history = new SecurityHistoryRequest(engine,market,board,security).Response.Object.Data;
```

