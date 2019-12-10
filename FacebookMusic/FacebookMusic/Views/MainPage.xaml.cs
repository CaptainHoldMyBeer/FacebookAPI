using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FacebookMusic.Services;
using winsdkfb;
using winsdkfb.Graph;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using FacebookMusic.Models;
using FacebookMusic.Services.Classes;
using Newtonsoft.Json;
using Facebook;
using Facebook.Reflection;
using Newtonsoft.Json.Linq;
using  Flurl;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FacebookMusic.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			//FacebookSocialNetwork fb = new FacebookSocialNetwork();
			//var ListM = fb.GetMusic().Select(n=>n.Name);

			//foreach (var item in ListM)
			//{
			//	FriendsList.Items.Add(item);
			//}
		}
	}
}
