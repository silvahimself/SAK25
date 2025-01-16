using SAK25.Helpers;

namespace SAK25_tests.Helpers
{
    [TestFixture]
    public class EnvironmentHelpersTests
    {
        [Test]
        public void EnvVar_WithExistingVariable_ReturnsValue()
        {
            string envName = "PATH";
            string result = EnvironmentHelpers.EnvVar(envName);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ExecutingDir_ReturnsValidDirectory()
        {
            string executingDir = EnvironmentHelpers.ExecutingDir();
            Assert.That(Directory.Exists(executingDir), Is.True);
        }

        [Test]
        public void BinDir_ReturnsValidDirectory()
        {
            string binDir = EnvironmentHelpers.BinDir();
            Assert.That(Directory.Exists(binDir), Is.True);
        }

        [Test]
        public void ProjectDir_ReturnsValidDirectory()
        {
            string projectDir = EnvironmentHelpers.ProjectDir();
            Assert.That(Directory.Exists(projectDir), Is.True);
        }
    }
}
