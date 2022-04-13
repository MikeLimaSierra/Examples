using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.TestSite;

using TestDrivenDiscipline;
using TestDrivenDiscipline.Contracts;

using File = TestDrivenDiscipline.File;

namespace TestDrivenDiscipline_uTests {
    class File_uTests {

        #region ctors

        [TestMethod]
        void DefaultCtorThrows() {

            Test.If.Action.ThrowsException(() => new File(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        [TestMethod]
        void DefaultCtor() {

            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new File(file), out Exception _);

            Test.If.Object.IsOfExactType<RealFileSystem>(sut.FileSystem);
            Test.If.Value.IsEqual(sut.Name, file.Name);
            Test.If.Value.IsEqual(sut.Path, file.FullName);
            Test.If.Value.IsEqual(sut.Directory.Path, file.Directory.FullName);
            Test.If.Reference.IsEqual(sut.Directory.FileSystem, sut.FileSystem);

        }

        [TestMethod]
        void CustomCtorThrows() {

            Test.If.Action.ThrowsException(() => new File(new FakeFileSystem(), null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        [TestMethod]
        void CustomCtor() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new File(fs, file), out Exception _);

            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Name, file.Name);
            Test.If.Value.IsEqual(sut.Path, file.FullName);
            Test.If.Value.IsEqual(sut.Directory.Path, file.Directory.FullName);

        }

        #endregion

        #region Exists

        [TestMethod]
        [TestData(nameof(File_Data))]
        void ExistsNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists, out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void ExistsExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Exists, out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        #endregion

        #region Create

        [TestMethod]
        [TestData(nameof(File_Data))]
        void CreateNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CreateExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Create(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        #endregion

        #region Delete

        [TestMethod]
        [TestData(nameof(File_Data))]
        void DeleteNotExisting(String subPath) {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, subPath));
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void DeleteExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            IFile sut = new File(fs, file);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.Delete(), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(file.Directory));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        #endregion

        #region CopyTo

        [TestMethod]
        void CopyTo_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);

            Test.If.Action.ThrowsException(() => sut.CopyTo(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "target");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyNotExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsFalse(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyNotExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            fs.Create(newFile);
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            fs.Create(newFile);
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, newFile.FullName);

        }

        [TestMethod]
        void CopyNotExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsFalse(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void CopyToRemote() {

            IFileSystem fs1 = new FakeFileSystem();
            IFileSystem fs2 = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs1.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs1, file);
            IFile target = new File(fs2, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.CopyTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs1.Exists(file));
            Test.If.Value.IsFalse(fs1.Exists(newFile));
            Test.If.Value.IsFalse(fs2.Exists(file));
            Test.If.Value.IsTrue(fs2.Exists(newFile));
            Test.If.Reference.IsEqual(fs1, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        #endregion

        #region MoveTo

        [TestMethod]
        void MoveTo_ThrowsArgNullEx() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);

            Test.If.Action.ThrowsException(() => sut.MoveTo(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "target");
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveNotExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsFalse(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveExistingToNotExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveNotExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            fs.Create(newFile);
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveExistingToExisting() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            fs.Create(newFile);
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsTrue(fs.Exists(file));
            Test.If.Value.IsTrue(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveNotExistingToSelf() {

            IFileSystem fs = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            IFile sut = new File(fs, file);
            IFile target = new File(fs, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Value.IsFalse(fs.Exists(file));
            Test.If.Value.IsFalse(fs.Exists(newFile));
            Test.If.Reference.IsEqual(fs, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        [TestMethod]
        void MoveToRemote() {

            IFileSystem fs1 = new FakeFileSystem();
            IFileSystem fs2 = new FakeFileSystem();
            FileInfo file = new FileInfo(Path.Combine(_tempDir.FullName, "MyFile.txt"));
            fs1.Create(file);
            FileInfo newFile = new FileInfo(Path.Combine(_tempDir.FullName, "MyNewFile.txt"));
            IFile sut = new File(fs1, file);
            IFile target = new File(fs2, newFile);
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = sut.MoveTo(target), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsFalse(fs1.Exists(file));
            Test.If.Value.IsFalse(fs1.Exists(newFile));
            Test.If.Value.IsFalse(fs2.Exists(file));
            Test.If.Value.IsTrue(fs2.Exists(newFile));
            Test.If.Reference.IsEqual(fs1, sut.FileSystem);
            Test.If.Value.IsEqual(sut.Path, file.FullName);

        }

        #endregion

        #region data, setup & teardown

        internal DirectoryInfo _tempDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), $"UTESTS_{Guid.NewGuid()}"));

        IEnumerable<Object[]> File_Data() {
            yield return new Object[] { "MyFile.txt" };
            yield return new Object[] { @"NotExisting\MyFile.txt" };
        }

        #endregion

    }
}
