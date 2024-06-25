namespace BookLibrary.Api.Models
{
	public class Book
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Yazar { get; set; }
        public int Durum { get; set; }
    }
}
