using TravelManagerFE.Pages;

namespace TravelManagerFE.Data.Models
{
    public class CommentRequest
    {
        public string ReviewId { get; set; }
        public string VisitId { get; set; }
        public string ParentCommentId { get; set; }
        public string Text { get; set; }
        public ReviewForm.ElementTypes ElementType { get; set; }
        public string CreatorId { get; set; }
    }
}