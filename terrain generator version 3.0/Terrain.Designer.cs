namespace terrain_generator_version_3._0
{
    partial class Terrain
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
            this.components = new System.ComponentModel.Container();
            this.GameWindow = new System.Windows.Forms.Panel();
            this.GameRenderFrame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WorldName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GameWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameRenderFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.GameWindow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GameWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GameWindow.Controls.Add(this.GameRenderFrame);
            this.GameWindow.Location = new System.Drawing.Point(12, 52);
            this.GameWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GameWindow.Name = "GameWindow";
            this.GameWindow.Size = new System.Drawing.Size(1312, 735);
            this.GameWindow.TabIndex = 0;
            // 
            // GameRenderFrame
            // 
            this.GameRenderFrame.Location = new System.Drawing.Point(3, 3);
            this.GameRenderFrame.Name = "GameRenderFrame";
            this.GameRenderFrame.Size = new System.Drawing.Size(1302, 725);
            this.GameRenderFrame.TabIndex = 0;
            this.GameRenderFrame.TabStop = false;
            this.GameRenderFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxOnpaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "World name:";
            // 
            // WorldName
            // 
            this.WorldName.AutoSize = true;
            this.WorldName.Location = new System.Drawing.Point(116, 12);
            this.WorldName.Name = "WorldName";
            this.WorldName.Size = new System.Drawing.Size(35, 20);
            this.WorldName.TabIndex = 2;
            this.WorldName.Text = "N/A";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Terrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 800);
            this.Controls.Add(this.WorldName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameWindow);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Terrain";
            this.Text = "Terrain";
            this.Load += new System.EventHandler(this.Terrain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            this.GameWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameRenderFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GameWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WorldName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox GameRenderFrame;
    }
}