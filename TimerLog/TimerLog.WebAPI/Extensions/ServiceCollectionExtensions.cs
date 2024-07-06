using System.Reflection;
using TimerLog.WebAPI.Attributes;

namespace TimerLog.WebAPI.Extensions
{
    /// <summary>
    /// ServiceCollectionの拡張メソッド
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// DIコンテナを登録する
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddDIComponents(
            this IServiceCollection services,
            Assembly assembly)
        {
            var classTypes = assembly.GetTypes()
                .Where(t => t.IsClass)
                .ToList();

            foreach (var type in classTypes)
            {
                var interfaces = type.GetInterfaces();
                var component = interfaces.FirstOrDefault(i => i.GetCustomAttributes<ComponentAttribute>(false).Any());

                if (component is null)
                {
                    continue;
                }
         
                // 有効期間が一時的なサービスは、サービス コンテナーから要求されるたびに作成されます
                // "一時的なもの" としてサービスを登録するには、AddTransient を呼び出します
                // https://learn.microsoft.com/ja-jp/dotnet/core/extensions/dependency-injection#service-lifetimes
                services.AddTransient(component, type);
            }

            return services;
        }

    }
}
