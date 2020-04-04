using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eco_db_backend.Constants
{
    public static class DbCredentials
    {
        /// <summary>
        /// Местоположение базы данных в глобальной сети
        /// </summary>
        public static string HOST = @"ec2-54-247-78-30.eu-west-1.compute.amazonaws.com";

        /// <summary>
        /// Идентификатор базы данных
        /// </summary>
        public static string DATABASE = @"d43ad2s3fi7ptt";

        /// <summary>
        /// Пользователь с доступом к БД
        /// </summary>
        public static string USER = @"obsvsyzfjudwyb";

        /// <summary>
        /// Порт для доступа к БД
        /// </summary>
        public static string PORT = @"5432";

        /// <summary>
        /// Пароль для доступа к БД
        /// </summary>
        public static string PASSWORD = @"2de6a561aa6a656bcf3d45ae60c37866b26d3e90856074d5935021899eed9ba8";

        /// <summary>
        /// URI для доступа к БД в строковом виде
        /// </summary>
        public static string URI = @"postgres://obsvsyzfjudwyb:2de6a561aa6a656bcf3d45ae60c37866b26d3e90856074d5935021899eed9ba8@ec2-54-247-78-30.eu-west-1.compute.amazonaws.com:5432/d43ad2s3fi7ptt";

        public static string REFRESH_PASSWORD = @"vbsdf4635vwe";
    }
}
