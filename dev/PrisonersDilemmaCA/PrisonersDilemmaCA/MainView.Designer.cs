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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.payoffMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Draw zone";
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
            this.label2.Location = new System.Drawing.Point(315, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lines";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
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
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 358);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLines);
            this.Controls.Add(this.tbColumns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGrid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Prisoner\'s Dilemma, Cellular Automaton";
            ((System.ComponentModel.ISupportInitialize)(this.pbGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem payoffMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

