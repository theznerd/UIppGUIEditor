﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UI__Editor.Models;

namespace UI__Editor.ViewModels.Menus
{
    public class ConfigurationViewModel : PropertyChangedBase
    {
        private IEventAggregator _eventAggregator;
        private UIpp UIpp;

        public ConfigurationViewModel(IEventAggregator ea, UIpp uipp)
        {
            _eventAggregator = ea;
            UIpp = uipp;
            ConfigFont = "Tahoma";
        }

        public void RefreshConfiguration()
        {
            ConfigTitle = UIpp.Title;
            ConfigRootXMLPath = UIpp.RootXMLPath;
            ConfigIcon = UIpp.Icon;
            ConfigColor = string.IsNullOrEmpty(UIpp.Color) ? "#002147" : UIpp.Color;
            ConfigAlwaysOnTop = (null != UIpp.AlwaysOnTop) ? (bool)UIpp.AlwaysOnTop : true;
            ConfigDialogSideBar = (null != UIpp.DialogSidebar) ? (bool)UIpp.DialogSidebar : true;
            ConfigFlatView = (null != UIpp.Flat) ? (bool)UIpp.Flat : false;
        }

        private string _configTitle;
        public string ConfigTitle
        {
            get { return _configTitle; }
            set
            {
                _configTitle = value;
                UIpp.Title = value;
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("title", value));
                NotifyOfPropertyChange(() => ConfigTitle);
            }
        }

        private string _configRootXMLPath;
        public string ConfigRootXMLPath
        {
            get { return _configRootXMLPath; }
            set
            {
                _configRootXMLPath = value;
                UIpp.RootXMLPath = value;
                Globals.BaseXMLPath = value;
                NotifyOfPropertyChange(() => ConfigRootXMLPath);
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("icon", Controllers.ImageController.ConvertURI(ConfigIcon, Globals.BaseXMLPath)));
            }
        }

        private string _configIcon;
        public string ConfigIcon
        {
            get { return _configIcon; }
            set
            {
                _configIcon = value;
                UIpp.Icon = value;
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("icon", Controllers.ImageController.ConvertURI(value, Globals.BaseXMLPath)));
                NotifyOfPropertyChange(() => ConfigIcon);
            }
        }

        private string _configColor = "#002147";
        public string ConfigColor
        {
            get { return _configColor; }
            set
            {
                _configColor = value.Replace("#FF", "#");
                UIpp.Color = value.Replace("#FF", "#");
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("color", value.Replace("#FF", "#")));
                NotifyOfPropertyChange(() => ConfigColor);
            }
        }

        private bool _configAlwaysOnTop;
        public bool ConfigAlwaysOnTop
        {
            get { return _configAlwaysOnTop; }
            set
            {
                _configAlwaysOnTop = value;
                UIpp.AlwaysOnTop = value;
                NotifyOfPropertyChange(() => ConfigAlwaysOnTop);
            }
        }

        private string _ConfigFont;
        public string ConfigFont
        {
            get { return _ConfigFont; }
            set
            {
                _ConfigFont = value;
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("font", value));
                Globals.DisplayFont = value;
                NotifyOfPropertyChange(() => ConfigFont);
            }
        }

        private bool _configDialogSideBar = true;
        public bool ConfigDialogSideBar
        {
            get { return _configDialogSideBar; }
            set
            {
                _configDialogSideBar = value;
                UIpp.DialogSidebar = value;
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("showsidebar", value));
                NotifyOfPropertyChange(() => ConfigDialogSideBar);
            }
        }

        private bool _configFlatView;
        public bool ConfigFlatView
        {
            get { return _configFlatView; }
            set
            {
                _configFlatView = value;
                UIpp.Flat = value;
                _eventAggregator.BeginPublishOnUIThread(new EventAggregators.ChangeUI("flatview", value));
                NotifyOfPropertyChange(() => ConfigFlatView);
            }
        }
    }
}
