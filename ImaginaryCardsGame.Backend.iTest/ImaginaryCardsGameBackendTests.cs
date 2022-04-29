using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImaginaryCardsGame.Backend.iTest
{
    public class ImaginaryCardsGameBackendTests : CustomTestBase
    {
        [Test]
        public async Task POST_UnSortedCardsToSORTEndPointReturnsSortedCards()
        {
            var unsortedCards = new string[] { "3C", "JS", "2D", "PT", "10H", "KH", "8S", "4T", "AC", "4H", "RT" };
            var sortedCards = new string[] { "4T", "PT", "RT", "2D", "8S", "JS", "3C", "AC", "4H", "10H", "KH" };

            var content = new StringContent(JsonSerializer.Serialize(unsortedCards), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync("/api/cards/sort", content).ConfigureAwait(false);
            var result = await JsonSerializer.DeserializeAsync<IList<string>>(response.Content.ReadAsStream()).ConfigureAwait(false);
            Assert.That(result, Is.EqualTo(sortedCards).AsCollection);
        }
    }
}