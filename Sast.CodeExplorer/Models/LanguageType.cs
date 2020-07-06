using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLog.Time;
using Antlr4.Runtime.Dfa;
using System.Reflection;

namespace Sast.CodeExplorer.Models
{
	public class LanguageType
	{
		#region Fields

		private static readonly Dictionary<string, LanguageType> _extensionMap = new Dictionary<string, LanguageType>();

		#endregion

		#region Constructors

		private LanguageType(string keyword, params string[] extensionNames)
		{
			Keyword = keyword;
			ExtenstionList = new List<string>(extensionNames);

			foreach (string extension in ExtenstionList)
			{
				_extensionMap.Add(extension, this);
			}
		}

		#endregion

		#region Properties

		public static LanguageType None
		{
			get
			{
				return new LanguageType(
					"None");
			}
		}

		public static LanguageType CPP
		{
			get
			{
				return new LanguageType(
					"cpp",
					".cpp", ".h", ".hpp");
			}
		}

		public static LanguageType CSharp
		{
			get
			{
				return new LanguageType(
					"csharp",
					".cs");
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
		}

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
				if (languageType.ExtenstionList.Contains(extensionName) == true)
				{
					type = languageType;
					return type;
				}
			}

			return type;
		}

		public static bool operator == (LanguageType leftType, LanguageType rightType)
		{
			return leftType.Keyword == rightType.Keyword;
		}

		public static bool operator != (LanguageType leftType, LanguageType rightType)
		{
			return leftType.Keyword != rightType.Keyword;
		}

		public override bool Equals(object obj)
		{
			LanguageType type = obj as LanguageType;
			if (type != null)
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
