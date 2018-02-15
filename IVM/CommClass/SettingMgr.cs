using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CommClass
{
    abstract class SettingMgr
    {
        protected string settingName;
        public SettingMgr(string SettingName)
        {
            settingName = SettingName;
        }

        public abstract string GetValue(string SectionName, string Key);
        public abstract void SetValue(string SectionName, string Key, string Val);
        public abstract bool DeleteSection(string SectionName);
    }

    class IniSetting : SettingMgr
    {
        IniFile iniFile;

        public IniSetting(string SettingName)
            : base(SettingName)
        {
            iniFile = new IniFile(SettingName);
        }

        public override string GetValue(string SectionName, string Key)
        {
            return iniFile.ReadValue(SectionName, Key);
        }

        public override void SetValue(string SectionName, string Key, string Val)
        {
            iniFile.WriteValue(SectionName, Key, Val);
        }

        public override bool DeleteSection(string SectionName)
        {
            bool result = false;
            ///todo: 删除节代码
            return result;
        }
    }

    class RegistrySetting : SettingMgr
    {
        RegistryKey hklm = Registry.LocalMachine;
        RegistryKey hkSetting;
        RegistryKey hkMine;

        public RegistrySetting(string SettingName)
            : base(SettingName)
        {
            RegistryKey hkSoftware;
            hkSoftware = hklm.OpenSubKey("SoftWare",true);
            hkSetting = hkSoftware.OpenSubKey(settingName,true);
            if (hkSetting == null)
            {
                hkSetting = hkSoftware.CreateSubKey(settingName);
            }
        }

        public override string GetValue(string SectionName, string Key)
        {
            string result;
            hkMine = hkSetting.OpenSubKey(SectionName);
            if (hkMine.GetValue(Key) ==null)
            {
                result="";
            }
            else
            {
                result=hkMine.GetValue(Key).ToString();
            }
            return result;
        }

        public override void SetValue(string SectionName, string Key, string Val)
        {
            hkMine = hkSetting.CreateSubKey(SectionName);
            hkMine.SetValue(Key, Val);
            hkMine.Close();
        }

        public override bool DeleteSection(string SectionName)
        {
            bool result = true;
            hkSetting.DeleteSubKeyTree(SectionName);
            hkSetting.Close();
            return result;
        }
    }
}
