using System;
using System.Collections.Generic;

namespace Clockwork.Web.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
        }

        public List<CurrentTimeQuery> CurrentTimeQueries { get; set; }
    }
}
