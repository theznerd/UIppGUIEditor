﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;
using Caliburn.Micro;

namespace UI__Editor.Models.ActionClasses
{
    public class WMIRead : PropertyChangedBase, IElement, IAction
    {
        public IEventAggregator EventAggregator { get; set; }
        public ViewModels.Actions.IAction ViewModel { get; set; }
        public IElement Parent { get; set; }
        public bool HasSubChildren { get { return false; } }
        public string ActionType { get; } = "WMI Read";
        public string Class { get; set; } // required
        public string Default { get; set; }
        public string KeyQualifier { get; set; }
        public string Namespace { get; set; } // defualt is root\cimv2
        public string Property { get; set; } // required
        public string Variable { get; set; } // required
        public string Query { get; set; } // required
        public string Condition { get; set; }

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
        public WMIRead(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            ViewModel = new ViewModels.Actions.WMIReadViewModel(this);
        }

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Action", null);
            XmlAttribute type = d.CreateAttribute("Type");
            XmlAttribute _class = d.CreateAttribute("Class");
            XmlAttribute _default = d.CreateAttribute("Default");
            XmlAttribute keyQualifier = d.CreateAttribute("KeyQualifier");
            XmlAttribute _namespace = d.CreateAttribute("Namespace");
            XmlAttribute property = d.CreateAttribute("Property");
            XmlAttribute variable = d.CreateAttribute("Variable");
            XmlAttribute query = d.CreateAttribute("Query");
            XmlAttribute condition = d.CreateAttribute("Condition");

            // Assign attribute values
            type.Value = "WMIRead";
            _class.Value = Class;
            property.Value = Property;
            variable.Value = Variable;
            query.Value = Query;
            _default.Value = Default;
            keyQualifier.Value = KeyQualifier;
            _namespace.Value = Namespace;
            condition.Value = Condition;

            // Append Attributes
            output.Attributes.Append(type);
            output.Attributes.Append(_class);
            output.Attributes.Append(property);
            output.Attributes.Append(variable);
            output.Attributes.Append(query);
            if (!string.IsNullOrEmpty(Default))
            {
                output.Attributes.Append(_default);
            }
            if (!string.IsNullOrEmpty(KeyQualifier))
            {
                output.Attributes.Append(keyQualifier);
            }
            if (!string.IsNullOrEmpty(Namespace))
            {
                output.Attributes.Append(_namespace);
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                output.Attributes.Append(condition);
            }

            return output;
        }
    }
}
