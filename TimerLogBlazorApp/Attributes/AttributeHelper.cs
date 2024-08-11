namespace TimerLogBlazorApp.Attributes
{
    /// <summary>
    /// カスタム属性ヘルパー
    /// </summary>
    public sealed class AttributeHelper
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
