using OperationContext;

namespace RequestContext.Tests.Requests;

public class UpdateProductContext : RequestContextBase<UpdateProductCommand>
{
    public UpdateProductContext(UpdateProductCommand request) : base(request)
    {
    }
    
    public Product Product {get;}
}