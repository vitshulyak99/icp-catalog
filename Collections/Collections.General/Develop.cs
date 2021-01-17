using System;

namespace Collections.General
{

    public static class Develop {
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
}