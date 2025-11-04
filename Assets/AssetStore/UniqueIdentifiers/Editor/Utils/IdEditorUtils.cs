namespace UniqueIdentifier.Editor
{
    public static class IdEditorUtils
    {
        public static string GetIdName(this UniqueId uniqueId)
        {
            var type = uniqueId.GetType();
            var typeInfo = TypeUtils.GetTypeInfo(type);
            foreach (var field in typeInfo.Fields)
            {
                var id = field.GetValue(null) as UniqueId;
                if (id == null)
                {
                    continue;
                }

                if (id.Guid == uniqueId.Guid)
                {
                    return field.Name;
                }
            }
            
            return string.Empty;
        }
    }
}