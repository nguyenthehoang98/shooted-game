using System;
using System.Collections.Generic;
using System.Reflection;
using LitJson;
using UnityEngine;

namespace Config {
	public class ConfigManager {
		private readonly string FOLDER = "Config/";
		private Dictionary<Type, ConfigData> dic = new Dictionary<Type, ConfigData>();
		private MappingConfigToScript mapping;
		private bool hasInit = false;

		public ConfigManager() {
			
		}

		private MappingConfigToScript GetSetup() {
			if (mapping == null)
				mapping = Resources.Load<MappingConfigToScript>("ScriptObject/MappingGameConfig");
			return mapping;
		}

		public T GetConfig<T>() where  T: IConfig
		{
			try {
				return dic[typeof(T)].GetConfig<T>();
			}
			catch (Exception e) {
				if(hasInit)
					Debug.LogError(e);
				else
					Debug.LogError("Need call Init !!!");
			}
			
			IConfig ret = null;
			return (T) ret;
		}
		
		public void Init() {
			List<string> configsName = GetListConfigInitWhenRun();

			for (int i = 0; i < configsName.Count; i++) {
				string path = FOLDER + configsName[i];
				TextAsset text = Resources.Load<TextAsset>(path);
				Map(configsName[i], text.text);
			}

			hasInit = true;
		}

		public void MapConfig<T>(string text) where T : IConfig {
			Type type = typeof(T);
			
			if(!dic.ContainsKey(type))
				dic.Add(type, new ConfigData());
			dic[type].SetData(text);
		}
		
		private void Map(string name, string text) {
			try {
				string className = GetSetup().GetDataClass(name);
				string nameSpace = "Config";
				string classFullName = nameSpace + "." + className;
				Type[] genericArgunments = new Type[]
				{
					Type.GetType(classFullName) 
				};

				MethodInfo info = GetType().GetMethod("MapConfig")?.MakeGenericMethod(genericArgunments);
				if (info != null)
					info.Invoke(this, new object[] {text});
			}
			catch (Exception e) {
				Console.WriteLine(e);
				throw;
			}
		}

		private List<string> GetListConfigInitWhenRun() {
			bool isEditor = true;

#if UNITY_EDITOR
			isEditor = true;
#else
			isEditor = false;
#endif
			return GetSetup().GetListConfigInitWhenRun(isEditor);
		}
		
		
		class  ConfigData {
			public string text;
			public IConfig config;
			private bool isNew = true;

			public ConfigData() {
				
			}

			public void SetData(string text) {
				this.text = text;
				this.isNew = true;
			}
			
			public T GetConfig<T>() where T : IConfig
			{
				if (isNew) {
					try {
						config = JsonMapper.ToObject<T>(text);
						config.Setup(text);
						isNew = false;
					}
					catch (Exception e) {
						Debug.Log("Config " + typeof(T).ToString() + " " + e);
					}
				}

				return (T) config;
			}
			
		}	
	}
}