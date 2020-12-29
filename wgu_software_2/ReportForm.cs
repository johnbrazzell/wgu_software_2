using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wgu_software_2
{
    
    public partial class ReportForm : Form
    {
        public ReportForm(DataSet dataSet, string reportName)
        {
            InitializeComponent();
            this.Text = reportName;
            this.reportDataGridView.DataSource = dataSet.Tables[0];
        }
    }
}
