using Films.Domain.Enums;

namespace Films.Domain.DTO
{
	public class FilmDtoForBroker : BaseDTOEntity
	{
		public string FilmName { get; set; }
		public BrokerOperationsEnum? TypeOfBrokerOperation { get; set; }
	}
}
