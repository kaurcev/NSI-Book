using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSI.Classes
{
    public class Combi
    {
        private Dictionary<string, ListItem> items = new Dictionary<string, ListItem>();

        public ListItem this[string key]
        {
            get
            {
                if (!items.ContainsKey(key))
                {
                    items[key] = new ListItem();
                }
                return items[key];
            }
        }
    }

    public class ListItem
    {
        public string Type { get; set; }
    }
}
