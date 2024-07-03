using System;
using System.Collections.Generic;
using System.Media;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using HelloItQuantum.Views;


namespace HelloItQuantum.ViewModels
{
	public class LabyrinthViewModel : MainWindowViewModel
	{
		List<string> listContent = new List<string>();
		bool isVisibleContextWindow = true;
		string dopPath = "";
		string textInSP = "���-��� ����� ������. �� ����� ������ ���������� �� �������, �� ����� ���� ��� �������� �� ��������� � ������� ������. ������ ��� ���� ������ �� ���������, ������� �������. ������ ������ ��������� �� ������� ����������.";
		string textInBTN = "�����";
		string pathAudio = "";

		StackPanel listCommandForRobots = new StackPanel();
		public StackPanel ListCommandForRobots { get => listCommandForRobots; set => SetProperty(ref listCommandForRobots, value); }
		public bool IsVisibleContextWindow { get => isVisibleContextWindow; set => SetProperty(ref isVisibleContextWindow, value); }
		public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
		public string TextInBTN { get => textInBTN; set => SetProperty(ref textInBTN, value); }

		public LabyrinthViewModel()
		{
			#if DEBUG
			dopPath = $"{System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))))}\\Assets\\";
			pathAudio = $"{dopPath}LabyrinthAudio\\voice_start.wav";
			#else
			pathAudio = $"LabyrinthAudio\\voice_start.wav";
			#endif
		}

		/// <summary>
		/// ������� ������� �����
		/// </summary>
		public void PlayTask()
		{
			SoundPlayer snd = new SoundPlayer(pathAudio);
			snd.Play();
		}
		public void GoNext()
		{
			IsVisibleContextWindow = false;
		}
		/// <summary>
		/// ��������� � ������� ����
		/// </summary>
		public void GoBack()
		{
			PageSwitch.View = new PlaySectionView();
		}
		/// <summary>
		/// ���������� ������ ������ ��� ������� �� ������
		/// </summary>
		/// <param name="comand">������������ ������� (�����, ������, ����, �����)</param>
		public void AddButton(string comand)
		{
			ListCommandForRobots.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
			TextBlock tb = new TextBlock();
			tb.Text = "go " + comand;
			tb.TextAlignment = TextAlignment.Center;
			tb.FontSize = 24;
			tb.Width = 150;
			tb.Margin = new Thickness(10);
			Border border = new Border();
			border.CornerRadius = new CornerRadius(20);
			border.Background = new SolidColorBrush(Avalonia.Media.Color.FromArgb(242, 101, 39, 0));
			border.Child = tb;
			border.Margin = new Thickness(5);
			ListCommandForRobots.Children.Add(border);
			listContent.Add(tb.Text);
		}
		/// <summary>
		/// �������� ������ ������ ��� ������
		/// </summary>
		public void DeleteCommand()
		{
			ListCommandForRobots.Children.Clear();
			listContent.Clear();
		}
		/// <summary>
		/// �������� ������������ ������ ������
		/// </summary>
		public void CheckCommand()
		{
			//ListCommandForRobots.Children.Clear();
			var c = ListCommandForRobots.Children;
			bool googCommands = true;
			if (listContent.Count < 9)
			{
				googCommands = false;
			}
			else
			{
				for (int i = 0; i < listContent.Count; i++)
				{
					if (listContent[0] != "go right")
					{
						googCommands = false; break;
					}
					if (listContent[1] != "go right")
					{
						googCommands = false; break;
					}
					if (listContent[2] != "go up")
					{
						googCommands = false; break;
					}
					if (listContent[3] != "go up")
					{
						googCommands = false; break;
					}
					if (listContent[4] != "go left")
					{
						googCommands = false; break;
					}
					if (listContent[5] != "go up")
					{
						googCommands = false; break;
					}
					if (listContent[6] != "go up")
					{
						googCommands = false; break;
					}
					if (listContent[7] != "go right")
					{
						googCommands = false; break;
					}
					if (listContent[8] != "go right")
					{
						googCommands = false; break;
					}
				}
			}
			if (googCommands)
			{
				CurrentUser.GameLabyrinth = 100;			
				#if DEBUG
				pathAudio = $"{dopPath}LabyrinthAudio\\voice_win.wav";
				#else
				pathAudio = $"LabyrinthAudio\\voice_win.wav";
				#endif
				TextInSP = "�������! ������ �������� �� ����������������� ������� � ����� ���������� �������� �����������. ������ ���������!";
				IsVisibleContextWindow = true;
				TextInBTN = "�������";
			}
			else
			{
				TextInSP = "� ���������, ������ ���������� � �� �������� �� ����������������� �������. �� ����������! �������� ������!";
				#if DEBUG
				pathAudio = $"{dopPath}LabyrinthAudio\\voice_loss.wav";
				#else
				pathAudio = $"LabyrinthAudio\\voice_loss.wav";
				#endif
				IsVisibleContextWindow = true;
				TextInBTN = "�������";
			}
		}


	}

}