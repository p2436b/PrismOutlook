using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using PrismOutlook.Core;
using System.Windows;

namespace PrismOutlook.Views
{
	public partial class MainWindow : XamRibbonWindow
	{
		private readonly IApplicationCommands applicationCommands;

		public MainWindow(IApplicationCommands applicationCommands)
		{
			InitializeComponent();
			this.applicationCommands = applicationCommands;
		}

		private void XamOutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
		{
			if(sender is XamOutlookBar outlookBar)
			{
				var selectedGroup = outlookBar.SelectedGroup as IOutlookBarGroup;
				applicationCommands.NavigateCommand.Execute(selectedGroup.DefaultNavigatinPath);
			}
		}
	}
}
