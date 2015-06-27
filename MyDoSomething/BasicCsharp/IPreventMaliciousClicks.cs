using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicCsharp
{
    interface IPreventMaliciousClicks
    {
        /// <summary>
        /// 账户是否设置规则
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns>是否</returns>
        bool IsAccountSetRules(string accountId);
        /// <summary>
        /// 该天拦截IP数
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="date">日期</param>
        /// <returns>个数</returns>
        int PreventIpCount(string accountId, DateTime date);
        /// <summary>
        /// 该天拦截用户数
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="date">日期</param>
        /// <returns>个数</returns>
        int PreventUuidCount(string accountId, DateTime date);
        /// <summary>
        /// 获取时间段内的数据
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        List<PreventData> GetDatas(string accountId, DateTime startTime, DateTime endTime);
        /// <summary>
        /// 检测代码是否生效
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="domain">域名</param>
        /// <returns></returns>
        bool IsCodeUseful(string accountId, string domain);
        /// <summary>
        /// 获取代码
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        string GetCode(string accountId);
        /// <summary>
        /// 更新IP排除数据
        /// </summary>
        /// <param name="accountid">账户ID</param>
        /// <param name="IPs">排除IP</param>
        /// <returns></returns>
        bool UpdateExcludeIP(string accountid, List<string> IPs);
        /// <summary>
        /// 获取排除IP
        /// </summary>
        /// <param name="accountid">账户ID</param>
        /// <returns></returns>
        List<string> GetExcludeIPs(string accountid);
        /// <summary>
        /// 更新拦截规则
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="second">时间（秒）</param>
        /// <param name="times">次数</param>
        /// <returns></returns>
        bool UpdateRule(string accountId, int second, int times);
        /// <summary>
        /// 获取拦截规则
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        PreventRule GetRule(string accountId);
        /// <summary>
        /// 设置规则
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="domain">域名</param>
        /// <param name="excludeIps">排除IP</param>
        /// <param name="rule">拦截规则</param>
        /// <returns></returns>
        bool SetRule(string accountId, string domain, List<string> excludeIps, PreventRule rule);
        /// <summary>
        /// 获取黑名单
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        List<PreventData> GetBList(string accountId);
    }

    public class PreventData
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 拦截IP
        /// </summary>
        public string InterceptIP { get; set; }
        /// <summary>
        /// 拦截用户
        /// </summary>
        public string InterceptUuid { get; set; }
        /// <summary>
        /// 拦截时间
        /// </summary>
        public DateTime InterceptTime { get; set; }

    }

    public class PreventRule
    {
        /// <summary>
        /// 账户ID
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 秒
        /// </summary>
        public int Seconds { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int ClickTimes { get; set; }
    }


}
