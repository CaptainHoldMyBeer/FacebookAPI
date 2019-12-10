using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using FacebookMusic.Interfaces;
using FacebookMusic.Models;
using Newtonsoft.Json;
using winsdkfb;

namespace FacebookMusic.Services.Classes
{
	public class FacebookSocialNetwork: ISocialNetwork
	{
		private string userToken = "EAAGrc8hTMm8BADtaHxtUMWWYQTaNpiPhBiw1gy0TkW3CpKYoSc4wziwkq1V6UOk039JZABZAZAb0V5e2hzm8zt4WhSTa9MF7jCM4y821YoZBZCA3ZBZAeWTV53faqd0Pd9u1UztIBfimsizZAmaujPCpDhYn1sPhBNiOSvcB83JY10oZAjnTqoZBYzFBdKRu4IjHyL7OnrZACWmqgZDZD";
		
		private bool _isLoged;

		public bool IsLogged
		{
			get
			{
				var cur = FBSession.ActiveSession;
				return cur.LoggedIn;
			}
			set { _isLoged = value; }
		} 
		
		public List<Friends> GetFriends()
		{
			List<Friends> FriendsList = new List<Friends>();

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://graph.facebook.com");

				try
				{
					HttpResponseMessage response =
						client.GetAsync($"me/friends?fields=name,id&access_token={userToken}").Result;

					response.EnsureSuccessStatusCode();
					string result = response.Content.ReadAsStringAsync().Result;

					var FriendsInformation = JsonConvert.DeserializeObject<dynamic>(result);
					foreach (var item in FriendsInformation["data"])
					{
						Friends currentFriend = new Friends {Id = item["id"], Name = item["name"]};

						FriendsList.Add(currentFriend);
					}
				}
				catch (Exception ex)
				{
					var dialog = new MessageDialog(ex.Message);
					dialog.Title = "Error";
					dialog.ShowAsync();
				}

				return FriendsList;
			}
		}

		public List<Compositions> GetMusic()
		{
			List<Compositions> musicList = new List<Compositions>
			{
				new Compositions { Name = "Song", Rank = 5 },
				new Compositions { Name = "Song1", Rank = 2 },
				new Compositions { Name = "Song2", Rank = 1 },
				new Compositions { Name = "Song3", Rank = 1 },
				new Compositions { Name = "Song4", Rank = 3 },
				new Compositions { Name = "Song5", Rank = 1 },
				new Compositions { Name = "Song6", Rank = 1 },
				new Compositions { Name = "Song7", Rank = 2 },
				new Compositions { Name = "Song8", Rank = 1 },
				new Compositions { Name = "Song9", Rank = 2 },
				new Compositions { Name = "Song10", Rank = 4 }
			};

			return musicList;
		}

		public async void Login()
		{
			var requestedPermissions = new[] { "public_profile", "email", "user_friends" };

			FBSession currentSession = FBSession.ActiveSession;
			currentSession.WinAppId = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
			currentSession.FBAppId = "469988747194991";

			FBPermissions permissions = new FBPermissions(requestedPermissions);
			FBResult result = await currentSession.LoginAsync(permissions);

			IsLogged = true;
		}

		public async void Logout()
		{
			FBSession currentSessionsession = FBSession.ActiveSession;
			await currentSessionsession.LogoutAsync();
			IsLogged = currentSessionsession.LoggedIn;
		}

	}
}
