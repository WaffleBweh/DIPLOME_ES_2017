namespace PrisonersDilemmaCA
{
    partial class MainView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbGrid = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.tbColumns = new System.Windows.Forms.TrackBar();
            this.tbLines = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.payoffMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbStrategies = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserHelp = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.StepTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tbTimerSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimerSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGrid
            // 
            this.pbGrid.BackColor = System.Drawing.Color.White;
            this.pbGrid.Location = new System.Drawing.Point(12, 46);
            this.pbGrid.Name = "pbGrid";
            this.pbGrid.Size = new System.Drawing.Size(300, 300);
            this.pbGrid.TabIndex = 0;
            this.pbGrid.TabStop = false;
            this.pbGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGrid_Paint);
            this.pbGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbGrid_MouseDown);
            this.pbGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbGrid_MouseMove);
            this.pbGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbGrid_MouseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grid";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 16;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // tbColumns
            // 
            this.tbColumns.Location = new System.Drawing.Point(318, 63);
            this.tbColumns.Maximum = 30;
            this.tbColumns.Minimum = 5;
            this.tbColumns.Name = "tbColumns";
            this.tbColumns.Size = new System.Drawing.Size(266, 45);
            this.tbColumns.TabIndex = 2;
            this.tbColumns.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbColumns.Value = 10;
            this.tbColumns.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tbLines
            // 
            this.tbLines.Location = new System.Drawing.Point(318, 139);
            this.tbLines.Maximum = 30;
            this.tbLines.Minimum = 5;
            this.tbLines.Name = "tbLines";
            this.tbLines.Size = new System.Drawing.Size(266, 45);
            this.tbLines.TabIndex = 3;
            this.tbLines.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbLines.Value = 10;
            this.tbLines.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lines";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(593, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateNewBoardToolStripMenuItem,
            this.toolStripMenuItem1,
            this.payoffMatrixToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generateNewBoardToolStripMenuItem
            // 
            this.generateNewBoardToolStripMenuItem.Name = "generateNewBoardToolStripMenuItem";
            this.generateNewBoardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateNewBoardToolStripMenuItem.Text = "Generate new board";
            this.generateNewBoardToolStripMenuItem.Click += new System.EventHandler(this.generateNewBoardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // payoffMatrixToolStripMenuItem
            // 
            this.payoffMatrixToolStripMenuItem.Name = "payoffMatrixToolStripMenuItem";
            this.payoffMatrixToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.payoffMatrixToolStripMenuItem.Text = "Payoff matrix...";
            this.payoffMatrixToolStripMenuItem.Click += new System.EventHandler(this.payoffMatrixToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            // 
            // cbStrategies
            // 
            this.cbStrategies.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbStrategies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategies.FormattingEnabled = true;
            this.cbStrategies.Location = new System.Drawing.Point(322, 206);
            this.cbStrategies.Name = "cbStrategies";
            this.cbStrategies.Size = new System.Drawing.Size(259, 21);
            this.cbStrategies.TabIndex = 7;
            this.cbStrategies.Click += new System.EventHandler(this.cbStrategies_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current strategy";
            // 
            // lblUserHelp
            // 
            this.lblUserHelp.Location = new System.Drawing.Point(12, 349);
            this.lblUserHelp.Name = "lblUserHelp";
            this.lblUserHelp.Size = new System.Drawing.Size(300, 34);
            this.lblUserHelp.TabIndex = 9;
            this.lblUserHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new System.Drawing.Point(12, 425);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(300, 33);
            this.btnStep.TabIndex = 10;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnPlayPause.Location = new System.Drawing.Point(12, 386);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(300, 33);
            this.btnPlayPause.TabIndex = 11;
            this.btnPlayPause.Text = "4";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // StepTimer
            // 
            this.StepTimer.Interval = 115;
            this.StepTimer.Tick += new System.EventHandler(this.StepTimer_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Autostep speed (ms)";
            // 
            // tbTimerSpeed
            // 
            this.tbTimerSpeed.Location = new System.Drawing.Point(318, 263);
            this.tbTimerSpeed.Maximum = 1000;
            this.tbTimerSpeed.Minimum = 16;
            this.tbTimerSpeed.Name = "tbTimerSpeed";
            this.tbTimerSpeed.Size = new System.Drawing.Size(266, 45);
            this.tbTimerSpeed.TabIndex = 14;
            this.tbTimerSpeed.TickFrequency = 100;
            this.tbTimerSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbTimerSpeed.Value = 115;
            this.tbTimerSpeed.Scroll += new System.EventHandler(this.tbTimerSpeed_Scroll);
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedValue.Location = new System.Drawing.Point(322, 311);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(259, 23);
            this.lblSpeedValue.TabIndex = 15;
            this.lblSpeedValue.Text = "automatically steps every 115 [ms]";
            this.lblSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 471);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.tbTimerSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lblUserHelp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStrategies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLines);
            this.Controls.Add(this.tbColumns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGrid);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Prisoner\'s Dilemma, Cellular Automaton";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimerSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TrackBar tbColumns;
        private System.Windows.Forms.TrackBar tbLines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem payoffMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbStrategies;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserHelp;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Timer StepTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbTimerSpeed;
        private System.Windows.Forms.Label lblSpeedValue;
    }
}

