//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game.Admin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quest
    {
        public int ID { get; set; }
        public int QuestID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Objective { get; set; }
        public int NeedMinLevel { get; set; }
        public int NeedMaxLevel { get; set; }
        public string PreQuestID { get; set; }
        public string NextQuestID { get; set; }
        public int IsOther { get; set; }
        public bool CanRepeat { get; set; }
        public int RepeatInterval { get; set; }
        public int RepeatMax { get; set; }
        public int RewardGP { get; set; }
        public int RewardGold { get; set; }
        public int RewardGiftToken { get; set; }
        public int RewardOffer { get; set; }
        public int RewardRiches { get; set; }
        public int RewardBuffID { get; set; }
        public int RewardBuffDate { get; set; }
        public int RewardMoney { get; set; }
        public decimal Rands { get; set; }
        public int RandDouble { get; set; }
        public bool TimeMode { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}