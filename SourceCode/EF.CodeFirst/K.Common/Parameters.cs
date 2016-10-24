
namespace K.Common
{
    public class Parameters
    {
        /// <summary>
        /// 本地localdb连接字符串，与配置文件一致
        /// </summary>
        public const string LocalDbConnString = nameof(LocalDbConnString);

        /// <summary>
        /// 本地localdb连接字符串，用于模拟生产环境，与配置文件一致
        /// </summary>
        public const string LocalDbOemConnString = nameof(LocalDbOemConnString);

        /// <summary>
        /// 远程标准数据库连接字符串，与配置文件一致
        /// </summary>
        public const string MssqlDbConnString = nameof(MssqlDbConnString);
    }
}
