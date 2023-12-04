using System.Text;
using System.Xml;

namespace XMLPrøveEksamen
{
    public class Program
    {
        public static void Main()
        {
            List<Car> cars = ReadCars("http://www.fkj.dk/cars.xml");

            foreach (Car car in cars)
                Console.WriteLine(car);

            WriteCars("D:/Datamatiker/XMLPrøveEksamen/XMLPrøveEksamen/data/carsNew.xml", cars);
        }

        private static void WriteCars(string path, List<Car> cars)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = Encoding.UTF8,
            };

            using XmlWriter writer = XmlWriter.Create(path, settings);

            writer.WriteStartDocument();
            {
                writer.WriteStartElement("cars");
                {
                    foreach (Car car in cars)
                        WriteCar(writer, car);
                }

                writer.WriteEndElement(); //</cars>
            }
            writer.WriteEndDocument();
        }

        private static void WriteCar(XmlWriter writer, Car car)
        {
            writer.WriteStartElement("car");
            {
                WriteElementString(writer, "name", car.Name);
                WriteElementString(writer, "cylinders", car.Cylinders);
                WriteElementString(writer, "country", car.Country);
            }
            writer.WriteEndElement(); //</cars>
        }

        private static void WriteElementString(XmlWriter writer, string name, string value)
        {
            if(value != null)
                writer.WriteElementString(name, value);
        }

        private static List<Car> ReadCars(string path)
        {
            List<Car> cars = new();

            XmlReaderSettings settings = new()
            {
                IgnoreWhitespace = true,
                IgnoreComments = true
            };

            using XmlReader reader = XmlReader.Create(path, settings);

            reader.MoveToContent();

            reader.ReadStartElement("cars");

            while (reader.IsStartElement("car"))
            {
                Car car = new Car();

                reader.ReadStartElement();

                while (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "name": car.Name = reader.ReadElementContentAsString();
                            break;
                        case "cylinders": car.Cylinders = reader.ReadElementContentAsString();
                            break;
                        case "country": car.Country = reader.ReadElementContentAsString();
                            break;
                    }
                reader.ReadEndElement(); // </car>

                cars.Add(car);
            }

            reader.ReadEndElement(); // </cars>
            return cars;
        }
    }
}
