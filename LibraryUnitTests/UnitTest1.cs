using Avalonia.Controls;
using HelloItQuantum.Function;

namespace LibraryUnitTests
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public void NameBlablabla()
		{
			//паттерн ААА должен быть но его нет
			string str = "хана";
			ComboBoxItem d = Converts.GenericToItem(str);
			Assert.IsNotNull(d);
		}
	}
}