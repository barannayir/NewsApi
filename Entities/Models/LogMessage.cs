using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public static class LogMessage<TEntity> where TEntity : class
    {
        //success
        public static string Add = $"{typeof(TEntity).Name} added to database.";
        public static string Delete = $"{typeof(TEntity).Name} deleted from database.";
        public static string Update = $"{typeof(TEntity).Name} updated in database.";
        public static string Get = $"{typeof(TEntity).Name} got from database.";
        public static string GetAll = $"{typeof(TEntity).Name} list got from database.";

        //error
        public static string AddError = $"Error while adding {typeof(TEntity).Name} to database.";
        public static string DeleteError = $"Error while deleting {typeof(TEntity).Name} from database.";
        public static string UpdateError = $"Error while updating {typeof(TEntity).Name} in database.";
        public static string GetError = $"Error while getting {typeof(TEntity).Name} from database.";
        public static string GetAllError = $"Error while getting {typeof(TEntity).Name} list from database.";


        //login
        public static string Login = $"{typeof(TEntity).Name} logged in.";
        public static string LoginError = $"Error while logging in {typeof(TEntity).Name}.";
        public static string PasswordError = $"Password is incorrect for {typeof(TEntity).Name}.";

        //register
        public static string Register = $"{typeof(TEntity).Name} registered.";
        public static string RegisterError = $"Error while registering {typeof(TEntity).Name}.";
        public static string UserExists = $"{typeof(TEntity).Name} already exists.";


    }
}
