using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace prjDemoLINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// LINQ TO OBJECT
        /// </summary>

        class HocSinh
        {
            public string MaSo { get; set; }
            public string Ten { get; set; }
            public int NamSinh { get; set; }
            public string MaLop { get; set; }

        }

        //Data source
        List<HocSinh> hocsinhlist = new List<HocSinh>
        {
            new HocSinh{MaSo="123", Ten="Nguyễn Văn A", NamSinh=1995, MaLop="A111" },
            new HocSinh{MaSo="124", Ten="Trần Thị B", NamSinh=1993, MaLop="A113" },
            new HocSinh{MaSo="125", Ten="Huỳnh Thu C", NamSinh=1995, MaLop="A111" },
            new HocSinh{MaSo="126", Ten="Hoàng Nam", NamSinh=1997, MaLop="A114" }
        };


        private void LINQObject_Click(object sender, EventArgs e)
        {
            //Query creation
            var lstTen = from hs in hocsinhlist select new
            {
                Ten = hs.Ten
            };


            //Query Execution       
            dataGridView.DataSource = lstTen.ToList();
        }



        /// <summary>
        /// LINQ TO XML
        /// </summary>

        //Data source
        XElement hocsinhs =
            new XElement("Hocsinhs",
                new XElement(
                    "Hocsinh",
                    new XElement("MaSo", "123" ),
                    new XElement("Ten", "Nguyễn Văn A"),
                    new XElement("NamSinh", 1995),
                    new XElement("MaLop", "A111")
                    ),
                new XElement(
                    "Hocsinh",
                    new XElement("MaSo", "124"),
                    new XElement("Ten", "Trần Thị B"),
                    new XElement("NamSinh", 1993),
                    new XElement("MaLop", "A113")
                    ),
                 new XElement(
                    "Hocsinh",
                    new XElement("MaSo", "125"),
                    new XElement("Ten", "Huỳnh Thu C"),
                    new XElement("NamSinh", 1995),
                    new XElement("MaLop", "A111")
                    ),
                 new XElement(
                    "Hocsinh",
                    new XElement("MaSo", "126"),
                    new XElement("Ten", "Hoàng Nam"),
                    new XElement("NamSinh", 1997),
                    new XElement("MaLop", "A114")
                    )
                );

        private void LINQXML_Click(object sender, EventArgs e)
        {
            //Query creation
            var ten_xml = from hs in hocsinhs.Descendants("Ten")
                          select new
                          {
                              Ten = hs.Value
                          };

            //Query Execution
            dataGridView.DataSource = ten_xml.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
        }
    }
}
