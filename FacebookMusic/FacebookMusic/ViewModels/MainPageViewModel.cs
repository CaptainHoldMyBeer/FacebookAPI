using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Autofac;
using FacebookMusic.Interfaces;
using FacebookMusic.Locator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FacebookMusic.ViewModels
{
	public class MainPageViewModel:ViewModelBase
	{
		private readonly ISocialNetwork _fbSocialNetwork;

		public List<string> _friendsNames { get; set; }
		public List<string> FriendsNames
		{
			get
			{
				return _friendsNames ?? (_friendsNames = new List<string>());
			}
			set
			{
				_friendsNames = value;
				RaisePropertyChanged();
			}
		}

		private List<string> _music;
		public List<string> Music
		{
			get
			{
				return _music ?? (_music = new List<string>());
			}
			set
			{
				_music = value;
				RaisePropertyChanged();
			}
		}

		private List<string> _currentView;
		public List<string> CurrentView
		{
			get
			{
				return _currentView ?? (_currentView = new List<string>());

			}
			set
			{
				_currentView = value;
				base.RaisePropertyChanged();
			}
		}
		private string _greeting;
		public string Greeting
		{
			get { return _greeting; }
			set
			{
				_greeting = value;
				RaisePropertyChanged();
			}
		}

		private bool _load;
		public bool Load
		{
			get { return _load; }
			set
			{
				_load = value;
				RaisePropertyChanged();
			}
		}

		public ICommand LoginCommand { get; set; }
		public ICommand LogoutCommand { get; set; }
		public ICommand GetFriendsCommand { get; set; }
		public ICommand GetMusicCommand { get; set; } 

		private async void Login()
		{
			 await Task.Run(()=>_fbSocialNetwork.Login());
			Greeting = "Welcome";
		}

		private async void Logout()
		{
			 await Task.Run(()=>_fbSocialNetwork.Logout());
			_fbSocialNetwork.IsLogged = false;

			Greeting = "Good by";
			CurrentView = null;
			Music = null;
			FriendsNames = null;
		}

		private async void GetFriends()
		{
			Load = true;

			if (_fbSocialNetwork.IsLogged)
			{
				FriendsNames = await Task.Run(() => _fbSocialNetwork.GetFriends().Select(n => n.Name).ToList());
				CurrentView = FriendsNames;
				Greeting = "User's Friends";
			}
			else
			{
				var dialog = new MessageDialog("You must login first");
				dialog.Title = "Error";
				await dialog.ShowAsync();
			}

			Load = false;
		}

		private async void GetMusic() 
		{
			Load = true;
			await Task.Delay(1000);
			if (_fbSocialNetwork.IsLogged)
			{
				Music = await Task.Run(()=> _fbSocialNetwork.GetMusic().Select(n=>"Name: "+n.Name+ ". Rank: "+n.Rank).ToList());
				
				CurrentView = Music;
				Greeting = "User's music";
			}
			else
			{
				var dialog = new MessageDialog("You must login first");
				dialog.Title = "Error";
				await dialog.ShowAsync();
			}

			Load = false;
		}

		public MainPageViewModel()
		{
			_fbSocialNetwork = ViewModelLocator.GetContainer().Resolve<ISocialNetwork>();

			LoginCommand=new RelayCommand(Login);

			LogoutCommand = new RelayCommand(Logout);

			GetFriendsCommand = new RelayCommand(GetFriends);

			GetMusicCommand = new RelayCommand(GetMusic); 
		}

	}
}
