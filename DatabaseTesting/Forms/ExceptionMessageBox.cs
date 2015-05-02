using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseTesting.Forms
{
    public partial class ExceptionMessageBox : Form
    {
        private ExceptionForMessageBox _exceptionParser;

        public ExceptionMessageBox(Exception e)
        {
            InitializeComponent();
            CustomInitializeComponents();
            AppendAllData(e);
        }

        private void AppendAllData(Exception e)
        {
            var exceptions = new List<ExceptionForMessageBox>();
            var inner = false;

            while (e != null)
            {
                exceptions.Add(new ExceptionForMessageBox(e, inner));
                e = e.InnerException;
                if (e != null)
                    inner = true;
            }

            this.listBox1.DataSource = exceptions;
            this.listBox1.DisplayMember = "Display";
            this.listBox1.ValueMember = "Value";
        }

        private void CustomInitializeComponents()
        {
            this.listBox1.SelectedIndexChanged += (sender, args) =>
            {
                var curItem = (ExceptionForMessageBox) listBox1.SelectedItem;
                this.richTextBox1.Text = curItem.Value;
            };
        }
    }
}
