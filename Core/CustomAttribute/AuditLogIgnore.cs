using System;

namespace Core.CustomAttribute
{
  
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuditLogIgnore : Attribute
    {
    }
}