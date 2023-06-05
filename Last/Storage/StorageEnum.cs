namespace Last.Storage
{
    public enum StorageEnum
    {
        Undefined,
        Avto,
        FileStorage
    }

    public static class StorageEnumExtensions
    {
        public static StorageEnum ToStorageEnum(this string value)
        {
            switch (value)
            {
                case var s when s.ToLowerInvariant() == "Avto"
                                || s.ToLowerInvariant() == "to"
                                || s.ToLowerInvariant() == "Av":
                    return StorageEnum.Avto;
                case var s when s.ToLowerInvariant() == "filestorage"
                                || s.ToLowerInvariant() == "file"
                                || s.ToLowerInvariant() == "storage":
                    return StorageEnum.FileStorage;
                default:
                    return StorageEnum.Undefined;
            }
        }
    }

}
