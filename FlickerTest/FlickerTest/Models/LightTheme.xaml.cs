using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlickerTest.Models
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LightThemeDictionary : ResourceDictionary
	{
		public LightThemeDictionary()
		{
			InitializeComponent();
			Add(new BaseApplicationResourceDictionary());
		}


		/*

		void OnButtonClicked (object sender, EventArgs e)
		{
			if (originalStyle) {
				Resources ["searchBarStyle"] = Resources ["greenSearchBarStyle"];
				originalStyle = false;
			} else {
				Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];
				originalStyle = true;
			}
		}

		 <ContentPage.Resources>
			<ResourceDictionary>
				<Style x:Key="baseStyle" TargetType="View">
					<Setter Property="VerticalOptions" Value="CenterAndExpand" />
				</Style>
				<Style x:Key="blueSearchBarStyle" TargetType="SearchBar" BasedOn="{StaticResource baseStyle}">
					<Setter Property="FontAttributes" Value="Italic" />
					<Setter Property="PlaceholderColor" Value="Blue" />
				</Style>
				<Style x:Key="greenSearchBarStyle" TargetType="SearchBar">
					<Setter Property="FontAttributes" Value="None" />
					<Setter Property="PlaceholderColor" Value="Green" />
				</Style>
				<Style x:Key="buttonStyle" TargetType="Button" BasedOn="{StaticResource baseStyle}">
					<Setter Property="FontSize" Value="Large" />
					<Setter Property="TextColor" Value="Red" />
				</Style>
			</ResourceDictionary>
		</ContentPage.Resources>
		<ContentPage.Content>
			<StackLayout Padding="0,20,0,0">
				<SearchBar Placeholder="These SearchBar controls" Style="{DynamicResource searchBarStyle}" />
				<SearchBar Placeholder="are demonstrating" Style="{DynamicResource searchBarStyle}" />
				<SearchBar Placeholder="dynamic styles," Style="{DynamicResource searchBarStyle}" />
				<SearchBar Placeholder="but this isn't dynamic" Style="{StaticResource blueSearchBarStyle}" />
				<Button Text="Change Style" Style="{StaticResource buttonStyle}" Clicked="OnButtonClicked" />
			</StackLayout>
		</ContentPage.Content>
		 */
	}
}