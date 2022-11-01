using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;

namespace CardAPI.Models
{
	public class DeckDAL
	{
		public string GetDeck()
		{
			string url = $"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
			var client = new RestClient(url);
			var request = new RestRequest();
			var response = client.GetAsync<DeckInfo>(request);
			string deckID = response.Result.deck_id;
			return deckID;
		}
		public CurrentDeck DrawCards(string deckID)
		{
			
			string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count=5";
			var client = new RestClient(url);
			var request = new RestRequest();
			var response = client.GetAsync<CurrentDeck>(request);
			CurrentDeck deck = response.Result;

			return deck;
		}
	}
}
