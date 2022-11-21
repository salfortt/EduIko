using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
   public class Video
    {
        

        public int CategoryTypeId { get; set; }
        public string CategoryUrl { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Length { get; set; }
        public string PageLink { get; set; }
        public int Rate { get; set; }
        public string RelatedVideoSource { get; set; }
        public string ShareLink { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public int TR_Code { get; set; }
        public string VideoCategoryName { get; set; }
        public int VideoId { get; set; }
        public int VideoSourceId { get; set; }
        public int VideoTypeId { get; set; }
        public string VideoURL { get; set; }
        public int ViewCount { get; set; }
        public string YoutubeBigThumb { get; set; }
        public string YoutubeSmallThumb { get; set; }
    }
}
