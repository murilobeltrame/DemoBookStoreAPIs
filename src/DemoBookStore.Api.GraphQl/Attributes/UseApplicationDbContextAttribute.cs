using DemoBookStore.Api.GraphQl.Data;
using DemoBookStore.Api.GraphQl.Extensions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace DemoBookStore.Api.GraphQl.Attributes
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
