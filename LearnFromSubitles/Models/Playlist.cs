using System;
using System.Collections.Generic;
using System.Text;

namespace LearnFromSubitles.Models
{
    class Playlist
    {
        public class VlcTrack
        {
            public string Name { get; set; }
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public string SubFile { get; set; }
            public string MediaFile { get; set; }
        }
        private StringBuilder _xml;
        private readonly List<VlcTrack> _trackList;
        private int _currentItem;

        public Playlist()
        {
            _trackList = new List<VlcTrack>();
        }

        public void AddTrack(VlcTrack vlcTrack)
        {
            _trackList.Add(vlcTrack);
        }

        private void GeneratePlayList()
        {
            _currentItem = 0;
            _xml = new StringBuilder(@"<?xml version=""1.0"" encoding=""UTF-8""?>
 <playlist xmlns=""http://xspf.org/ns/0/"" xmlns:vlc=""http://www.videolan.org/vlc/playlist/ns/0/"" version=""1"">
  <trackList>");

            foreach (var vlcTrack in _trackList)
            {
                _xml.AppendFormat(@"<track>
		<title>{0} - {2}</title>
		<location>{1}</location>
		<trackNum>{2}</trackNum>
		<extension application=""http://www.videolan.org/vlc/playlist/0"">
			<vlc:option>start-time={3}</vlc:option>
			<vlc:option>stop-time={4}</vlc:option>
			<vlc:id>{2}</vlc:id>
			<vlc:option>sub-file={5}</vlc:option>
		</extension>
	</track>{6}", vlcTrack.Name, vlcTrack.MediaFile, ++_currentItem, vlcTrack.StartTime, vlcTrack.EndTime, vlcTrack.SubFile, Environment.NewLine);
            }

            _xml.AppendFormat("</trackList>{0}</playlist>{0}", Environment.NewLine);
        }


        public override string ToString()
        {
            GeneratePlayList();
            return _xml.ToString();
        }
    }
}