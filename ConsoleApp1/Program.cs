using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Numbers.One);
			Console.WriteLine((int)Numbers.Two);
			Console.WriteLine(Numbers.Three.ToString());
			Console.WriteLine(GetDescription(Numbers.Four));
			Console.ReadLine();
		}

		/// <summary>
		/// Приведение значения перечисления в удобочитаемый формат.
		/// </summary>
		/// <remarks>
		/// Для корректной работы необходимо использовать атрибут [Description("Name")] для каждого элемента перечисления.
		/// </remarks>
		/// <param name="enumElement">Элемент перечисления</param>
		/// <returns>Название элемента</returns>
		static string GetDescription(Enum enumElement)
		{
			Type type = enumElement.GetType();

			MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
			if (memInfo != null && memInfo.Length > 0)
			{
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
				if (attrs != null && attrs.Length > 0)
					return ((DescriptionAttribute)attrs[0]).Description;
			}

			return enumElement.ToString();
		}

		/// <summary>
		/// Числа
		/// </summary>
		public enum Numbers
		{
			/// <summary>
			/// Один
			/// </summary>
			[Description("Один")]
			One = 1,
			/// <summary>
			/// Два
			/// </summary>
			[Description("Два")]
			Two = 2,
			/// <summary>
			/// Три
			/// </summary>
			[Description("Три")]
			Three = 3,
			/// <summary>
			/// Четыре
			/// </summary>
			[Description("Четыре")]
			Four = 4,
			/// <summary>
			/// Пять
			/// </summary>
			[Description("Пять")]
			Five = 5
		}
	}
}
