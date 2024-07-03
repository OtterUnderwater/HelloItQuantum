using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using HelloItQuantum.Views;

namespace HelloItQuantum.ViewModels
{
	public class HomeViewModel : MainWindowViewModel
	{
		public void ClickPlay()
		{
			PlaySectionVM = new PlaySectionViewModel();
			PageSwitch.View = new PlaySectionView();
		}

		public void ClickStatistic()
		{
            ProgressVM = new ProgressViewModel();
            PageSwitch.View = new ProgressView();
        }

		public void ClickExit()
		{
			Window window = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
			if (window != null)
				window.Close();
		}
	}
}