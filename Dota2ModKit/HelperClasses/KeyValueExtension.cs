using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVLib;

namespace Dota2ModKit.HelperClasses
{
    public static class KeyValueExtension
    {
        private const char FlattenChar = '|';

        public static KeyValue ToFlat(this KeyValue toFlat)
        {
            KeyValue result = new KeyValue(toFlat.Key);
            foreach (KeyValue kv in toFlat.Children)
            {
                if (kv.HasChildren)
                {
                    var kvFlat = kv.ToFlat();
                    foreach (var kvFlatChild in kvFlat.Children)
                    {
                        var helper = new KeyValue(kv.Key + FlattenChar + kvFlatChild.Key);
                        helper.Set(kvFlatChild.GetString());
                        result += helper;
                    }
                    continue;
                }
                result += kv;
            }
            return result;
        }

        public static KeyValue UnFlat(this KeyValue toUnFlat)
        {
            KeyValue result = new KeyValue(toUnFlat.Key);
            foreach (var kv in toUnFlat.Children)
            {
                if (kv.Key.Contains(FlattenChar))
                {
                    string key = kv.Key;
                    string superKey = string.Concat(kv.Key.TakeWhile(c => c != FlattenChar));
                    key = key.Replace(superKey + FlattenChar, "");
                    if (!result.HasKey(superKey))
                        result += new KeyValue(superKey);
                    result[superKey].AddChild(new KeyValue(key) + kv.GetString());
                }
                else
                {
                    result += kv;
                }
            }
            List<KeyValue> toRemove = new List<KeyValue>();
            List<KeyValue> toAdd = new List<KeyValue>();
            foreach (var child in result.Children)
            {
                if (child.HasChildren)
                {
                    toRemove.Add(child);
                    toAdd.Add(child.UnFlat());
                }
            }
            toRemove.ForEach(kv => result.RemoveChild(kv));
            result.AddChildren(toAdd);
            return result;
        }
    }
}
