using System.Collections.Generic;

namespace WorldCup.DataLayer.Settings
{
    public class Base
    {
		protected static Dictionary<string, string> compilerCode = [];
        public static bool InitializationCheck()
			=> compilerCode.Count > 0;
		protected static void InitializeCompilerCode(Dictionary<string, string> code)
		{
			foreach (var item in code)
			{
				compilerCode.Add(item.Key, item.Value);
			}
		}
		public static string GetCompilerCode(string text)
		{
			if (!compilerCode.ContainsKey(text))
				return string.Empty;

			else
				return compilerCode[text];			
		}
    }
}
