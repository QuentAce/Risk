using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Risk
{
    public class LigneMonde
    {
        public List<MaZone> items = new List<MaZone>();

        public void Add(MaZone z)
        {
            items.Add(z);
        }
    }
}