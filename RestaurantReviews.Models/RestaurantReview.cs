using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Models {
    public class RestaurantReview {
        public int RestaurantReviewId { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
        public DateTime ReviewDate { get; set; }
        public Restaurant Restaurant { get; set; }


    }
}
