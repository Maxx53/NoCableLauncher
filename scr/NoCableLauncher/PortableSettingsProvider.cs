using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace NoCableLauncher
{
    public sealed class PortableSettingsProvider : SettingsProvider, IApplicationSettingsProvider
    {
        public const string SettingsFileName = "NCL_Settings.xml";
        private const string _rootNodeName = "settings";
        private const string _className = "PortableSettingsProvider";
        private XmlDocument _xmlDocument;

        private string _filePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), SettingsFileName);
            }
        }

        private XmlNode _rootNode => _rootDocument.SelectSingleNode(_rootNodeName);

        private XmlDocument _rootDocument
        {
            get
            {
                if (_xmlDocument != null) return _xmlDocument;

                try
                {
                    _xmlDocument = new XmlDocument();
                    _xmlDocument.Load(_filePath);
                }
                catch (Exception)
                {

                }

                if (_xmlDocument.SelectSingleNode(_rootNodeName) != null)
                    return _xmlDocument;

                _xmlDocument = GetBlankXmlDocument();

                return _xmlDocument;
            }
        }

        public override string ApplicationName
        {
            get => Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            set { }
        }

        public override string Name => _className;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(Name, config);
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
           var sorted =  collection.Cast<SettingsPropertyValue>().OrderBy(s => s.Name);

            foreach (SettingsPropertyValue propertyValue in sorted)
                SetValue(propertyValue);

            try
            {
                _rootDocument.Save(_filePath);
            }
            catch (Exception)
            {
                /* 
                 * If this is a portable application and the device has been 
                 * removed then this will fail, so don't do anything. It's 
                 * probably better for the application to stop saving settings 
                 * rather than just crashing outright. Probably.
                 */
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            foreach (SettingsProperty property in collection)
            {
                values.Add(new SettingsPropertyValue(property)
                {
                    SerializedValue = GetValue(property)
                });
            }

            return values;
        }

        private void SetValue(SettingsPropertyValue propertyValue)
        {

            XmlNode settingNode = _rootNode.SelectSingleNode($"setting[@name='{propertyValue.Name}']");

            if (settingNode != null)
            {
                //Fix for binary serialized setting
                if (propertyValue.SerializedValue is byte[])
                    settingNode.InnerText = Convert.ToBase64String((byte[])propertyValue.SerializedValue);
                else
                    settingNode.InnerText = propertyValue.SerializedValue.ToString();
            }
            else
            {
                settingNode = _rootDocument.CreateElement("setting");

                XmlAttribute nameAttribute = _rootDocument.CreateAttribute("name");
                nameAttribute.Value = propertyValue.Name;

                settingNode.Attributes?.Append(nameAttribute);

                settingNode.InnerText = propertyValue.SerializedValue.ToString();

                _rootNode.AppendChild(settingNode);
            }
        }

        private string GetValue(SettingsProperty property)
        {
            XmlNode settingNode = _rootNode.SelectSingleNode($"setting[@name='{property.Name}']");

            if (settingNode == null)
                return property.DefaultValue != null ? property.DefaultValue.ToString() : string.Empty;

            return settingNode.InnerText;
        }

        private XmlNode GetSettingsNode(string name)
        {
            XmlNode settingsNode = _rootNode.SelectSingleNode(name);

            if (settingsNode != null) return settingsNode;

            settingsNode = _rootDocument.CreateElement(name);
            _rootNode.AppendChild(settingsNode);

            return settingsNode;
        }

        public XmlDocument GetBlankXmlDocument()
        {
            XmlDocument blankXmlDocument = new XmlDocument();
            blankXmlDocument.AppendChild(blankXmlDocument.CreateXmlDeclaration("1.0", "utf-8", string.Empty));
            blankXmlDocument.AppendChild(blankXmlDocument.CreateElement(_rootNodeName));

            return blankXmlDocument;
        }

        public void Reset(SettingsContext context)
        {
            _xmlDocument.Save(_filePath);
        }

        public SettingsPropertyValue GetPreviousVersion(SettingsContext context, SettingsProperty property)
        {
            // do nothing
            return new SettingsPropertyValue(property);
        }

        public void Upgrade(SettingsContext context, SettingsPropertyCollection properties)
        {
            // do nothing
        }
    }
}

