using System;

using Xamarin.Forms;

namespace EmailTestApp
{
	public class App : Application
	{
		public App()
		{
			var sendEmail = new Button
			{
				Text = "Send",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			sendEmail.Clicked += (sender, e) =>
			{
				DependencyService.Get<IEmailService>().ShowDraft();
			};

			var content = new ContentPage
			{
				Title = "EmailTestApp",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						sendEmail
					}
				}
			};
			MainPage = new NavigationPage(content);
		}
	}
}
