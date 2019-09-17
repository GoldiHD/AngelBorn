using AngelBorn.Grapihcs;
using AngelBorn.Grapihcs.MapGra;
using AngelBorn.Tools;
using AngelBorn.World;
using AngleBorn.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Grapihcs
{
    class DrawInfoBox
    {
        private string[] Cor = { "╔", "╗", "╝", "╚" };
        private string Side = "║";
        private string TopBot = "═";
        public static List<string> Inputs { get; private set; }
        private int Index = 0;

        public DrawInfoBox()
        {
            Inputs = new List<string> { "Welcome to the world of AngleBorn", "Level survive and become someone new slay monsters and beasts", "best of luck " + SingleTon.GetPlayerController().PlayerName };
        }

        public void Draw(int x, int y)
        {
            CW.SetPos(x, y);
            Draw();
        }

        public static void AddToBox(string input)
        {
            Inputs.Insert(0, input);
        }

        public void Draw()
        {
            int line = 0;
            Cord pos = CW.GetPos();
            int Lenght = 8;
            int Height = 1;
            int LinesToWrite = 0;
            string TopLine = "";
            string BottomLine = "";
            line = (MapDraw.ViewSize.X * 2) + 40;
            line += -2;
            TopLine += Cor[0];
            BottomLine += Cor[3];
            for (int b = 0; b < line; b++)
            {
                TopLine += TopBot;
                BottomLine += TopBot;
            }
            TopLine += Cor[1];
            BottomLine += Cor[2];
            if(Inputs.Count < Lenght)
            {
                LinesToWrite = Inputs.Count;
            }
            else if (60 - Index > Lenght)
            {
                LinesToWrite = Lenght;
            }
            else
            {
                LinesToWrite = 60 - Index;
            }
            CW.SetPos(pos.X, (MapDraw.ViewSize.Y) + 3 + Height);
            Height++;
            CW.Write(TopLine);
            string FillText = "";
            for(int x = 0; x < line + 1; x++)
            {
                FillText += " ";
            }
            for(int c = Index; c < LinesToWrite; c++)
            {
                CW.SetPos(pos.X, (MapDraw.ViewSize.Y) + 3 + Height);
                CW.Write(FillText);
                Height++;
            }

            Height = 2;

            for (int i = Index; i < LinesToWrite + Index; i++)
            {
                CW.SetPos(pos.X, (MapDraw.ViewSize.Y) + 3 + Height);
                CW.Write(Side +" "+ Inputs[i]); 
                CW.SetPos(pos.X + line + 1, (MapDraw.ViewSize.Y) + 3 + Height) ;
                CW.WriteLine(Side);
                Height++;
            }
            CW.SetPos(pos.X, (MapDraw.ViewSize.Y) + 3 + Height);
            CW.WriteLine(BottomLine);
        }
    }
}
