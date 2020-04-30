﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Classes.ActionClasses
{
    public class RegWrite : IElement, IAction
    {
        public string Type { get; } = "RegWrite";
        public string Default { get; set; }
        public string Hive { get; set; } // Default is HKLM
        public string Key { get; set; } // Required
        public bool? Reg64 { get; set; } // Default is true
        public string ValueType { get; set; }
        public string Value { get; set; } // required
        public string Content { get; set; }
        public string Condition { get; set; }

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Action", null);
            XmlAttribute type = d.CreateAttribute("Type");
            XmlAttribute _default = d.CreateAttribute("Default");
            XmlAttribute hive = d.CreateAttribute("Hive");
            XmlAttribute key = d.CreateAttribute("Key");
            XmlAttribute reg64 = d.CreateAttribute("Reg64");
            XmlAttribute valueType = d.CreateAttribute("ValueType");
            XmlAttribute value = d.CreateAttribute("Value");
            XmlAttribute condition = d.CreateAttribute("Condition");

            // Assign attribute values
            type.Value = Type;
            _default.Value = Default;
            hive.Value = Hive;
            key.Value = Key;
            reg64.Value = Reg64.ToString();
            valueType.Value = ValueType;
            value.Value = Value;
            condition.Value = Condition;

            // Append Attributes
            output.Attributes.Append(type);
            if (!string.IsNullOrEmpty(Default))
            {
                output.Attributes.Append(_default);
            }
            if (!string.IsNullOrEmpty(Hive))
            {
                output.Attributes.Append(hive);
            }
            output.Attributes.Append(key);
            if(null != Reg64)
            {
                output.Attributes.Append(reg64);
            }
            if (!string.IsNullOrEmpty(ValueType))
            {
                output.Attributes.Append(valueType);
            }
            output.Attributes.Append(value);
            if (!string.IsNullOrEmpty(Condition))
            {
                output.Attributes.Append(condition);
            }

            output.InnerText = Content;

            return output;
        }
    }
}
