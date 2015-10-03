﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web;
using Lsj.Util;
using Lsj.Util.Log;
using Game.Base;
using System.Reflection;
using Bussiness;
using Game.Base.Events;
using NVelocityTemplateEngine.Interfaces;
using NVelocityTemplateEngine;
using System.Collections;

namespace Web.Server.Module
{
    public class Charge :IModule
    {
        public static Log log = new Log(new LogConfig { FilePath = "log/Charge/", UseConsole = true });
        public void Process(ref HttpClient client)
        {
            var response = new HttpResponse();
            response.contenttype = "text/html";
            
            //  "/charge.do?"
            var request = client.request;
            log.Info(request.QueryString["step"]);
            if (request.QueryString["step"].ConvertToInt(0) == 1)
            {
                response = ProcessStep1(client);
            }
            else if (request.QueryString["step"].ConvertToInt(0) == 2)
            {
                response = ProcessStep2(client);
            }
            else
            {
                response.WriteError(404);
            }
            client.response = response;
        }



        private HttpResponse ProcessStep1(HttpClient client)
        {
            var response = new HttpResponse();
            response.contenttype = "text/html";
            var request = client.request;
            string userid = request.QueryString["userid"];


            
            log.Info(request.QueryString["userid"]);
            if (userid.ConvertToInt(0) == 0)
            {
                response.WriteError(404);
            }
            else
            {
                INVelocityEngine AssemblyEngine = NVelocityEngineFactory.CreateNVelocityAssemblyEngine(Server.ModulePath+"ChargeModule.dll", false);
                IDictionary context = new Hashtable();
                
                context.Add("userid", userid);
                response.Write(AssemblyEngine.Process(context, "ChargeModule.PayIndex.html"));
            }
            return response;
        }

        private HttpResponse ProcessStep2(HttpClient client)
        {
            var response = new HttpResponse();
            response.contenttype = "text/html";
            var request = client.request;
            string userid = request.QueryString["userid"];
            string paytype = request.QueryString["paytype"];

            

            if (paytype.ConvertToInt(0) == 0 || userid.ConvertToInt(0) == 0)
            {
                response.WriteError(404);
                return response;
            }

            if (paytype.ConvertToInt(0) >= 1 && paytype.ConvertToInt(0) <= 24)
            {
                string username = "";
                using (PlayerBussiness a = new PlayerBussiness())
                {
                    var b = a.GetUserSingleByUserID(userid.ConvertToInt(0));
                    {
                        if (b != null)
                        {
                            username = b.UserName;
                        }
                        else
                        {
                            response.WriteError(404);
                            return response;
                        }
                    }
                }

              //  content.Replace("/queryorder.asp", "http://p5m0.357p.com/queryorder.asp");

                INVelocityEngine AssemblyEngine = NVelocityEngineFactory.CreateNVelocityAssemblyEngine(Server.ModulePath + "ChargeModule.dll", false);
                IDictionary context = new Hashtable();

                context.Add("userid", userid);
                context.Add("username", username);
                response.Write(AssemblyEngine.Process(context, $"ChargeModule.Pay{paytype}.html").Replace("/queryorder.asp", "http://p5m0.357p.com/queryorder.asp"));
            }
            else
            {
                response.WriteError(404);
            }
            return response;
        }
        [ScriptLoadedEvent]
        public static void AddModule(RoadEvent e, object sender, EventArgs arguments)
        {
            Charge.log.Info("Load Charge Module");
            Server.AddModule(@"\charge.do", "Web.Server.Module.Charge");            
        }
    }
}

