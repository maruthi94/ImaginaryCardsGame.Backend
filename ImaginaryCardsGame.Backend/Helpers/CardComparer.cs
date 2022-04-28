namespace ImaginaryCardsGame.Backend.Helpers
{
    public class CardComparer : IComparer<string>
    {
        private const int DEFAULT_PRIORITY = 100;
        private readonly HashSet<string> specialCards = new() { "4T", "2T", "ST", "PT", "RT" };

        private readonly Dictionary<string, int> cardsPriority = new()
        {
            { "4T", 1 },
            { "2T", 2 },
            { "ST", 3 },
            { "PT", 4 },
            { "RT", 5 },
            { "T", 6 },
            { "D", 8 },
            { "S", 10 },
            { "C", 12 },
            { "H", 14 }
        };

        public int Compare(string cardA, string cardB)
        {
            var cardAValue = GetPriority(cardA);
            var cardBValue = GetPriority(cardB);
            return cardAValue.CompareTo(cardBValue);
        }

        private int GetPriority(string card)
        {
            return specialCards.Contains(card) 
                ? cardsPriority.GetValueOrDefault(card, DEFAULT_PRIORITY) 
                : GetNormalCardPriority(card);

            int GetNormalCardPriority(string card)
            {
                var cardType = card[^1];
                var cardValue = card[0..^1];
                var priority = cardsPriority.GetValueOrDefault(cardType.ToString(), DEFAULT_PRIORITY);

                return int.TryParse(cardValue,out int _) ? priority : priority+1;
            }
        }
    }
}