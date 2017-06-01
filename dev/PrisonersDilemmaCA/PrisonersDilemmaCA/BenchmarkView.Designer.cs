namespace PrisonersDilemmaCA
{
    partial class BenchmarkView
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
            this.cbStrategy1 = new System.Windows.Forms.ComboBox();
            this.cbStrategy2 = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNbTurns = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNbTurns = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.scoreChart = new LiveCharts.WinForms.CartesianChart();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbNbTurns)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStrategy1
            // 
            this.cbStrategy1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbStrategy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy1.FormattingEnabled = true;
            this.cbStrategy1.Location = new System.Drawing.Point(12, 103);
            this.cbStrategy1.Name = "cbStrategy1";
            this.cbStrategy1.Size = new System.Drawing.Size(178, 21);
            this.cbStrategy1.TabIndex = 8;
            // 
            // cbStrategy2
            // 
            this.cbStrategy2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbStrategy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy2.FormattingEnabled = true;
            this.cbStrategy2.Location = new System.Drawing.Point(257, 103);
            this.cbStrategy2.Name = "cbStrategy2";
            this.cbStrategy2.Size = new System.Drawing.Size(178, 21);
            this.cbStrategy2.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(419, 43);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Choose two strategies for benchmarking";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "Strategy 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "Strategy 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNbTurns
            // 
            this.tbNbTurns.Location = new System.Drawing.Point(12, 173);
            this.tbNbTurns.Maximum = 1000;
            this.tbNbTurns.Minimum = 1;
            this.tbNbTurns.Name = "tbNbTurns";
            this.tbNbTurns.Size = new System.Drawing.Size(423, 45);
            this.tbNbTurns.TabIndex = 13;
            this.tbNbTurns.TickFrequency = 50;
            this.tbNbTurns.Value = 100;
            this.tbNbTurns.Scroll += new System.EventHandler(this.tbNbTurns_Scroll);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 27);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number of turns";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNbTurns
            // 
            this.lblNbTurns.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbTurns.Location = new System.Drawing.Point(16, 204);
            this.lblNbTurns.Name = "lblNbTurns";
            this.lblNbTurns.Size = new System.Drawing.Size(423, 27);
            this.lblNbTurns.TabIndex = 15;
            this.lblNbTurns.Text = "100";
            this.lblNbTurns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(125, 259);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(200, 31);
            this.btnPlay.TabIndex = 17;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // scoreChart
            // 
            this.scoreChart.Hoverable = true;
            this.scoreChart.Location = new System.Drawing.Point(506, 9);
            this.scoreChart.Name = "scoreChart";
            this.scoreChart.ScrollHorizontalFrom = 0D;
            this.scoreChart.ScrollHorizontalTo = 0D;
            this.scoreChart.ScrollMode = LiveCharts.ScrollMode.None;
            this.scoreChart.ScrollVerticalFrom = 0D;
            this.scoreChart.ScrollVerticalTo = 0D;
            this.scoreChart.Size = new System.Drawing.Size(286, 281);
            this.scoreChart.TabIndex = 18;
            this.scoreChart.Text = "Chart";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(468, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 31);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "<<";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // BenchmarkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 302);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.scoreChart);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblNbTurns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNbTurns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbStrategy2);
            this.Controls.Add(this.cbStrategy1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BenchmarkView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Benchmark strategies";
            this.Load += new System.EventHandler(this.BenchmarkView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbNbTurns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStrategy1;
        private System.Windows.Forms.ComboBox cbStrategy2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbNbTurns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNbTurns;
        private System.Windows.Forms.Button btnPlay;
        private LiveCharts.WinForms.CartesianChart scoreChart;
        private System.Windows.Forms.Button btnClose;
    }
}