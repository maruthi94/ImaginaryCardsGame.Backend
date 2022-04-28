using ImaginaryCardsGame.Backend.Helpers;

namespace ImaginaryCardsGame.Backend.Services
{
    public class CardsSortService : ICardsSortService
    {   
        public IList<string> Sort(IList<string> cards)
        {
            return cards.OrderBy(x => x, new CardComparer()).ToList();
        }
    }
}
