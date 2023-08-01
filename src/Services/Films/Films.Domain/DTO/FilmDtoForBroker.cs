namespace Films.Domain.DTO
{
	public class FilmDtoForBroker : BaseDTOEntity
	{
		public string FilmName { get; set; }
		public string? TypeOfBrokerOperation { get; set; }
	}
}
