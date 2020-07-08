﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI__Editor.Models;
using UI__Editor.ViewModels.Elements;
using UI__Editor.ViewModels.Preview;

namespace UI__Editor.ViewModels.Actions.Children
{
    public class InputChoiceViewModel : IAction
    {
        public IPreview PreviewViewModel { get; set; }
        public object ModelClass { get; set; }
        public string ActionTitle { get { return "Choice"; } }
        public string HiddenAttributes
        {
            get { return ""; }
        }

        public InputChoiceViewModel(InputChoice i)
        {
            ModelClass = i;
            PreviewViewModel = new ViewModels.Preview.Children.InputChoiceViewModel();
        }

        public string AlternateVariable
        {
            get { return (ModelClass as InputChoice).AlternateVariable; }
            set
            {
                (ModelClass as InputChoice).AlternateVariable = value;
            }
        }

        public bool AutoComplete
        {
            get { return (ModelClass as InputChoice).AutoComplete; }
            set
            {
                (ModelClass as InputChoice).AutoComplete = value;
            }
        }

        public string Default
        {
            get { return (ModelClass as InputChoice).Default; }
            set
            {
                (ModelClass as InputChoice).Default = value;
            }
        }

        public int DropDownSize
        {
            get { return (ModelClass as InputChoice).DropDownSize; }
            set
            {
                (ModelClass as InputChoice).DropDownSize = value;
            }
        }

        public string Question
        {
            get { return (ModelClass as InputChoice).Question; }
            set
            {
                (ModelClass as InputChoice).Question = value;
            }
        }

        public bool Required
        {
            get { return (ModelClass as InputChoice).Required; }
            set
            {
                (ModelClass as InputChoice).Required = value;
            }
        }

        public bool Sort
        {
            get { return (ModelClass as InputChoice).Sort; }
            set
            {
                (ModelClass as InputChoice).Sort = value;
            }
        }

        public string Variable
        {
            get { return (ModelClass as InputChoice).Variable; }
            set
            {
                (ModelClass as InputChoice).Variable = value;
            }
        }

        public string Condition
        {
            get { return (ModelClass as InputChoice).Condition; }
            set
            {
                (ModelClass as InputChoice).Condition = value;
            }
        }
    }
}
