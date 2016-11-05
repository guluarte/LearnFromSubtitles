using System;

using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var probability = Convert.ToInt16(txtProbability.Text);

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
                    Interval = interval,
                    Probability = probability
                };

                var videoPlayList = PlayListGenerator.GeneratePlayList(videoInfo, parser);

                File.WriteAllText(string.Format("{0}{1}.xspf", txtDirectoryPath.Text, videoFile), videoPlayList.ToString());
            }

            MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void chkOnlyAudio_CheckedChanged(object sender, EventArgs e)
        {
            txtTargetPrefix.Enabled = chkOnlyAudio.CheckState != CheckState.Checked;
        }

        private void btnVvtToSrt_Click(object sender, EventArgs e)
        {
            if (!txtDirectoryPath.Text.EndsWith("\\"))
            {
                txtDirectoryPath.Text += "\\";
            }

            var dirInfo = new DirectoryInfo(txtDirectoryPath.Text);
            var files = dirInfo.GetFiles();
            var videoExtensions = new[] { ".vtt" };

            var vvtSubtitles = files.Where(f => !string.IsNullOrWhiteSpace(f.Extension) && videoExtensions.Contains(f.Extension.ToLower()));

            foreach (var vvtSubtitle in vvtSubtitles)
            {
                var vvtSubitleContent = File.ReadAllText(vvtSubtitle.FullName);
                var srtSubitleContent = ConvertWebvttToSrt(vvtSubitleContent);

                File.WriteAllText(string.Format("{0}.srt", vvtSubtitle.FullName), srtSubitleContent);
            }

            MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static String ConvertWebvttToSrt(String webvttContent)
        {
            if (webvttContent == null)
                throw new ArgumentNullException("webvttContent");


            // remove the first three lines

            var lines = Regex.Split(webvttContent, "\r\n|\r|\n").Skip(3);

            String srtResult = string.Join(Environment.NewLine, lines.ToArray());

            Int32 srtPartLineNumber = 0;


            srtResult = Regex.Replace(srtResult, @"(WEBVTT\s+)(\d{2}:)", "$2", RegexOptions.Multiline);

            srtResult = Regex.Replace(srtResult, @"(\d{2}:\d{2}:\d{2})\.(\d{3}\s+)-->(\s+\d{2}:\d{2}:\d{2})\.(\d{3}\s*)", match =>
            {
                srtPartLineNumber++;
                return srtPartLineNumber.ToString() + Environment.NewLine +
                Regex.Replace(match.Value, @"(\d{2}:\d{2}:\d{2})\.(\d{3}\s+)-->(\s+\d{2}:\d{2}:\d{2})\.(\d{3}\s*)", "$1,$2-->$3,$4");

            });

            return srtResult;
        }
    }
}