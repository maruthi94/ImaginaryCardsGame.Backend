namespace ImaginaryCardsGame.Backend.Services
{
    public interface ICardsSortService
    {
        public IList<string> Sort(IList<string> cards);
    }
}
