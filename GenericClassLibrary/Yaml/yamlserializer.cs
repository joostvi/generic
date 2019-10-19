using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


/// <summary>
/// https://github.com/aaubry/YamlDotNet/wiki/Samples.SerializeObjectGraph
/// </summary>
namespace GenericClassLibrary.Yaml
{
    public static class YamlSerializer
    {
        public static T Deserialize<T>(string fileName) where T : class
        {
            using (StringReader input = new StringReader(fileName))
            {
                IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();

                T obj = deserializer.Deserialize<T>(input);
                return obj;
            }
        }

        public static string Serialize<T>(T obj, bool emitDefaults = false) where T : class
        {
            SerializerBuilder serializerBuilder = new SerializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());
            ISerializer serializer = serializerBuilder.Build();
            return serializer.Serialize(obj);
        }
    }
}
