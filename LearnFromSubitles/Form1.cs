using System;

using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using LearnFromSubitles.Models;

namespace LearnFromSubitles
{
    public partial class MainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowseDirectory_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            var result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtDirectoryPath.Text = fbd.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirectoryPath.Text))
            {
                MessageBox.Show("Please select a directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtHelperPrefix.Text) && !chkOnlyAudio.Checked)
            {
                MessageBox.Show("Please enter all the prefixes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtTargetPrefix.Text))
            {
                MessageBox.Show("Please enter all the prefixes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // scan for all video files
            var interval = Convert.ToInt16(txtInterval.Text);

            if (!txtDirectoryPath.Text.EndsWith("\\"))
            {
                txtDirectoryPath.Text += "\\";
            }

            var dirInfo = new DirectoryInfo(txtDirectoryPath.Text);
            var files = dirInfo.GetFiles();
            var videoExtensions = new[] { ".mp4", ".avi", ".mkv", ".mpg", ".m4v" };

            var videoFiles = files.Where(f => !string.IsNullOrWhiteSpace(f.Extension) && videoExtensions.Contains(f.Extension.ToLower()));

            var parser = new SubtitlesParser.Classes.Parsers.SrtParser();

            var emptyStrFile = "empty.srt";

            if (chkOnlyAudio.Checked)
            {
                File.WriteAllText(string.Format("{0}{1}", txtDirectoryPath.Text, emptyStrFile), string.Empty);
            }

            foreach (var videoFile in videoFiles)
            {
                
                var targetSubFile = string.Format("{0}.{1}.srt", videoFile, txtTargetPrefix.Text);

                if (chkOnlyAudio.Checked)
                {
                    targetSubFile = string.Format("{0}", emptyStrFile);
                }

                var helperSubFile = string.Format("{0}.{1}.srt", videoFile, txtHelperPrefix.Text);

                var fullTargetSubFile = new FileInfo(string.Format("{0}{1}", txtDirectoryPath.Text, targetSubFile));

                var fullHelperSubFile = new FileInfo(string.Format("{0}{1}", txtDirectoryPath.Text, helperSubFile));

                var videoInfo = new VideoInfo
                {
                    TargetSubFile = fullTargetSubFile,
                    HerlperSubFile = fullHelperSubFile,
                    VideoFile = videoFile,
                    Interval = interval
                };

                var videoPlayList = PlayListGenerator.GeneratePlayList(videoInfo, parser);

                File.WriteAllText(string.Format("{0}{1}.xspf", txtDirectoryPath.Text, videoFile), videoPlayList.ToString());
            }

            MessageBox.Show("Done", "Done");

        }

        private void chkOnlyAudio_CheckedChanged(object sender, EventArgs e)
        {
            txtTargetPrefix.Enabled = chkOnlyAudio.CheckState != CheckState.Checked;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtHelperPrefix_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}