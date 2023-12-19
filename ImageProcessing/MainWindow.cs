using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSProcessor;


namespace ImageProcessing
{


    public partial class main_form : Form
    {

        ImageProcessor processor = new ImageProcessor();
        public main_form()
        {
            InitializeComponent();    
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            image_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            image_box.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            //openFileDialog.InitialDirectory = "C:";
            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                processor.SetFilePath(openFileDialog.FileName);
                image_box.Image = Image.FromFile(openFileDialog.FileName);
            }

        }

        private void btn_process_with_scale_Click(object sender, EventArgs e)
        {
            StreamWriter stream = makeStream("GETPIXEL");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            processor.ProcessImage(stream, GetScale());
            watch.Stop();

            setStatusBar("Processing complete in " + watch.ElapsedMilliseconds + "ms");
        }

        private void btn_bmp_data_Click(object sender, EventArgs e)
        {
            StreamWriter stream = makeStream("BMPDATA");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            processor.BitmapDataProcess(stream, GetScale());
            watch.Stop();

            setStatusBar("Processing complete in " + watch.ElapsedMilliseconds + "ms");
        }
        private int GetScale()
        {
            return (int)scale_selector.Value;
        }

        private StreamWriter makeStream(string file_appendix)
        {
            StreamWriter stream;
            if (check_box_to_file.Checked)
                stream = new StreamWriter(processor.MakeOutFilePath(file_appendix));
            else
                stream = new StreamWriter(Console.OpenStandardOutput());

            return stream;
        }

        private void setStatusBar(string message)
        {
            status_label.Text = message;
        }

    }
}
