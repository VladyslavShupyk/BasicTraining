using System;
using System.Collections.Generic;
namespace NET02._3
{
    [Serializable]
    class LogerDataJson
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public List<ListenerDataJson> Listeners { get; set; }
    }
}
