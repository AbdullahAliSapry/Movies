using System.Reflection;

namespace WebsiteMovies.Utlites
{
    public static class ObjectExtensions
    {
        public static T OmitProperties<T>(this T obj, params string[] propertiesToOmit) where T : class
        {
            var type = typeof(T);
            var newObject = Activator.CreateInstance(type);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (!propertiesToOmit.Contains(property.Name))
                {
                    property.SetValue(newObject, property.GetValue(obj));
                }
            }

            return (T)newObject;
        }
    }

}
