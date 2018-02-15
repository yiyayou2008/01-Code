using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace IVMUpgrade
{
    class SoftwareUpgrade
    {
        private string softwareName;
        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }

        private Version softwareVersion;
        public Version SoftwareVersion
        {
            get { return softwareVersion; }
        }

        private Version localSoftwareVersion;
        public Version LocalSoftwareVersion
        {
            get { return localSoftwareVersion; }
        }

        private List<string> upgradeFileList = new List<string>();
        public List<string> UpgradeFileList
        {
            get { return upgradeFileList; }
            set { upgradeFileList = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
        }

        private string exeFileName;
        private string upgradeInfoFileName;
        private string localFilePath;
        public string LocalFilePath
        {
            get { return localFilePath; }
        }
        private string localFileUpgradePath;

        private string remoteFilePath;
        public string RemoteFilePath
        {
            get { return remoteFilePath; }
        }

        public SoftwareUpgrade(string ExeFileName, string UpgradeInfoFileName)
        {
            exeFileName = ExeFileName;
            upgradeInfoFileName = UpgradeInfoFileName;
            FileInfo fi = new FileInfo(exeFileName);
            localFilePath = fi.DirectoryName;
            localFileUpgradePath = LocalFilePath + "\\Upgrage";
            //获取本地执行文件版本号
            FileVersionInfo ExeVersionInfo = FileVersionInfo.GetVersionInfo(exeFileName);
            localSoftwareVersion = new Version(ExeVersionInfo.FileVersion);

            fi = new FileInfo(upgradeInfoFileName);
            remoteFilePath = fi.DirectoryName;
            LoadFromXML(upgradeInfoFileName);
        }

        public bool LoadFromXML(string XmlFile)
        {
            bool result = false;

            upgradeFileList.Clear();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFile);
            //加载升级文件列表
            XmlNode RootNode = xmlDoc.DocumentElement;
            foreach (XmlNode SoftwareNode in RootNode.ChildNodes)
            {
                if ((SoftwareNode.NodeType != XmlNodeType.Element) || (SoftwareNode.Name != "Software"))
                {
                    continue;
                }
                softwareName = SoftwareNode.Attributes["Name"].InnerText;
                foreach (XmlNode FileListNode in SoftwareNode.ChildNodes)
                {
                    if (SoftwareNode.NodeType == XmlNodeType.Element)
                    {
                        if (FileListNode.Name == "Version")
                        {
                            softwareVersion = new Version(FileListNode.InnerText);
                        }
                        if (FileListNode.Name == "UpdateFileList")
                        {
                            foreach (XmlNode FileNode in FileListNode.ChildNodes)
                            {
                                if (FileNode.Name == "UpdateFile")
                                {
                                    upgradeFileList.Add(FileNode.InnerText);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }


        public bool IsOldVersion()
        {
            bool result = false;
            if (localSoftwareVersion >= softwareVersion)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public void Upgrade()
        {
            Directory.CreateDirectory(localFileUpgradePath);
            foreach (string fileName in upgradeFileList)
            {
                File.Copy(remoteFilePath + "\\" + fileName, localFileUpgradePath + "\\" + fileName, true);
            }

            foreach (string fileName in upgradeFileList)
            {
                File.Copy(localFileUpgradePath + "\\" + fileName, localFilePath + "\\" + fileName, true);
                File.Delete(localFileUpgradePath + "\\" + fileName);
            }
        }
    }
}
