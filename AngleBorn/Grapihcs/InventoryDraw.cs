using AngelBorn.Tools;
using AngelBorn.World;
using AngleBorn.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBorn.Grapihcs
{
    class InventoryDraw
    {
        public static int InventoryIndex = 1;
        /// <summary>
        /// what tab the menu is in
        /// </summary>
        public static InventoryDrawMenuState state = InventoryDrawMenuState.All;
        private static Cord GoldHeight;
        private static Cord TabHeight;
        private static Cord InventoryContainerHeight;
        private int lineheight = 0;

        public void Draw()
        {
            Console.Clear();
            GoldHeight = new Cord { X = 2, Y = 2 };
            DrawGold();
            TabHeight = new Cord { X = GoldHeight.X, Y = GoldHeight.Y + 4 };
            DrawTabs();
            InventoryContainerHeight = new Cord { X = TabHeight.X, Y = TabHeight.Y + 3 };
            DrawInventoryContainer();
        }

        public void DrawGold()
        {
            lineheight = 0;
            string GoldText = "║ Gold: " + SingleTon.GetPlayerController().Inventory.Gold + " ║";
            CW.FillOutStringBorder(GoldText, true, GoldHeight.X, GoldHeight.Y + lineheight);
            lineheight++;
            CW.Write(GoldText, GoldHeight.X, GoldHeight.Y + lineheight);
            lineheight++;
            CW.FillOutStringBorder(GoldText, false, GoldHeight.X, GoldHeight.Y + lineheight);
        }
        public void DrawTabs()
        {
            lineheight = 0;
            string[] Tabs = new string[] { "All", "Weapon", "Armor", "Consumable", "Misc" };
            string tabString = "║";
            for (int i = 0; i < Tabs.Length; i++)
            {
                if ((int)state == i)
                {
                    tabString += " [" + Tabs[i] + "] ║";
                }
                else
                {
                    tabString += "  " + Tabs[i] + "  ║";
                }
            }
            CW.FillOutStringBorder(tabString, true, TabHeight.X, TabHeight.Y + lineheight);
            lineheight++;
            CW.Write(tabString, TabHeight.X, TabHeight.Y + lineheight);
            lineheight++;
            CW.FillOutStringBorder(tabString, false, TabHeight.X, TabHeight.Y + lineheight);
        }


        public void DrawInventoryContainer()
        {
            lineheight = 0;
            List<string> ItemLine = new List<string>();
            ItemLine.Add(SizeAble("Name", "Description", "Stats", "Value", "Type", ItemLine.Count, false, true));
            switch (state)
            {
                case InventoryDrawMenuState.All:
                    foreach (BaseItem element in SingleTon.GetPlayerController().Inventory.Inventory)
                    {
                        if (element is EquippableItem item)
                        {
                            ItemLine.Add(SizeAble(element.name, element.describtion, element.Effect, element.Value.ToString(), element.itemType.ToString(), ItemLine.Count, SingleTon.GetPlayerController().Inventory.CheckIfItemsIsEquipped(item)));
                        }
                        else
                        {
                            ItemLine.Add(SizeAble(element.name, element.describtion, element.Effect, element.Value.ToString(), element.itemType.ToString(), ItemLine.Count));
                        }

                    }
                    break;

                case InventoryDrawMenuState.Armor:
                    foreach (BaseItem element in (SingleTon.GetPlayerController().Inventory.Inventory.Where(x => x is ArmorItem).ToList()))
                    {
                        ItemLine.Add(SizeAble(element.name, element.describtion, element.Effect, element.Value.ToString(), element.itemType.ToString(), ItemLine.Count, SingleTon.GetPlayerController().Inventory.CheckIfItemsIsEquipped((EquippableItem)element)));
                    }
                    break;

                case InventoryDrawMenuState.Weapon:
                    foreach (BaseItem element in (SingleTon.GetPlayerController().Inventory.Inventory.Where(x => x is WeaponItem).ToList()))
                    {
                        ItemLine.Add(SizeAble(element.name, element.describtion, element.Effect, element.Value.ToString(), element.itemType.ToString(), ItemLine.Count, SingleTon.GetPlayerController().Inventory.CheckIfItemsIsEquipped((EquippableItem)element)));
                    }
                    break;

                case InventoryDrawMenuState.Consumeable:
                    throw new NotImplementedException();
                    break;

                case InventoryDrawMenuState.Misc:
                    throw new NotImplementedException();
                    break;
            }
            CW.FillOutStringBorder(ItemLine[0], true, InventoryContainerHeight.X, InventoryContainerHeight.Y + lineheight);
            lineheight++;
            CW.Write(ItemLine[0], InventoryContainerHeight.X, InventoryContainerHeight.Y + lineheight);
            lineheight++;
            CW.FillOutStringSplitter(ItemLine[0], InventoryContainerHeight.X, InventoryContainerHeight.Y + lineheight);
            lineheight++;
            for (int i = 1; i < ItemLine.Count; i++)
            {
                CW.Write(ItemLine[i], InventoryContainerHeight.X, InventoryContainerHeight.Y + lineheight);
                lineheight++;
            }
            CW.FillOutStringBorder(ItemLine[0], false, InventoryContainerHeight.X, InventoryContainerHeight.Y + lineheight);
        }

        private string SizeAble(string name, string des, string stats, string value, string type, int index, bool equippted = false, bool title = false)
        {
            int NameDistance = 25;
            int DesDistance = 50;
            int statsDistance = 10;
            int valueDistance = 10;
            int typeDistance = 10;
            int equippedDistance = 8;

            string NewString = "";
            if (index == InventoryIndex)
            {
                NewString += "║ >" + AddSpaces(name, NameDistance) + "  ";
            }
            else
            {
                NewString += "║  " + AddSpaces(name, NameDistance) + "  ";
            }
            NewString += "║  " + AddSpaces(des, DesDistance) + "  ║  " + AddSpaces(stats, statsDistance) + "  ║  " + AddSpaces(value, valueDistance) + "  ║  " + AddSpaces(type, typeDistance) + "  ";
            if (title)
            {
                NewString += "║  " + AddSpaces("Equipped", equippedDistance) + "  ║";
            }
            else if (equippted)
            {
                NewString += "║  " + AddSpaces("[X]", equippedDistance) + "  ║";
            }
            else
            {
                NewString += "║  " + AddSpaces("[ ]", equippedDistance) + "  ║";
            }

            return NewString;
        }

        private string AddSpaces(string text, int amount)
        {
            amount -= text.Length;
            for (int i = 0; i < amount; i++)
            {
                text += " ";
            }
            return text;
        }
    }

    enum InventoryDrawMenuState
    {
        All, Weapon, Armor, Consumeable, Misc
    }
}
