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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.lblGridInfo = new System.Windows.Forms.Label();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.tbColumns = new System.Windows.Forms.TrackBar();
            this.tbLines = new System.Windows.Forms.TrackBar();
            this.lblCols = new System.Windows.Forms.Label();
            this.lblLines = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payoffMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.importOrExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnClear = new System.Windows.Forms.Button();
            this.tsExtendedView = new JCS.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.pieStrategy = new LiveCharts.WinForms.PieChart();
            this.lblPieChart = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.cartesianStrategy = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.pbGrid = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tsWrapMode = new JCS.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimerSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGridInfo
            // 
            this.lblGridInfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridInfo.Location = new System.Drawing.Point(9, 24);
            this.lblGridInfo.Name = "lblGridInfo";
            this.lblGridInfo.Size = new System.Drawing.Size(304, 19);
            this.lblGridInfo.TabIndex = 1;
            this.lblGridInfo.Text = "Grid";
            this.lblGridInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tbColumns.SmallChange = 5;
            this.tbColumns.TabIndex = 2;
            this.tbColumns.TickFrequency = 5;
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
            this.tbLines.SmallChange = 5;
            this.tbLines.TabIndex = 3;
            this.tbLines.TickFrequency = 5;
            this.tbLines.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbLines.Value = 10;
            this.tbLines.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCols.Location = new System.Drawing.Point(319, 40);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(82, 20);
            this.lblCols.TabIndex = 4;
            this.lblCols.Text = "Columns : 10";
            // 
            // lblLines
            // 
            this.lblLines.AutoSize = true;
            this.lblLines.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.Location = new System.Drawing.Point(318, 116);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(63, 20);
            this.lblLines.TabIndex = 5;
            this.lblLines.Text = "Rows : 10";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(594, 24);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateNewBoardToolStripMenuItem,
            this.payoffMatrixToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importOrExportToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generateNewBoardToolStripMenuItem
            // 
            this.generateNewBoardToolStripMenuItem.Name = "generateNewBoardToolStripMenuItem";
            this.generateNewBoardToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.generateNewBoardToolStripMenuItem.Text = "Generate new board...";
            this.generateNewBoardToolStripMenuItem.Click += new System.EventHandler(this.generateNewBoardToolStripMenuItem_Click);
            // 
            // payoffMatrixToolStripMenuItem
            // 
            this.payoffMatrixToolStripMenuItem.Name = "payoffMatrixToolStripMenuItem";
            this.payoffMatrixToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.payoffMatrixToolStripMenuItem.Text = "Payoff matrix...";
            this.payoffMatrixToolStripMenuItem.Click += new System.EventHandler(this.payoffMatrixToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // importOrExportToolStripMenuItem
            // 
            this.importOrExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGridToolStripMenuItem,
            this.loadGridToolStripMenuItem});
            this.importOrExportToolStripMenuItem.Name = "importOrExportToolStripMenuItem";
            this.importOrExportToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.importOrExportToolStripMenuItem.Text = "Import / Export";
            // 
            // saveGridToolStripMenuItem
            // 
            this.saveGridToolStripMenuItem.Name = "saveGridToolStripMenuItem";
            this.saveGridToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveGridToolStripMenuItem.Text = "Save grid...";
            this.saveGridToolStripMenuItem.Click += new System.EventHandler(this.saveGridToolStripMenuItem_Click);
            // 
            // loadGridToolStripMenuItem
            // 
            this.loadGridToolStripMenuItem.Name = "loadGridToolStripMenuItem";
            this.loadGridToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.loadGridToolStripMenuItem.Text = "Load grid...";
            this.loadGridToolStripMenuItem.Click += new System.EventHandler(this.loadGridToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
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
            this.lblUserHelp.Text = "Lorem ipsum dolor sit amet, this displays help for the user";
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
            this.lblSpeedValue.Location = new System.Drawing.Point(319, 311);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(265, 21);
            this.lblSpeedValue.TabIndex = 15;
            this.lblSpeedValue.Text = "automatically steps every 115 [ms]";
            this.lblSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(12, 464);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 33);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear board";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tsExtendedView
            // 
            this.tsExtendedView.Location = new System.Drawing.Point(464, 464);
            this.tsExtendedView.Name = "tsExtendedView";
            this.tsExtendedView.OffFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsExtendedView.OffText = "OFF";
            this.tsExtendedView.OnFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.tsExtendedView.OnForeColor = System.Drawing.Color.White;
            this.tsExtendedView.OnText = "ON";
            this.tsExtendedView.Size = new System.Drawing.Size(117, 33);
            this.tsExtendedView.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone;
            this.tsExtendedView.TabIndex = 17;
            this.tsExtendedView.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tsExtendedView_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Extended view";
            // 
            // pieStrategy
            // 
            this.pieStrategy.Location = new System.Drawing.Point(611, 63);
            this.pieStrategy.Name = "pieStrategy";
            this.pieStrategy.Size = new System.Drawing.Size(461, 164);
            this.pieStrategy.TabIndex = 19;
            this.pieStrategy.Text = "pieChart1";
            // 
            // lblPieChart
            // 
            this.lblPieChart.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPieChart.Location = new System.Drawing.Point(611, 42);
            this.lblPieChart.Name = "lblPieChart";
            this.lblPieChart.Size = new System.Drawing.Size(461, 19);
            this.lblPieChart.TabIndex = 20;
            this.lblPieChart.Text = "Strategy Distribution Across the Grid";
            this.lblPieChart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSeparator.Location = new System.Drawing.Point(601, 40);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(1, 450);
            this.lblSeparator.TabIndex = 21;
            // 
            // cartesianStrategy
            // 
            this.cartesianStrategy.Hoverable = true;
            this.cartesianStrategy.Location = new System.Drawing.Point(611, 263);
            this.cartesianStrategy.Name = "cartesianStrategy";
            this.cartesianStrategy.ScrollHorizontalFrom = 0D;
            this.cartesianStrategy.ScrollHorizontalTo = 0D;
            this.cartesianStrategy.ScrollMode = LiveCharts.ScrollMode.None;
            this.cartesianStrategy.ScrollVerticalFrom = 0D;
            this.cartesianStrategy.ScrollVerticalTo = 0D;
            this.cartesianStrategy.Size = new System.Drawing.Size(461, 227);
            this.cartesianStrategy.TabIndex = 22;
            this.cartesianStrategy.Text = "cartesianChart1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(611, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Average Days in Jail by Strategy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Torus wrap";
            // 
            // tsWrapMode
            // 
            this.tsWrapMode.Location = new System.Drawing.Point(323, 464);
            this.tsWrapMode.Name = "tsWrapMode";
            this.tsWrapMode.OffFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsWrapMode.OffText = "OFF";
            this.tsWrapMode.OnFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.tsWrapMode.OnForeColor = System.Drawing.Color.White;
            this.tsWrapMode.OnText = "ON";
            this.tsWrapMode.Size = new System.Drawing.Size(117, 33);
            this.tsWrapMode.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone;
            this.tsWrapMode.TabIndex = 24;
            this.tsWrapMode.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tsWrapMode_CheckedChanged);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 512);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tsWrapMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cartesianStrategy);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblPieChart);
            this.Controls.Add(this.pieStrategy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsExtendedView);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.tbTimerSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lblUserHelp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStrategies);
            this.Controls.Add(this.lblLines);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.tbLines);
            this.Controls.Add(this.tbColumns);
            this.Controls.Add(this.lblGridInfo);
            this.Controls.Add(this.pbGrid);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Prisoner\'s Dilemma, Cellular Automaton";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimerSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGrid;
        private System.Windows.Forms.Label lblGridInfo;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TrackBar tbColumns;
        private System.Windows.Forms.TrackBar tbLines;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.MenuStrip MenuStrip;
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
        private System.Windows.Forms.Button btnClear;
        private JCS.ToggleSwitch tsExtendedView;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.PieChart pieStrategy;
        private System.Windows.Forms.Label lblPieChart;
        private System.Windows.Forms.Label lblSeparator;
        private LiveCharts.WinForms.CartesianChart cartesianStrategy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private JCS.ToggleSwitch tsWrapMode;
        private System.Windows.Forms.ToolStripMenuItem importOrExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGridToolStripMenuItem;
    }
}

