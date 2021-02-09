using System;

namespace Collections.General
{
    public static partial class Develop {
        public static bool IsDeploy => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IS_DEPLOY"));
        public static string HerokuConnectionString()
        {
            var url = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            var uri = new Uri(url);
            var db = uri.AbsolutePath.Substring(1);
            var username = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            return
                $"Host={uri.Host};Port={uri.Port};Username={username};Password={password};Database={db};SSL Mode=Require;Pooling=true;TrustServerCertificate=true;";
        }
    }

    public static partial class Develop
    {
        public static class Env
        {
            private static string FromEnv(string variable) => Environment.GetEnvironmentVariable(variable);
            public static class Google
            {
                private static string Get(string variable) => FromEnv($"GOOGLE_{variable}");
                public static string ClientId => Get("CLIENT_ID");
                public static string ClientSecret => Get("CLIENT_SECRET");
            }
            
            public static class Jwt
            {
                private static string Get(string variable) => FromEnv($"JWT_{variable}");
                public static string Issuer => Get("ISSUER");
                public static string Audience => Get("AUDIENCE");
                public static string Key => Get("KEY");
                public static TimeSpan LifeTime =>
                    int.TryParse(Get("LIFETIME"), out var minutes) ? TimeSpan.FromMinutes(minutes) : TimeSpan.FromHours(2);

            }
        }
    }
}