using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Otus.Serializer
{

    [Serializable]
    public class GameSave : ISerializable
    {
        public GameSave()
        {
        }

        public int A { get; set; }

        public DateTime SaveTimestamp { get; set; }

        // Из ISerializable, вызывается при сериализации
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
         info.AddValue("saveTimestamp", DateTime.Now);
            // ...
        }

        // Особый конструктор - при десериализации
        public GameSave(SerializationInfo info, StreamingContext context)
        {
            SaveTimestamp=info.GetDateTime("saveTimestamp");
        }
    }

    public class SerializableDemo
    {
        public void Show()
        {
            var obj=new GameSave();

            var bf = new BinaryFormatter();

            var fs = new FileStream("demoDataFiles\\file.bin", FileMode.Create);
            bf.Serialize(fs, obj);
        }
    }
}