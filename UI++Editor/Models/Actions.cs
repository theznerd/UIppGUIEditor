﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UI__Editor.Interfaces;

namespace UI__Editor.Models
{
    public class Actions : IElement, IRootElement
    {
        public string RootElementType { get; } = "Actions";
        public ObservableCollection<IAction> actions;

        public XmlNode GenerateXML()
        {
            // Create XML Node and Attributes
            XmlDocument d = new XmlDocument();
            XmlNode output = d.CreateNode("element", "Actions", null);

            // Append all children
            foreach(IAction action in actions)
            {
                XmlNode importNode = d.ImportNode(action.GenerateXML(), true);
                output.AppendChild(importNode);
            }

            return output;
        }
    }
}