using System;
using System.Windows.Forms;
using GraphSample.Properties;

namespace GraphSample
{
    public partial class RendererContainerForm : Form
    {
        private int _oldWidth, _oldHeight;

        public RendererContainerForm(string name)
        {
            InitializeComponent(name);    
        }

        private void RendererContainerForm_Resize(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if(control.Size.Height != (int)control.Size.Width)
                {
                    control.Size = new System.Drawing.Size(control.Size.Width, (int)control.Size.Width);   
                }
                Dll.Resize(Handle);

            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
            
        }

        private void RendererContainerForm_ResizeBegin(object sender, EventArgs e)
        {
            _oldWidth = this.Width;
            _oldHeight = this.Height;
            
        }

        private void RendererContainerForm_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if (_oldHeight != this.Height)
                    control.Size = new System.Drawing.Size(control.Size.Height, (int)(control.Size.Height));
                else if (_oldWidth != this.Width)
                    control.Size = new System.Drawing.Size(control.Size.Width, (int)(control.Size.Width));

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
