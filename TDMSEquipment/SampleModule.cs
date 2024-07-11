using Autofac;
using System;
using System.Linq;
using System.Reflection;
using Tdms.Api;

namespace TDMSEquipment
{
    /// <summary>
    /// Модуль расширения, в котором происходит регистрация конфигурационных файлов и обработчиков
    /// </summary>
    public class SampleModule : TDMSExtensionModule
    {
        /// <summary>
        /// Используется для регистрации конфигурационных файлов в контейнер
        /// </summary>
        public override void Configure(ContainerBuilder builder)
        {
            builder.RegisterConfig<SampleConfiguration>();
            builder.RegisterHandlers(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Выполняется после сборки контейнера
        /// </summary>
        public override void Start(ILifetimeScope scope)
        {

        }
    }
}