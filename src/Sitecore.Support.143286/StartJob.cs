namespace Sitecore.Support.Pipelines.ReplaceItemReferences
{
  using Sitecore.Configuration;
  using Sitecore.Diagnostics;
  using Sitecore.Jobs;
  using Sitecore.Pipelines.ReplaceItemReferences;
  using System;

  public class StartJob
  {
    public void Process(ReplaceItemReferencesArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      Assert.IsNotNull(args.SourceItem, "args.SourceItem");
      Assert.IsNotNull(args.CopyItem, "args.CopyItem");
      ReferenceReplacementJob job = new ReferenceReplacementJob(args.SourceItem, args.CopyItem, Settings.RelinkClonedSubtree, args.FieldIDs);

      if (args.Async)
      {
        job.StartAsync();
      }
      else
      {
        job.Start();
      }
    }
  }
}
