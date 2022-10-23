using System.Text.Json;
using ZooApi.Models;

namespace ZooApi.Services
{
    public class FileHelper
    {
        
        //private string Serializer<T>(IEnumerable<T> lista)
        //{
        //    return JsonSerializer.Serialize(lista);
        //}

        public static void WriteAndSerialize<T>(string path, IEnumerable<T> lista)
        {
            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText(path, json);
        }

        ///private static List<Animal> Deserialize(string json)
        //{
        //    return JsonSerializer.Deserialize<List<Animal>>(json);
        //}/
       
        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public static  IEnumerable<T>  ReadAndDeserialize<T>(string path)
        {

            string json = File.ReadAllText(path);
            if (json == string.Empty)
            {
                return new List<T>();
            }
            else
            {
                IEnumerable<T> lista = JsonSerializer.Deserialize<IEnumerable<T>>(json);
                return lista;
            }
        }


    }
}
