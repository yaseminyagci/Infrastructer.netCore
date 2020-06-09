using System;

namespace Domain.VmModel
{
    public class HadithVM:IModel
    {
        public int Id { get; set; }
        public string Turkish { get; set; }
        public string Arabic { get; set; }
    }
}
