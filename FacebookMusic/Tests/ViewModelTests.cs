using System;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FacebookMusic;
using FacebookMusic.Interfaces;
using FacebookMusic.ViewModels;
using Moq;

namespace FacebookMusic
{
	[TestClass]
	public class ViewModelTests
	{
		[TestMethod]
		public void LoginCommand_OnCall_CallsLoginMethod()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.LoginCommand.Execute(null);

			mock.Verify(x=>x.Login());
		}

		[TestMethod]
		public void LogoutCommand_OnCall_CallsLogoutMethod()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.LogoutCommand.Execute(null);

			mock.Verify(x => x.Logout());
		}

		[TestMethod]
		public void LogoutCommand_OnCall_ClearFriendsLists()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.LogoutCommand.Execute(null);

			Assert.IsNull(sut.FriendsNames);
		}

		[TestMethod]
		public void LogoutCommand_OnCall_ClearMusicLists()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.LogoutCommand.Execute(null);

			Assert.IsNull(sut.Music);
		}

		[TestMethod]
		public void GetFriendsCommand_OnCall_CallsGetFriendsFromInterface()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.GetFriendsCommand.Execute(null);

			mock.Verify(x => x.GetFriends());
		}

		[TestMethod]
		public void GetMusicCommand_OnCall_CallsGetMusicFromInterface()
		{
			var mock = new Mock<ISocialNetwork>();
			var sut = new MainPageViewModel();

			sut.GetMusicCommand.Execute(null);

			mock.Verify(x => x.GetMusic());
		}
	}
}
