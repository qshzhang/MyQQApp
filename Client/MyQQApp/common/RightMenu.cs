using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp.common
{
    public class RightMenu : ContextMenu
    {
        private object internalPara;

        public RightMenu(object obj)
        {
            internalPara = obj;
        }

        public void AddMenuItem(string text, object pra = null)
        {
            RightMenuItem menuItem;

            if (pra == null)
            {
                menuItem = new RightMenuItem(text, internalPara);
            }
            else
            {
                menuItem = new RightMenuItem(text, pra);
            }

            this.MenuItems.Add(menuItem);
        }

    }

    public class RightMenuItem : MenuItem
    {
        private object internalPara;
        public delegate void MenuItenClickCallback(object obj);
        public MenuItenClickCallback OnMenuItenClickCallback;

        public RightMenuItem(string text, object obj)
        {
            internalPara = obj;
            this.Text = text;
            base.Click += InterOnMenuItemClickCallback;
        }

        public void AddMenuItem(string text, object pra = null)
        {
            RightMenuItem menuItem;

            if (pra == null)
            {
                menuItem = new RightMenuItem(text, internalPara);
            }
            else
            {
                menuItem = new RightMenuItem(text, pra);
            }

            this.MenuItems.Add(menuItem);
        }

        public void InterOnMenuItemClickCallback(object obj, EventArgs args)
        {
            if(null != OnMenuItenClickCallback)
            {
                OnMenuItenClickCallback(internalPara);
            }
        }
    }

}
