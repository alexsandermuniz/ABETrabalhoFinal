﻿using System;
using System.IO;
using System.Net;

namespace WholesaleApi.Utils
{
    public class CallApi
    {
        public static string GetRequest(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
                return response;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            return "ERROR";

        }
        public static long PostRequest(string DATA, string URL, bool isPatch)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            if (isPatch)
                request.Method = "PATCH";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(DATA);
            requestWriter.Close();

            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
                return long.Parse(response);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            return -1;

        }
    }

}