using System;
using System.Windows.Forms;
using GraphSample.Properties;

namespace GraphSample
{
    public partial class RendererContainerForm : Form
    {
        

        public RendererContainerForm(string name)
        {
            InitializeComponent(name);    
        }

        private void RendererContainerForm_Resize(object sender, EventArgs e)
        {
            try
            {
                Dll.Resize(Handle);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
            
        }

        private void RendererContainerForm_Closing(object sender, EventArgs e)
        {
            SavePosition();
        }
    }
}
