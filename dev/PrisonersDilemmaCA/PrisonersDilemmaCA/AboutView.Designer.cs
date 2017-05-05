namespace PrisonersDilemmaCA
{
    partial class AboutView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWikiLink = new System.Windows.Forms.LinkLabel();
            this.lblGithubLink = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.border = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 209);
            this.label3.TabIndex = 7;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "About this project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 149);
            this.label2.TabIndex = 9;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "About the author";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(459, 406);
            this.label5.TabIndex = 11;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "About the prisoner\'s dilemma";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWikiLink
            // 
            this.lblWikiLink.AutoSize = true;
            this.lblWikiLink.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.lblWikiLink.Location = new System.Drawing.Point(323, 459);
            this.lblWikiLink.Name = "lblWikiLink";
            this.lblWikiLink.Size = new System.Drawing.Size(260, 17);
            this.lblWikiLink.TabIndex = 13;
            this.lblWikiLink.TabStop = true;
            this.lblWikiLink.Text = "https://en.wikipedia.org/wiki/Prisoner%27s_dilemma";
            this.lblWikiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblGithubLink
            // 
            this.lblGithubLink.AutoSize = true;
            this.lblGithubLink.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.lblGithubLink.Location = new System.Drawing.Point(12, 459);
            this.lblGithubLink.Name = "lblGithubLink";
            this.lblGithubLink.Size = new System.Drawing.Size(260, 17);
            this.lblGithubLink.TabIndex = 14;
            this.lblGithubLink.TabStop = true;
            this.lblGithubLink.Text = "https://github.com/WaffleBweh/DIPLOME_ES_2017";
            this.lblGithubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGithubLink_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(602, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(173, 37);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // border
            // 
            this.border.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.border.Location = new System.Drawing.Point(299, 23);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(1, 450);
            this.border.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(276, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "More info";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 492);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.border);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblGithubLink);
            this.Controls.Add(this.lblWikiLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lblWikiLink;
        private System.Windows.Forms.LinkLabel lblGithubLink;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.Label label7;
    }
}