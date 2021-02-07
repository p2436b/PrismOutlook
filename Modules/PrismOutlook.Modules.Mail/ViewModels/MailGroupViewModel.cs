using Prism.Commands;
using Prism.Mvvm;
using PrismOutlook.Business;
using PrismOutlook.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Modules.Mail.ViewModels
{
	public class MailGroupViewModel : ViewModelBase
	{
		private ObservableCollection<NavigationItem> _items;
		public ObservableCollection<NavigationItem> Items
		{
			get { return _items; }
			set { SetProperty(ref _items, value); }
		}

		private DelegateCommand<NavigationItem> _selectedCommand;
		private readonly IApplicationCommands applicationCommands;

		public DelegateCommand<NavigationItem> SelectedCommand =>
				_selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedCommand));

		void ExecuteSelectedCommand(NavigationItem navigationItem)
		{
			if (navigationItem != null)
				applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
		}

		public MailGroupViewModel(IApplicationCommands applicationCommands)
		{
			GenerateMenu();
			this.applicationCommands = applicationCommands;
		}

		void GenerateMenu()
		{
			Items = new ObservableCollection<NavigationItem>();
			var root = new NavigationItem { Caption = "Personal Folder", NavigationPath = "MailList?id=Default" };
			root.Items.Add(new NavigationItem { Caption = "Inbox", NavigationPath = "MailList?id=Inbox" });
			root.Items.Add(new NavigationItem { Caption = "Sent", NavigationPath = "MailList?id=Sent" });
			root.Items.Add(new NavigationItem { Caption = "Trash", NavigationPath = "MailList?id=Trash" });
			Items.Add(root);
		}
	}
}
