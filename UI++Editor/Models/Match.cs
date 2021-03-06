﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;
using UI__Editor.ViewModels.Actions.Children;

namespace UI__Editor.Models
{
    public class Match : PropertyChangedBase, IElement, IChildElement
    {
        public ViewModels.Actions.IAction ViewModel { get; set; }
        public IElement Parent { get; set; }
        public bool HasSubChildren { get { return false; } }
        public string ActionType { get { return "Match"; } }
        public string[] ValidChildren { get; set; } = { "" };
        public string[] ValidParents { get; set; } = { "SoftwareDiscovery" };
        public string DisplayName { get; set; } // required
        public string Variable { get; set; } // required
        public string Version { get; set; }
        public string VersionOperator { get; set; }
        public string Condition { get; set; }

        public Match(IParentElement parent)
        {
            Parent = parent;
            ViewModel = new MatchViewModel(this);
        }

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

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Match", null);
            XmlAttribute displayName = d.CreateAttribute("DisplayName");
            XmlAttribute variable = d.CreateAttribute("Variable");
            XmlAttribute version = d.CreateAttribute("Version");
            XmlAttribute versionOperator = d.CreateAttribute("VersionOperator");
            XmlAttribute condition = d.CreateAttribute("Condition");

            // Set Attribute Values
            displayName.Value = DisplayName;
            variable.Value = Variable;
            version.Value = Version;
            versionOperator.Value = VersionOperator;
            condition.Value = Condition;

            // Append Attributes
            output.Attributes.Append(displayName);
            output.Attributes.Append(variable);
            if (!string.IsNullOrEmpty(Version))
            {
                output.Attributes.Append(version);
            }
            if (!string.IsNullOrEmpty(VersionOperator))
            {
                output.Attributes.Append(versionOperator);
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                output.Attributes.Append(condition);
            }

            return output;
        }
    }
}
