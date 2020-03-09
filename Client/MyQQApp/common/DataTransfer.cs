using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    class DataTransfer
    {
    }

    public class MoveFriendGroup
    {
        public string friendAccount;
        public string newGroupName;
        public string newGroupId;

        public MoveFriendGroup(string account, string groupid, string groupname)
        {
            friendAccount = account;
            newGroupName = groupname;
            newGroupId = groupid;
        }

    }
}
