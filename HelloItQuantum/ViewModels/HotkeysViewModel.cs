﻿using HelloItQuantum.Function;
using HelloItQuantum.Views;
using System;
using System.Media;
using System.IO;

namespace HelloItQuantum.ViewModels
{
	public class HotkeysViewModel : MainWindowViewModel
    {

        #region
        bool visibleBtnNext = true; //Кнопка Далее
        string textInBtnNext = "Далее"; //Текст внутри кнопки Далее (иногда он может быть Да)
        bool visibleBtnNo = false; //Кнопка Нет
        bool visibleTBAnswer = false; //TB куда вводить ответ
        bool visibleImgAnswer = false; //SP с ответом
        bool visibleSvgHotkey = true; 
        string pathSvgHotkey = "/Assets/ImgHotkeys/Backspace.svg"; 
        string textInSP = ""; //Текст в StackPanel
        string textAnswer = ""; //Текст в поле ввода ответа
        (int, string, int) act = (1, "", 1); 
        string textShowAct = "1/5";
        string dopPath = "";
        string path = "";

        public bool VisibleBtnNext { get => visibleBtnNext; set => SetProperty(ref visibleBtnNext, value); }
        public string TextInBtnNext { get => textInBtnNext; set => SetProperty(ref textInBtnNext, value); }
        public bool VisibleBtnNo { get => visibleBtnNo; set => SetProperty(ref visibleBtnNo, value); }
        public bool VisibleTBAnswer { get => visibleTBAnswer; set => SetProperty(ref visibleTBAnswer, value); }
        public bool VisibleImgAnswer { get => visibleImgAnswer; set => SetProperty(ref visibleImgAnswer, value); }
        public string TextInSP { get => textInSP; set => SetProperty(ref textInSP, value); }
        public string TextShowAct { get => textShowAct; set => SetProperty(ref textShowAct, value); }
        public string TextAnswer { get => textAnswer; set => SetProperty(ref textAnswer, value); }
        public bool VisibleSvgHotkey { get => visibleSvgHotkey; set => SetProperty(ref visibleSvgHotkey, value); }
        public string PathSvgHotkey { get => pathSvgHotkey; set => SetProperty(ref pathSvgHotkey, value); }
        #endregion

        public HotkeysViewModel()
        {
            #if DEBUG
            dopPath = $"{Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))))}\\Assets\\";
            path = $"{dopPath}HotkeysAudio\\voice1.wav";
            #else
            path = $"HotkeysAudio\\voice1.wav";
            #endif
            switch (CurrentUser.GameHotkeys)
            {
                case 20:
                    {
                        act = (6, "Ты молодец. Знаешь ли ты, как с помощью клавиатуры скопировать текст?", 2);
                        path = $"{dopPath}HotkeysAudio\\voice6.wav";
                        TextShowAct = "2/5";
                    }
                    break;
                case 40:
                    {
                        act = (9, "Отлично справляешься. Знаешь ли ты, как с помощью клавиатуры вставить скопированный текст?", 2);
                        path = $"{dopPath}HotkeysAudio\\voice11.wav";
                        TextShowAct = "3/5";
                    }
                    break;
                case 60:
                    {
                        act = (12, "Почти конец! Знаешь ли ты, как стереть символ спереди курсора?", 2);
                        path = $"{dopPath}HotkeysAudio\\voice15.wav";
                        TextShowAct = "4/5";
                    }
                    break;
                case 80:
                    {
                        act = (15, "И мой последний вопрос. Знаешь ли ты, как закрыть приложение, в котором ты сейчас находишься, с помощью клавиш?", 2);
                        path = $"{dopPath}HotkeysAudio\\voice19.wav";
                        TextShowAct = "5/5";
                    } break;
                default: act = act = (1, "Изучать программирование - значит уметь выполнять различные действия на компьютере с помощью клавиатуры", 1); break;
            }
            ParsAct();
        }

        /// <summary>
        /// Функция запуска аудио
        /// </summary>
        public void PlayTask()
        {
            SoundPlayer snd = new SoundPlayer(path);
            snd.Play();
        }

        /// <summary>
        /// Парс элемента очереди
        /// </summary>
        public void ParsAct()
        {
            TextAnswer = "";
            TextInSP = act.Item2;
            switch (act.Item3)
            {
                case 1:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Далее";
                    }; break;
                case 2:
                    {
                        VisibleTBAnswer = false;
                        VisibleBtnNo = true;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Да";
                    }; break;
                case 3:
                    {
                        VisibleTBAnswer = true;
                        VisibleBtnNo = false;
                        VisibleBtnNext = true;
                        TextInBtnNext = "Далее";
                    }; break;
            }
        }

        public void GoBack()
        {
            PageSwitch.View = new PlaySectionView();
        }

        /// <summary>
        /// Обработка нажатий на кнопку
        /// </summary>
        /// <param name="button">Какая кнопка была нажата</param>
        public void GoNext(string button)
        {
            switch (act.Item1)
            {
                case 1:
                    {
                        act = (2, "Готов ли ты проверить свои знания в мире горячих клавиш? Не волнуйся, я тебя научу", 2);
                        path = $"{dopPath}HotkeysAudio\\voice2.wav";
                    }; break;
                case 2:
                    {
                        if (button == "Далее")
                        {
                            act = (3, "Отлично. Начнем с простого вопроса. Знаешь ли ты, как с помощью клавиатуры стирать текст?", 2);
                            path = $"{dopPath}HotkeysAudio\\voice3.wav";
                        }
                        else
                        {
                            GoBack();
                        }
                    }; break;
                case 3:
                    {
                        if (button == "Далее")
                        {
                            act = (4, "Если говоришь, знаешь, введи название клавиши, с помощью которой можно стереть текст", 3);
                            path = $"{dopPath}HotkeysAudio\\voice4.wav";
                        }
                        else
                        {
                            act = (5, "Чтобы стереть текст, который ты написал, необходимо нажать клавишу Backspace. Иногда её изображают стрелочкой влево.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/Backspace.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice5.wav";
                        }
                    }; break;
                case 4:
                    {
                        if (button == "Забыл")
                        {
                            act = (5, "Чтобы стереть текст, который ты написал, необходимо нажать клавишу Backspace. Иногда её изображают стрелочкой влево.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/Backspace.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice5.wav";
                        } 
                        else
                        {
                            if (TextAnswer.ToLower().Trim() == "backspace" || TextAnswer.ToLower().Trim() == "←" || TextAnswer.ToLower().Trim() == "<-")
                            {
                                WorkWithFile.UpdateValueGameProgress(1, 20, CurrentUser);
                                act = (6, "Ты молодец. Знаешь ли ты, как с помощью клавиатуры скопировать текст?", 2);
                                path = $"{dopPath}HotkeysAudio\\voice6.wav";
                                TextShowAct = "2/5";
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer($"HotkeysAudio\\error.wav");
                                snd.Play();
                            }
                        }
                    }; break;
                case 5:
                    {
                        VisibleSvgHotkey = !VisibleSvgHotkey;
                        act = (4, "Введи название клавиши, которую ты узнал, с помощью которой можно стереть текст", 3);
                        path = $"{dopPath}HotkeysAudio\\voice7.wav";
                    }; break;
                case 6:
                    {
                        if (button == "Далее")
                        {
                            act = (8, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно скопировать текст", 3);
                            path = $"{dopPath}HotkeysAudio\\voice8.wav";
                        }
                        else
                        {
                            act = (7, "Чтобы с помощью клавиатуры скопировать текст, необходимо использовать сочетание клавиш Ctrl + C.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/CtrlC.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice9.wav";
                        }
                    }; break;
                case 7:
                    {
                        VisibleSvgHotkey = !VisibleSvgHotkey;
                        act = (8, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно скопировать текст", 3);
                        path = $"{dopPath}HotkeysAudio\\voice10.wav";
                    }; break;
                case 8:
                    {
                        if (button == "Забыл")
                        {
                            act = (7, "Чтобы с помощью клавиатуры скопировать текст, необходимо использовать сочетание клавиш Ctrl + C.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/CtrlC.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice9.wav";
                        }
                        else
                        {
                            if (TextAnswer.ToLower().Trim() == "ctrl + c" || TextAnswer.ToLower().Trim() == "ctrl c" || TextAnswer.ToLower().Trim() == "ctrl+c" || TextAnswer.ToLower().Trim() == "ctrl +c" || TextAnswer.ToLower().Trim() == "ctrl+ c" || TextAnswer.ToLower().Trim() == "ctrlc" || TextAnswer.ToLower().Trim() == "ctrl c")
                            {
                                WorkWithFile.UpdateValueGameProgress(1, 40, CurrentUser);
                                act = (9, "Отлично справляешься. Знаешь ли ты, как с помощью клавиатуры вставить скопированный текст?", 2);
                                path = $"{dopPath}HotkeysAudio\\voice11.wav";
                                TextShowAct = "3/5";
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer($"HotkeysAudio\\error.wav");
                                snd.Play();
                            }
                        }
                    }; break;
                case 9:
                    {
                        if (button == "Далее")
                        {
                            act = (11, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно вставить скопированный текст", 3);
                            path = $"{dopPath}HotkeysAudio\\voice12.wav";
                        }
                        else
                        {
                            act = (10, "Чтобы с помощью клавиатуры вставить скопированный текст, необходимо использовать сочетание клавиш Ctrl + V.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/CtrlV.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice13.wav";
                        }
                    }; break;
                case 10:
                    {
                        VisibleSvgHotkey = !VisibleSvgHotkey;
                        act = (11, "Введи сочетание клавиш, с помощью которых можно вставить скопированный текст", 3);
                        path = $"{dopPath}HotkeysAudio\\voice14.wav";
                    }; break;
                case 11:
                    {
                        if (button == "Забыл")
                        {
                            act = (10, "Чтобы с помощью клавиатуры вставить скопированный текст, необходимо использовать сочетание клавиш Ctrl + V.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/CtrlV.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice13.wav";
                        }
                        else
                        {
                            if (TextAnswer.ToLower().Trim() == "ctrl + v" || TextAnswer.ToLower().Trim() == "ctrl+v" || TextAnswer.ToLower().Trim() == "ctrl +v" || TextAnswer.ToLower().Trim() == "ctrl+ v" || TextAnswer.ToLower().Trim() == "ctrl v" || TextAnswer.ToLower().Trim() == "ctrlv")
                            {
                                WorkWithFile.UpdateValueGameProgress(1, 60, CurrentUser);
                                act = (12, "Почти конец! Знаешь ли ты, как стереть символ спереди курсора?", 2);
                                path = $"{dopPath}HotkeysAudio\\voice15.wav";
                                TextShowAct = "4/5";
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer($"HotkeysAudio\\error.wav");
                                snd.Play();
                            }
                        }
                    }; break;
                case 12:
                    {
                        if (button == "Далее")
                        {
                            act = (14, "Если говоришь, знаешь, введи клавишу, с помощью которой можно стереть текст спереди курсора", 3);
                            path = $"{dopPath}HotkeysAudio\\voice16.wav";
                        }
                        else
                        {
                            act = (13, "Курсор - мерцающая линия, которая дает знать, в каком месте сейчас будет изменяться текст. Чтобы стереть символ спереди курсора необходимо нажать клавишу Delete или Del.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/Del.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice17.wav";
                        }
                    }; break;
                case 13:
                    {
                        VisibleSvgHotkey = !VisibleSvgHotkey;
                        act = (14, "Введи клавишу, с помощью которой можно стереть текст спереди курсора", 3);
                        path = $"{dopPath}HotkeysAudio\\voice18.wav";
                    }; break;
                case 14:
                    {
                        if (button == "Забыл")
                        {
                            act = (13, "Курсор - мерцающая линия, которая дает знать, в каком месте сейчас будет изменяться текст. Чтобы стереть символ спереди курсора необходимо нажать клавишу Delete или Del.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/Del.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice17.wav";
                        }
                        else
                        {
                            if (TextAnswer.ToLower().Trim() == "delete" || TextAnswer.ToLower().Trim() == "del")
                            {
                                WorkWithFile.UpdateValueGameProgress(1, 80, CurrentUser);
                                act = (15, "И мой последний вопрос. Знаешь ли ты, как закрыть приложение, в котором ты сейчас находишься, с помощью клавиш?", 2);
                                path = $"{dopPath}HotkeysAudio\\voice19.wav";
                                TextShowAct = "5/5";
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer($"HotkeysAudio\\error.wav");
                                snd.Play();
                            }
                        }
                    }; break;
                case 15:
                    {
                        if (button == "Далее")
                        {
                            act = (17, "Если говоришь, знаешь, введи сочетание клавиш, с помощью которых можно закрыть приложение, в котором ты сейчас находишься", 3);
                            path = $"{dopPath}HotkeysAudio\\voice20.wav";
                        }
                        else
                        {
                            act = (16, "Чтобы закрыть приложение, в котором ты сейчас находишься, с помощью клавиш, необходимо нажать клавиши Alt + F4.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/AltF4.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice21.wav";
                        }
                    }; break;
                case 16:
                    {
                        VisibleSvgHotkey = !VisibleSvgHotkey;
                        act = (17, "Введи сочетание клавиш, с помощью которых можно закрыть приложение, в котором ты сейчас находишься", 3);
                        path = $"{dopPath}HotkeysAudio\\voice22.wav";
                    }; break;
                case 17:
                    {
                        if (button == "Забыл")
                        {
                            act = (16, "Чтобы закрыть приложение, в котором ты сейчас находишься, с помощью клавиш, необходимо нажать клавиши Alt + F4.", 1);
                            PathSvgHotkey = "/Assets/ImgHotkeys/AltF4.svg";
                            VisibleSvgHotkey = !VisibleSvgHotkey;
                            path = $"{dopPath}HotkeysAudio\\voice21.wav";
                        }
                        else
                        {
                            if (TextAnswer.ToLower().Trim() == "alt + f4" || TextAnswer.ToLower().Trim() == "alt+f4" || TextAnswer.ToLower().Trim() == "alt +f4" || TextAnswer.ToLower().Trim() == "alt+ f4")
                            {
                                WorkWithFile.UpdateValueGameProgress(1, 100, CurrentUser);
                                act = (18, "Ты молодец и знаешь все базовые горячие клавиши для того, чтобы изучать программирование. Надеюсь это поможет тебе выбрать направление. Пока-пока!", 1);
                                path = $"{dopPath}HotkeysAudio\\voice23.wav";
                                TextInBtnNext = "Выйти";
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer($"HotkeysAudio\\error.wav");
                                snd.Play();
                            }
                        }
                    }; break;
                case 18:
                    {
                        GoBack();
                    }; break;
            }
            ParsAct();
        }

    }
}