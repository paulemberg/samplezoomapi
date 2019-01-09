using System.Collections.Generic;

namespace DashZoomApp.Models
{
    public class RoomsViewModel
    {
        public class ZoomRoom
        {
            public string id { get; set; }
            public string room_name { get; set; }
            public string calender_name { get; set; }
            public string email { get; set; }
            public string account_type { get; set; }
            public string status { get; set; }
            public string device_ip { get; set; }
            public string camera { get; set; }
            public string microphone { get; set; }
            public string speaker { get; set; }
            public string last_start_time { get; set; }
        }

        public class ZooObject
        {
            public string page_count { get; set; }
            public string page_number { get; set; }
            public string page_size { get; set; }
            public string total_records { get; set; }
            public List<ZoomRoom> zoom_rooms { get; set; }
        }
    }
}