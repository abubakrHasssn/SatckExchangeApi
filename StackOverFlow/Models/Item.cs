using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Models
{
    public class Item
    {
        public List<string> tags { get; set; }
        public Owner owner { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
        public int last_edit_date { get; set; }
        public int question_id { get; set; }
        public string content_license { get; set; }
        public string link { get; set; }
        public string title { get; set; }

        [AllowHtml]
        public string body { get; set; }

    }
}