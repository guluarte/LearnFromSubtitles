using System.IO;
using System.Linq;
using System.Text;
using SubtitlesParser.Classes.Parsers;

namespace LearnFromSubitles.Models
{
    public class VideoInfo
    {
        public FileInfo VideoFile { get; set; }
        public FileInfo HerlperSubFile { get; set; }
        public FileInfo TargetSubFile { get; set; }
        public int Interval { get; set; }
    }
    class PlayListGenerator
    {
        public static Playlist GeneratePlayList(VideoInfo videoInfo, ISubtitlesParser parser)
        {
            var currentSecond = 0;

            var playList = new Playlist();

            using (var fileStream = File.OpenRead(videoInfo.HerlperSubFile.FullName))
            {
                var items = parser.ParseStream(fileStream, Encoding.UTF8);

                var lastItem = items.LastOrDefault();

                while (lastItem != null && currentSecond < lastItem.EndTime)
                {
                    var newEndTime = currentSecond + (videoInfo.Interval * 1000);

                    var contains = items.Any(i => i.StartTime >= currentSecond && i.EndTime <= newEndTime);

                    // if false add only original, if true add both
                    var startTime = currentSecond > 0 ? (currentSecond / 1000 - 5) : 0;
                    var endTime = startTime + videoInfo.Interval + 5;

                    var vlcTargetTrack = new Playlist.VlcTrack
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        MediaFile = videoInfo.VideoFile.Name,
                        Name = string.Format("{0} - {1}", startTime, videoInfo.VideoFile.Name),
                        SubFile = videoInfo.HerlperSubFile.Name
                    };

                    playList.AddTrack(vlcTargetTrack);

                    if (contains)
                    {
                        var vlcHelperTrack = new Playlist.VlcTrack
                        {
                            StartTime = startTime,
                            EndTime = endTime,
                            MediaFile = videoInfo.VideoFile.Name,
                            Name = string.Format("{0} - {1}", startTime, videoInfo.VideoFile.Name),
                            SubFile = videoInfo.TargetSubFile.Name
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
                MediaFile = videoInfo.VideoFile.Name,
                Name = videoInfo.VideoFile.Name,
                SubFile = videoInfo.TargetSubFile.Name
            };

            playList.AddTrack(lastTrack);

            return playList;
        }
    }
}
