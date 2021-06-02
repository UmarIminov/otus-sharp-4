using System.IO;
using System.Xml.Serialization;

namespace Otus.Serializer
{
    [XmlRoot("ShopShop")]
    public class AutoShop
    {
        [XmlArray("MyBeautifulCars")]
        public Car[] Cars { get; set; }
    }


    [XmlRoot("TestCar")]
    public class Car
    {
        [XmlAttribute("BarColor")]
        public string Color { get; set; }

        [XmlElement("NewName")]
        public string Name { get; set; }

        [XmlIgnore]
        public int Price { get; set; }
    }

    public class XmlDemo
    {
        public void Show()
        {
            var car = new Car { Name = "LADA", Color = "Red", Price=222 };
            var shop = new AutoShop { Cars = new[] { car } };
            var s = new XmlSerializer(typeof(AutoShop));


            using (var fs = new FileStream("demoDataFiles\\demo.xml", FileMode.Create))
            {
                s.Serialize(fs, shop);
            }

        }
    }
}