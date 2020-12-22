using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wgu_software_2
{
    public partial class AddAppointmentForm : wgu_software_2.AppointmentBaseForm
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
            base.PopulateCustomerGrid();
        }
    }
}
