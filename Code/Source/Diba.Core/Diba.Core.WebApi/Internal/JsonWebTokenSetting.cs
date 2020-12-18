using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diba.Core.WebApi.Internal
{
    public class JsonWebTokenSetting : IJsonWebTokenSetting
    {
        private const string CONFIGSECTION = "AppSettings";
        private const string CONFIGFILENAME = "appSettings.json";

        private readonly IConfigurationSection Configuration;

        public JsonWebTokenSetting()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(CONFIGFILENAME);
            var ConfigurationBuilder = builder.Build();
            Configuration = ConfigurationBuilder.GetSection(CONFIGSECTION);
        }

        private static long lifeTime { get; set; } = 0;

        private static string secret { get; set; } = null;

        private const string TEMP_KEY = "No more evasion: We have with a leaven'd and prepared choice 60 Proceeded to you; therefore take your honours. Our haste from hence is of so quick condition That it prefers itself and leaves unquestion'd Matters of needful value. We shall write to you, As time and our concernings shall importune, 65 How it goes with us, and do look to know What doth befall you here.So, fare you well; To the hopeful execution do I leave you Of your commissions.";
        private const string PASS_PHRASE = "愛の気分で。 彼女が私を望んでいるなら、私は彼女のために死ぬでしょう。。";

        private const string LIFETIME = "LifeTime";
        private const string SECRET = "Secret";

        /// <summary>
        /// 
        /// </summary>
        public string Secret => Configuration.GetValue<string>(nameof(this.Secret));

        /// <summary>
        /// 
        /// </summary>
        public long LifeTime => Configuration.GetValue<long>(nameof(this.LifeTime));
    }
}
