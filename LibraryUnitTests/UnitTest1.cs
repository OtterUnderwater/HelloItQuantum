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
			//������� ��� ������ ���� �� ��� ���
			string str = "����";
			ComboBoxItem d = Converts.GenericToItem(str);
			Assert.IsNotNull(d);
		}
	}
}