using System.Threading;

namespace Unity.VersionControl.Git.Tasks
{

    public class GitListLocksTask : ProcessTaskWithListOutput<GitLock>
    {
        private const string TaskName = "git lfs locks";
        private readonly string args;

        public GitListLocksTask(bool local,
            IGitObjectFactory gitObjectFactory,
            CancellationToken token, BaseOutputListProcessor<GitLock> processor = null)
            : base(token, processor ?? new LocksOutputProcessor(gitObjectFactory))
        {
            Name = TaskName;
            args = "lfs locks --json";
            if (local)
            {
                args += " --local";
            }
        }

        public override string ProcessArguments => args;
        public override string Message { get; set; } = "Reading locks...";
    }
}
