﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using UI__Editor.Views.Menus.Actions;

namespace UI__Editor.ViewModels.Preview
{
    class UserAuthViewModel : PropertyChangedBase, IPreview
    {
        public bool PreviewRefreshButtonVisible { get { return false; } }
        public bool PreviewBackButtonVisible { get { return false; } }
        public bool PreviewCancelButtonVisible { get { return true; } }
        public bool PreviewAcceptButtonVisible { get { return true; } }

        private string title = "Welcome";
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
    }
}