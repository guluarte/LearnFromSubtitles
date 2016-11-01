using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

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

            if (string.IsNullOrEmpty(txtHelperPrefix.Text))
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
            var videoExtensions = new []{".mp4",".avi"};

            var videoFiles = files.Where(f => !string.IsNullOrWhiteSpace(f.Extension) && videoExtensions.Contains(f.Extension.ToLower()));

            foreach (var videoFile in videoFiles)
            {
                var currentSecond = 0;
                var playList = new Playlist();

                var targetSubFile = string.Format("{0}.{1}.srt", videoFile, txtTargetPrefix.Text);
                var helperSubFile = string.Format("{0}.{1}.srt", videoFile, txtHelperPrefix.Text);

                var parser = new SubtitlesParser.Classes.Parsers.SrtParser();

                var fullTargetSubFile = string.Format("{0}{1}", txtDirectoryPath.Text, targetSubFile);
                using (var fileStream = File.OpenRead(fullTargetSubFile))
                {
                    var items = parser.ParseStream(fileStream, Encoding.UTF8);

                    var lastItem = items.LastOrDefault();

                    while (lastItem != null && currentSecond < lastItem.EndTime)
                    {
                        var newEndTime = currentSecond + (interval * 1000);
                        var contains = items.Any(i => i.StartTime >= currentSecond && i.EndTime <= newEndTime);

                        // if false add only original, if true add both
                        var startTime = currentSecond > 0 ? (currentSecond / 1000 - 5) : 0;
                        var endTime = startTime + interval + 5;

                        var vlcTargetTrack = new Playlist.VlcTrack
                        {
                            StartTime = startTime,
                            EndTime = endTime,
                            MediaFile = videoFile.ToString(),
                            Name = string.Format("{0} - {1}", startTime, videoFile),
                            SubFile = helperSubFile
                        };

                        playList.AddTrack(vlcTargetTrack);

                        if (contains)
                        {
                            var vlcHelperTrack = new Playlist.VlcTrack
                            {
                                StartTime = startTime,
                                EndTime = endTime,
                                MediaFile = videoFile.ToString(),
                                Name = string.Format("{0} - {1}", startTime, videoFile),
                                SubFile = targetSubFile
                            }; 

                            playList.AddTrack(vlcHelperTrack);
                        }

                        currentSecond = newEndTime;
                    }
                }

                // add last segment
                var lastTrack = new Playlist.VlcTrack
                {
                    StartTime = (currentSecond / 1000) - 5,
                    EndTime = 0,
                    MediaFile = videoFile.ToString(),
                    Name = videoFile.ToString(),
                    SubFile = targetSubFile
                };

                playList.AddTrack(lastTrack);

                var videoPlayList = playList.ToString();

                File.WriteAllText(string.Format("{0}{1}.xspf", txtDirectoryPath.Text, videoFile), videoPlayList);
            }

            MessageBox.Show("Done", "Done");

        }
    }
}

