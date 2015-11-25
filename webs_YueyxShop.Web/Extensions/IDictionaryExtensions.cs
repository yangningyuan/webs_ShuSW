using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class IDictionaryExtensions
{
    public static IDictionary<string, object> DeepCopy(this IDictionary<string, object> ht)
    {
        Dictionary<string, object> _ht = new Dictionary<string, object>();

        foreach (var p in ht)
        {
            _ht.Add(p.Key, p.Value);
        }
        return _ht;
    }
}
