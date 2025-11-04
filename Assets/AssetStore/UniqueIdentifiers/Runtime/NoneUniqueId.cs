namespace UniqueIdentifier
{
    /// <summary>
    /// Used to represent a null or empty CarambaId.
    /// </summary>
    public class NoneUniqueId : UniqueId
    {
        public NoneUniqueId() : base(LongGuid.None) { }
    }
}