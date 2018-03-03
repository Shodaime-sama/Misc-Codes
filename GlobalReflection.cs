public class GlobalReflection
    {
        public static T ConvertToObjectElement<T>(IEnumerable ObjectCollection)
        {
            System.Reflection.ConstructorInfo info = typeof(T).GetConstructor(new Type[] { });
            T Obj = (T)info.Invoke(new object[] { });
            IList<PropertyInfo> props = new List<PropertyInfo>(Obj.GetType().GetProperties());
            foreach (var item in ObjectCollection)
            {
                foreach (PropertyInfo property in props)
                {
                    var data = item.GetType().GetProperty(property.Name).GetValue(item, null);
                    if (item.GetType().GetProperty(data.ToString()) != null)
                    {

                    }
                    if (item.GetType().GetProperty(property.Name) != null && item.GetType().GetProperty(property.Name).GetValue(item, null) != null && !string.IsNullOrEmpty(item.GetType().GetProperty(property.Name).GetValue(item, null).ToString()))
                    {
                        property.SetValue(Obj, item.GetType().GetProperty(property.Name).GetValue(item, null), null);
                    }
                }
            }
            return Obj;
        }
    }
