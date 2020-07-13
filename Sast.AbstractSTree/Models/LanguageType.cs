using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sast.AbstractSTree.Models
{
	public class LanguageType
	{
		#region Constructors

		private LanguageType()
		{

		}

		#endregion

		#region Properties

		public static LanguageType None
		{
			get
			{
				return new LanguageType()
				{
					Keyword = "none",
				};
			}
		}

		public static LanguageType CPP
		{
			get
			{
				return new LanguageType()
				{
					Keyword = "cpp",
					ExtenstionList = { ".cpp", ".h", ".hpp" }
				};
			}
		}

		public static LanguageType CSharp
		{
			get
			{
				return new LanguageType()
				{
					Keyword = "csharp",
					ExtenstionList = { ".cs" }
				};
			}
		}

		public string Keyword
		{
			get;
			private set;
		}

		public IList<string> ExtenstionList
		{
			get;
			private set;
		} = new List<string>();

		#endregion

		#region Public methods

		public static LanguageType GetLanguageType(string extensionName)
		{
			LanguageType type = None;
			var infos = typeof(LanguageType).GetProperties(BindingFlags.Public | BindingFlags.Static).Select(x => 
			{
				return x.GetValue(null, null) as LanguageType;
			});

			foreach (var languageType in infos)
			{
				if (languageType.ExtenstionList.Contains(extensionName) == false)
				{
					continue;
				}

				type = languageType;

				return type;
			}

			return type;
		}

		#endregion

		#region Override methods

		public override bool Equals(object obj)
		{
			if (obj is LanguageType type)
			{
				return Keyword == type.Keyword;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return Keyword.GetHashCode();
		}

		public override string ToString()
		{
			return Keyword;
		}

		#endregion
	}
}
