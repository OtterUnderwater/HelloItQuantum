using HelloItQuantum.Views;
using System;
using System.IO;
using System.Media;

namespace HelloItQuantum.ViewModels
{
	public class HotkeysViewModel : MainWindowViewModel
    {

        #region
        bool visibleBtnNext = true; //������ �����
        string textInBtnNext = "�����"; //����� ������ ������ ����� (������ �� ����� ���� ��)
        bool visibleBtnNo = false; //������ ���
        bool visibleTBAnswer = false; //TB ���� ������� �����
        bool visibleImgAnswer = false; //SP � �������
        string textInSP = "������� ���������������� - ������ ����� ��������� ��������� �������� �� ���������� � ������� ����������"; //����� � StackPanel
        string textAnswer = ""; //����� � ���� ����� ������
        (int, string, int) act = (1, "", 1); 
        string textShowAct = "1/5";

        public bool VisibleBtnNext { get => visibleBtnNext; set => SetProperty(ref visibleBtnNext, value); }
        public string TextInBtnNext { get => textInBtnNext; set => SetProperty(ref textInBtnNext, value); }
        public bool VisibleBtnNo { get => visibleBtnNo; set => SetProperty(ref visibleBtnNo, value); }
        public bool VisibleTBAnswer { get => visibleTBAnswer; set => SetProperty(ref visibleTBAnswer, value); }
        public bool VisibleImgAnswer { get => visibleImgAnswer; set => SetProperty(ref visibleImgAnswer, value); }
        public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
        public string TextShowAct { get => textShowAct; set => SetProperty(ref textShowAct, value); }
        public string TextAnswer { get => textAnswer; set => SetProperty(ref textAnswer, value); }
        #endregion

        /// <summary>
        /// ������� ������� �����
        /// </summary>
        public void PlayTask()
        {
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))));
            string path = "";
            switch (act.Item1)
            {
                case 1:
                    {
                        path = $"{directory}\\Assets\\HotkeysAudio\\voice1.wav";
                    }; break;
                case 2:
                    {
                        path = $"{directory}\\Assets\\HotkeysAudio\\voice2.wav";
                    }; break;
            }
            SoundPlayer snd = new SoundPlayer(path);
            snd.Play();
        }

        /// <summary>
        /// ���� �������� �������
        /// </summary>
        public void NextAct()
        {
            TextInSP = act.Item2;
            TextShowAct = "1/5";
            switch (act.Item3)
            {
                case 1:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "�����";
                    }; break;
                case 2:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = true;
                        VisibleBtnNext = true;
                        TextInBtnNext = "��";
                    }; break;
                case 3:
                    {
                        VisibleTBAnswer = true;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "�����";
                    }; break;
            }
        }

        /// <summary>
        /// ��������� ������� �� ������
        /// </summary>
        /// <param name="button">����� ������ ���� ������</param>
        public void GoNext(string button) 
        {
            switch (act.Item1)
            {
                case 1:
                    {
                        act = (2, "����� �� �� ��������� ���� ������ � ���� ������� ������? �� ��������, � ���� �����", 2);
                    }; break;
                case 2:
                    {
                        if (button == "�����")
                        {
                            act = (3, "�������. ������ � �������� �������. ������ �� ��, ��� � ������� ���������� ������� �����?", 2);
                        }
                        else
                        {
                            PageSwitch.View = new PlaySectionView();
                        }
                    }; break;
                case 3:
                    {
                        if (button == "�����")
                        {
                            act = (4, "���� ��������, ������, ����� �������� �������, � ������� ������� ����� ������� �����", 3);
                        }
                        else
                        {
                            act = (5, "����� ������� �����, ������� �� �������, ���������� ������ ������� Backspace. ������ � ���������� ���������� ����� ? ", 1);
                        }
                    }; break;
                case 4:
                    {
                        if (TextAnswer == "Backspace" || TextAnswer == "?")
                        {
                            act = (6, "�� �������. ������ �� ��, ��� � ������� ���������� ����������� �����?", 2);
                        }
                        else
                        {
                            TextAnswer = "�������";
                        }
                    }; break;
                case 5:
                    {
                        act = (4, "����� �������� �������, ������� �� �����, � ������� ������� ����� ������� �����", 3);
                    }; break;
            }
            NextAct();
        }


    }
}