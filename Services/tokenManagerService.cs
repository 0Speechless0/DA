using DA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DA.Services
{
    public class tokenManagerService
    {

        //public static Dictionary<string, tokenModel> userTokenList = new Dictionary<string, tokenModel>();
        public System.Web.SessionState.HttpSessionState _session = HttpContext.Current.Session;
        public string _remoteUrl;
        public string _remoteUrlBase;


        private class remoteReturnModel
        {
            public object content { get; set; }
        }
        private class content
        {

            public string userName { get; set; }
            
            public int userRole { get; set; }
            public  string userAccount { get; set; }
        }
        private class _user : user
        {
            public string token { get; set; }
        }
        public tokenManagerService(string reomteUrl)
        {
            _remoteUrl = reomteUrl;
    
        }
        public bool checkTokenVaild(string token)
        {

            if (_session["userAccount"] == null)
            {
                return checkTokenFromReomte(token);
            }
            else
            {
                string userAccount = _session["userAccount"].ToString();
                DateTime sessionCreateTime = (DateTime)_session["CreateTime"];
                if (sessionCreateTime > DateTime.Now.AddHours(-1) )
                {
                    return true;
                }
                else
                { 
                    //userTokenList.Remove( userAccount );
                    return checkTokenFromReomte(token);
                }


            }



            return false;

        }
 

        private bool checkTokenFromReomte(string token)
        {



            string jsonString = "";
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                var res = client.GetAsync(_remoteUrl).Result;

                if (res.IsSuccessStatusCode)
                {
                    jsonString = res.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return false;
                }
            }

            var remoteReturnInfo = JsonConvert.DeserializeObject<remoteReturnModel>(jsonString).content;

            var returnRemoteContent = JsonConvert.DeserializeObject<content>(JsonConvert.SerializeObject(remoteReturnInfo));
            if(returnRemoteContent is content returnContent)

            {
                _session["userAccount"] = returnContent.userAccount;
                _session["userName"] = returnContent.userName;
                _session["userRole"] = returnContent.userRole;
                _session["token"] = token;
                _session["CreateTime"] = DateTime.Now;

                //userTokenList.Add(returnContent.userAccount, new tokenModel
                //{
                //    createTime = DateTime.Now,
                //    token = token
                //});


                if( returnContent.userRole != 1)
                {
                    return false;
                }
            }

            

            return true;
            
        }



        //internal string addToken(string userNo)
        //{
        //    byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        //    byte[] key = Guid.NewGuid().ToByteArray();

        //    string token = Convert.ToBase64String(time.Concat(key).ToArray());

        //    if (tokens.ContainsKey(userNo))
        //    {

        //        tokens.Remove(userNo);
        //    }

        //    tokens.Add(userNo, token);
        //    return token;
        //}

        //internal int removeToken(string token)
        //{
        //    string userNo =  tokens.ToList().Find(item => item.Value == token).Key;
        //    if(userNo == null)
        //    {
        //        return 0;
        //    }
        //    if (tokens.Remove(userNo))
        //    {
        //        return  1;
        //    }

        //    return -1;

        //}
    }
}