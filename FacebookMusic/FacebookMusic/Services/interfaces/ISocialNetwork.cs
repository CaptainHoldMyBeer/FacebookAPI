using System.Collections.Generic;
using FacebookMusic.Models;

namespace FacebookMusic.Interfaces
{
	public interface ISocialNetwork
	{
		bool IsLogged { get; set; }
		void Login();
		void Logout();
		List<Friends> GetFriends();
		List<Compositions> GetMusic();
	}
}
