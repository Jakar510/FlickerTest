﻿using System;
using System.ComponentModel;
using FlickerTest.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlickerTest.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : TabbedPage
	{
		public MainPage(Theme theme = Theme.Unspecified)
		{
			InitializeComponent();
			App.SetTheme(theme);
		}
	}
}