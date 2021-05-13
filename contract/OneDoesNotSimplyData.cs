using System.Runtime.Serialization;

namespace contract
{
    [DataContract]
    public class OneDoesNotSimplyData
    {
        [DataMember(Order = 1)]
        public string Answer { get; set; }
    }
}