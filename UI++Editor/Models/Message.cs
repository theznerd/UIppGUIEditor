﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Models
{
    public class Message : PropertyChangedBase, IElement
    {
        public ViewModels.Actions.IAction ViewModel { get; set; }
        public IElement Parent { get; set; }
        public bool HasSubChildren { get { return false; } }
        public string ActionType { get { return "Message"; } }

        // Code to handle TreeView Selection
        private bool _TVSelected = false;
        public bool TVSelected
        {
            get { return _TVSelected; }
            set
            {
                _TVSelected = value;
                NotifyOfPropertyChange(() => TVSelected);
            }
        }

        private bool _TVIsExpanded = true;
        public bool TVIsExpanded
        {
            get { return _TVIsExpanded; }
            set
            {
                _TVIsExpanded = value;
                NotifyOfPropertyChange(() => TVIsExpanded);
            }
        }
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private string _Content;
        public string Content
        {
            get { return _Content; }
            set
            {
                _Content = value;
                NotifyOfPropertyChange(() => Content);
                Type t = typeof(Globals);
                FieldInfo f = t.GetField(Id);
                f.SetValue(null, value);
            }
        }

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Message", null);
            
            XmlAttribute id = d.CreateAttribute("Id");

            // Set Attribute Values
            id.Value = Id;

            // Append Attributes to Node
            output.Attributes.Append(id);
            output.InnerText = Content;

            return output;
        }
    }
}
