using System;
using System.Linq;
using System.Web.Mvc;

namespace Clockwork.Web.Models
{
    public class TimeZoneModel
    {
        public TimeZoneModel()
        {
            var tzs = TimeZoneInfo.GetSystemTimeZones();
            TimezoneList = tzs.Select(tz => new SelectListItem()
            {
                Text = tz.DisplayName,
                Value = tz.Id
            }).ToArray();
        }

        public SelectListItem[] TimezoneList { get; set; }
        public SelectListItem SelectedTimeZone { get; set; }

    }
}
