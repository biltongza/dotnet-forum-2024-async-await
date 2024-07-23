namespace WinformsAsyncExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            asyncButton = new Button();
            syncButton = new Button();
            delaySelector = new NumericUpDown();
            label2 = new Label();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)delaySelector).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(244, 45);
            label1.TabIndex = 0;
            label1.Text = "Async Example";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(pictureBox1);
            flowLayoutPanel2.Controls.Add(groupBox1);
            flowLayoutPanel2.Location = new Point(12, 57);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1240, 612);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.the_dude;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.MinimumSize = new Size(480, 270);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(480, 270);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(asyncButton);
            groupBox1.Controls.Add(syncButton);
            groupBox1.Controls.Add(delaySelector);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(489, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 270);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controls";
            // 
            // asyncButton
            // 
            asyncButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            asyncButton.Location = new Point(180, 62);
            asyncButton.Name = "asyncButton";
            asyncButton.Size = new Size(168, 53);
            asyncButton.TabIndex = 3;
            asyncButton.Text = "Async (Good)";
            asyncButton.UseVisualStyleBackColor = true;
            asyncButton.Click += asyncButton_Click;
            // 
            // syncButton
            // 
            syncButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            syncButton.Location = new Point(6, 62);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(168, 53);
            syncButton.TabIndex = 2;
            syncButton.Text = "Sync (Bad)";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // numericUpDown1
            // 
            delaySelector.Location = new Point(102, 33);
            delaySelector.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            delaySelector.Name = "numericUpDown1";
            delaySelector.Size = new Size(35, 23);
            delaySelector.TabIndex = 1;
            delaySelector.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 35);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 0;
            label2.Text = "Delay (seconds)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 345);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(891, 384);
            MinimumSize = new Size(891, 384);
            Name = "Form1";
            RightToLeftLayout = true;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Async Example";
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)delaySelector).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox1;
        private Button asyncButton;
        private Button syncButton;
        private NumericUpDown delaySelector;
        private Label label2;
    }
}
