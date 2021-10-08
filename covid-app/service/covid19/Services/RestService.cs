using System;
using System.IO;
using System.Net;

namespace covid19.Services
{
	public class RestService<TModel>
    {
        public RestService(): base()
		{
		}

        public T Get<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return (T)Convert.ChangeType(reader.ReadToEnd(), typeof(T));
            }
        }
    }
}
