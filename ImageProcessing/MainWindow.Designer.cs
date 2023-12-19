namespace ImageProcessing
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_load = new System.Windows.Forms.Button();
            this.image_box = new System.Windows.Forms.PictureBox();
            this.btn_process_with_scale = new System.Windows.Forms.Button();
            this.check_box_to_file = new System.Windows.Forms.CheckBox();
            this.btn_bmp_data = new System.Windows.Forms.Button();
            this.scale_selector = new System.Windows.Forms.NumericUpDown();
            this.scale_label = new System.Windows.Forms.Label();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scale_selector)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(12, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(95, 20);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "LOAD IMAGE";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // image_box
            // 
            this.image_box.Location = new System.Drawing.Point(13, 38);
            this.image_box.Name = "image_box";
            this.image_box.Size = new System.Drawing.Size(693, 388);
            this.image_box.TabIndex = 1;
            this.image_box.TabStop = false;
            // 
            // btn_process_with_scale
            // 
            this.btn_process_with_scale.Location = new System.Drawing.Point(625, 12);
            this.btn_process_with_scale.Name = "btn_process_with_scale";
            this.btn_process_with_scale.Size = new System.Drawing.Size(81, 20);
            this.btn_process_with_scale.TabIndex = 3;
            this.btn_process_with_scale.Text = "GETPIXEL";
            this.btn_process_with_scale.UseVisualStyleBackColor = true;
            this.btn_process_with_scale.Click += new System.EventHandler(this.btn_process_with_scale_Click);
            // 
            // check_box_to_file
            // 
            this.check_box_to_file.AutoSize = true;
            this.check_box_to_file.Location = new System.Drawing.Point(304, 12);
            this.check_box_to_file.Name = "check_box_to_file";
            this.check_box_to_file.Size = new System.Drawing.Size(105, 17);
            this.check_box_to_file.TabIndex = 5;
            this.check_box_to_file.Text = "WRITE TO FILE";
            this.check_box_to_file.UseVisualStyleBackColor = true;
            // 
            // btn_bmp_data
            // 
            this.btn_bmp_data.Location = new System.Drawing.Point(538, 12);
            this.btn_bmp_data.Name = "btn_bmp_data";
            this.btn_bmp_data.Size = new System.Drawing.Size(81, 20);
            this.btn_bmp_data.TabIndex = 10;
            this.btn_bmp_data.Text = "BMPDATA";
            this.btn_bmp_data.UseVisualStyleBackColor = true;
            this.btn_bmp_data.Click += new System.EventHandler(this.btn_bmp_data_Click);
            // 
            // scale_selector
            // 
            this.scale_selector.Location = new System.Drawing.Point(465, 12);
            this.scale_selector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scale_selector.Name = "scale_selector";
            this.scale_selector.Size = new System.Drawing.Size(67, 20);
            this.scale_selector.TabIndex = 11;
            this.scale_selector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scale_label
            // 
            this.scale_label.AutoSize = true;
            this.scale_label.Location = new System.Drawing.Point(415, 13);
            this.scale_label.Name = "scale_label";
            this.scale_label.Size = new System.Drawing.Size(44, 13);
            this.scale_label.TabIndex = 12;
            this.scale_label.Text = "SCALE:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_label
            // 
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(85, 17);
            this.status_label.Text = "Load an image";
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 460);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scale_label);
            this.Controls.Add(this.scale_selector);
            this.Controls.Add(this.btn_bmp_data);
            this.Controls.Add(this.check_box_to_file);
            this.Controls.Add(this.btn_process_with_scale);
            this.Controls.Add(this.image_box);
            this.Controls.Add(this.btn_load);
            this.Name = "main_form";
            this.Text = "Image To Ascii";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scale_selector)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.PictureBox image_box;
        private System.Windows.Forms.Button btn_process_with_scale;
        private System.Windows.Forms.CheckBox check_box_to_file;
        private System.Windows.Forms.Button btn_bmp_data;
        private System.Windows.Forms.NumericUpDown scale_selector;
        private System.Windows.Forms.Label scale_label;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
    }
}

