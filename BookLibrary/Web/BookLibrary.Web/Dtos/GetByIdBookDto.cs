namespace BookLibrary.Web.Dtos
{
    public class GetByIdBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Yazar { get; set; }
        public int Durum { get; set; }
    }
}
