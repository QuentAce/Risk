using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Risk
{
    public class MaZone
    {
        public int x;
        public int y;
        public String nom { get; set; }
        public bool terrain = false;        // true=terrain   si false=eau

        public String style_css
        {
            get
            {
                if (terrain == false) return "terrain";
                return "eau";
            }
        }
    }
}