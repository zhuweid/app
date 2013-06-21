namespace app.web.core
{
  public class SecuredFeature : IImplementAFeature
  {
    IImplementAFeature actual_feature;
    IVerifyASecurityConstraint security_specification;

    public SecuredFeature(IImplementAFeature actual_feature, IVerifyASecurityConstraint security_specification)
    {
      this.actual_feature = actual_feature;
      this.security_specification = security_specification;
    }

    public void process(IContainRequestInformation request)
    {
        if (security_specification()) 
          actual_feature.process(request);

    }
  }
}