using ImaginaryCardsGame.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImaginaryCardsGame.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsSortService cardsSortService;

        public CardsController(ICardsSortService cardsSortService)
        {
            this.cardsSortService = cardsSortService;
        }

        [HttpPost("sort")]
        [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
        [Consumes("application/json")]
        public IActionResult Sort([FromBody] IList<string> cards)
        {
            var sortedCards = cardsSortService.Sort(cards);
            return Ok(sortedCards);
        }
    }
}