﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Classes
{
    public class ChoiceInput : IInput, IElement
    {
        public string AlternateValue { get; set; }
        public bool AutoComplete { get; set; } = false;
        public string Default { get; set; }
        public int DropDownSize { get; set; } = 5;
        public string Question { get; set; } // required
        public bool? Required { get; set; }
        public bool Sort { get; set; } = true;
        public string Variable { get; set; } // required
        public ObservableCollection<IChoice> Choices { get; set; }

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "ChoiceInput", null);
            XmlAttribute alternateValue = d.CreateAttribute("AlternateValue");
            XmlAttribute autoComplete = d.CreateAttribute("AutoComplete");
            XmlAttribute _default = d.CreateAttribute("Default");
            XmlAttribute dropDownSize = d.CreateAttribute("DropDownSize");
            XmlAttribute question = d.CreateAttribute("Question"); // required
            XmlAttribute required = d.CreateAttribute("Required");
            XmlAttribute sort = d.CreateAttribute("Sort");
            XmlAttribute variable = d.CreateAttribute("Variable"); // required

            // Set Attribute values
            alternateValue.Value = AlternateValue;
            autoComplete.Value = AutoComplete.ToString();
            _default.Value = Default;
            dropDownSize.Value = DropDownSize.ToString();
            question.Value = Question;
            required.Value = Required.ToString();
            sort.Value = Sort.ToString();
            variable.Value = Variable;

            // Append Attributes
            if(!string.IsNullOrEmpty(AlternateValue))
            {
                output.Attributes.Append(alternateValue);
            }
            output.Attributes.Append(autoComplete);
            if(!string.IsNullOrEmpty(Default))
            {
                output.Attributes.Append(_default);
            }
            output.Attributes.Append(dropDownSize);
            output.Attributes.Append(question);
            if(null != Required)
            {
                output.Attributes.Append(required);
            }
            output.Attributes.Append(sort);
            output.Attributes.Append(variable);

            // Append Children
            foreach(IChoice choice in Choices)
            {
                output.AppendChild(choice.GenerateXML());
            }

            return output;
        }
    }
}
