using Avalonia.Controls;
using HelloItQuantum.Function;
using HelloItQuantum.Models;
using Avalonia.Media;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;

namespace LibraryUnitTests
{
	[TestClass]
	public class UnitTestsFunction
    {
		[TestMethod]
		public void Converts_GenericToItem_TextConvertToItemSuccess()
		{
			string expectedText = "Тест";
            ComboBoxItem expectedItem = new ComboBoxItem();
            expectedItem.Content = expectedText;
            ComboBoxItem resultItem = Converts.GenericToItem(expectedText);
			Equals(expectedItem, resultItem);	
		}

        [TestMethod]
        public void CreateElFriend_CreateRectangleColor293558_RectangleColorIsCorrect()
        {
			Color color = Color.Parse("#293558");
			double size = 50;
            Rectangle expectedRectangle = new Rectangle();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Rectangle resultRectangle = CreateElFriend.CreateRectangle(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateRectangleColorF26527_RectangleColorIsCorrect()
        {
            Color color = Color.Parse("#F26527");
            double size = 50;
            Rectangle expectedRectangle = new Rectangle();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Rectangle resultRectangle = CreateElFriend.CreateRectangle(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateRectangleColor0036A0_RectangleColorIsCorrect()
        {
            Color color = Color.Parse("#0036A0");
            double size = 50;
            Rectangle expectedRectangle = new Rectangle();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Rectangle resultRectangle = CreateElFriend.CreateRectangle(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateRectangleColorB21E22_RectangleColorIsCorrect()
        {
            Color color = Color.Parse("#B21E22");
            double size = 50;
            Rectangle expectedRectangle = new Rectangle();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Rectangle resultRectangle = CreateElFriend.CreateRectangle(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateRectangleColor006838_RectangleColorIsCorrect()
        {
            Color color = Color.Parse("#006838");
            double size = 50;
            Rectangle expectedRectangle = new Rectangle();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Rectangle resultRectangle = CreateElFriend.CreateRectangle(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateEllipseColor293558_EllipseColorIsCorrect()
        {
            Color color = Color.Parse("#293558");
            double size = 50;
            Ellipse expectedRectangle = new Ellipse();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Ellipse resultRectangle = CreateElFriend.CreateEllipse(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateEllipseColorF26527_EllipseColorIsCorrect()
        {
            Color color = Color.Parse("#F26527");
            double size = 50;
            Ellipse expectedRectangle = new Ellipse();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Ellipse resultRectangle = CreateElFriend.CreateEllipse(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateEllipseColor0036A0_EllipseColorIsCorrect()
        {
            Color color = Color.Parse("#0036A0");
            double size = 50;
            Ellipse expectedRectangle = new Ellipse();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Ellipse resultRectangle = CreateElFriend.CreateEllipse(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateEllipseColorB21E22_EllipseColorIsCorrect()
        {
            Color color = Color.Parse("#B21E22");
            double size = 50;
            Ellipse expectedRectangle = new Ellipse();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Ellipse resultRectangle = CreateElFriend.CreateEllipse(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }

        [TestMethod]
        public void CreateElFriend_CreateEllipseColor006838_EllipseColorIsCorrect()
        {
            Color color = Color.Parse("#006838");
            double size = 50;
            Ellipse expectedRectangle = new Ellipse();
            expectedRectangle.Fill = new SolidColorBrush(color);
            Ellipse resultRectangle = CreateElFriend.CreateEllipse(size, color);
            Equals(expectedRectangle.Fill, resultRectangle.Fill);
        }
    }
}