using System;
using System.Collections.Generic;
using UnityEngine;

namespace Config
{

	[CreateAssetMenu(menuName = "ScriptObject/MappingGameConfig", order = 0, fileName = "MappingGameConfig")]
	public class MappingConfigToScript : ScriptableObject
	{

		public List<string> fileConfigs = new List<string>();
		public List<string> dataClass = new List<string>();
		public List<ConfigMode> configModes = new List<ConfigMode>();

		private Dictionary<bool, List<string>> configInitWhenRun = new Dictionary<bool, List<string>>();

		private Dictionary<string, ConfigMode> configModeContainer { get; }
			= new Dictionary<string, ConfigMode>();


		public string GetDataClass(string nameFileConfig)
		{
			try
			{
				int index = fileConfigs.IndexOf(nameFileConfig);
				return dataClass[index];
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public List<string> GetListConfigInitWhenRun(bool isEditor)
		{
			if (!configInitWhenRun.ContainsKey(isEditor))
			{
				List<string> ret = new List<string>();

				for (int i = 0; i < fileConfigs.Count; i++)
				{
					string file = fileConfigs[i];
					ConfigMode mode = GetModeConfig(file);
					bool flag = isEditor ? mode.initWithEditor : mode.initWithDevice;

					if (flag)
						ret.Add(file);
				}

				configInitWhenRun.Add(isEditor, ret);
			}

			return configInitWhenRun[isEditor];
		}

		public ConfigMode GetModeConfig(string nameFileConfig)
		{
			if (!configModeContainer.ContainsKey(nameFileConfig))
			{
				ConfigMode mode = new ConfigMode();

				try
				{
					int index = fileConfigs.IndexOf(nameFileConfig);
					mode = configModes[index];
				}
				catch (Exception e)
				{
					//
				}

				configModeContainer.Add(nameFileConfig, mode);
			}

			return configModeContainer[nameFileConfig];
		}

		public List<string> GetListDownloadFromFireBase()
		{
			List<string> listConfigs = new List<string>();

			for (int i = 0; i < fileConfigs.Count; i++)
			{
				string config = fileConfigs[i];
				ConfigMode mode = GetModeConfig(config);

				if (mode.allowDownload)
					listConfigs.Add(config);
			}

			return listConfigs;
		}

		public void AddFileConfig(string nameFileConfig)
		{
			if (!fileConfigs.Contains(nameFileConfig))
			{
				fileConfigs.Add(nameFileConfig);
				configModes.Add(new ConfigMode());
				dataClass.Add(string.Empty);
			}
		}
	}

	[System.Serializable]
	public class ConfigMode
	{
		public bool initWithEditor = true;
		public bool initWithDevice = true;
		public bool allowDownload = false;
	}
}