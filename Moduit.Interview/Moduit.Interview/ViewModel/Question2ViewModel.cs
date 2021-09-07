using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.ViewModel
{
    public class Question2ViewModel
    {
        public string id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public string[]? tags { get; set; }
        public DateTime createdAt { get; set; }
    }
}
