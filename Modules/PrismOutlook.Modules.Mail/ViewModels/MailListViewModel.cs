using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismOutlook.Modules.Mail.ViewModels
{
	public class MailListViewModel : ViewModelBase, INavigationAware
	{
		private string title;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}
		public MailListViewModel()
		{

		}

		override public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Title = navigationContext.Parameters.GetValue<string>("id");
		}
	}
}
