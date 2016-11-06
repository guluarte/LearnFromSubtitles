using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Windows.Forms;

using LearnFromSubitles.Models;
using LearnFromSubitles.Properties;
using SubtitlesParser.Classes.Parsers;

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

            fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtDirectoryPath.Text = fbd.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirectoryPath.Text))
            {
                MessageBox.Show(Resources.Please_select_a_directory, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtHelperPrefix.Text) && !chkOnlyAudio.Checked)
            {
                MessageBox.Show(Resources.Please_enter_all_the_prefixes, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtTargetPrefix.Text))
            {
                MessageBox.Show(Resources.Please_enter_all_the_prefixes, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( (!rdioSubSrt.Checked && !rdioSubVtt.Checked) && string.IsNullOrWhiteSpace(txtYouTubeUrl.Text))
            {
                MessageBox.Show(Resources.Select_Srt_or_Vtt, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var interval = Convert.ToInt16(txtInterval.Text);
                var probability = Convert.ToInt16(txtProbability.Text);

                if (!txtDirectoryPath.Text.EndsWith("\\"))
                {
                    txtDirectoryPath.Text += Resources.End_Dir_Prefix;
                }

                //if youtube url download the video
                // youtube-dl --write-sub --write-auto-sub --sub-lang fr,en

                if (!string.IsNullOrWhiteSpace(txtYouTubeUrl.Text))
                {
                    var youtubeDlCmd = $"/C youtube-dl --write-sub --write-auto-sub --sub-lang {txtTargetPrefix.Text},{txtHelperPrefix.Text} {txtYouTubeUrl.Text} -o {txtDirectoryPath.Text}%(id)s.%(ext)s ";

                    var process = Process.Start("cmd.exe", youtubeDlCmd);

                    process?.WaitForExit();

                    rdioSubVtt.Checked = true;
                }
                // scan for all video files

                var dirInfo = new DirectoryInfo(txtDirectoryPath.Text);
                var files = dirInfo.GetFiles();
                var videoExtensions = new[] { ".mp4", ".avi", ".mkv", ".mpg", ".m4v" };

                var videoFiles = files.Where(f => !string.IsNullOrWhiteSpace(f.Extension) && videoExtensions.Contains(f.Extension.ToLower()));

                ISubtitlesParser parser;
                

                var emptyStrFile = "empty.srt";

                var subExtension = "srt";

                if (rdioSubVtt.Checked)
                {
                    subExtension = "vtt";
                    parser = new VttParser();
                }
                else
                {
                    parser = new SrtParser();
                }

                if (chkOnlyAudio.Checked)
                {
                    File.WriteAllText($"{txtDirectoryPath.Text}{emptyStrFile}", string.Empty);
                }

                foreach (var videoFile in videoFiles)
                {

                    var videoFileNameWithoutExt = Path.GetFileNameWithoutExtension(videoFile.Name);

                    try
                    {
                        
                        var targetSubFile = $"{videoFileNameWithoutExt}.{txtTargetPrefix.Text}.{subExtension}";

                        if (chkOnlyAudio.Checked)
                        {
                            targetSubFile = $"{emptyStrFile}";
                        }

                        var helperSubFile = $"{videoFileNameWithoutExt}.{txtHelperPrefix.Text}.{subExtension}";

                        var fullTargetSubFile = new FileInfo($"{txtDirectoryPath.Text}{targetSubFile}");

                        var fullHelperSubFile = new FileInfo($"{txtDirectoryPath.Text}{helperSubFile}");

                        var videoInfo = new VideoInfo
                        {
                            TargetSubFile = fullTargetSubFile,
                            HerlperSubFile = fullHelperSubFile,
                            VideoFile = videoFile,
                            Interval = interval,
                            Probability = probability
                        };

                        var videoPlayList = PlayListGenerator.GeneratePlayList(videoInfo, parser);

                        File.WriteAllText($"{txtDirectoryPath.Text}{videoFile}.xspf", videoPlayList.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, string.Format(Resources.Error_Processing_Video, videoFileNameWithoutExt), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show(Resources.Done, Resources.Done, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkOnlyAudio_CheckedChanged(object sender, EventArgs e)
        {
            txtTargetPrefix.Enabled = chkOnlyAudio.CheckState != CheckState.Checked;
        }

    }
}