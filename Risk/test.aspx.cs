using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int y=0;y<10;y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    Button bouton1 = new Button();
                    bouton1.ID = x.ToString() + "_" + y.ToString();
                    bouton1.Text = "";
                    bouton1.BackColor = System.Drawing.Color.GreenYellow;
                    bouton1.Click += bouton1_Click;
                    Panel1.Controls.Add(bouton1);
                }
                LiteralControl br = new LiteralControl();
                br.Text = "<br />";
                Panel1.Controls.Add(br);
            }
 
        }

        void bouton1_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            //bouton.BackColor = System.Drawing.Color.Red;

            if (bouton.BackColor == System.Drawing.Color.GreenYellow)
            {
                bouton.BackColor = System.Drawing.Color.Blue;
            }
            else
            {
                bouton.BackColor = System.Drawing.Color.GreenYellow;
            }
            
        }
    }
}