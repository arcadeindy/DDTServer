﻿using Bussiness;
using SqlDataProvider.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using zlib;
using Lsj.Util.Text;

namespace Web.Server
{

    public class XMLBuild
    {
        public static byte[] Compress(string str)
        {
            byte[] src = Encoding.UTF8.GetBytes(str);
            return Compress(src);
        }
        public static byte[] Compress(byte[] src)
        {
            return Compress(src, 0, src.Length);
        }
        public static byte[] Compress(byte[] src, int offset, int length)
        {
            MemoryStream ms = new MemoryStream();
            Stream s = new ZOutputStream(ms, 9);
            s.Write(src, offset, length);
            s.Close();
            return ms.ToArray();
        }
        public static byte[] CreateCompressXml(XElement result, bool isCompress)
        {

            if (isCompress)
            {
                return Compress(result.ToString(false));
            }
            else
            {
                return result.ToString(false).ConvertToBytes();
            }

        }



        public static byte[] BoxTemplateList()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    ItemBoxInfo[] infos = db.GetItemBoxInfos();
                    if (infos != null && infos.Length > 0)
                    {
                        ItemBoxInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ItemBoxInfo info = array[i];
                            result.Add(FlashUtils.CreateItemBox(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, false);
        }
        public static byte[] FightLabDropItemList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11021, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11002, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11006, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11010, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11014, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11408, 1));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, 11107, 2000));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 0, -300, 100));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11022, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11003, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11007, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11011, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11015, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11408, 3));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, 11107, 5000));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 1, -300, 300));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11023, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11004, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11008, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11012, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11016, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11408, 5));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, 11107, 8000));
                result.Add(FlashUtils.CreateFightLabDropItem(5, 2, -300, 500));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11021, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11002, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11006, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11010, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11014, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11408, 1));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, 11107, 2000));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 0, -300, 100));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11022, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11003, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11007, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11011, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11015, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11408, 3));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, 11107, 5000));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 1, -300, 300));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11023, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11004, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11008, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11012, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11016, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11408, 5));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, 11107, 8000));
                result.Add(FlashUtils.CreateFightLabDropItem(6, 2, -300, 500));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11021, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11002, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11006, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11010, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11014, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11408, 1));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, 11107, 2000));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 0, -300, 100));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11022, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11003, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11007, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11011, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11015, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11408, 3));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, 11107, 5000));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 1, -300, 300));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11023, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11004, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11008, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11012, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11016, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11408, 5));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, 11107, 8000));
                result.Add(FlashUtils.CreateFightLabDropItem(7, 2, -300, 500));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11021, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11002, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11006, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11010, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11014, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11408, 1));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, 11107, 2000));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 0, -300, 100));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11022, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11003, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11007, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11011, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11015, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11408, 3));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, 11107, 5000));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 1, -300, 300));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11023, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11004, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11008, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11012, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11016, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11408, 5));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, 11107, 8000));
                result.Add(FlashUtils.CreateFightLabDropItem(8, 2, -300, 500));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11021, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11002, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11006, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11010, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11014, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11408, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, 11107, 2000));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 0, -300, 100));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11022, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11003, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11007, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11011, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11015, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11408, 3));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, 11107, 5000));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 1, -300, 300));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11023, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11004, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11008, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11012, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11016, 4));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11408, 5));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, 11107, 8000));
                result.Add(FlashUtils.CreateFightLabDropItem(9, 2, -300, 500));
                value = true;
                message = "Success!";
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }

        public static byte[] LoadUserBox()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    List<BoxInfo> infos = db.GetAllBoxInfo();
                    if (infos != null && infos.Count<BoxInfo>() > 0)
                    {
                        foreach (BoxInfo info in infos)
                        {
                            result.Add(FlashUtils.CreateUserBox(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, false);
        }
        public static byte[] AchievementList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    AchievementInfo[] achievements = db.GetALlAchievement();
                    AchievementConditionInfo[] achievementConditions = db.GetALlAchievementCondition();
                    AchievementRewardInfo[] achievementRewards = db.GetALlAchievementReward();
                    if (achievements != null && achievementConditions != null && achievementRewards != null && achievements.Length > 0 && achievementConditions.Length > 0 && achievementRewards.Length > 0)
                    {
                        AchievementInfo[] array = achievements;
                        AchievementInfo achievement;
                        for (int i = 0; i < array.Length; i++)
                        {
                            achievement = array[i];
                            XElement temp_xml = FlashUtils.CreateAchievement(achievement);
                            IEnumerable temp_achievementConditions =
                                from s in achievementConditions
                                where s.AchievementID == achievement.ID
                                select s;
                            foreach (AchievementConditionInfo achievementCondition in temp_achievementConditions)
                            {
                                temp_xml.Add(FlashUtils.CreateAchievementCondition(achievementCondition));
                            }
                            IEnumerable temp_achievementRewards =
                                from s in achievementRewards
                                where s.AchievementID == achievement.ID
                                select s;
                            foreach (AchievementRewardInfo achievementReward in temp_achievementRewards)
                            {
                                temp_xml.Add(FlashUtils.CreateAchievementReward(achievementReward));
                            }
                            result.Add(temp_xml);
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] DropList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness pb = new ProduceBussiness())
                {
                    DropItem[] infos = pb.GetDropItemForNewRegister();
                    if (infos != null && infos.Length > 0)
                    {
                        DropItem[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            DropItem info = array[i];
                            result.Add(FlashUtils.CreateDropItemForNewRegister(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] NPCInfoList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    NpcInfo[] infos = db.GetAllNPCInfo();
                    if (infos != null && infos.Length > 0)
                    {
                        NpcInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            NpcInfo info = array[i];
                            result.Add(FlashUtils.CreatNPCInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result,true);
        }
        public static byte[] DailyAwardList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    DailyAwardInfo[] infos = db.GetAllDailyAward();
                    if (infos != null && infos.Length > 0)
                    {
                        DailyAwardInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            DailyAwardInfo info = array[i];
                            result.Add(FlashUtils.CreateActiveInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] ConsortiaLevelList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ConsortiaBussiness db = new ConsortiaBussiness())
                {
                    ConsortiaLevelInfo[] infos = db.GetAllConsortiaLevel();
                    if (infos != null && infos.Length > 0)
                    {
                        ConsortiaLevelInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ConsortiaLevelInfo info = array[i];
                            result.Add(FlashUtils.CreateConsortiLevelInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result,  true);
        }
        public static byte[] MapServerList()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (MapBussiness db = new MapBussiness())
                {
                    ServerMapInfo[] infos = db.GetAllServerMap();
                    if (infos != null && infos.Length > 0)
                    {
                        ServerMapInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ServerMapInfo info = array[i];
                            result.Add(FlashUtils.CreateMapServer(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result,true);
        }
        public static byte[] ItemStrengthenList()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    StrengthenInfo[] infos = db.GetAllStrengthen();
                    if (infos != null && infos.Length > 0)
                    {
                        StrengthenInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            StrengthenInfo info = array[i];
                            result.Add(FlashUtils.CreateStrengthenInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] ItemsCategory()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    CategoryInfo[] infos = db.GetAllCategory();
                    if (infos != null && infos.Length > 0)
                    {
                        CategoryInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            CategoryInfo info = array[i];
                            result.Add(FlashUtils.CreateCategoryInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] ShopItemList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    XElement Store = new XElement("Store");
                    ShopItemInfo[] shop = db.GetALllShop();
                    if (shop != null && shop.Length > 0)
                    {
                        ShopItemInfo[] array = shop;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ShopItemInfo s = array[i];
                            Store.Add(FlashUtils.CreateShopInfo(s));
                        }
                        result.Add(Store);
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result,  true);
        }
        public static byte[] TemplateAllList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    XElement template = new XElement("ItemTemplate");
                    ItemTemplateInfo[] items = db.GetAllGoods();
                    if (items != null && items.Length > 0)
                    {
                        ItemTemplateInfo[] array = items;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ItemTemplateInfo g = array[i];
                            template.Add(FlashUtils.CreateItemInfo(g));
                        }
                        result.Add(template);
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] QuestList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    QuestInfo[] quests = db.GetALlQuest();
                    QuestAwardInfo[] questgoods = db.GetAllQuestGoods();
                    QuestConditionInfo[] questcondiction = db.GetAllQuestCondiction();
                    if (quests != null && questgoods != null && questcondiction != null && quests.Length > 0 && questgoods.Length > 0 && questcondiction.Length > 0)
                    {
                        QuestInfo[] array = quests;
                        QuestInfo quest;
                        for (int i = 0; i < array.Length; i++)
                        {
                            quest = array[i];
                            XElement temp_xml = FlashUtils.CreateQuestInfo(quest);
                            IEnumerable temp_questcondiction =
                                from s in questcondiction
                                where s.QuestID == quest.ID
                                select s;
                            foreach (QuestConditionInfo item in temp_questcondiction)
                            {
                                temp_xml.Add(FlashUtils.CreateQuestCondiction(item));
                            }
                            IEnumerable temp_questgoods =
                                from s in questgoods
                                where s.QuestID == quest.ID
                                select s;
                            foreach (QuestAwardInfo item2 in temp_questgoods)
                            {
                                temp_xml.Add(FlashUtils.CreateQuestGoods(item2));
                            }
                            result.Add(temp_xml);
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }       
        public static byte[] PVEList()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (PveBussiness db = new PveBussiness())
                {
                    PveInfo[] infos = db.GetAllPveInfos();
                    if (infos != null && infos.Length > 0)
                    {
                        PveInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            PveInfo info = array[i];
                            if (info.Type == 5)
                            {
                            }
                            result.Add(FlashUtils.CreatePveInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] MapList()
        {
            bool value = false;
            string message = "Fail";
            XElement result = new XElement("Result");
            try
            {
                using (MapBussiness db = new MapBussiness())
                {
                    MapInfo[] infos = db.GetAllMap();
                    if (infos != null && infos.Length > 0)
                    {
                        MapInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            MapInfo info = array[i];
                            result.Add(FlashUtils.CreateMapInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] BallList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ProduceBussiness db = new ProduceBussiness())
                {
                    BallInfo[] infos = db.GetAllBall();
                    if (infos != null && infos.Length > 0)
                    {
                        BallInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            BallInfo info = array[i];
                            result.Add(FlashUtils.CreateBallInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }
            result.Add(new XAttribute("value", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, true);
        }
        public static byte[] ActiveList()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (ActiveBussiness db = new ActiveBussiness())
                {
                    ActiveInfo[] infos = db.GetAllActives();
                    if (infos != null && infos.Length > 0)
                    {
                        ActiveInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            ActiveInfo info = array[i];
                            result.Add(FlashUtils.CreateActiveInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                    else
                    {
                        value = false;
                        message = "Fail!";
                    }
                }
            }
            catch (Exception ex)
            {
                WebServer.log.Error(ex);
            }

            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result,true);
        }





        public static byte[] CelebForBestEquip()
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                using (PlayerBussiness db = new PlayerBussiness())
                {
                    BestEquipInfo[] infos = db.GetCelebByDayBestEquip();
                    BestEquipInfo[] array = infos;
                    for (int i = 0; i < array.Length; i++)
                    {
                        BestEquipInfo info = array[i];
                        result.Add(FlashUtils.CreateBestEquipInfo(info));
                    }
                    value = true;
                    message = "Success!";
                }
            }
            catch
            {

            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            return CreateCompressXml(result, false);
        }

        public static byte[] BuildCelebConsortia(int order)
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            int total = 0;
            try
            {
                int page = 1;
                int size = 100;
                int consortiaID = -1;
                string name = "";
                int level = -1;
                using (ConsortiaBussiness db = new ConsortiaBussiness())
                {
                    ConsortiaInfo[] infos = db.GetConsortiaPage(page, size, ref total, order, name, consortiaID, level, -1);
                    ConsortiaInfo[] array = infos;
                    for (int i = 0; i < array.Length; i++)
                    {
                        ConsortiaInfo info = array[i];
                        XElement node = FlashUtils.CreateConsortiaInfo(info);
                        if (info.ChairmanID != 0)
                        {
                            using (PlayerBussiness pb = new PlayerBussiness())
                            {
                                PlayerInfo player = pb.GetUserSingleByUserID(info.ChairmanID);
                                if (player != null)
                                {
                                    node.Add(FlashUtils.CreateCelebInfo(player));
                                }
                            }
                        }
                        result.Add(node);
                    }
                    value = true;
                    message = "Success!";
                }
            }
            catch (Exception ex)
            {
                
            }
            result.Add(new XAttribute("total", total));
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            result.Add(new XAttribute("date", DateTime.Now.ToString("MM-dd HH:mm")));
            return CreateCompressXml(result, true);
        }
        public static byte[] BuildCelebUsers(int order)
        {
            bool value = false;
            string message = "Fail!";
            XElement result = new XElement("Result");
            try
            {
                int page = 1;
                int size = 100;
                int userID = -1;
                int total = 0;
                bool resultValue = false;
                using (PlayerBussiness db = new PlayerBussiness())
                {
                    PlayerInfo[] infos = db.GetPlayerPage(page, size, ref total, order, userID, ref resultValue);
                    if (resultValue)
                    {
                        PlayerInfo[] array = infos;
                        for (int i = 0; i < array.Length; i++)
                        {
                            PlayerInfo info = array[i];
                            result.Add(FlashUtils.CreateCelebInfo(info));
                        }
                        value = true;
                        message = "Success!";
                    }
                }
            }
            catch
            {
                
            }
            result.Add(new XAttribute("vaule", value));
            result.Add(new XAttribute("message", message));
            result.Add(new XAttribute("date", DateTime.Now.ToString("MM-dd HH:mm")));
            return CreateCompressXml(result, true);
        }
    }




    public class FlashUtils
    {
        public static XElement CreateUserLoginList(PlayerInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("UserName", (info.UserName == null) ? "" : info.UserName),
                new XAttribute("NickName", (info.NickName == null) ? "" : info.NickName),
                new XAttribute("Grade", info.Grade),
                new XAttribute("Repute", info.Repute),
                new XAttribute("Sex", info.Sex),
                new XAttribute("WinCount", info.Win),
                new XAttribute("TotalCount", info.Total),
                new XAttribute("ConsortiaName", info.ConsortiaName),
                new XAttribute("Rename", info.Rename),
                new XAttribute("ConsortiaRename", info.ConsortiaRename ? (info.NickName == info.ChairmanName) : info.ConsortiaRename),
                new XAttribute("EscapeCount", info.Escape),
                new XAttribute("IsFirst", info.IsFirst),
                new XAttribute("FightPower", info.FightPower)
            });
        }
        public static XElement CreateServerInfo(int id, string name, string ip, int port, int state, int mustLevel, int lowestLevel, int online)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", id),
                new XAttribute("Name", name),
                new XAttribute("IP", ip),
                new XAttribute("Port", port),
                new XAttribute("State", state),
                new XAttribute("MustLevel", mustLevel),
                new XAttribute("LowestLevel", lowestLevel),
                new XAttribute("Online", online),
                new XAttribute("Remark", "")
            });
        }

        public static XElement CreateMapInfo(MapInfo m)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", m.ID),
                new XAttribute("Name", (m.Name == null) ? "" : m.Name),
                new XAttribute("Description", (m.Description == null) ? "" : m.Description),
                new XAttribute("ForegroundWidth", m.ForegroundWidth),
                new XAttribute("ForegroundHeight", m.ForegroundHeight),
                new XAttribute("BackroundWidht", m.BackroundWidht),
                new XAttribute("BackroundHeight", m.BackroundHeight),
                new XAttribute("DeadWidth", m.DeadWidth),
                new XAttribute("DeadHeight", m.DeadHeight),
                new XAttribute("Weight", m.Weight),
                new XAttribute("DragIndex", m.DragIndex),
                new XAttribute("ForePic", (m.ForePic == null) ? "" : m.ForePic),
                new XAttribute("BackPic", (m.BackPic == null) ? "" : m.BackPic),
                new XAttribute("DeadPic", (m.DeadPic == null) ? "" : m.DeadPic),
                new XAttribute("Pic", (m.Pic == null) ? "" : m.Pic),
                new XAttribute("BackMusic", (m.BackMusic == null) ? "" : m.BackMusic),
                new XAttribute("Remark", (m.Remark == null) ? "" : m.Remark),
                new XAttribute("Type", m.Type)
            });
        }
        public static XElement CreatePveInfo(PveInfo m)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", m.ID),
                new XAttribute("Name", (m.Name == null) ? "" : m.Name),
                new XAttribute("Type", m.Type),
                new XAttribute("LevelLimits", m.LevelLimits),
                new XAttribute("SimpleTemplateIds", (m.SimpleTemplateIds == null) ? "" : m.SimpleTemplateIds),
                new XAttribute("NormalTemplateIds", (m.NormalTemplateIds == null) ? "" : m.NormalTemplateIds),
                new XAttribute("HardTemplateIds", (m.HardTemplateIds == null) ? "" : m.HardTemplateIds),
                new XAttribute("TerrorTemplateIds", (m.TerrorTemplateIds == null) ? "" : m.TerrorTemplateIds),
                new XAttribute("Pic", (m.Pic == null) ? "" : m.Pic),
                new XAttribute("Description", (m.Description == null) ? "" : m.Description),
                new XAttribute("AdviceTips", (m.AdviceTips == null) ? "" : m.AdviceTips)
            });
        }
        public static XElement CreateUserBox(BoxInfo m)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", m.ID),
                new XAttribute("Type", m.Type),
                new XAttribute("Level", m.Level),
                new XAttribute("Condition", m.Condition),
                new XAttribute("TemplateID", m.Template)
            });
        }
        public static XElement CreateItemBox(ItemBoxInfo m)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", m.DataId),
                new XAttribute("TemplateId", m.TemplateId),
                new XAttribute("StrengthenLevel", m.StrengthenLevel),
                new XAttribute("IsBind", m.IsBind),
                new XAttribute("ItemCount", m.ItemCount),
                new XAttribute("LuckCompose", m.LuckCompose),
                new XAttribute("DefendCompose", m.DefendCompose),
                new XAttribute("AttackCompose", m.AttackCompose),
                new XAttribute("AgilityCompose", m.AgilityCompose),
                new XAttribute("ItemValid", m.ItemValid)
            });
        }
        public static XElement CreateStrengthenInfo(StrengthenInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("StrengthenLevel", info.StrengthenLevel),
                new XAttribute("Rock", info.Rock)
            });
        }
        public static XElement CreateItemInfo(ItemTemplateInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("AddTime", info.AddTime),
                new XAttribute("Agility", info.Agility),
                new XAttribute("Attack", info.Attack),
                new XAttribute("CanCompose", info.CanCompose),
                new XAttribute("CanDelete", info.CanDelete),
                new XAttribute("CanDrop", info.CanDrop),
                new XAttribute("CanEquip", info.CanEquip),
                new XAttribute("CanStrengthen", info.CanStrengthen),
                new XAttribute("CanUse", info.CanUse),
                new XAttribute("CategoryID", info.CategoryID),
                new XAttribute("Colors", info.Colors),
                new XAttribute("Defence", info.Defence),
                new XAttribute("Description", (info.Description == null) ? "" : info.Description),
                new XAttribute("Level", info.Level),
                new XAttribute("Luck", info.Luck),
                new XAttribute("MaxCount", info.MaxCount),
                new XAttribute("Name", (info.Name == null) ? "" : info.Name),
                new XAttribute("NeedLevel", info.NeedLevel),
                new XAttribute("NeedSex", info.NeedSex),
                new XAttribute("Pic", (info.Pic == null) ? "" : info.Pic),
                new XAttribute("Data", (info.Data == null) ? "" : info.Data),
                new XAttribute("Property1", info.Property1),
                new XAttribute("Property2", info.Property2),
                new XAttribute("Property3", info.Property3),
                new XAttribute("Property4", info.Property4),
                new XAttribute("Property5", info.Property5),
                new XAttribute("Property6", info.Property6),
                new XAttribute("Property7", info.Property7),
                new XAttribute("Property8", info.Property8),
                new XAttribute("Quality", info.Quality),
                new XAttribute("Script", (info.Script == null) ? "" : info.Script),
                new XAttribute("BindType", info.BindType),
                new XAttribute("FusionType", info.FusionType),
                new XAttribute("FusionRate", info.FusionRate),
                new XAttribute("FusionNeedRate", info.FusionNeedRate),
                new XAttribute("TemplateID", info.TemplateID),
                new XAttribute("RefineryLevel", info.RefineryLevel),
                new XAttribute("Hole", info.Hole),
                new XAttribute("ReclaimValue", info.ReclaimValue),
                new XAttribute("ReclaimType", info.ReclaimType),
                new XAttribute("IsOnly",info.IsOnly)
            });
        }
        public static XElement CreateGoodsInfo(ItemInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("AgilityCompose", info.AgilityCompose),
                new XAttribute("AttackCompose", info.AttackCompose),
                new XAttribute("BeginDate", info.BeginDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Color", (info.Color == null) ? "" : info.Color),
                new XAttribute("Skin", (info.Skin == null) ? "" : info.Skin),
                new XAttribute("Count", info.Count),
                new XAttribute("DefendCompose", info.DefendCompose),
                new XAttribute("IsBinds", info.IsBinds),
                new XAttribute("IsUsed", info.IsUsed),
                new XAttribute("IsJudge", info.IsJudge),
                new XAttribute("ItemID", info.ItemID),
                new XAttribute("LuckCompose", info.LuckCompose),
                new XAttribute("Place", info.Place),
                new XAttribute("StrengthenLevel", info.StrengthenLevel),
                new XAttribute("TemplateID", info.TemplateID),
                new XAttribute("UserID", info.UserID),
                new XAttribute("BagType", info.BagType),
                new XAttribute("ValidDate", info.ValidDate),
                new XAttribute("Hole1", info.Hole1),
                new XAttribute("Hole2", info.Hole2),
                new XAttribute("Hole3", info.Hole3),
                new XAttribute("Hole4", info.Hole4),
                new XAttribute("Hole5", info.Hole5),
                new XAttribute("Hole6", info.Hole6)
            });
        }
        public static XElement CreateShopInfo(ShopItemInfo shop)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", shop.ID),
                new XAttribute("ShopID", shop.ShopID),
                new XAttribute("GroupID", shop.GroupID),
                new XAttribute("TemplateID", shop.TemplateID),
                new XAttribute("BuyType", shop.BuyType),
                new XAttribute("Sort", shop.Sort),
                new XAttribute("IsBind", shop.IsBind),
                new XAttribute("IsVouch", shop.IsVouch),
                new XAttribute("Label", shop.Label),
                new XAttribute("Beat", shop.Beat),
                new XAttribute("AUnit", shop.AUnit),
                new XAttribute("APrice1", shop.APrice1),
                new XAttribute("AValue1", shop.AValue1),
                new XAttribute("APrice2", shop.APrice2),
                new XAttribute("AValue2", shop.AValue2),
                new XAttribute("APrice3", shop.APrice3),
                new XAttribute("AValue3", shop.AValue3),
                new XAttribute("BUnit", shop.BUnit),
                new XAttribute("BPrice1", shop.BPrice1),
                new XAttribute("BValue1", shop.BValue1),
                new XAttribute("BPrice2", shop.BPrice2),
                new XAttribute("BValue2", shop.BValue2),
                new XAttribute("BPrice3", shop.BPrice3),
                new XAttribute("BValue3", shop.BValue3),
                new XAttribute("CUnit", shop.CUnit),
                new XAttribute("CPrice1", shop.CPrice1),
                new XAttribute("CValue1", shop.CValue1),
                new XAttribute("CPrice2", shop.CPrice2),
                new XAttribute("CValue2", shop.CValue2),
                new XAttribute("CPrice3", shop.CPrice3),
                new XAttribute("CValue3", shop.CValue3),
                new XAttribute("IsCheap", shop.IsCheap)
            });
        }
        public static XElement CreateBallInfo(BallInfo b)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", b.ID),
                new XAttribute("Power", b.Power),
                new XAttribute("Radii", b.Radii),
                new XAttribute("FlyingPartical", (b.FlyingPartical == null) ? "" : b.FlyingPartical),
                new XAttribute("BombPartical", (b.BombPartical == null) ? "" : b.BombPartical),
                new XAttribute("IsSpin", b.IsSpin),
                new XAttribute("SpinV", b.SpinV),
                new XAttribute("SpinVA", b.SpinVA),
                new XAttribute("Amount", b.Amount),
                new XAttribute("Wind", b.Wind),
                new XAttribute("DragIndex", b.DragIndex),
                new XAttribute("Weight", b.Weight),
                new XAttribute("Shake", b.Shake),
                new XAttribute("ShootSound", (b.ShootSound == null) ? "" : b.ShootSound),
                new XAttribute("BombSound", (b.BombSound == null) ? "" : b.BombSound),
                new XAttribute("ActionType", b.ActionType),
                new XAttribute("Mass", b.Mass)
            });
        }
        public static XElement CreateCategoryInfo(CategoryInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("Name", (info.Name == null) ? "" : info.Name),
                new XAttribute("Place", info.Place),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark)
            });
        }
        public static XElement CreateQuestInfo(QuestInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("QuestID", info.QuestID),
                new XAttribute("Title", info.Title),
                new XAttribute("Detail", info.Detail),
                new XAttribute("Objective", info.Objective),
                new XAttribute("NeedMinLevel", info.NeedMinLevel),
                new XAttribute("NeedMaxLevel", info.NeedMaxLevel),
                new XAttribute("PreQuestID", info.PreQuestID),
                new XAttribute("NextQuestID", info.NextQuestID),
                new XAttribute("IsOther", info.IsOther),
                new XAttribute("CanRepeat", info.CanRepeat),
                new XAttribute("RepeatInterval", info.RepeatInterval),
                new XAttribute("RepeatMax", info.RepeatMax),
                new XAttribute("RewardGP", info.RewardGP),
                new XAttribute("RewardGold", info.RewardGold),
                new XAttribute("RewardGiftToken", info.RewardGiftToken),
                new XAttribute("RewardOffer", info.RewardOffer),
                new XAttribute("RewardRiches", info.RewardRiches),
                new XAttribute("RewardBuffID", info.RewardBuffID),
                new XAttribute("RewardBuffDate", info.RewardBuffDate),
                new XAttribute("RewardMoney", info.RewardMoney),
                new XAttribute("Rands", info.Rands),
                new XAttribute("RandDouble", info.RandDouble),
                new XAttribute("TimeMode", info.TimeMode),
                new XAttribute("StartDate", info.StartDate),
                new XAttribute("EndDate", info.EndDate)
            });
        }
        public static XElement CreateQuestCondiction(QuestConditionInfo info)
        {
            return new XElement("Item_Condiction", new object[]
            {
                new XAttribute("QuestID", info.QuestID),
                new XAttribute("CondictionID", info.CondictionID),
                new XAttribute("CondictionTitle", info.CondictionTitle),
                new XAttribute("CondictionType", info.CondictionType),
                new XAttribute("Para1", info.Para1),
                new XAttribute("Para2", info.Para2)
            });
        }
        public static XElement CreateQuestGoods(QuestAwardInfo info)
        {
            return new XElement("Item_Good", new object[]
            {
                new XAttribute("QuestID", info.QuestID),
                new XAttribute("RewardItemID", info.RewardItemID),
                new XAttribute("IsSelect", info.IsSelect),
                new XAttribute("RewardItemValid", info.RewardItemValid),
                new XAttribute("RewardItemCount", info.RewardItemCount),
                new XAttribute("StrengthenLevel", info.StrengthenLevel),
                new XAttribute("AttackCompose", info.AttackCompose),
                new XAttribute("DefendCompose", info.DefendCompose),
                new XAttribute("AgilityCompose", info.AgilityCompose),
                new XAttribute("LuckCompose", info.LuckCompose),
                new XAttribute("IsCount", info.IsCount)
                        });
        }
        public static XElement CreateQuestDataInfo(QuestDataInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("CompletedDate", info.CompletedDate),
                new XAttribute("IsComplete", info.IsComplete),
                new XAttribute("Condition1", info.Condition1),
                new XAttribute("Condition2", info.Condition2),
                new XAttribute("Condition3", info.Condition3),
                new XAttribute("Condition4", info.Condition4),
                new XAttribute("QuestID", info.QuestID),
                new XAttribute("UserID", info.UserID),
                new XAttribute("RepeatFinish", info.RepeatFinish)
            });
        }
        public static XElement CreateMapServer(ServerMapInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ServerID", info.ServerID),
                new XAttribute("OpenMap", info.OpenMap),
                new XAttribute("IsSpecial", info.IsSpecial)
            });
        }
        public static XElement CreateActiveInfo(ActiveInfo info)
        {
            XName arg_1C0_0 = "Item";
            object[] array = new object[11];
            array[0] = new XAttribute("ActiveID", info.ActiveID);
            array[1] = new XAttribute("Description", (info.Description == null) ? "" : info.Description);
            array[2] = new XAttribute("Content", (info.Content == null) ? "" : info.Content);
            array[3] = new XAttribute("AwardContent", (info.AwardContent == null) ? "" : info.AwardContent);
            array[4] = new XAttribute("HasKey", info.HasKey);
            object[] arg_ED_0 = array;
            int arg_ED_1 = 5;
            XName arg_E8_0 = "EndDate";
            DateTime arg_D4_0 = info.EndDate;
            arg_ED_0[arg_ED_1] = new XAttribute(arg_E8_0, info.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
            array[6] = new XAttribute("IsOnly", info.IsOnly);
            array[7] = new XAttribute("StartDate", string.IsNullOrEmpty(info.StartDate.ToString()) ? "" : info.StartDate.ToString("yyyy-MM-dd HH:mm:ss"));
            array[8] = new XAttribute("Title", (info.Title == null) ? "" : info.Title);
            array[9] = new XAttribute("Type", info.Type);
            array[10] = new XAttribute("ActionTimeContent", (info.ActionTimeContent == null) ? "" : info.ActionTimeContent);
            return new XElement(arg_1C0_0, array);
        }
        public static XElement CreateAuctionInfo(AuctionInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("AuctionID", info.AuctionID),
                new XAttribute("AuctioneerID", info.AuctioneerID),
                new XAttribute("AuctioneerName", (info.AuctioneerName == null) ? "" : info.AuctioneerName),
                new XAttribute("BeginDate", info.BeginDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("BuyerID", info.BuyerID),
                new XAttribute("BuyerName", (info.BuyerName == null) ? "" : info.BuyerName),
                new XAttribute("ItemID", info.ItemID),
                new XAttribute("Mouthful", info.Mouthful),
                new XAttribute("PayType", info.PayType),
                new XAttribute("Price", info.Price),
                new XAttribute("Rise", info.Rise),
                new XAttribute("ValidDate", info.ValidDate)
            });
        }
        public static XElement CreateConsortiaInfo(ConsortiaInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("BuildDate", info.BuildDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("CelebCount", info.CelebCount),
                new XAttribute("ChairmanID", info.ChairmanID),
                new XAttribute("ChairmanName", (info.ChairmanName == null) ? "" : info.ChairmanName),
                new XAttribute("ConsortiaName", (info.ConsortiaName == null) ? "" : info.ConsortiaName),
                new XAttribute("CreatorID", info.CreatorID),
                new XAttribute("CreatorName", (info.CreatorName == null) ? "" : info.CreatorName),
                new XAttribute("Description", (info.Description == null) ? "" : info.Description),
                new XAttribute("Honor", info.Honor),
                new XAttribute("IP", info.IP),
                new XAttribute("Level", info.Level),
                new XAttribute("MaxCount", info.MaxCount),
                new XAttribute("Placard", (info.Placard == null) ? "" : info.Placard),
                new XAttribute("Repute", info.Repute),
                new XAttribute("Count", info.Count),
                new XAttribute("Riches", info.Riches),
                new XAttribute("FightPower", info.FightPower),
                new XAttribute("DeductDate", info.DeductDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("AddDayHonor", info.AddDayHonor),
                new XAttribute("AddDayRiches", info.AddDayRiches),
                new XAttribute("AddWeekHonor", info.AddWeekHonor),
                new XAttribute("AddWeekRiches", info.AddWeekRiches),
                new XAttribute("LastDayRiches", info.LastDayRiches),
                new XAttribute("OpenApply", info.OpenApply),
                new XAttribute("StoreLevel", info.StoreLevel),
                new XAttribute("SmithLevel", info.SmithLevel),
                new XAttribute("ShopLevel", info.ShopLevel),
                new XAttribute("Port", info.Port)
            });
        }
        public static XElement CreateConsortiaApplyUserInfo(ConsortiaApplyUserInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("ApplyDate", info.ApplyDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("ConsortiaName", (info.ConsortiaName == null) ? "" : info.ConsortiaName),
                new XAttribute("Remark", info.Remark),
                new XAttribute("UserID", info.UserID),
                new XAttribute("UserName", (info.UserName == null) ? "" : info.UserName),
                new XAttribute("UserLevel", info.UserLevel),
                new XAttribute("Win", info.Win),
                new XAttribute("Total", info.Total),
                new XAttribute("Repute", info.Repute),
                new XAttribute("FightPower", info.FightPower)
            });
        }
        public static XElement CreateConsortiaInviteUserInfo(ConsortiaInviteUserInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("CelebCount", info.CelebCount),
                new XAttribute("ChairmanName", (info.ChairmanName == null) ? "" : info.ChairmanName),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("ConsortiaName", (info.ConsortiaName == null) ? "" : info.ConsortiaName),
                new XAttribute("Count", info.Count),
                new XAttribute("Honor", info.Honor),
                new XAttribute("InviteDate", info.InviteDate),
                new XAttribute("InviteID", info.InviteID),
                new XAttribute("InviteName", (info.InviteName == null) ? "" : info.InviteName),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark),
                new XAttribute("Repute", info.Repute),
                new XAttribute("UserID", info.UserID),
                new XAttribute("UserName", (info.UserName == null) ? "" : info.UserName)
            });
        }
        public static XElement CreateConsortiaUserInfo(ConsortiaUserInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("DutyID", info.DutyID),
                new XAttribute("DutyName", (info.DutyName == null) ? "" : info.DutyName),
                new XAttribute("GP", info.GP),
                new XAttribute("Grade", info.Grade),
                new XAttribute("Right", info.Right),
                new XAttribute("DutyLevel", info.Level),
                new XAttribute("Offer", info.Offer),
                new XAttribute("RatifierID", info.RatifierID),
                new XAttribute("RatifierName", (info.RatifierName == null) ? "" : info.RatifierName),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark),
                new XAttribute("Repute", info.Repute),
                new XAttribute("State", (info.State == 1) ? 1 : 0),
                new XAttribute("UserID", info.UserID),
                new XAttribute("Hide", info.Hide),
                new XAttribute("Colors", (info.Colors == null) ? "" : info.Colors),
                new XAttribute("Skin", (info.Skin == null) ? "" : info.Skin),
                new XAttribute("Style", info.Style),
                new XAttribute("LastDate", info.LastDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Sex", info.Sex),
                new XAttribute("IsBanChat", info.IsBanChat),
                new XAttribute("WinCount", info.Win),
                new XAttribute("TotalCount", info.Total),
                new XAttribute("EscapeCount", info.Escape),
                new XAttribute("RichesOffer", info.RichesOffer),
                new XAttribute("RichesRob", info.RichesRob),
                new XAttribute("Nimbus", info.Nimbus),
                new XAttribute("LoginName", (info.LoginName == null) ? "" : info.LoginName),
                new XAttribute("UserName", (info.UserName == null) ? "" : info.UserName),
                new XAttribute("FightPower", info.FightPower)
        });
        }
        public static XElement CreateConsortiaIMInfo(ConsortiaUserInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("DutyID", info.DutyID),
                new XAttribute("DutyName", (info.DutyName == null) ? "" : info.DutyName),
                new XAttribute("GP", info.GP),
                new XAttribute("Grade", info.Grade),
                new XAttribute("Level", info.Level),
                new XAttribute("Offer", info.Offer),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark),
                new XAttribute("Repute", info.Repute),
                new XAttribute("State", (info.State == 1) ? 1 : 0),
                new XAttribute("UserID", info.UserID),
                new XAttribute("Hide", info.Hide),
                new XAttribute("Colors", (info.Colors == null) ? "" : info.Colors),
                new XAttribute("Skin", (info.Skin == null) ? "" : info.Skin),
                new XAttribute("Style", info.Style),
                new XAttribute("LastDate", info.LastDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Sex", info.Sex),
                new XAttribute("LoginName", info.LoginName),
                new XAttribute("NickName", (info.UserName == null) ? "" : info.UserName)
            });
        }
        public static XElement CreateConsortiaDutyInfo(ConsortiaDutyInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("DutyID", info.DutyID),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("DutyName", (info.DutyName == null) ? "" : info.DutyName),
                new XAttribute("Right", info.Right),
                new XAttribute("Level", info.Level)
            });
        }
        public static XElement CreateConsortiaApplyAllyInfo(ConsortiaApplyAllyInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("CelebCount", info.CelebCount),
                new XAttribute("ChairmanName", (info.ChairmanName == null) ? "" : info.ChairmanName),
                new XAttribute("ConsortiaID", info.Consortia1ID),
                new XAttribute("ConsortiaName", (info.ConsortiaName == null) ? "" : info.ConsortiaName),
                new XAttribute("Count", info.Count),
                new XAttribute("Date", info.Date.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Honor", info.Honor),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark),
                new XAttribute("Level", info.Level),
                new XAttribute("Description", (info.Description == null) ? "" : info.Description),
                new XAttribute("Repute", info.Repute)
            });
        }
        public static XElement CreateConsortiaAllyInfo(ConsortiaAllyInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("ChairmanName", (info.ChairmanName1 == null) ? "" : info.ChairmanName1),
                new XAttribute("ConsortiaID", info.Consortia1ID),
                new XAttribute("ConsortiaName", (info.ConsortiaName1 == null) ? "" : info.ConsortiaName1),
                new XAttribute("Count", info.Count1),
                new XAttribute("Honor", info.Honor1),
                new XAttribute("State", info.State),
                new XAttribute("Date", info.Date.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Level", info.Level1),
                new XAttribute("IsApply", info.IsApply),
                new XAttribute("Description", info.Description1),
                new XAttribute("Riches", info.Riches1),
                new XAttribute("Repute", info.Repute1)
            });
        }
        public static XElement CreateConsortiaEventInfo(ConsortiaEventInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("Date", info.Date.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Type", info.Type),
                new XAttribute("Remark", (info.Remark == null) ? "" : (info.Date.ToString("yy-MM-dd") + " " + info.Remark))
            });
        }
        public static XElement CreateConsortiLevelInfo(ConsortiaLevelInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("Level", info.Level),
                new XAttribute("Count", info.Count),
                new XAttribute("Deduct", info.Deduct),
                new XAttribute("NeedGold", info.NeedGold),
                new XAttribute("NeedItem", info.NeedItem),
                new XAttribute("Reward", info.Reward),
                new XAttribute("ShopRiches", info.ShopRiches),
                new XAttribute("SmithRiches", info.SmithRiches),
                new XAttribute("StoreRiches", info.StoreRiches),
                new XAttribute("Riches", info.Riches)
            });
        }
        public static XElement CreateCelebInfo(PlayerInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("UserName", (info.UserName == null) ? "" : info.UserName),
                new XAttribute("NickName", (info.NickName == null) ? "" : info.NickName),
                new XAttribute("Grade", info.Grade),
                new XAttribute("Colors", (info.Colors == null) ? "" : info.Colors),
                new XAttribute("Skin", (info.Skin == null) ? "" : info.Skin),
                new XAttribute("Sex", info.Sex),
                new XAttribute("Style", (info.Style == null) ? "" : info.Style),
                new XAttribute("ConsortiaName", (info.ConsortiaName == null) ? "" : info.ConsortiaName),
                new XAttribute("Hide", info.Hide),
                new XAttribute("Offer", info.Offer),
                new XAttribute("ReputeOffer", info.ReputeOffer),
                new XAttribute("ConsortiaHonor", info.ConsortiaHonor),
                new XAttribute("ConsortiaLevel", info.ConsortiaLevel),
                new XAttribute("StoreLevel", info.StoreLevel),
                new XAttribute("ShopLevel", info.ShopLevel),
                new XAttribute("SmithLevel", info.SmithLevel),
                new XAttribute("ConsortiaRepute", info.ConsortiaRepute),
                new XAttribute("WinCount", info.Win),
                new XAttribute("TotalCount", info.Total),
                new XAttribute("EscapeCount", info.Escape),
                new XAttribute("Repute", info.Repute),
                new XAttribute("AddDayGP", info.AddDayGP),
                new XAttribute("AddDayOffer", info.AddDayOffer),
                new XAttribute("AddWeekGP", info.AddWeekGP),
                new XAttribute("AddWeekOffer", info.AddWeekOffer),
                new XAttribute("ConsortiaRiches", info.ConsortiaRiches),
                new XAttribute("Nimbus", info.Nimbus),
                new XAttribute("GP", info.GP),
                new XAttribute("FightPower", info.FightPower)
            });
        }
        public static XElement CreateBestEquipInfo(BestEquipInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("Date", info.Date.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("GP", info.GP),
                new XAttribute("Grade", info.Grade),
                new XAttribute("ItemName", (info.ItemName == null) ? "" : info.ItemName),
                new XAttribute("NickName", (info.NickName == null) ? "" : info.NickName),
                new XAttribute("Sex", info.Sex),
                new XAttribute("Strengthenlevel", info.Strengthenlevel),
                new XAttribute("Type", (info.UserName == null) ? "" : info.UserName)
            });
        }
        public static XElement CreateMailInfo(MailInfo info, string nodeName)
        {
            TimeSpan days = DateTime.Now.Subtract(info.SendTime);
            return new XElement(nodeName, new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("Title", info.Title),
                new XAttribute("Content", info.Content),
                new XAttribute("Sender", info.Sender),
                new XAttribute("Receiver", info.Receiver),
                new XAttribute("SendTime", info.SendTime.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("ValidDate", info.ValidDate),
                new XAttribute("Gold", info.Gold),
                new XAttribute("Money", info.Money),
                new XAttribute("Annex1ID", (info.Annex1 == null) ? "" : info.Annex1),
                new XAttribute("Annex2ID", (info.Annex2 == null) ? "" : info.Annex2),
                new XAttribute("Annex3ID", (info.Annex3 == null) ? "" : info.Annex3),
                new XAttribute("Annex4ID", (info.Annex4 == null) ? "" : info.Annex4),
                new XAttribute("Annex5ID", (info.Annex5 == null) ? "" : info.Annex5),
                new XAttribute("Annex1Name", (info.Annex1Name == null) ? "" : info.Annex1Name),
                new XAttribute("Annex2Name", (info.Annex2Name == null) ? "" : info.Annex2Name),
                new XAttribute("Annex3Name", (info.Annex3Name == null) ? "" : info.Annex3Name),
                new XAttribute("Annex4Name", (info.Annex4Name == null) ? "" : info.Annex4Name),
                new XAttribute("Annex5Name", (info.Annex5Name == null) ? "" : info.Annex5Name),
                new XAttribute("AnnexRemark", (info.AnnexRemark == null) ? "" : info.AnnexRemark),
                new XAttribute("Type", info.Type),
                new XAttribute("IsRead", info.IsRead)
            });
        }
        public static XElement CreateBuffInfo(BufferInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("BeginDate", info.BeginDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new XAttribute("Data", (info.Data == null) ? "" : info.Data),
                new XAttribute("IsExist", info.IsExist),
                new XAttribute("Type", info.Type),
                new XAttribute("UserID", info.UserID),
                new XAttribute("ValidDate", info.ValidDate),
                new XAttribute("Value", info.Value)
            });
        }
        public static XElement CreateMarryInfo(MarryInfo info)
        {
            return new XElement("Info", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("UserID", info.UserID),
                new XAttribute("IsPublishEquip", info.IsPublishEquip),
                new XAttribute("Introduction", info.Introduction),
                new XAttribute("NickName", info.NickName),
                new XAttribute("IsConsortia", info.IsConsortia),
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("Sex", info.Sex),
                new XAttribute("Win", info.Win),
                new XAttribute("Total", info.Total),
                new XAttribute("Escape", info.Escape),
                new XAttribute("GP", info.GP),
                new XAttribute("Honor", info.Honor),
                new XAttribute("Style", info.Style),
                new XAttribute("Colors", info.Colors),
                new XAttribute("Hide", info.Hide),
                new XAttribute("Grade", info.Grade),
                new XAttribute("State", info.State),
                new XAttribute("Repute", info.Repute),
                new XAttribute("Skin", info.Skin),
                new XAttribute("Offer", info.Offer),
                new XAttribute("IsMarried", info.IsMarried),
                new XAttribute("ConsortiaName", info.ConsortiaName),
                new XAttribute("DutyName", info.DutyName),
                new XAttribute("Nimbus", info.Nimbus),
                new XAttribute("FightPower", info.FightPower)
            });
        }
        public static XElement CreateActiveInfo(DailyAwardInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("Count", info.Count),
                new XAttribute("CountRemark", (info.CountRemark == null) ? "" : info.CountRemark),
                new XAttribute("IsBinds", info.IsBinds),
                new XAttribute("Remark", (info.Remark == null) ? "" : info.Remark),
                new XAttribute("Sex", info.Sex),
                new XAttribute("TemplateID", info.TemplateID),
                new XAttribute("Type", info.Type),
                new XAttribute("ValidDate", info.ValidDate),
                new XAttribute("GetWay", info.GetWay)
            });
        }
        public static XElement CreateConsortiaEquipControlInfo(ConsortiaEquipControlInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ConsortiaID", info.ConsortiaID),
                new XAttribute("Level", info.Level),
                new XAttribute("Riches", info.Riches),
                new XAttribute("Type", info.Type)
            });
        }
        public static XElement CreatNPCInfo(NpcInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("Name", info.Name),
                new XAttribute("Level", info.Level),
                new XAttribute("Camp", info.Camp),
                new XAttribute("Type", info.Type),
                new XAttribute("Blood", info.Blood),
                new XAttribute("MoveMin", info.MoveMin),
                new XAttribute("MoveMax", info.MoveMax),
                new XAttribute("BaseDamage", info.BaseDamage),
                new XAttribute("BaseGuard", info.BaseGuard),
                new XAttribute("Defence", info.Defence),
                new XAttribute("Agility", info.Agility),
                new XAttribute("Lucky", info.Lucky),
                new XAttribute("ModelID", info.ModelID),
                new XAttribute("ResourcesPath", info.ResourcesPath),
                new XAttribute("DropRate", info.DropRate),
                new XAttribute("Experience", info.Experience),
                new XAttribute("Delay", info.Delay),
                new XAttribute("Immunity", info.Immunity),
                new XAttribute("Alert", info.Alert),
                new XAttribute("Range", info.Range),
                new XAttribute("Preserve", info.Preserve),
                new XAttribute("Script", info.Script),
                new XAttribute("FireX", info.FireX),
                new XAttribute("FireY", info.FireY),
                new XAttribute("DropId", info.DropId)
            });
        }
        public static XElement CreateDropItemForNewRegister(DropItem info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("Id", info.Id),
                new XAttribute("DropId", info.DropId),
                new XAttribute("ItemId", info.ItemId),
                new XAttribute("ValueDate", info.ValueDate),
                new XAttribute("IsBind", info.IsBind),
                new XAttribute("Random", info.Random),
                new XAttribute("BeginData", info.BeginData),
                new XAttribute("EndData", info.EndData),
                new XAttribute("IsTips", info.IsTips)
            });
        }
        public static XElement CreateAchievement(AchievementInfo info)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", info.ID),
                new XAttribute("PlaceID", info.PlaceID),
                new XAttribute("Title", info.Title),
                new XAttribute("Detail", info.Detail),
                new XAttribute("NeedMinLevel", info.NeedMinLevel),
                new XAttribute("NeedMaxLevel", info.NeedMaxLevel),
                new XAttribute("PreAchievementID", info.PreAchievementID),
                new XAttribute("IsOther", info.IsOther),
                new XAttribute("AchievementType", info.AchievementType),
                new XAttribute("CanHide", info.CanHide),
                new XAttribute("StartDate", info.StartDate),
                new XAttribute("EndDate", info.EndDate),
                new XAttribute("AchievementPoint", info.AchievementPoint)
            });
        }
        public static XElement CreateAchievementCondition(AchievementConditionInfo info)
        {
            return new XElement("Item_Condiction", new object[]
            {
                new XAttribute("AchievementID", info.AchievementID),
                new XAttribute("CondictionID", info.CondictionID),
                new XAttribute("CondictionType", info.CondictionType),
                new XAttribute("Condiction_Para1", info.Condiction_Para1),
                new XAttribute("Condiction_Para2", info.Condiction_Para2)
            });
        }
        public static XElement CreateAchievementReward(AchievementRewardInfo info)
        {
            return new XElement("Item_Reward", new object[]
            {
                new XAttribute("AchievementID", info.AchievementID),
                new XAttribute("RewardType", info.RewardType),
                new XAttribute("RewardPara", info.RewardPara),
                new XAttribute("RewardValueId", info.RewardValueId),
                new XAttribute("RewardCount", info.RewardCount)
            });
        }
        public static XElement CreateAchievementData(AchievementDataInfo info)
        {
            return new XElement("Achievement_Data", new object[]
            {
                new XAttribute("UserID", info.UserID),
                new XAttribute("AchievementID", info.AchievementID),
                new XAttribute("IsComplete", info.IsComplete),
                new XAttribute("CompletedDate", info.CompletedDate)
            });
        }
        public static XElement CreateUsersRecord(UsersRecordInfo info)
        {
            return new XElement("Users_Record", new object[]
            {
                new XAttribute("UserID", info.UserID),
                new XAttribute("RecordID", info.RecordID),
                new XAttribute("Total", info.Total)
            });
        }
        public static XElement CreateFightLabDropItem(int id, int easy, int awardItem, int count)
        {
            return new XElement("Item", new object[]
            {
                new XAttribute("ID", id),
                new XAttribute("Easy", easy),
                new XAttribute("AwardItem", awardItem),
                new XAttribute("Count", count)
            });
        }
        private static void AppendAttribute(XmlDocument doc, XmlNode node, string attr, string value)
        {
            XmlAttribute at = doc.CreateAttribute(attr);
            at.Value = value;
            node.Attributes.Append(at);
        }
    }
}