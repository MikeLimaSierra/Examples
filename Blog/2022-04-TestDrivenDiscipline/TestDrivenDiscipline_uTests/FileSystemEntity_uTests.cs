using System;

using Nuclear.TestSite;

using TestDrivenDiscipline;
using TestDrivenDiscipline.Contracts;

namespace TestDrivenDiscipline_uTests {
    class FileSystemEntity_uTests {

        #region ctors

        [TestMethod]
        void CtorThrows() {

            Test.If.Action.ThrowsException(() => new DummyFileSystemEntity(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "fileSystem");

        }

        [TestMethod]
        void Ctor() {

            IFileSystem fs = new FakeFileSystem();
            IFileSystemEntity entity = default;

            Test.IfNot.Action.ThrowsException(() => entity = new DummyFileSystemEntity(fs), out ArgumentNullException _);

            Test.If.Reference.IsEqual(fs, entity.FileSystem);

        }

        #endregion

    }
}
