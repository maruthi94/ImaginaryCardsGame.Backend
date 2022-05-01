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

        /// <summary>
        /// Sorts cards provided with special cards periority considered. 
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST api/cards/sort
        ///     
        ///     ["3C", "JS", "2D", "PT", "10H", "KH", "8S", "4T", "AC", "4H", "RT" ]
        ///
        /// </remarks>
        /// <param name="cards" example='["3C", "JS", "2D", "PT", "10H", "KH"]'>Unsorted cards as list of strings</param>
        /// <returns>Sorted cards as list of strings</returns>
        /// <response code="200">List of sorted cards</response>
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