using AngelBorn.Tools;
using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Grapihcs
{
    class CombatDraw
    {
        private string[] Cor = { "╔", "╗", "╝", "╚" };
        private string Side = "║";
        private string TopBot = "═";
        private string TopLine = "";
        private string BottomLine = "";
        private int LineHeightPos;
        private Cord Pos;
        public void Draw(Cord _Pos)
        {
            Pos = _Pos;
            LineHeightPos = 0;
            string BigLine = Side+" Round: " + SingleTon.GetPlayerController().CBM.Rounds+" " + Side;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            BigLine = Side+ " Name: " + SingleTon.GetPlayerController().PlayerName+ " " + Side;
            CW.Write("", Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos += 2;
            List<string> StatsBlockList = StatBlockDraw();
            string SizeBox = "";
            for(int i = 0; i < StatsBlockList.Count; i++)
            {
                if(StatsBlockList[i].Length > SizeBox.Length)
                {
                    SizeBox = StatsBlockList[i];
                }
            }
            CW.Write(FilloutString(SizeBox + " ", true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            foreach(string element in StatsBlockList)
            {
                CW.Write(element, Pos.X, Pos.Y + LineHeightPos);
                CW.Write(Side, Pos.X + (SizeBox.Length), Pos.Y + LineHeightPos);
                LineHeightPos++;
            }
            CW.Write(FilloutString(SizeBox + " ", false), Pos.X, Pos.Y + LineHeightPos);


            //Other Side
            BigLine = Side + " Name: " + SingleTon.GetPlayerController().CBM.enemyFighting.Name + " " + Side;
            Pos = new Cord(){ X = Console.WindowWidth - (BigLine.Length + 1) , Y = Pos.Y + 4 };
            LineHeightPos = 0;
            CW.Write(FilloutString(BigLine, true), Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(BigLine, Pos.X, Pos.Y + LineHeightPos);
            LineHeightPos++;
            CW.Write(FilloutString(BigLine, false), Pos.X, Pos.Y + LineHeightPos);


        }

        private List<string> StatBlockDraw()
        {
            List<string> DataReturn = new List<string>();
            DataReturn.Add(Side + " Health: " + SingleTon.GetPlayerController().Skills.Vitallity.HealthCurrent +  "/" + SingleTon.GetPlayerController().Skills.Vitallity.Health+" ");
            DataReturn.Add(Side + " Mana: " + SingleTon.GetPlayerController().Skills.Magic.ManaCurrent + "/" + SingleTon.GetPlayerController().Skills.Magic.Mana + " ");
            DataReturn.Add(Side + " Damage: " + SingleTon.GetPlayerController().Skills.Power.ExtraAttack + " + " + SingleTon.GetPlayerController().Skills.Power.Buff + " "); 
            return DataReturn;
        }

        private void ActionMenu()
        {

        }

        private string FilloutString(string InputString, bool Top)
        {
            string ReturnString = "";
            if(Top)
            {
                ReturnString += Cor[0];
                for(int x = 0; x < InputString.Length - 2; x++)
                {
                    ReturnString += TopBot;
                }
                ReturnString += Cor[1];
                return ReturnString;
            }
            else
            {
                ReturnString += Cor[3];
                for(int x = 0; x < InputString.Length - 2; x++)
                {
                    ReturnString += TopBot;
                }
                ReturnString += Cor[2];
                return ReturnString;
            }
        }

        private void WriteStat()
        {
            
        }
    }
}
