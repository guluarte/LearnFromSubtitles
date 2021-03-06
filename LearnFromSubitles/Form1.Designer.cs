﻿using System.Windows.Forms;

namespace LearnFromSubitles
{
    partial class MainForm: Form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdioSubVtt = new System.Windows.Forms.RadioButton();
            this.rdioSubSrt = new System.Windows.Forms.RadioButton();
            this.txtProbability = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkOnlyAudio = new System.Windows.Forms.CheckBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHelperPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTargetPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBrowseDirectory = new System.Windows.Forms.Button();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtYouTubeUrl = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 355);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtYouTubeUrl);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.rdioSubVtt);
            this.tabPage1.Controls.Add(this.rdioSubSrt);
            this.tabPage1.Controls.Add(this.txtProbability);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.chkOnlyAudio);
            this.tabPage1.Controls.Add(this.txtInterval);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtHelperPrefix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtTargetPrefix);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.btnBrowseDirectory);
            this.tabPage1.Controls.Add(this.txtDirectoryPath);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Target and Helper Language";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rdioSubVtt
            // 
            this.rdioSubVtt.AutoSize = true;
            this.rdioSubVtt.Location = new System.Drawing.Point(533, 96);
            this.rdioSubVtt.Name = "rdioSubVtt";
            this.rdioSubVtt.Size = new System.Drawing.Size(46, 17);
            this.rdioSubVtt.TabIndex = 38;
            this.rdioSubVtt.TabStop = true;
            this.rdioSubVtt.Text = "VTT";
            this.rdioSubVtt.UseVisualStyleBackColor = true;
            // 
            // rdioSubSrt
            // 
            this.rdioSubSrt.AutoSize = true;
            this.rdioSubSrt.Location = new System.Drawing.Point(470, 96);
            this.rdioSubSrt.Name = "rdioSubSrt";
            this.rdioSubSrt.Size = new System.Drawing.Size(47, 17);
            this.rdioSubSrt.TabIndex = 37;
            this.rdioSubSrt.TabStop = true;
            this.rdioSubSrt.Text = "SRT";
            this.rdioSubSrt.UseVisualStyleBackColor = true;
            // 
            // txtProbability
            // 
            this.txtProbability.Location = new System.Drawing.Point(204, 96);
            this.txtProbability.Name = "txtProbability";
            this.txtProbability.Size = new System.Drawing.Size(47, 20);
            this.txtProbability.TabIndex = 34;
            this.txtProbability.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Show Second Language % of the time:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(10, 227);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(618, 85);
            this.textBox3.TabIndex = 32;
            this.textBox3.Text = "Follow this name convention: if the video filename is cnp-uvfs01e01.avi the subti" +
    "tles should be cnp-uvfs01e01.en.srt and cnp-uvfs01e01.fr.srt. For Audio Only the" +
    " second subtitle is not needed.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(493, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "First Language [fr] and Only Audio display the video with French subtitles first " +
    "and then without subtitles.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(562, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Tip: First Language [en] and second language [fr] display the video first with th" +
    "e subtitles in English and then in French";
            // 
            // chkOnlyAudio
            // 
            this.chkOnlyAudio.AutoSize = true;
            this.chkOnlyAudio.Location = new System.Drawing.Point(388, 96);
            this.chkOnlyAudio.Name = "chkOnlyAudio";
            this.chkOnlyAudio.Size = new System.Drawing.Size(76, 17);
            this.chkOnlyAudio.TabIndex = 28;
            this.chkOnlyAudio.Text = "Only audio";
            this.chkOnlyAudio.UseVisualStyleBackColor = true;
            this.chkOnlyAudio.CheckedChanged += new System.EventHandler(this.chkOnlyAudio_CheckedChanged);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(527, 67);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(75, 20);
            this.txtInterval.TabIndex = 26;
            this.txtInterval.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Interval:";
            // 
            // txtHelperPrefix
            // 
            this.txtHelperPrefix.Location = new System.Drawing.Point(125, 67);
            this.txtHelperPrefix.Name = "txtHelperPrefix";
            this.txtHelperPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtHelperPrefix.TabIndex = 24;
            this.txtHelperPrefix.Text = "en";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "First Language Prefix:";
            // 
            // txtTargetPrefix
            // 
            this.txtTargetPrefix.Location = new System.Drawing.Point(364, 67);
            this.txtTargetPrefix.Name = "txtTargetPrefix";
            this.txtTargetPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtTargetPrefix.TabIndex = 22;
            this.txtTargetPrefix.Text = "fr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Second Language Prefix:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(517, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(111, 23);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "Create Playlist";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBrowseDirectory
            // 
            this.btnBrowseDirectory.Location = new System.Drawing.Point(531, 32);
            this.btnBrowseDirectory.Name = "btnBrowseDirectory";
            this.btnBrowseDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDirectory.TabIndex = 16;
            this.btnBrowseDirectory.Text = "Browse";
            this.btnBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Location = new System.Drawing.Point(65, 34);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(460, 20);
            this.txtDirectoryPath.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Directory:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, -42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, -40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(389, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-120, -33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Helper Language Subtitle:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, -72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, -67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-120, -64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Target Language Subtitle:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "YouTube URL:";
            // 
            // txtYouTubeUrl
            // 
            this.txtYouTubeUrl.Location = new System.Drawing.Point(93, 7);
            this.txtYouTubeUrl.Name = "txtYouTubeUrl";
            this.txtYouTubeUrl.Size = new System.Drawing.Size(509, 20);
            this.txtYouTubeUrl.TabIndex = 40;
            this.txtYouTubeUrl.Tag = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(650, 369);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Learn From Subitles";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnStart;
        private Button btnBrowseDirectory;
        private TextBox txtDirectoryPath;
        private Label label4;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private TextBox txtHelperPrefix;
        private Label label5;
        private TextBox txtTargetPrefix;
        private Label label3;
        private TextBox txtInterval;
        private Label label6;
        private CheckBox chkOnlyAudio;
        private Label label8;
        private Label label7;
        private Label label9;
        private TextBox textBox3;
        private TextBox txtProbability;
        private Label label10;
        private RadioButton rdioSubVtt;
        private RadioButton rdioSubSrt;
        private Label label11;
        private TextBox txtYouTubeUrl;
    }
}

