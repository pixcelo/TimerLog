namespace TimerLog.WebAPI.Attributes
{
    /// <summary>
    /// カスタム属性お助けクラス
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// <see cref="MasterAttribute"/>が適用されているかを判定する
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasMasterAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(MasterAttribute), false).Any();
        }

    }
}
