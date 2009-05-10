using System;

namespace SilverlightScratch {
    public class DiggStory {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumDiggs { get; set; }
        public Uri HrefLink { get; set; }
        public string Thumbnail { get; set; }
        public string UserName { get; set; }
    }
}
