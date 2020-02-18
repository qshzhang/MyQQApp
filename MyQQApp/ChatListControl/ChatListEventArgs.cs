using System;
using System.Collections.Generic;
using System.Text;

namespace MyQQApp.ChatListControl
{
    //自定义事件参数类
    public class ChatListEventArgs
    {
        private ChatListSubItem mouseOnSubItem;
        public ChatListSubItem MouseOnSubItem {
            get { return mouseOnSubItem; }
        }

        private ChatListSubItem selectSubItem;
        public ChatListSubItem SelectSubItem {
            get { return selectSubItem; }
        }

        public ChatListEventArgs(ChatListSubItem mouseonsubitem, ChatListSubItem selectsubitem) {
            this.mouseOnSubItem = mouseonsubitem;
            this.selectSubItem = selectsubitem;
        }
    }

    public class ChatGroupEventArgs
    {
        
        private ChatListItem selectItem;
        public ChatListItem SelectItem
        {
            get { return selectItem; }
        }

        public ChatGroupEventArgs(ChatListItem selectitem)
        {
            this.selectItem = selectitem;
        }
    }
}
