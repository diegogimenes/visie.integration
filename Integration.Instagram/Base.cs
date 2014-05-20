using InstaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Instagram
{
    public class Base
    {
        public static InstagramConfig config;


       


        public static void Authenticate()
        {
            config = new InstagramConfig("https://api.instagram.com/v1",
                "https://api.instagram.com/oauth", "eac7bb50e619481ca39defc185e8fd15",
                "fd400937d6ee4f50bc8b0f696003841d", "");
            List<Auth.Scope> scopes = new List<Auth.Scope>();
            scopes.Add(Auth.Scope.basic);
            var link = InstaSharp.Auth.AuthLink(config.OAuthURI, config.ClientId, config.RedirectURI, scopes);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            var auth = new InstaSharp.Auth(config);
            var response = request.GetResponse();
            string location = response.Headers["Location"];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--Responce from the webrequest--");
            Console.ResetColor();
            Console.WriteLine(((HttpWebResponse)response).ResponseUri + "\n\n");            
            Stream stream = request.GetRequestStream();
            var authInfo = new InstaSharp.AuthInfo();
            var users = new InstaSharp.Endpoints.Users.Authenticated(config, authInfo);

            
        }


        public void Callback(string code)
        {
            
           
        }
    }

    
        
}
