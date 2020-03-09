using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQAppServer
{
    public class DBOperator
    {
        private SqlConnection conn = new SqlConnection();

        public DBOperator()
        {
            try
            {
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyQQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                // 打开连接
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataSet _QueryData(string sql)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);

            try
            {
                dataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                return null;
            }
            return dataSet;
        }

        private Boolean _InsertOrUpdateData(string sql)
        {
            int result = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return result > 0;
        }

        public Boolean IsValidAccount(string account, string pwd)
        {
            string sql = "select account from login where account=N'" + account + "' and password=N'" + pwd + "'";
            DataSet dataSet = _QueryData(sql);

            if ((null == dataSet) || (null != dataSet && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 0))
            {
                return false;
            }

            return true;
        }

        public Boolean InsertLoginTab(string id, string pwd)
        {
            string sql = "insert into login(account, password, publicip, localip, udpport, tcpport) values(N'" + id + "',N'" + pwd + "',N'" + "127.0.0.1" + "', " + "',N'" + "127.0.0.1" + "'"+ 0 + ", " + 0 + " )";
            return _InsertOrUpdateData(sql);
        }

        public Boolean InsertRelationTab(string myaccount, string friend, string groupid, string remark)
        {
            string sql = "insert into relation(myaccount, friendaccount, groupid, remark) values(N'" +
                myaccount + "',N'" + friend + "',N'" + groupid + "', N'" + remark + "')";

            return _InsertOrUpdateData(sql);
        }

        public Boolean GenerateNewGroup(string myaccount, string groupid, string groupname)
        {
            //return InsertRelationTab(myaccount, "_0000_", groupid, "_0000_");

            return InsertGroupInfo(myaccount, groupid, groupname);
        }

        public List<string> GetGroupIdByAccount(string account)
        {
            List<string> groupids = new List<string>();
            string sql = "select groupid from groupinfo where account=N'" + account + "'";
            DataSet dataSet = _QueryData(sql);

            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return groupids;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                groupids.Add(row["groupid"].ToString());
            }

            return groupids;
        }

        public Boolean InsertGroupInfo(string account, string groupid, string groupname)
        {
            string sql = "insert into groupinfo(account, groupid, groupname, " +
                "createtime) values(N'" + account + "', N'" + groupid + "',N'" + groupname +
                "', N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            return _InsertOrUpdateData(sql);
        }

        public Boolean InsertUserInfoTab(string account, string nickname, string signature, string headimage, short sex, short age, short degree)
        {
            string sql = "insert into userinfo(account, nickname, signature, headimage, " +
                "sex, age, degree, registertime) values(N'" + account + "', N'" + nickname + "', N'" +
                signature + "', N'" + headimage + "', " + sex + ", " + age + ", " +
                degree + ", N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateUserStatus(string account, short status)
        {
            string sql = "update login set status = " + status + " where account = N'" + account + "'";
            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateUserAddr(string account, string publicip, string localip, int udpport, int tcpport)
        {
            string sql = "update login set publicip = N'" + publicip + "', localip = N'" + localip + "',udpport = " + udpport + ", tcpport = " + tcpport + " where account = N'" + account + "'";
            return _InsertOrUpdateData(sql);
        }

        public NetAddr GetFriendAddr(string account)
        {
            string sql = "select publicip, localip, udpport, tcpport from login where account = '" + account + "'";
            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return null;

            DataRow dataRow = dataSet.Tables[0].Rows[0];

            NetAddr netAddr = new NetAddr();
            netAddr.PublicIP = dataRow["publicip"].ToString();
            netAddr.LocalIP = dataRow["localip"].ToString();

            try
            {
                netAddr.UdpPort = Convert.ToInt16(dataRow["udpport"].ToString());
            }
            catch (Exception)
            {
                netAddr.UdpPort = 0;
            }

            try
            {
                netAddr.TcpPort = Convert.ToInt16(dataRow["tcpport"].ToString());
            }
            catch (Exception)
            {
                netAddr.TcpPort = 0;
            }




            return netAddr;
        }

        public Boolean UpdateUserLastLoginTime(string account)
        {
            string sql = "update login set lastlogin = N'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where account = N'" + account + "'";
            return _InsertOrUpdateData(sql);
        }

        public GlobalValue.UserStatus QueryFriendStatus(string account)
        {
            string sql = "select status from login where account = N'" + account + "'";
            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return GlobalValue.UserStatus.OffLine;

            DataRow dataRow = dataSet.Tables[0].Rows[0];
            return (GlobalValue.UserStatus)Convert.ToInt16(dataRow["status"].ToString());
        }

        public Boolean UpdateUserInfo(string account, string nickname, string signature, string headimage, short sex, short age, short degree)
        {
            string sql = "update userinfo set nickname = N'" + nickname +
                "', signature = N'" + signature + "', headimage = N'" + headimage +
                "', sex = " + sex + ", age = " + age + ", degree = " + degree +
                " where account = N'" + account + "'";
            return _InsertOrUpdateData(sql);
        }

        public List<RelationTab> QueryRelationTabByMyAccount(string account)
        {
            string sql = "select a.friendaccount as friendaccount, " +
                " b.groupid as groupid, a.remark as remark, b.groupname as groupname " +
                "from relation a right join groupinfo b on a.myaccount=N'" + account + "'" +
                " and a.groupid = b.groupid";
            DataSet dataSet = _QueryData(sql);

            List<RelationTab> list = new List<RelationTab>();

            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return list;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                RelationTab relationTab = new RelationTab();
                relationTab.MyAccount = account;
                relationTab.FriendAccount = row["friendaccount"].ToString();
                relationTab.GroupName = row["groupname"].ToString();
                relationTab.GroupID = row["groupid"].ToString();
                relationTab.Remark = row["remark"].ToString();
                list.Add(relationTab);
            }

            return list;
        }

        public Boolean RemoveFriend(string myAccount, string friendAccount)
        {
            string sql = "delete from relation where myaccount = N'" + myAccount +
                "' and friendaccount = N'" + friendAccount + "'";

            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateFriendRemark(string myAccount, string friendAccount, string newRemark)
        {
            string sql = "update relation set remark = N'" + newRemark +
                "' where myaccount = N'" + myAccount + "' and friendaccount = N'" +
                friendAccount + "'";

            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateGroupName(string myAccount, string groupid, string newGroupName)
        {
            string sql = "update groupinfo set groupname = N'" + newGroupName +
                "' where account = N'" + myAccount + "' and groupid = N'" +
                groupid + "'";

            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateFriendGroup(string myAccount, string friendaccount, string newGroupId)
        {
            string sql = "update relation set groupid = N'" + newGroupId +
                "' where myaccount = N'" + myAccount + "' and friendaccount = N'" +
                friendaccount + "'";

            return _InsertOrUpdateData(sql);
        }

        public Boolean UpdateUserSignature(string account, string sig)
        {
            string sql = "update userinfo set signature = N'" + sig + "' where account = N'" + account + "'";

            return _InsertOrUpdateData(sql);
        }

        public string GetUserSignature(string account)
        {
            string sql = "select signature from userinfo where account = N'" + account + "'";

            DataSet dataSet = _QueryData(sql);

            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return "";

            DataRow dataRow = dataSet.Tables[0].Rows[0];
            return dataRow["signature"].ToString(); ;
        }

        public List<User> GetFriendsByFuzzySearch(string account)
        {
            List<User> list = new List<User>();
            string sql = "select a.account account, nickname, age, sex, signature, degree, publicip, localip from userinfo a, login b where a.account = b.account and a.account like '%" + account + "%'";
            DataSet dataSet = _QueryData(sql);

            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return list;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                User usr = new User();
                usr.ID = row["account"].ToString();
                usr.Nickname = row["nickname"].ToString();
                usr.Signature = row["signature"].ToString();
                usr.PublicIP = row["publicip"].ToString();
                usr.LocalIP = row["localip"].ToString();
                try
                {
                    usr.Sex = (short)Convert.ToUInt16(row["sex"].ToString());
                }
                catch (Exception ex)
                {
                    usr.Sex = 0;
                }

                try
                {
                    usr.Age = (short)Convert.ToUInt16(row["age"].ToString());
                }
                catch (Exception ex)
                {
                    usr.Degree = 0;
                }
                try
                {
                    usr.Degree = (short)Convert.ToUInt16(row["degree"].ToString());
                }
                catch (Exception ex)
                {
                    usr.Age = 0;
                }
                list.Add(usr);

            }
            return list;
        }

        public string QueryUserHeadImageName(string account)
        {
            string sql = "select headimage from userinfo where account = N'" + account + "'";
            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return null;

            DataRow dataRow = dataSet.Tables[0].Rows[0];
            return dataRow["headimage"].ToString(); ;
        }

        public List<string> GetAllGroupNameByAccount(string account)
        {
            string sql = "select distinct groupid from relation where myaccount=N'" + account + "'";

            DataSet dataSet = _QueryData(sql);

            List<string> list = new List<string>();

            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return list;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(row["groupid"].ToString());
            }
            return list;
        }

        public User QueryUserInfo(string account)
        {
            User user = new User();
            user.ID = "INVALID";
            string sql = "select a.status as Status, a.publicip as PublicIP, a.localip as LocalIP, a.udpport as UdpPort, a.tcpport as TcpPort, a.lastlogin as LastLogin, " +
                "b.nickname as Nickname, b.signature as Signature, b.headimage as HeadImage, " +
                "b.registertime as RegisterTime, b.sex as Sex, b.age as Age, b.degree as Degree" +
                " from login a, userinfo b where a.account = N'" + account + "' and a.account= b.account";

            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return user;

            DataRow dataRow = dataSet.Tables[0].Rows[0];

            user.ID = account;
            try
            {
                user.Status = (GlobalValue.UserStatus)Convert.ToInt16(dataRow["Status"].ToString());
            }
            catch (Exception ex)
            {
                user.Status = GlobalValue.UserStatus.OffLine;
            }
            user.PublicIP = dataRow["PublicIP"].ToString();
            user.LocalIP = dataRow["LocalIP"].ToString();
            try
            {
                user.UdpPort = Convert.ToInt16(dataRow["UdpPort"].ToString());
            }
            catch (Exception)
            {
                user.UdpPort = 0;
            }
            try
            {
                user.TcpPort = Convert.ToInt16(dataRow["TcpPort"].ToString());
            }
            catch (Exception)
            {
                user.TcpPort = 0;
            }

            user.LastLogin = dataRow["LastLogin"].ToString();
            user.Nickname = dataRow["Nickname"].ToString();
            user.Signature = dataRow["Signature"].ToString();
            user.HeadImage = dataRow["HeadImage"].ToString();
            user.RegisterTime = dataRow["RegisterTime"].ToString();
            try
            {
                user.Sex = Convert.ToInt16(dataRow["Sex"].ToString());
            }
            catch (Exception ex)
            {
                user.Sex = 0;
            }
            try
            {
                user.Age = Convert.ToInt16(dataRow["Age"].ToString());
            }
            catch (Exception ex)
            {
                user.Age = 1;
            }
            try
            {
                user.Degree = Convert.ToInt16(dataRow["Degree"].ToString());
            }
            catch (Exception ex)
            {
                user.Degree = 0;
            }

            return user;
        }

        public List<GroupInfo> QueryGroupInfoByAccount(string account)
        {
            List<GroupInfo> result = new List<GroupInfo>();
            string sql = "select groupid, groupname from groupinfo where account = N'" + account + "' ";

            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return result;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                GroupInfo groupInfo = new GroupInfo();
                groupInfo.GroupId = row["groupid"].ToString();
                groupInfo.GroupName = row["groupname"].ToString();

                result.Add(groupInfo);
            }

            return result;
        }

        public List<Friend> QueryAllFriendAndGroupInfoByMyAccount(string myaccount)
        {
            List<Friend> result = new List<Friend>();
            string sql = "select a.friendaccount as friendaccount," +
             "a.groupid as groupid,a.remark as remark,a.groupname as groupname," +
             "b.nickname as nickname,b.signature as signature,b.headimage as headimage," +
             "b.sex as sex,b.age as age,b.degree as degree,b.registertime as registertime, " +
             "b.publicip as publicip, b.localip as localip, b.udpport as udpport, b.tcpport as tcpport,b.status as status," +
             "b.lastlogin as lastlogin from (select x.friendaccount as friendaccount, y.groupid as groupid, " +
             "x.remark as remark, y.groupname as groupname from relation x right join " +
             "(select groupid, groupname from groupinfo where account = N'" + myaccount + "') y " +
             "on x.groupid = y.groupid) a " +
             "left join(select c.account, c.nickname as nickname, c.signature as signature, c.headimage as headimage, " +
             "c.sex as sex, c.age as age,c.degree as degree, " +
             "c.registertime as registertime, d.publicip as publicip, d.localip as localip, d.udpport as udpport, d.tcpport as tcpport, " +
             "d.status as status, d.lastlogin as lastlogin from userinfo c, login d " +
             "where c.account in (select friendaccount from relation where myaccount= N'" + myaccount + "') and c.account = d.account) b on a.friendaccount = b.account";

            DataSet dataSet = _QueryData(sql);
            if (dataSet == null || dataSet.Tables == null || dataSet.Tables.Count == 0 ||
                dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0) return result;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                //string str = row["age"].ToString();
                Friend friend = new Friend();
                friend.GroupID = row["groupid"].ToString();
                friend.GroupName = row["groupname"].ToString();
                friend.ID = row["friendaccount"].ToString();
                friend.Age = row["age"].ToString().Length == 0 ? (short)0 : Convert.ToInt16(row["age"].ToString());
                friend.Degree = row["degree"].ToString().Length == 0 ? (short)0 : Convert.ToInt16(row["degree"].ToString());
                friend.HeadImage = row["headimage"].ToString();
                friend.PublicIP = row["publicip"].ToString();
                friend.LocalIP = row["localip"].ToString();
                friend.LastLogin = row["lastlogin"].ToString();
                friend.Nickname = row["nickname"].ToString();
                friend.RegisterTime = row["registertime"].ToString();
                friend.Remark = row["remark"].ToString();
                friend.Sex = row["sex"].ToString().Length == 0 ? (short)0 : Convert.ToInt16(row["sex"].ToString());
                friend.Signature = row["signature"].ToString();
                friend.Status = row["status"].ToString().Length == 0 ? GlobalValue.UserStatus.OffLine:(GlobalValue.UserStatus)Convert.ToInt16(row["status"].ToString());
                friend.TcpPort = row["tcpport"].ToString().Length == 0 ? (short)0 : Convert.ToInt16(row["tcpport"].ToString());
                friend.UdpPort = row["udpport"].ToString().Length == 0 ? (short)0 : Convert.ToInt16(row["udpport"].ToString());

                result.Add(friend);
            }
            return result;
        }
    }
}
