﻿using Lsj.Util.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web;
using Game.Base.Events;
using NVelocityTemplateEngine.Interfaces;
using NVelocityTemplateEngine;
using System.Collections;
using Lsj.Util;
using Bussiness;
using SqlDataProvider.Data;

namespace Web.Server.Module
{
    public class Login : IModule
    {
        public static Log log = new Log(new LogConfig { FilePath = "log/Login/", UseConsole = true });

        public void Process(ref HttpClient client)
        {

            var request = client.request;
            var response = new HttpResponse();


            int inviteid = request.QueryString["i"].ConvertToInt(0);
            response.cookies.Add(new HttpCookie { name = "inviteid", content = inviteid.ToString(), Expires = DateTime.Now.AddYears(1) });


            if (request.QueryString["method"] == "login")
            {
                ProcessLogin(ref response, ref request);
            }
            else if (request.QueryString["method"] == "register")
            {
                ProcessRegister(ref response, ref request);
            }
            else if (request.QueryString["method"] == "logout")
            {
                response.cookies.Add(new HttpCookie { name = "username", Expires = DateTime.Now.AddYears(-1) });
                response.cookies.Add(new HttpCookie { name = "password", Expires = DateTime.Now.AddYears(-1) });
                response.ReturnAndRedict("注销成功", "login.do");
            }
            else if (request.QueryString["method"] == "pay")
            {
                ProcessPay(ref response, ref request);
            }
            else if (request.QueryString["method"] == "getinvite")
            {
                ProcessInvite(ref response, ref request);
            }
            else if (request.Cookies["username"].content != "" && request.Cookies["password"].content != "")
            {
                response.Write302("http://www.hqgddt.com/game.htm");
            }
            else
            {
                response.Write302("http://www.hqgddt.com/login.htm");
            }
            client.response = response;

        }

        private void ProcessInvite(ref HttpResponse response, ref HttpRequest request)
        {
            string username = request.QueryString["user"];
            int c = 0;
            using (PlayerBussiness a = new PlayerBussiness())
            {
                PlayerInfo b = a.GetUserSingleByUserName(username);
                if (b != null)
                    c = b.ID;
            }
            if (c == 0)
            {
                response.ReturnAndRedict("用户不存在，请确保已经注册角色！", "login.htm");
            }
            else
            {
                INVelocityEngine FileEngine = NVelocityEngineFactory.CreateNVelocityFileEngine(Server.ModulePath + @"vm", false);

                IDictionary context = new Hashtable();
                context.Add("content", "http://www.hqgddt.com/?i="+c);
                response.Write(FileEngine.Process(context, "invite.vm"));
            }
        }

        private void ProcessPay(ref HttpResponse response, ref HttpRequest request)
        {
            string username = request.QueryString["username"];
            int c = 0;
            using (PlayerBussiness a = new PlayerBussiness())
            {
                PlayerInfo b = a.GetUserSingleByUserName(username);
                if (b != null)
                    c = b.ID;
            }
            if (c == 0)
            {
                response.ReturnAndRedict("用户不存在，请确保已经注册角色！", "login.htm");
            }
            else
            {
                response.Write302("http://www.hqgddt.com/charge.do?userid="+c.ToString()+"&step=1");
            }
        }

        private void ProcessLogin(ref HttpResponse response, ref HttpRequest request)
        {
            Login.log.Info(request.postdata.ToSafeString());
            string username = request.Form["username"];
            string password = request.Form["password1"];
            Login.log.Info(username.ToSafeString());
            Login.log.Info(password.ToSafeString());
            response.cookies.Add(new HttpCookie { name = "username", content = username.ToSafeString(), Expires = DateTime.Now.AddYears(1) });
            response.cookies.Add(new HttpCookie { name = "password", content = password.ToSafeString(), Expires = DateTime.Now.AddYears(1) });
            response.Write302("http://www.hqgddt.com/game.htm");
        }
        private void ProcessRegister(ref HttpResponse response, ref HttpRequest request)
        {
            string username = request.Form["username"];
            string password = request.Form["password1"];
            int inviteid = request.Cookies["inviteid"].content.ConvertToInt(0);
            using (MemberShipbussiness a = new MemberShipbussiness())
            {
                if (a.ExistsUsername(username))
                {
                    response.ReturnAndRedict("该用户名已被注册", "login.do");
                }
                else
                {
                    if (a.CreateUsername(username, password, inviteid))
                    {
                        response.cookies.Add(new HttpCookie { name = "username", content = username.ToSafeString(), Expires = DateTime.Now.AddYears(1) });
                        response.cookies.Add(new HttpCookie { name = "password", content = password.ToSafeString(), Expires = DateTime.Now.AddYears(1) });
                        response.ReturnAndRedict("注册成功", "game.htm");
                    }
                }
            }
        }


        [ScriptLoadedEvent]
        public static void AddModule(RoadEvent e, object sender, EventArgs arguments)
        {
            Login.log.Info("Load Login Module");
            Server.AddModule(@"\", "Web.Server.Module.Login");
            Server.AddModule(@"\login.do", "Web.Server.Module.Login");
            Server.AddModule(@"\login.aspx", "Web.Server.Module.Login");
        }
    }
}
