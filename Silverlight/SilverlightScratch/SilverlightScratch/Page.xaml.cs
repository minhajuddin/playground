using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SilverlightScratch {
    public partial class Page : UserControl {
        public Page() {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e) {
            string topic = searchTxtBox.Text;
            string diggUrl = String.Format("http://services.digg.com/stories/topic/{0}?count=20&appkey=http%3A%2F%2Fscottgu.com", topic);

            //async callback
            WebClient diggService = new WebClient();
            diggService.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DiggService_DownloadStringCompleted);
            diggService.DownloadStringAsync(new Uri(diggUrl));
        }

        void DiggService_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error == null) {
                string result = e.Result;
                DisplayStories(result);
            }
        }

        void DisplayStories(string xmlContent) {
            XDocument xmlStories = XDocument.Parse(xmlContent);

            var stories = xmlStories.Descendants("story")
                .Where(st => st.Element("thumbnail") != null
                    && !st.Element("thumbnail").Attribute("src").Value.EndsWith(".gif"))
                .Select(st => new DiggStory
                {
                    ID = (int)st.Attribute("id"),
                    Title = ((string)st.Attribute("title")).Trim(),
                    Thumbnail = (string)st.Element("thumbnail").Attribute("src").Value,
                    HrefLink = new Uri((string)st.Attribute("link")),
                    NumDiggs = (int)st.Attribute("diggs"),
                    UserName = ((string)st.Element("user").Attribute("name")).Trim(),
                });

            StoriesList.SelectedIndex = -1;
            StoriesList.ItemsSource = stories;
        }
    }
}
