namespace BookLibrary.Api.Dtos
{
	public class CreateBookDto
	{
		public string Name { get; set; }
		public string Yazar { get; set; }
		public int Durum { get; set; }
	}
}
