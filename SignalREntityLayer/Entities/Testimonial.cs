namespace SignalREntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string? NameSurname { get; set; }
        public string? Title { get; set; }
        public string? Commet { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
