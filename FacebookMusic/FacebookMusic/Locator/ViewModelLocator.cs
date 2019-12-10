using GalaSoft.MvvmLight;
using Autofac;
using FacebookMusic.Interfaces;
using FacebookMusic.Services.Classes;
using FacebookMusic.ViewModels;

namespace FacebookMusic.Locator
{
	class ViewModelLocator
	{
		private static readonly IContainer _container;

		public static MainPageViewModel MainPageInstance => 
			_container.Resolve<MainPageViewModel>();

		public ViewModelLocator()
		{

		}
		static ViewModelLocator()
		{
			ContainerBuilder builder = new ContainerBuilder();

			ViewModelLocator.AddBindings(builder);

			_container = builder.Build();
		}
		public static IContainer GetContainer()
		{
			return _container;
		}

		private static void AddBindings(ContainerBuilder builder)
		{
			builder.RegisterType<FacebookSocialNetwork>().As<ISocialNetwork>();

			builder.RegisterType<MainPageViewModel>();
		}
	}
}
