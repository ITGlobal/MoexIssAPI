using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MoexIssAPI.Helper;

public static class QueryHelper {
    public static string Compile(dynamic query) {
        if(query == null) return "";

        object obj = query;
        var values = obj.GetType().GetProperties();
        var result = string.Join('&', 
            values.Select(_ => KeyValuePair.Create(_.Name, _.GetValue(obj)))
                .Where(_ => _.Value != null)
                .Select(_ => {
                    if(_.Value is DateTime) {
                        return $"{_.Key}={_.Value:yyyy-MM-dd}";
                    }
                    return $"{_.Key}={_.Value}";
                })
        );
        if(string.IsNullOrEmpty(result)) return "";
        return $"?{result}";
    }


    public static string CompileDict(IDictionary<string, object> query) {
        if(query == null) return "";

        var result = string.Join('&', 
            query
                .Where(_ => _.Value != null)
                .Select(_ => {
                    if(_.Value is DateTime) {
                        return $"{_.Key}={_.Value:yyyy-MM-dd}";
                    }
                    return $"{_.Key}={_.Value}";
                })
        );
        if(string.IsNullOrEmpty(result)) return "";
        return $"?{result}";
    }
}